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

    //图片添加和上传，图片点击查看
    var tmpl = '<li class="weui-uploader__file" style="background-image:url(#url#)"></li>',
        $gallery = $("#gallery"),
        $galleryImg = $("#galleryImg"),
        $uploaderInput = $("#uploaderInput"),
        $uploaderFiles = $("#uploaderFiles");

    $uploaderInput.on("change", function (e) {
        $uploaderFiles.empty();
        $uploaderInput.parent().css('display', null);
        if ($("li[class='weui-uploader__file']").length >= 4) {
            f.reg_length();
        } else {
            var src, url = window.URL || window.webkitURL || window.mozURL, files = e.target.files;
            for (var i = 0, len = files.length; i < len; ++i) {
                var file = files[i];

                if (url) {
                    src = url.createObjectURL(file);
                } else {
                    src = e.target.result;
                }

                $uploaderFiles.append($(tmpl.replace('#url#', src)));
                $(".weui-uploader__input-box").hide();
            }
            $uploaderInput.hide();
            $uploaderInput.css('display', null);
        }
    });
    $uploaderFiles.on("click", "li", function () {
        $galleryImg.attr("style", this.getAttribute("style"));
        $gallery.fadeIn(100);
        $uploaderInput.click();
    });
    $gallery.on("click", function () {
        $gallery.fadeOut(100);
    });

    //头像上传
    var $uploaderIdPhoto = $("#uploaderIdPhoto"),
        tmpl2 = '<li class="weui-uploader__file" style="background-image:url(#url#)"></li>',
        $uploaderFiles2 = $("#uploaderFiles2");
    $uploaderIdPhoto.on("change", function (e) {
        var url = window.URL || window.webkitURL || window.mozURL;
        var fileUpload = $("#uploaderIdPhoto").get(0);
        var files = fileUpload.files;
        var data = new FormData();
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }
        $.ajax({
            type: "POST",
            //url: getRootPath_web() + "/Sign/UploadImage",
            url: getRootPath_web() + "/UploadImage",
            contentType: false,
            processData: false,
            data: data,
            success: function (response) {
                if (response != "") {
                    $uploaderFiles2.html($(tmpl2.replace('#url#', response)));
                    $(".weui-uploader__input-box").hide();
                    $("#Avatar").val(response);
                }
            },
            error: function () {
                alert("上传失败");
            }
        });
    });

    $uploaderFiles2.on("click", "li", function () {
        $uploaderIdPhoto.click();
    });

    //慢病切换按钮
    $(".cDisease_tab").find("a").on("click", function () {
        $(".cDisease_tab").find("a").removeClass("weui-bar__item_on");
        $(this).addClass("weui-bar__item_on");
    })
});

