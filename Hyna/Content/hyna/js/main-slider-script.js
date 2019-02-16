var tpj=jQuery;
var revapi486;
tpj(document).ready(function() {
  if(tpj("#rev_slider_one").revolution==undefined) {
    revslider_showDoubleJqueryError("#rev_slider_one");
  }
  else {
    revapi486=tpj("#rev_slider_one").show().revolution( {
      sliderType:"standard", jsFileLocation:"plugins/revolution/js/", sliderLayout:"fullwidth", dottedOverlay:"none", delay:9000, navigation: { 
        onHoverStop:"off",
      }
      , responsiveLevels:[1170, 992, 767, 540], 
        visibilityLevels:[1170, 960, 767, 540], 
        gridwidth:[1170, 960, 767, 540], 
        gridheight:[1033, 810, 810, 800], 
        lazyType:"none", 
        parallax: {
        type: 'mouse', origo: 'enterpoint', speed: 400, speedbg:0,
				speedls:0, levels: [5, 10, 15, 20, 25, 30, 35, 40, 45, 46, 47, 48, 49, 50, 51, 55], disable_onmobile: 'on'
      }, 
      shadow:0, 
      spinner:"ospinner0n", 
      stopLoop:"off", 
      stopAfterLoops:-1, 
      stopAtSlide:-1, 
      shuffle:"off", 
      autoHeight:"off", 
      hideThumbsOnMobile:"off", 
      hideSliderAtLimit:0, 
      hideCaptionAtLimit:0, 
      hideAllCaptionAtLilmit:0, 
      debugMode:false, 
      fallbacks: {
        simplifyAll: "off", 
        nextSlideOnWindowFocus: "off", 
        disableFocusListener: false,
      }
    }
    );
  }
}
);

/*ready*/