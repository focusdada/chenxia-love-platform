using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LovePlatform.Service;
using LovePlatform.DTO.WebAdmin;
using LovePlatform.Domain.Models;
using LovePlatform.DTO.Common;
using AutoMapper;
using LovePlatform.WebAdmin.MvcUtility;
using LovePlatform.Common.Enum;
using LovePlatform.DTO.WebAPI.Input;
using System.IO;
using LovePlatform.Domain;
using Microsoft.Extensions.Options;

namespace LovePlatform.WebAdmin.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly DiagnoseService _diagnoseService;
        private readonly TreatService _treatService;
        private readonly TreatImageService _treatImageService;
        private readonly LovePlatformAdminApi _lovePlatformApi;
        private readonly MyOptions _optionsAccessor;

        public UserController(UserService userService, DiagnoseService diagnoseService,
            TreatService treatService, TreatImageService treatImageService, IOptions<MyOptions> optionsAccessor)
        {
            _userService = userService;
            _diagnoseService = diagnoseService;
            _treatService = treatService;
            _treatImageService = treatImageService;
            _optionsAccessor = optionsAccessor.Value;
            _lovePlatformApi = new LovePlatformAdminApi(_optionsAccessor.WebApiUrl);
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(int pageIndex = 1)
        {
            var search = new UserSearchInput { PageIndex = pageIndex };

            return View(search);
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IActionResult> List(UserSearchInput input)
        {
            var model = new Page<UserDto>();

            var items = await _userService.GetUserPageList(input);
            model.CurrentPage = input.PageIndex;
            model.Items = Mapper.Map<List<User>, List<UserDto>>(items.Item1);
            model.TotalRecords = items.Item2;

            return PartialView("_ListPartial", model);
        }

        /// <summary>
        /// 用户详情
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(int id)
        {
            var user = await _userService.Get(id);
            var diagnose = await _diagnoseService.Get(id) ?? new Diagnose();
            var treatList = await _treatService.GetList(id) ?? new List<Treat>();
            var treatImageList = await _treatImageService.GetListByUser(id) ?? new List<TreatImage>();
            var model = new Tuple<UserDto, Diagnose, List<Treat>, List<TreatImage>>(Mapper.Map<User, UserDto>(user), diagnose, treatList, treatImageList);
            return View(model);
        }

        public async Task<IActionResult> EditUserInfo(int id)
        {
            ViewBag.UserTypeList = EnumExtensionHelper.EnumToSelectList<UserTypeEnum>(false);
            ViewBag.UserGenderList = EnumExtensionHelper.EnumToSelectList<SexEnum>(false);
            var user = await _userService.Get(id);
            return PartialView("_EditUserPartial", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserInfo(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var response = await _userService.Update(user);
            if (!response.IsSuccess)
            {
                ModelState.AddModelError("", response.Message);
                return View(user);
            }
            return Content("");
        }

        public async Task<IActionResult> EditDiagnose(int id)
        {
            ViewBag.DiesasesTypeList = EnumExtensionHelper.EnumToSelectList<DiseasesTypeEnum>(false);
            var diagnose = await _diagnoseService.Get(id) ?? new Diagnose() { UserId = id };
            return PartialView("_EditDiagnosePartial", diagnose);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDiagnose(Diagnose diagnose)
        {
            if (!ModelState.IsValid)
            {
                return View(diagnose);
            }
            var diagnoseModel = await _diagnoseService.Get(diagnose.UserId);
            if(diagnoseModel == null)
            {
                _diagnoseService.Add(diagnose);
            }
            else
            {
                await _diagnoseService.Update(diagnose);
            }
            return Content("");
        }

        public async Task<IActionResult> AddTreat(int id)
        {
            var treatModel = new Treat() { UserId = id };
            return PartialView("_AddTreatPartial", treatModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTreat(Treat treat)
        {
            if (!ModelState.IsValid)
            {
                return View(treat);
            }
            var treatId = _treatService.Add(treat);

            //上传文件
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                //转换成二进制
                Byte[] fileData = new Byte[(int)file.Length];
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                }

                //保存图片到服务器
                var r = await _lovePlatformApi.UploadImage(
                    new UploadImageInput { AvatarBuffer = fileData, Folder = "cure-record" });

                var fileName = r.ResultValue;

                _treatImageService.Add(new TreatImage() { ImagePath = fileName, TreatId = treatId, UserId = treat.UserId });

            }

            return RedirectToAction("Detail","User", new { id = treat.UserId });
        }

        public async Task<IActionResult> EditTreat(int id)
        {
            var treat = await _treatService.Get(id) ?? new Treat() { UserId = id };
            return PartialView("_EditTreatPartial", treat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTreat(Treat treat)
        {
            if (!ModelState.IsValid)
            {
                return View(treat);
            }
            await _treatService.Update(treat);

            //上传文件
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                //转换成二进制
                Byte[] fileData = new Byte[(int)file.Length];
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                }

                //保存图片到服务器
                var r = await _lovePlatformApi.UploadImage(
                    new UploadImageInput { AvatarBuffer = fileData, Folder = "cure-record" });

                var fileName = r.ResultValue;

                _treatImageService.Add(new TreatImage() { ImagePath = fileName, TreatId = treat.Id, UserId = treat.UserId });

            }

            return RedirectToAction("Detail", "User", new { id = treat.UserId });
        }

        [HttpGet]
        public IActionResult DeleteTreatImage(int id)
        {
            _treatImageService.Delete(id);
            return Content(string.Empty);
        }
    }
}