var dialog,
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
    myScroll,
    pullDownEl,
    pullDownOffset,
    pullUpEl,
    pullUpOffset,
    generatedCount = 0,
    f = {
        dialog: function (e) {
            $("#" + e).on("click", function () {
                $("#dialog_" + e + "").fadeIn(0);
            });
            $("#dialog_" + e + " .weui-dialog__btn_default").on("click", function () {
                $("#dialog_" + e + "").fadeOut(0);
            });
        },
        dialog_class: function (e) {
            $("." + e).on("click", function () {
                $("#dialog_" + e + "").fadeIn(0);
            });
            $("#dialog_" + e + " .weui-dialog__btn_default").on("click", function () {
                $("#dialog_" + e + "").fadeOut(0);
            });
        },
        reg_name: function (e) {
            if (e == "") {
                text = "请输入姓名";
                this.toptips(text);
                return false;
            }
            reg = /^[\u4E00-\u9FA5]+$/;
            if (!reg.test(e)) {
                text = "姓名请使用汉字";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_phone: function (e) {
            if (e == "") {
                text = "请输入电话";
                this.toptips(text);
                return false;
            }
            reg = /^[0-9]*$/;
            if (!reg.test(e)) {
                text = "电话格式错误";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_idNo: function (e) {
            if (e == "") {
                text = "请输入身份证号";
                this.toptips(text);
                return false;
            }
            reg = /^[1-9][0-9]{5}(19|20)[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|30|31)|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}([0-9]|x|X)$/;
            if (!reg.test(e)) {
                text = "身份证号格式错误";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_address: function (e) {
            if (e == "请选择") {
                text = "请选择地址";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_building: function (e) {
            if (e == "") {
                text = "请输入幢(组)";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_room: function (e) {
            if (e == "") {
                text = "请输入室(号)";
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
        reg_specialcrowd: function (e) {
            if (e == "请选择") {
                text = "请选择特殊人群";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_disease: function (e) {
            if (e == "请选择") {
                text = "请选择既往病史";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_contactphone: function (e) {
            reg = /^[0-9]*$/;
            if (!reg.test(e)) {
                text = "联系电话格式错误";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_question: function (e) {
            if (e == "") {
                this.toptips("请输入您的症状");
                return false;
            }
            return true;
        },
        reg_length: function (e) {
            this.toptips("最多只能上传4张图片");
            return false;
        },
        reg_bloodsugar: function (e) {
            if (e == "") {
                text = "请输入血糖值";
                this.toptips(text);
                return false;
            }
            reg = /^[0-9]+(\.[0-9]{1})?$/;
            if (!reg.test(e)) {
                text = "血糖值应为整数或最多一位小数";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_bloodpressure: function (val1, val2) {
            if (parseInt(val1) < parseInt(val2)) {
                text = "收缩压应不小于舒张压";
                this.toptips(text);
                return false;
            }
            return true;
        },
        reg_decimal: function (e, txt) {
            if (e == "") {
                text = "请输入" + txt;
                this.toptips(text);
                return false;
            }
            reg = /^[0-9]+(\.[0-9]{1,2})?$/;
            if (!reg.test(e)) {
                text = txt + "应为整数或最多两位小数";
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
        successToptips: function (e, href) {
            if ($(".weui-successToptips").length > 0) {
                $(".weui-successToptips").html(e)
            }
            else {
                $("body").prepend("<div class='weui-toptips weui-successToptips weui-toptips_warn js_tooltips' style='display:none;'>" + e + "</div>")
            }
            $(".weui-successToptips").show(200);
            setTimeout(function () {
                $(".weui-successToptips").hide();
                location.href = href;
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
            return { birth: birth, sex: sex, age: age }
        },
        id_blur: function (e) {
            $("#" + e + "_id").on("blur", function () {
                if (f.reg_id($(this).val())) {
                    $("#" + e + "_birth").text(f.extract_id($(this).val()).birth);
                    $("#" + e + "_sex").text(f.extract_id($(this).val()).sex);
                }
            })
        },
        signData: function () {
            var date = new Date();
            var seperator1 = "-";
            var seperator2 = ":";
            var month = date.getMonth() + 1;
            var strDate = date.getDate();
            if (month >= 1 && month <= 9) {
                month = "0" + month;
            }
            if (strDate >= 0 && strDate <= 9) {
                strDate = "0" + strDate;
            }
            var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate;
            return currentdate;
        },
        pullDownAction: function () {
            //setTimeout(function () {	// <-- Simulate network congestion, remove setTimeout from production!
            //    var el, li, i;
            //    el = document.getElementById('thelist');

            //    for (i = 0; i < 3; i++) {
            //        li = document.createElement('li');
            //        li.innerText = 'Generated row ' + (++generatedCount);
            //        el.insertBefore(li, el.childNodes[0]);
            //    }

            //    myScroll.refresh();		//数据加载完成后，调用界面更新方法   Remember to refresh when contents are loaded (ie: on ajax completion)
            //}, 1000);	// <-- Simulate network congestion, remove setTimeout from production!
        },
        pullUpAction: function (e, type) {
            if (typeof getData === 'function') {
                e = getData();
            }
            setTimeout(function () {	// <-- Simulate network congestion, remove setTimeout from production!
                var el, li, i;
                el = document.getElementById('thelist');

                if (type == "serviceRecord") {
                    for (i = 0; i < e.length; i++) {
                        li = document.createElement('div');
                        li.className = "weui-form-preview";
                        li.innerHTML = "<div class='weui-form-preview__hd'>" +
                            "<div class='weui-form-preview__item'> " +
                            "<label class='weui-form-preview__label'>" + e[i].id + "</label> " +
                            "<em class='weui-form-preview__value done'>已经完成</em> " +
                            "</div> " +
                            "</div>" +
                            "<div class='weui-form-preview__bd'>" +
                            "<div class='weui-form-preview__item'>" +
                            "<label class='weui-form-preview__label'>家庭成员</label>" +
                            "<span class='weui-form-preview__value'>" + e[i].family + "</span>" +
                            "</div>" +
                            "<div class='weui-form-preview__item'>" +
                            "<label class='weui-form-preview__label'>建立时间</label>" +
                            "<span class='weui-form-preview__value'>" + e[i].time + "</span>" +
                            "</div>" +
                            "</div>" +
                            "<div class='weui-form-preview__ft'>" +
                            "<a class='weui-form-preview__btn weui-form-preview__btn_primary' href='服务记录_服务详情.html'>查看</a>" +
                            "</div>";
                        el.appendChild(li);
                    }
                }
                if (type == "onlineConsulting") {
                    for (i = 0; i < e.length; i++) {
                        li = document.createElement('div');
                        li.className = "weui-panel onlineConsulting_panel";
                        li.setAttribute("onclick", "detail(" + e[i].id + ")");
                        li.setAttribute("id", e[i].id);
                        var isAnswerStr = "";
                        if (e[i].isAnswer) {
                            isAnswerStr = "<span class='weui-badge weui-badge-success'>已回复</span>";
                        } else {
                            isAnswerStr = "<span class='weui-badge weui-badge-warning'>等待回复</span>";
                        }
                        li.innerHTML = "<div class='weui-panel__bd'> " +
                            "<div class='weui-media-box weui-media-box_text onlineConsulting_box'> " +
                            "<p class='weui-media-box__desc'>" + e[i].text + "</p> " +
                            "<ul class='weui-media-box__info'> " +
                            "<li class='weui-media-box__info__meta' style='color: #0099FF;'>" + e[i].sex + "</li> " +
                            "<li class='weui-media-box__info__meta weui-media-box__info__meta_extra' style='color: #0099FF;'>" + e[i].age + "岁</li> " +
                            "<li class='weui-media-box__info__meta weui-media-box__info__meta_extra'>" + e[i].time + "</li> " +
                            "</ul> " +
                            "</div> " +
                            "</div> " +
                            "<div class='weui-panel__ft onlineConsulting_tab'> " +
                            "<div class='weui-cell weui-cell_access weui-cell_link'> " +
                            "<div class='weui-cell__bd'> " +
                            isAnswerStr +
                            "</div> " +
                            "</div> " +
                            "</div>";
                        el.appendChild(li);
                    }
                }
                if (type == "myOnlineConsulting") {
                    for (i = 0; i < e.length; i++) {
                        li = document.createElement('div');
                        li.className = "weui-panel onlineConsulting_panel onlineConsulting_my";
                        li.setAttribute("onclick", "detail(" + e[i].id + ")");
                        li.setAttribute("id", e[i].id);
                        var isAnswerStr = "";
                        if (e[i].isAnswer) {
                            isAnswerStr = "<span class='weui-badge weui-badge-success'>已回复</span>";
                        } else {
                            isAnswerStr = "<span class='weui-badge weui-badge-warning'>等待回复</span>";
                        }
                        li.innerHTML = "<div class='weui-panel__bd'> " +
                            "<div class='weui-media-box weui-media-box_text onlineConsulting_box'> " +
                            "<p class='weui-media-box__desc'>" + e[i].text + "</p> " +
                            "<ul class='weui-media-box__info'> " +
                            "<li class='weui-media-box__info__meta' style='color: #0099FF;'>" + e[i].name + "</li> " +
                            "<li class='weui-media-box__info__meta weui-media-box__info__meta_extra' style='color: #0099FF;'>" + e[i].sex + "</li> " +
                            "<li class='weui-media-box__info__meta weui-media-box__info__meta_extra' style='color: #0099FF;'>" + e[i].age + "岁</li> " +
                            "<li class='weui-media-box__info__meta weui-media-box__info__meta_extra'>" + e[i].time + "</li> " +
                            "</ul> " +
                            "</div> " +
                            "</div> " +
                            "<div class='weui-panel__ft onlineConsulting_tab'> " +
                            "<div class='weui-cell weui-cell_access weui-cell_link'> " +
                            "<div class='weui-cell__bd'> " +
                            isAnswerStr +
                            "</div> " +
                            "</div> " +
                            "</div>";
                        el.appendChild(li);
                    }
                }

                myScroll.refresh();		// 数据加载完成后，调用界面更新方法 Remember to refresh when contents are loaded (ie: on ajax completion)
            }, 0);	// <-- Simulate network congestion, remove setTimeout from production!
        },
        loaded: function (e, type) {
            pullDownEl = document.getElementById('pullDown');
            pullDownOffset = pullDownEl.offsetHeight;
            pullUpEl = document.getElementById('pullUp');
            pullUpOffset = pullUpEl.offsetHeight;

            myScroll = new iScroll('wrapper', {
                scrollbarClass: 'myScrollbar', /* 重要样式 */
                useTransition: false, /* 此属性不知用意，本人从true改为false */
                topOffset: pullDownOffset,
                onRefresh: function () {
                    if (pullDownEl.className.match('loading')) {
                        pullDownEl.className = '';
                        pullDownEl.querySelector('.pullDownLabel').innerHTML = '下拉刷新...';
                    } else if (pullUpEl.className.match('loading')) {
                        pullUpEl.className = '';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '上拉加载更多...';
                    }
                },
                onScrollMove: function () {
                    if (this.y > 5 && !pullDownEl.className.match('flip')) {
                        pullDownEl.className = 'flip';
                        pullDownEl.querySelector('.pullDownLabel').innerHTML = '松手开始更新...';
                        this.minScrollY = 0;
                    } else if (this.y < 5 && pullDownEl.className.match('flip')) {
                        pullDownEl.className = '';
                        pullDownEl.querySelector('.pullDownLabel').innerHTML = '下拉刷新...';
                        this.minScrollY = -pullDownOffset;
                    } else if (this.y < (this.maxScrollY - 5) && !pullUpEl.className.match('flip')) {
                        pullUpEl.className = 'flip';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '松手开始更新...';
                        this.maxScrollY = this.maxScrollY;
                    } else if (this.y > (this.maxScrollY + 5) && pullUpEl.className.match('flip')) {
                        pullUpEl.className = '';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '上拉加载更多...';
                        this.maxScrollY = pullUpOffset;
                    }
                },
                onScrollEnd: function () {
                    if (pullDownEl.className.match('flip')) {
                        pullDownEl.className = 'loading';
                        pullDownEl.querySelector('.pullDownLabel').innerHTML = '加载中...';
                        f.pullDownAction();	// Execute custom function (ajax call?)
                    } else if (pullUpEl.className.match('flip')) {
                        pullUpEl.className = 'loading';
                        pullUpEl.querySelector('.pullUpLabel').innerHTML = '加载中...';
                        f.pullUpAction(e, type);	// Execute custom function (ajax call?)
                    }
                }
            });

            setTimeout(function () {
                document.getElementById('wrapper').style.left = '0';
            }, 800);
        }
    };

function getRootPath_web() {
    //获取当前网址，如： http://localhost/familydoctorh5/sign/applysuccess
    var curWwwPath = window.document.location.href;
    //获取主机地址之后的目录，如： familydoctorh5/sign/applysuccess
    var pathName = window.document.location.pathname;
    var pos = curWwwPath.indexOf(pathName);
    //获取主机地址，如： http://localhost
    var localhostPaht = curWwwPath.substring(0, pos);
    //获取带"/"的项目名，如：/familydoctorh5
    var projectName = pathName.substring(0, pathName.substr(1).indexOf('/') + 1);
    return (localhostPaht + projectName);
}