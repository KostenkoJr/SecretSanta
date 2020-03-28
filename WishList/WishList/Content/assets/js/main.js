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


    ///*====== sidebargift ======*/
    //function sidebargift() {
    //    var menuTrigger = $('button.sidebar-trigger'),
    //        endTrigger = $('button.op-sidebar-close'),
    //        container = $('.sidebar-gift'),
    //        wrapper = $('.wrapper');
    //    wrapper.prepend('<div class="body-overlay"></div>');
    //    menuTrigger.on('click', function () {
    //        container.addClass('inside');
    //        wrapper.addClass('overlay-active');
    //    });
    //    endTrigger.on('click', function () {
    //        container.removeClass('inside');
    //        wrapper.removeClass('overlay-active');
    //    });
    //    $('.body-overlay').on('click', function () {
    //        container.removeClass('inside');
    //        wrapper.removeClass('overlay-active');
    //    });
    //};
    //sidebargift();


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


    /* slider active */
    $('.new-collection-slider').owlCarousel({
        loop: true,
        nav: false,
        autoplay: true,
        autoplayTimeout: 5000,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
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


    /* collection-wish active */
    $('.collection-wish-active').owlCarousel({
        loop: true,
        nav: false,
        autoplay: true,
        autoplayTimeout: 5000,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        item: 3,
        margin: 30,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            1000: {
                items: 3
            }
        }
    })


    /* collection-wish active */
    $('.trending-wish-active').owlCarousel({
        loop: true,
        nav: false,
        autoplay: true,
        autoplayTimeout: 5000,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        item: 4,
        margin: 20,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            1000: {
                items: 3
            }
        }
    })


    /* testimonial active */
    $('.testimonial-active').owlCarousel({
        loop: true,
        autoplay: false,
        autoplayTimeout: 5000,
        navText: ['<i class="ti-angle-left"></i>', '<i class="ti-angle-right"></i>'],
        nav: true,
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


    /* wish-dec-slider active */
    $('.wish-dec-slider').owlCarousel({
        loop: true,
        autoplay: false,
        autoplayTimeout: 5000,
        navText: ['<i class="ti-angle-left"></i>', '<i class="ti-angle-right"></i>'],
        nav: true,
        item: 4,
        margin: 12,
        responsive: {
            0: {
                items: 2
            },
            768: {
                items: 4
            },
            1000: {
                items: 4
            }
        }
    })


    /* testimonial active */
    $('.brand-logo-active').owlCarousel({
        loop: true,
        autoplay: true,
        autoplayTimeout: 5000,
        nav: false,
        item: 5,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 3
            },
            1000: {
                items: 4
            },
            1100: {
                items: 5
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


    /*------ Wow Active ----*/
    new WOW().init();


    /*----------------------------
    	gift Plus Minus Button
    ------------------------------ */
    $(".gift-plus-minus").prepend('<div class="dec qtybutton">-</div>');
    $(".gift-plus-minus").append('<div class="inc qtybutton">+</div>');
    $(".qtybutton").on("click", function () {
        var $button = $(this);
        var oldValue = $button.parent().find("input").val();
        if ($button.text() === "+") {
            var newVal = parseFloat(oldValue) + 1;
        } else {
            // Don't allow decrementing below zero
            if (oldValue > 0) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 1;
            }
        }
        $button.parent().find("input").val(newVal);
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

    //function inputEffect() {
    //    $('<b></b>').appendTo('.confirm-btn');
    //    $('.confirm-btn')
    //        .on('mouseenter', function (e) {
    //            var parentOffset = $(this).offset(),
    //                relX = e.pageX - parentOffset.left,
    //                relY = e.pageY - parentOffset.top;
    //            $(this).find('b').css({
    //                top: relY,
    //                left: relX
    //            });
    //        })
    //        .on('mouseout', function (e) {
    //            var parentOffset = $(this).offset(),
    //                relX = e.pageX - parentOffset.left,
    //                relY = e.pageY - parentOffset.top;
    //            $(this).find('b').css({
    //                top: relY,
    //                left: relX
    //            });
    //        });
    //    $('[href="#"]').click(function () {
    //        return true;
    //    });
    //}
    //inputEffect();


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


    /*---------------------
    chosen
    --------------------- */
    jQuery('.orderby').chosen({
        disable_search: true,
        width: "auto"
    });


    /*---------------------
    shop grid list
    --------------------- */
    $('.view-mode li a').on('click', function () {
        var $proStyle = $(this).data('view');
        $('.view-mode li').removeClass('active');
        $(this).parent('li').addClass('active');
        $('.wish-view').removeClass('wish-grid wish-list').addClass($proStyle);
    })


    /*-- Price Range --*/
    $('#price-range').slider({
        range: true,
        min: 0,
        max: 700,
        values: [70, 500],
        slide: function (event, ui) {
            $('.price-amount').val('$' + ui.values[0] + ' - $' + ui.values[1]);
        }
    });
    $('.price-amount').val('$' + $('#price-range').slider('values', 0) +
        ' - $' + $('#price-range').slider('values', 1));
    $('.wish-filter-toggle').on('click', function () {
        $('.wish-filter-wrapper').slideToggle();
    })


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


    /*--- showlogin toggle function ----*/
    $('#showlogin').on('click', function () {
        $('#checkout-login').slideToggle(900);
    });


    /*--- showlogin toggle function ----*/
    $('#showcoupon').on('click', function () {
        $('#checkout_coupon').slideToggle(900);
    });


    /*--- showlogin toggle function ----*/
    $('#ship-box').on('click', function () {
        $('#ship-box-info').slideToggle(1000);
    })


    /* isotop active */
    // filter items on button click
    $('.blog-area').imagesLoaded(function () {
        $('.portfolio-menu-active').on('click', 'button', function () {
            var filterValue = $(this).attr('data-filter');
            $grid.isotope({
                filter: filterValue
            });
        });
        // init Isotope
        var $grid = $('.blog-grid').isotope({
            itemSelector: '.blog-grid-item',
            percentPosition: true,
            masonry: {
                // use outer width of grid-sizer for columnWidth
                columnWidth: '.blog-grid-item',
            }
        });
    });


    /* slider active */
    $('.blog-gallery-slider').owlCarousel({
        loop: true,
        nav: true,
        autoplay: true,
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