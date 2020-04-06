(function ($) {
    "use strict";

    /* jQuery MeanMenu */
    $('#mobile-menu-active').meanmenu({
        meanScreenWidth: "767",
        meanMenuContainer: ".mobile-menu-area .mobile-menu",
    });

    /* Profile page Buttons with different window width */   
    $('.d-inline').ready(function () {
        function nowWidth() {
            var currentWidth = window.innerWidth || document.documentElement.clientWidth;
            if (((currentWidth <= 1209) && (currentWidth >= 1200)) || ((currentWidth <= 1109) && (currentWidth >= 992))) {
                $('#profileButtons').removeClass('d-inline');
                $('#profileButtonsInn').addClass('mb-20');
            }
            else {
                $('#profileButtonsInn').removeClass('mb-20');
            }
        }

        nowWidth(); // check while load page

        $(window).resize(function () {
            nowWidth(); // check while resize by client
        });
    });


    /*====== sidebarSearch ======*/
    function sidebarSearch() {
        var searchTrigger = $('button.sidebar-trigger-search'),
            endTriggersearch = $('button.search-close'),
            container = $('.main-search-active');
        searchTrigger.on('click', function () {
            container.addClass('inside');
        });
        endTriggersearch.on('click', function () {
            container.removeClass('inside');
        });
    };
    sidebarSearch();


    /* slider active */
    $('.slider-active').owlCarousel({
        loop: true,
        nav: true,
        autoplay: false,
        autoplayTimeout: 5000,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        navText: ['<i class="ion-chevron-left"></i>', '<i class="ion-chevron-right"></i>'],
        item: 1,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })

    /*---------------------
    countdown
  --------------------- */
    $('[data-countdown]').each(function () {
        var $this = $(this),
            finalDate = $(this).data('countdown');
        $this.countdown(finalDate, function (event) {
            $this.html(event.strftime('<span class="cdown day">%-D <p>Days</p></span> <span class="cdown hour">%-H <p>Hour</p></span> <span class="cdown minutes">%M <p>Min</p></span class="cdown second"> <span>%S <p>Sec</p></span>'));
        });
    });

    /*--
    Menu Stick
    -----------------------------------*/
    var header = $('.transparent-bar');
    var win = $(window);

    win.on('scroll', function () {
        var scroll = win.scrollTop();
        if (scroll < 200) {
            header.removeClass('stick');
        } else {
            header.addClass('stick');
        }
    });


    /* Button Effect */
    function buttonEffect() {
        $('<b></b>').appendTo('.cr-btn');
        $('.cr-btn')
            .on('mouseenter', function (e) {
                var parentOffset = $(this).offset(),
                    relX = e.pageX - parentOffset.left,
                    relY = e.pageY - parentOffset.top;
                $(this).find('b').css({
                    top: relY,
                    left: relX
                });
            })
            .on('mouseout', function (e) {
                var parentOffset = $(this).offset(),
                    relX = e.pageX - parentOffset.left,
                    relY = e.pageY - parentOffset.top;
                $(this).find('b').css({
                    top: relY,
                    left: relX
                });
            });
        $('[href="#"]').click(function () {
            return true;
        });
    }
    buttonEffect();

    /* creative-menu-6 */
    var CreativeMenu = $('.sidebarmenu-wrapper');
    $(".menu-icon").on("click", function () {
        CreativeMenu.css('left', '0').addClass('animated Toggle');
    })
    $(".menu-close").on("click", function () {
        CreativeMenu.css('left', '-420px').removeClass('animated Toggle');
    })


    /* Sidemenu Dropdown */
    function sidemenuDropdown() {
        var $this = $('.sidebarmenu-wrapper');
        $this.find('nav.menu .cr-dropdown')
            .find('ul').slideUp();
        $this.find('nav.menu li.cr-dropdown > a, nav.menu li.cr-sub-dropdown > a').on('click', function (e) {
            e.preventDefault();
            $(this).next().slideToggle();
        });
    }
    sidemenuDropdown();


    // Instantiate EasyZoom instances
    var $easyzoom = $('.easyzoom').easyZoom();


    /*---------------------
    sidebar sticky
    --------------------- */
    $('.sidebar-active').stickySidebar({
        topSpacing: 80,
        bottomSpacing: 30,
        minWidth: 991,
    });

    /*--------------------------
    tab active
    ---------------------------- */
    $('.wish-details-small a').on('click', function (e) {
        e.preventDefault();

        var $href = $(this).attr('href');

        $('.wish-details-small a').removeClass('active');
        $(this).addClass('active');

        $('.wish-details-large .tab-pane').removeClass('active');
        $('.wish-details-large ' + $href).addClass('active');
    })


    /*--------------------------
     ScrollUp
    ---------------------------- */
    $.scrollUp({
        scrollText: '<i class="ion-arrow-up-c"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade'
    });




})(jQuery);