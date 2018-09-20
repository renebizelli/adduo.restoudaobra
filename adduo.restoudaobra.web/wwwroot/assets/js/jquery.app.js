$(function() {

    var json = sessionStorage.getItem('RO-AUTH')

    let menu = {
        nameOwner : $('#menu-name-owner'),
        elementsOnlyAuth : $('.menu-only-auth'),
        elementsOnlyAnonimous : $('.menu-only-anonimous'),
        btnLogOff : $('#menu-btn-logoff'),
        btnOpen : $('#menu-btn-open'),
        btnClose : $('#menu-btn-close'),
        nav : $('#menu-nav'),
        logo : $('#menu-logo')
    }

    /* ******************************************************************* */

    if(json) {

        var auth = jQuery.parseJSON(json)

        if(auth.name) {

            menu.nameOwner.html('Olá ' + auth.name)

            menu.elementsOnlyAuth.each(function(i, ui) {
                $(ui).show()
            });

            menu.elementsOnlyAnonimous.each(function(i, ui) {
                $(ui).hide()
            });
        }
    }
    else {
            menu.elementsOnlyAnonimous.each(function(i, ui) {
                $(ui).show()
            });

    }

    menu.btnLogOff.on('click', function() {

        sessionStorage.removeItem('RO-AUTH');

        menu.elementsOnlyAuth.each(function(i, ui) {
            $(ui).hide()
        });

        menu.elementsOnlyAnonimous.each(function(i, ui) {
            $(ui).show()
        });

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


    $(document).scroll(function(x, y) {

        var scroll = $(this).scrollTop();

        if(scroll > 250) {
            menu.logo.fadeIn();
        }
        else {
            menu.logo.fadeOut();
        }


      });


});