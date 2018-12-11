/**
 * Created by wangqi on 2016/12/15.
 */
//zepto.js的两个扩展，解决不能选中元素前后的所有兄弟节点
$.fn.prevAll = function (selector) {
    var prevEls = [];
    var el = this[0];
    if (!el) return $([]);
    while (el.previousElementSibling) {
        var prev = el.previousElementSibling;
        if (selector) {
            if ($(prev).is(selector)) prevEls.push(prev);
        }
        else prevEls.push(prev);
        el = prev;
    }
    return $(prevEls);
};
$.fn.nextAll = function (selector) {
    var nextEls = [];
    var el = this[0];
    if (!el) return $([]);
    while (el.nextElementSibling) {
        var next = el.nextElementSibling;
        if (selector) {
            if ($(next).is(selector)) nextEls.push(next);
        }
        else nextEls.push(next);
        el = next;
    }
    return $(nextEls);
};


$(function () {
    //顶部进度条样式
    $(".progress_bar_item_on").prevAll().css("background-color", "rgba(4, 190, 2, 0.8)");
    $(".progress_bar_item_on_end").prevAll().css("background-color", "rgba(4, 190, 2, 0.8)");
    var tmpl = '<li class="weui-uploader__file" style="background-image:url(#url#)"></li>',
        $gallery = $("#gallery"), $galleryImg = $("#galleryImg"),
        $uploaderInput = $("#uploaderInput"),
        $uploaderFiles = $("#uploaderFiles")
    ;

    //图片添加和上传，图片点击查看
    $uploaderInput.on("change", function (e) {
        var src, url = window.URL || window.webkitURL || window.mozURL, files = e.target.files;
        for (var i = 0, len = files.length; i < len; ++i) {
            var file = files[i];

            if (url) {
                src = url.createObjectURL(file);
            } else {
                src = e.target.result;
            }

            $uploaderFiles.append($(tmpl.replace('#url#', src)));
        }
    });
    $uploaderFiles.on("click", "li", function () {
        $galleryImg.attr("style", this.getAttribute("style"));
        $gallery.fadeIn(100);
    });
    $gallery.on("click", function () {
        $gallery.fadeOut(100);
    });
});

