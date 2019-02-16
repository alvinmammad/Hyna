(function ($) {
  "use strict";

  /*------------------------------------
    Preloader
  ------------------------------------- */
  setTimeout(function () {
    $('#preloader').fadeOut();
    $('.loader-icon').delay(150).fadeOut('slow');
  }, 1000);

  /*------------------------------------
    Search Option
  ------------------------------------- */
  $('.search-btn-area .input-group').hide();
  $(".main-search").on('click', function (event) {
    event.preventDefault();
    $('.search-btn-area .input-group').animate({
      height: 'toggle',
    });
  });

  /*------------------------------------
    Active Menu
  ------------------------------------- */
  var url = window.location;
  $('ul.navbar-nav a[href="' + url + '"]').parent().addClass('active');
  $('ul.navbar-nav a').filter(function () {
    return this.href == url;
  }).parent().addClass('active').parent().parent().addClass('active');

  /*--------------------------
    Menu
  ---------------------------- */
  if ($(window).width() < 992) {
    $('.dropdown-menu a.dropdown-toggle').on('click', function (e) {
      if (!$(this).next().hasClass('show')) {
        $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
      }
      var $subMenu = $(this).next(".dropdown-menu");
      $subMenu.toggleClass('show');

      $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
        $('.dropdown-submenu .show').removeClass("show");
      });
      return false;
    });
  }

  /*--------------------------
    Revolution Slider Hero Area
  ---------------------------- */
  if ($('.rev_slider_wrapper #slider1').length) {
    $("#slider1").revolution({
      sliderType: "standard",
      sliderLayout: "auto",
      delay: 5000,
      navigationType: "bullet",
      navigationArrows: "0",
      navigationStyle: "preview3",
      dottedOverlay: 'yes',
      hideTimerBar: "off",
      onHoverStop: "off",
      navigation: {
        arrows: { enable: true }
      },
      responsiveLevels: [1920, 1280, 975, 600, 300],
      gridwidth: [1170, 720, 500, 500, 300],
      gridheight: [650, 600, 550, 450, 400]
    });
  };

  /*--------------------------
    Knob
  ---------------------------- */
  $(".dial").knob();

  /*--------------------------
    ScrollUp
  ---------------------------- */
  if (('#scrollUp').length) {
    $.scrollUp({
      scrollText: '<i class="fas fa-angle-up"></i>', easingType: 'linear', scrollSpeed: 900, animation: 'fade'
    });
  }

  /*---------------------
    Video
  ---------------------*/
  $(".cd-popup-trigger").on("click", function (p) {
    p.preventDefault(), $(".cd-popup").addClass("is-visible")
  }), $(".cd-popup").on("click", function (p) {
    ($(p.target).is(".cd-popup-close") || $(p.target).is(".cd-popup")) && (p.preventDefault(), $(this).removeClass("is-visible"))
  });

  /*---------------------
    Feedback carousel
  ---------------------*/
  if ($('.feedback-block').length) {
    var feedbackBxSlider = $('.feedback-block');
    if (feedbackBxSlider.length > 0) {
      feedbackBxSlider.bxSlider({
        auto: true,
        controls: true,
        mode: 'fade',
        pause: 5000,
        speed: 600,
        pager: true,
        pagerCustom: '#feedback-slider-pager'
      });
    }
  }

  /*----------------------------
    Venobox Popup
  ------------------------------ */
  $('.venobox').venobox({
    border: '3px', titleattr: 'data-title', numeratio: true, infinigall: true
  });

  /*---------------------
    Counter
  ---------------------*/
  var timer = $('.timer');
  if (timer.length) {
    timer.appear(function () {
      timer.countTo();
    })
  }

  /*---------------------
    Clients Logo carousel
  ---------------------*/
  var ClientLogo = $('.client-logo-slider');
  ClientLogo.owlCarousel({
    items: 4,
    loop: true,
    nav: false,
    margin: 100,
    dots: false,
    autoplay: true,
    responsive: {
      0: {
        items: 1,
        margin: 0
      }
      , 768: {
        items: 2
      }
      , 992: {
        items: 3
      }
      , 1200: {
        items: 4
      }
    }
  });

  /*---------------------
    Video
  ---------------------*/
  $(".cd-popup-trigger").on("click", function (p) {
    p.preventDefault(), $(".cd-popup").addClass("is-visible")
  }), $(".cd-popup").on("click", function (p) {
    ($(p.target).is(".cd-popup-close") || $(p.target).is(".cd-popup")) && (p.preventDefault(), $(this).removeClass("is-visible"))
  });

  /*---------------------
    WOW
  ---------------------*/
  if ($('.wow').length) {
    var wow = new WOW({
      mobile: false
    });
    wow.init();
  };

  /*---------------------
    icheck
  ---------------------*/
  var inputCheckBox = $('.form-check');

  if (inputCheckBox.length) {
    inputCheckBox.iCheck({
      checkboxClass: 'icheckbox_minimal-blue',
      radioClass: 'iradio_minimal-blue'
    });
  }

  /*---------------------
   Mail Ajax
  ---------------------*/
  if ($('.contact-form').length) {
    var form = $('#ajax-contact');
    var formMessages = $('.form-messages');
    $(form).submit(function (e) {
      e.preventDefault();
      var formData = $(form).serialize();
      $.ajax({
        type: 'POST',
        url: $(form).attr('action'),
        data: formData
      }).done(function (response) {
        $(formMessages).removeClass('error');
        $(formMessages).addClass('success');
        $(formMessages).text(response);
        $(this).find("input").val("");
        $(form).trigger("reset");
      }).fail(function (data) {
        $(formMessages).removeClass('success');
        $(formMessages).addClass('error');
        if (data.responseText !== '') {
          $(formMessages).text(data.responseText);
        } else {
          $(formMessages).text('Oops! An error occured and your message couldn\'t be sent.');
        }
      });
    });
  }


})(jQuery);