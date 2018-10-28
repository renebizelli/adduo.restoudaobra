    var isMobile = false;
    var mobileDevice = false;

    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini|Opera Mobile|Kindle|Windows Phone|PSP|AvantGo|Atomic Web Browser|Blazer|Chrome Mobile|Dolphin|Dolfin|Doris|GO Browser|Jasmine|MicroB|Mobile Firefox|Mobile Safari|Mobile Silk|Motorola Internet Browser|NetFront|NineSky|Nokia Web Browser|Obigo|Openwave Mobile Browser|Palm Pre web browser|Polaris|PS Vita browser|Puffin|QQbrowser|SEMC Browser|Skyfire|Tear|TeaShark|UC Browser|uZard Web|wOSBrowser|Yandex.Browser mobile/i.test(navigator.userAgent)) mobileDevice = true;

    $(function() {

        $.setIsMobileByWindowWith = function() {
            isMobile = mobileDevice || parseInt( $(window).width(), 10) < 1024
        }
        $.setIsMobileByWindowWith();

        /* ******************************************************************* */


        let menuauth = {
            nav: $('#menu-only-auth'),
            nameOwner : $('#menu-name-owner'),
            btnLogOff : $('.menu-logoff'),
            btnLogIn : $('#menu-login'),
            elementOnlyAuth: $(".menu-only-auth")

        }

        let menu = {
            btnOpen : $('#menu-btn-open'),
            btnClose : $('#menu-btn-close'),
            nav : $('#menu-nav'),
            logo : $('#menu-logo')
        }

        /* ******************************************************************* */

        $.initAuth = function() {

            var json = sessionStorage.getItem('RO-AUTH')


            if(json) {

                var auth = jQuery.parseJSON(json)

                if(auth.name) {
                    menuauth.nav.show()
                    menuauth.btnLogIn.hide()
                    menuauth.nameOwner.html('Olá ' + auth.name)
                }

                menuauth.elementOnlyAuth.each(function(i, ui){
                    if(isMobile)
                     { 
                        $(ui).show()
                     } 
                })

            }
            else {
                menuauth.btnLogIn.show()
                menuauth.nav.hide()
                menuauth.elementOnlyAuth.each(function(i, ui){
                    $(ui).hide()
                })

            }

        }

        $.initAuth()

        menuauth.btnLogOff.on('click', function() {

            sessionStorage.removeItem('RO-AUTH');

            $.initAuth()

        });

        $.toogleMenu = function() {
            if(menu.nav.hasClass('open')) {
                menu.btnClose.hide();
                menu.nav.removeClass('open');
            }
            else {
                menu.btnClose.show();
                menu.nav.addClass('open');
            }
        }

        menu.btnOpen.on('click', $.toogleMenu);
        menu.btnClose.on('click', $.toogleMenu);


        /* ******************************************************************* */


        $.setInitScroll = function() {

            var scroll = $(this).scrollTop();

            if(menu.logo.hasClass("menu-logo-scroll")) {

                if(scroll > 250) {
                    menu.logo.fadeIn();
                }
                else {
                    menu.logo.fadeOut();
                }
            }

        }

        $.setInitScroll();


        $(window).resize(function() {
            $.setIsMobileByWindowWith();
            $.setInitScroll();
        });


        $(document).scroll(function(x, y) {

            if(!isMobile) {
                $.setInitScroll()
            }
        });



        /* ******************************************************************* */

        $("#contact-btn").on("click", function() {

            var _this = $(this)

            var ad = _this.attr("data-ad")

            $("#contact-loader").fadeIn()

            _this.hide()

            $.get("http://localhost:5050/owner/contact/" + ad, function(response) {

                if(response) {
                    $("#contact-info-name").html(response.dto.firstname)
                    $("#contact-info-email").html(response.dto.email)
                    $("#contact-info-phone").html(response.dto.phoneFormat)
                    $("#contact-info-cellphone").html(response.dto.cellphoneFormat)
                }

                $("#contact-loader").hide()
                $("#contact-data").fadeIn()

            })
        })

        /* ******************************************************************* */
        

    });
