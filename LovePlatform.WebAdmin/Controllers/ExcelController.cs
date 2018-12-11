using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LovePlatform.Common;
using LovePlatform.Common.Enum;
using LovePlatform.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace LovePlatform.WebAdmin.Controllers
{
    public class ExcelController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly UserService _userService;
        private readonly DiagnoseService _diagnoseService;

        public ExcelController(IHostingEnvironment hostingEnvironment, UserService userService, DiagnoseService diagnoseService)
        {
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            _diagnoseService = diagnoseService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Export()
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            using (ExcelPackage package = new ExcelPackage(file))
            {
                // ���worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("�û���Ϣ");
                //���ͷ
                worksheet.Cells[1, 1].Value = "����";
                worksheet.Cells[1, 2].Value = "������";
                worksheet.Cells[1, 3].Value = "����";
                worksheet.Cells[1, 4].Value = "��ϵ��ʽ";
                worksheet.Cells[1, 5].Value = "�Ա�";
                worksheet.Cells[1, 6].Value = "��ס��";
                worksheet.Cells[1, 7].Value = "��������";
                worksheet.Cells[1, 8].Value = "Ⱦɫ��";
                worksheet.Cells[1, 9].Value = "���߷���";
                worksheet.Cells[1, 10].Value = "�ںϻ���";
                worksheet.Cells[1, 11].Value = "�����������";


                // ��ȡ�û���Ϣ
                var userInfo = await _userService.GetAllUser();

                // ��ȡ�����Ϣ
                var diagnoseInfo = await _diagnoseService.GetAllDiagnose();

                var index = 2;
                userInfo.ForEach(i =>
                {
                    var diagnose = diagnoseInfo.Where(d => d.UserId.Equals(i.Id)).FirstOrDefault();
                    worksheet.Cells[index, 1].Value = i.Name;
                    worksheet.Cells[index, 2].Value = i.BirthPlace;
                    worksheet.Cells[index, 3].Value = i.Birthday.ToString("yyyy-MM-dd");
                    worksheet.Cells[index, 4].Value = i.Contact;
                    worksheet.Cells[index, 5].Value = i.Gender == 1 ? "Ů" : "��";
                    worksheet.Cells[index, 6].Value = i.ResidentialPlace;
                    if(diagnose != null)
                    {
                        worksheet.Cells[index, 7].Value = EnumHelper.GetDescription((DiseasesTypeEnum)diagnose.DiseasesType);
                        worksheet.Cells[index, 8].Value = diagnose.Chromosomal;
                        worksheet.Cells[index, 9].Value = diagnose.Immunophenotyping;
                        worksheet.Cells[index, 10].Value = diagnose.FusionGene;
                        worksheet.Cells[index, 11].Value = diagnose.SecondGenerationGeneSequencing;
                    }
                    
                    index++;
                });

                package.Save();
            }
            return File(sFileName, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}