var dialog,
    dialog_p,
    dialog_title,
    dialog_name,
    dialog_tel,
    dialog_id,
    dialog_address,
    dialog_footer,
    dialog_input,
    dialog_birth,
    dialog_sex,
    dialog_select,
    dialog_radio,
    name,
    tel,
    id,
    address,
    birth,
    rel,
    href,
    reg,
    text,
    sex,
    i,
    f = {
        dialog: function (e) {
            $("#" + e.id).on("click", function () {
                $("#dialog_" + e.id + "").fadeIn(200);
            });
            this.dialog_add(e);
        },
        dialog_add: function (e) {
            name = "#" + e.id + "_name";
            tel = "#" + e.id + "_tel";
            id = "#" + e.id + "_id";
            address = "#" + e.id + "_address";
            birth = "#" + e.id + "_birth";
            sex = "#" + e.id + "_sex";
            rel = "#" + e.id + "_rel";
            dialog_title = "<div class='weui-dialog__hd'><strong class='weui-dialog__title'>" + e.title + "</strong></div>";
            dialog_p = "<div class='weui-dialog__bd dialog_p'>" + e.p +
                "</div>";
            dialog_name = "<div class='weui-cell'>" +
                "<div class='weui_cell__hd'><label class='weui-label'>姓名</label></div>" +
                "<div class='weui_cell__bd weui_cell_primary'>" +
                "<input id='" + e.id + "_name' class='weui-input' type='text' placeholder='请输入姓名'>" +
                "</div>" +
                "</div>";
            dialog_tel = "<div class='weui-cell'>" +
                "<div class='weui_cell__hd'><label class='weui-label'>联系电话</label></div>" +
                "<div class='weui_cell__bd weui_cell_primary'>" +
                "<input id='" + e.id + "_tel' class='weui-input' type='tel' placeholder='请输入联系电话'>" +
                "</div>" +
                "</div>";
            dialog_id = "<div class='weui-cell'>" +
                "<div class='weui_cell__hd'><label class='weui-label'>身份证</label></div>" +
                "<div class='weui_cell__bd weui_cell_primary'>" +
                "<input id='" + e.id + "_id' class='weui-input' type='text' placeholder='请输入身份证' value='" + $(".id").find(".weui-cell__ft").text() + "'>" +
                "</div>" +
                "</div>";
            dialog_address = "<div class='weui-cell'>" +
                "<div class='weui_cell__hd'><label class='weui-label'>地址</label></div>" +
                "<div class='weui_cell__bd weui_cell_primary'>" +
                "<input id='" + e.id + "_address' class='weui-input' type='text' placeholder='请输入地址'>" +
                "</div>" +
                "</div>";
            dialog_birth = "<div class='weui-cell'>" +
                "<div class='weui_cell__hd'><label class='weui-label'>生日</label></div>" +
                "<div id='" + e.id + "_birth' class='weui-cell__ft'>—" +
                "</div>" +
                "</div>";
            dialog_sex = "<div class='weui-cell'>" +
                "<div class='weui_cell__hd'><label class='weui-label'>性别</label></div>" +
                "<div id='" + e.id + "_sex' class='weui-cell__ft'>—" +
                "</div>" +
                "</div>";
            dialog_footer = "";
            dialog_select = "";
            dialog_radio = "";
            if (e.id == "sign") {
                dialog_title = "";
                dialog_footer = "<div class='weui-dialog__ft'>" +
                    "<a href='javascript:;' class='weui-dialog__btn weui-dialog__btn_default'>取消</a>" +
                    "<a href='javascript:;' class='weui-dialog__btn weui-dialog__btn_primary'>提交</a>" +
                    "</div>";
                dialog_input = "<div class='weui-dialog__bd dialog_input'>" + dialog_name + dialog_tel + dialog_id + dialog_address +
                    "</div>"
            }
            if (e.id == "clause") {
                dialog_input = "";
                dialog_footer = "<div class='weui-dialog__ft'>" +
                    "<a href='javascript:;' class='weui-dialog__btn weui-dialog__btn_default'>我同意</a>" +
                    "</div>";
            }
            if (e.id == "family" || e.id == "family_d") {
                dialog_title = "";
                dialog_p = "";
                dialog_address = "";
                dialog_id = "<div class='weui-cell'>" +
                    "<div class='weui_cell__hd'><label class='weui-label'>身份证</label></div>" +
                    "<div class='weui_cell__bd weui_cell_primary'>" +
                    "<input id='" + e.id + "_id' class='weui-input' type='text' placeholder='请输入身份证'>" +
                    "</div>" +
                    "</div>";
                dialog_select = "<div class='weui-cell weui-cell_select weui-cell_select-after'>" +
                    "<div class='weui-cell__hd'>" +
                    "<label class='weui-label'>关系</label>" +
                    "</div>" +
                    "<div class='weui-cell__bd'>" +
                    "<select id='" + e.id + "_rel' class='weui-select' name='rel'>" +
                    "<option value='0'>请选择</option>" +
                    "<option value='1'>母亲</option>" +
                    "<option value='2'>父亲</option>" +
                    "<option value='3'>儿子</option>" +
                    "<option value='4'>女儿</option>" +
                    "<option value='5'>爷爷</option>" +
                    "<option value='6'>奶奶</option>" +
                    "<option value='7'>外公</option>" +
                    "<option value='8'>外婆</option>" +
                    "<option value='9'>孙子</option>" +
                    "<option value='10'>孙女</option>" +
                    "<option value='11'>其他</option>" +
                    "</select>" +
                    "</div>" +
                    "</div>";
                dialog_footer = "<div class='weui-dialog__ft'>" +
                    "<a href='javascript:;' class='weui-dialog__btn weui-dialog__btn_default'>取消</a>" +
                    "<a href='javascript:;' class='weui-dialog__btn weui-dialog__btn_primary'>提交</a>" +
                    "</div>";
                dialog_input = "<div class='weui-dialog__bd dialog_input'>" + dialog_select + dialog_id + dialog_birth + dialog_name + dialog_tel + dialog_sex +
                    "</div>"
            }
            if (e.id == "package") {
                dialog_input = "";
                dialog_footer = "<div class='weui-dialog__ft'>" +
                    "<a href='javascript:;' class='weui-dialog__btn weui-dialog__btn_default'>明白了</a>" +
                    "</div>";
            }
            if (e.id == "btn_del") {
                dialog_p = "";
                dialog_input = "";
                dialog_select = ""
                dialog_footer = "<div class='weui-dialog__ft'>" +
                    "<a href='javascript:;' class='weui-dialog__btn weui-dialog__btn_default'>取消</a>" +
                    "<a href='javascript:;' class='weui-dialog__btn weui-dialog__btn_primary'>提交</a>" +
                    "</div>";

            }
            dialog = "<div class='js_dialog' id='dialog_" + e.id + "' style='opacity: 0; display: none;'>" +
                "<div class='weui-mask'></div>" +
                "<div class='weui-dialog'>" + dialog_title + dialog_p + dialog_input + dialog_footer +
                "</div>" +
                "</div>";

            $("body").append(dialog);
            this.id_blur(e.id);
            this.dialog_click(e.id);
        },
        dialog_list: function (e, l) {
            $("." + e.id).on("click", function () {
                $("#dialog_" + e.id + "").fadeIn(200);
            });
            this.dialog_add(e);
            if (e.id == "package") {
                this.add_package(l);
            }
            if (e.id == "btn_del") {
                this.family_list(l);
            }

        },
        dialog_list_click: function (e, l) {
            $("." + e.id).on('click', function () {
                for (i = 0; i < l.length; i++) {
                    if (l[i].id == $(this).attr("id")) {
                        $("#dialog_" + e.id).find(".weui-dialog__title").text(l[i].title);
                        $("#dialog_" + e.id).find(".dialog_p").html(l[i].p);
                    }
                }
                $("#dialog_" + e.id).fadeIn(200);
            });
        },
        dialog_click: function (e) {
            $("#dialog_" + e + "").on("click", '.weui-dialog__btn_default', function () {
                $(this).parents('.js_dialog').fadeOut(200);
            }).on("click", '.weui-dialog__btn_primary', function () {
                if (!$(rel) || f.reg_rel($(rel).val())) {
                    if (!$(id) || f.reg_id($(id).val())) {
                        if (!$(name) || f.reg_name($(name).val())) {
                            if (!$(tel) || f.reg_tel($(tel).val())) {
                                if (!$(address) || f.reg_address($(address).val())) {
                                    if (e == "sign" || e == "clause") {
                                        location.href = "未签约_家庭地址_提交成功.html"
                                    }
                                    if (e == "family") {
                                        var p = {
                                            rel: $(rel).find("option:checked").text(),
                                            id: $(id).val(),
                                            birth: birth,
                                            name: $(name).val(),
                                            tel: $(tel).val(),
                                            sex: sex
                                        };
                                        f.add_family(p);
                                        $(id).val("");
                                        $("#" + e + "_birth").text("—");
                                        $(name).val("");
                                        $(tel).val("");
                                        $(rel).val(0);
                                        $("#" + e + "_sex").text("—");
                                        $("#dialog_" + e + "").fadeOut(200);
                                    }
                                    if (e == "family_d") {
                                        var p = {
                                            rel: $(rel).find("option:checked").text(),
                                            id: $(id).val(),
                                            birth: birth,
                                            name: $(name).val(),
                                            tel: $(tel).val(),
                                            sex: sex
                                        };
                                        f.add_family_del(p);
                                        $(id).val("");
                                        $("#" + e + "_birth").text("—");
                                        $(name).val("");
                                        $(tel).val("");
                                        $(rel).val(0);
                                        $("#" + e + "_sex").text("—");
                                        $("#dialog_" + e + "").fadeOut(200);
                                    }
                                    else {
                                        // alert("在f.js中添加点击事件");
                                    }
                                }
                            }
                        }
                    }
                }
            });
        },
        reg_name: function (e) {
            if (e == "") {
                text = "姓名不能为空";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_tel: function (e) {
            if (e == "") {
                text = "联系电话不能为空";
                this.toptips(text);
                return false;
            }
            reg = /^1([34578]\d{9})$/;
            if (!reg.test(e)) {
                text = "联系电话格式错误";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_id: function (e) {
            if (e == "") {
                text = "身份证不能为空";
                this.toptips(text);
                return false;
            }
            reg = /^[1-9][0-9]{5}(19|20)[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|30|31)|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}([0-9]|x|X)$/;
            if (!reg.test(e)) {
                text = "身份证格式错误";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_address: function (e) {
            if (e == "") {
                text = "地址不能为空";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_address_select: function (e) {
            if (e == "请选择") {
                text = "请选择地址";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_txt: function (e, txt) {
            if (e == "") {
                text = txt;
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_rel: function (e) {
            if (e == "0") {
                text = "请选择与本人的关系";
                this.toptips(text);
                return false;
            }
            return true;
        },
        toptips: function (e) {
            if ($(".weui-toptips").length > 0) {
                $(".weui-toptips").html(e)
            }
            else {
                $("body").prepend("<div class='weui-toptips weui-toptips_warn js_tooltips' style='display:none;'>" + e + "</div>")
            }
            $(".weui-toptips").show(200);
            setTimeout(function () {
                $(".weui-toptips").hide();
            }, 2000);
        },
        extract_id: function (e) {
            //获取出生日期
            birth = e.substring(6, 10) + "-" + e.substring(10, 12) + "-" + e.substring(12, 14);

            //获取性别
            if (parseInt(e.substr(16, 1)) % 2 == 1) {
                //男
                sex = "男";
            } else {
                //女
                sex = "女";
            }

            //获取年龄
            var myDate = new Date();
            var month = myDate.getMonth() + 1;
            var day = myDate.getDate();
            var age = myDate.getFullYear() - e.substring(6, 10) - 1;
            if (e.substring(10, 12) < month || e.substring(10, 12) == month && e.substring(12, 14) <= day) {
                age++;
            }
            return {birth: birth, sex: sex, age: age}
        },
        id_blur: function (e) {
            $("#" + e + "_id").on("blur", function () {
                if (f.reg_id($(this).val())) {
                    $("#" + e + "_birth").text(f.extract_id($(this).val()).birth);
                    $("#" + e + "_sex").text(f.extract_id($(this).val()).sex);
                }
            })
        },
        add_family: function (e) {
            var flist = "<div class='weui-cells'>" +
                "<div class='weui-cell'>" +
                "<div class='weui-cell__hd'>" +
                "<label class='weui-label'>关系</label>" +
                "</div>" +
                "<div id='' class='weui-cell__ft'>" + e.rel + "</div>" +
                "</div>" +
                "<div class='weui-cell'>" +
                "<div class='weui-cell__hd'>" +
                "<label class='weui-label'>身份证号</label>" +
                "</div>" +
                "<div id='' class='weui-cell__ft'>" + e.id + "</div>" +
                "</div>" +
                "<div class='weui-cell'>" +
                "<div class='weui-cell__hd'>" +
                "<label class='weui-label'>生日</label>" +
                "</div>" +
                "<div id='' class='weui-cell__ft'>" + e.birth + "</div>" +
                "</div>" +
                "<div class='weui-cell'>" +
                "<div class='weui-cell__hd'>" +
                "<label class='weui-label'>姓名</label>" +
                "</div>" +
                "<div id='' class='weui-cell__ft'>" + e.name + "</div>" +
                "</div>" +
                "<div class='weui-cell'>" +
                "<div class='weui-cell__hd'>" +
                "<label class='weui-label'>联系电话</label>" +
                "</div>" +
                "<div id='' class='weui-cell__ft'>" + e.tel + "</div>" +
                "</div>" +
                "<div class='weui-cell'>" +
                "<div class='weui-cell__hd'>" +
                "<label class='weui-label'>性别</label>" +
                "</div>" +
                "<div id='' class='weui-cell__ft'>" + e.sex + "</div>" +
                "</div>" +
                "</div>";
            $(".flist").append(flist);
        },
        add_family_del: function (e) {
            var flist = "<div class='weui-cells'>" +
                "<div class='weui-cell weui-cell_vcode'>" +
                "<div class='weui-cell__hd'><label class='weui-label'>关系</label></div>" +
                "<div class='weui-cell__bd' style='color:#999'><label class='weui-label'></label>" + e.rel + "</div>" +
                "<div class='weui-cell__ft'>" +
                "<button class='weui-vcode-btn btn_del'>删除</button>" +
                "</div>" +
                "</div>" +
                "<div class='weui-cell'>" +
                "<div class='weui-cell__hd'>" +
                "<label class='weui-label'>身份证号</label>" +
                "</div>" +
                "<div id='' class='weui-cell__ft'>" + e.id + "</div>" +
                "</div>" +
                "<div class='weui-cell'>" +
                "<div class='weui-cell__hd'>" +
                "<label class='weui-label'>生日</label>" +
                "</div>" +
                "<div id='' class='weui-cell__ft'>" + e.birth + "</div>" +
                "</div>" +
                "<div class='weui-cell'>" +
                "<div class='weui-cell__hd'>" +
                "<label class='weui-label'>姓名</label>" +
                "</div>" +
                "<div id='' class='weui-cell__ft'>" + e.name + "</div>" +
                "</div>" +
                "<div class='weui-cell'>" +
                "<div class='weui-cell__hd'>" +
                "<label class='weui-label'>联系电话</label>" +
                "</div>" +
                "<div id='' class='weui-cell__ft'>" + e.tel + "</div>" +
                "</div>" +
                "<div class='weui-cell'>" +
                "<div class='weui-cell__hd'>" +
                "<label class='weui-label'>性别</label>" +
                "</div>" +
                "<div id='' class='weui-cell__ft'>" + e.sex + "</div>" +
                "</div>" +
                "</div>";
            $(".flist").append(flist);
        },
        family_list: function (e) {
            var type, type0, type1;
            for (i = 0; i < e.length; i++) {
                type = "";
                type0 = "<div class='weui-cell'>" +
                    "<div class='weui-cell__hd'>" +
                    "<label class='weui-label'>关系</label>" +
                    "</div>" +
                    "<div id='' class='weui-cell__ft'>" + e[i].rel + "</div>" +
                    "</div>";
                type1 = "<div class='weui-cell weui-cell_vcode'>" +
                    "<div class='weui-cell__hd'><label class='weui-label'>关系</label></div>" +
                    "<div class='weui-cell__bd' style='color:#999'><label class='weui-label'></label>" + e[i].rel + "</div>" +
                    "<div class='weui-cell__ft'>" +
                    "<button class='weui-vcode-btn btn_del'>删除</button>" +
                    "</div>" +
                    "</div>";
                if (e[i].type == 0) {
                    type = type0;
                }
                else {
                    type = type1;
                }
                var flist = "<div class='weui-cells'>" + type +
                    "<div class='weui-cell'>" +
                    "<div class='weui-cell__hd'>" +
                    "<label class='weui-label'>身份证号</label>" +
                    "</div>" +
                    "<div id='' class='weui-cell__ft'>" + e[i].id + "</div>" +
                    "</div>" +
                    "<div class='weui-cell'>" +
                    "<div class='weui-cell__hd'>" +
                    "<label class='weui-label'>生日</label>" +
                    "</div>" +
                    "<div id='' class='weui-cell__ft'>" + e[i].birth + "</div>" +
                    "</div>" +
                    "<div class='weui-cell'>" +
                    "<div class='weui-cell__hd'>" +
                    "<label class='weui-label'>姓名</label>" +
                    "</div>" +
                    "<div id='' class='weui-cell__ft'>" + e[i].name + "</div>" +
                    "</div>" +
                    "<div class='weui-cell'>" +
                    "<div class='weui-cell__hd'>" +
                    "<label class='weui-label'>联系电话</label>" +
                    "</div>" +
                    "<div id='' class='weui-cell__ft'>" + e[i].tel + "</div>" +
                    "</div>" +
                    "<div class='weui-cell'>" +
                    "<div class='weui-cell__hd'>" +
                    "<label class='weui-label'>性别</label>" +
                    "</div>" +
                    "<div id='' class='weui-cell__ft'>" + e[i].sex + "</div>" +
                    "</div>" +
                    "</div>";
                $(".flist").append(flist);
            }
        },
        add_package: function (e) {
            var plist;
            var br = "<br>";
            for (i = 0; i < e.length; i++) {
                if (i == e.length - 1) {
                    br = "";
                }
                plist = "<div class='weui-form-preview'>" +
                    "<div class='weui-form-preview__hd'>" +
                    "<div class='weui-form-preview__item'>" +
                    "<label class='weui-form-preview__label'>" + e[i].title + "</label>" +
                    "<em class='weui-form-preview__value'>￥" + e[i].price + "</em>" +
                    "</div>" +
                    "</div>" +
                    "<div class='weui-form-preview__bd'>" +
                    "<div class='weui-form-preview__item'>" +
                    "<label class='weui-form-preview__label'>有效时间</label>" +
                    "<span class='weui-form-preview__value'>" + e[i].time + "</span>" +
                    "</div>" +
                    "</div>" +
                    "<div class='weui-form-preview__ft'>" +
                    "<a id='" + e[i].id + "' class='package weui-form-preview__btn weui-form-preview__btn_primary' href='javascript:'>查看</a>" +
                    "</div>" +
                    "</div>" + br;
                $(".preview_list").append(plist);
            }
        }
    };