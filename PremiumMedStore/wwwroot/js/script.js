$('#client-section .slidere-clients').owlCarousel({
    items: 1,
    loop: true,
   autoplay:true,
    nav:true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 3
        },
        1000: {
            items: 9
        }
    }
  });
$('#product-image .karuselerow').owlCarousel({
    items: 1,
    loop: true,
   autoplay:true,
   autoplayTimeout:9000,
    autoplayHoverPause:true,
    nav:true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 3
        },
        1000: {
            items: 1
        }
    }
  });
$('#galery .karusele-row').owlCarousel({
  items: 1,
  loop: true,
  nav:true,
  responsive: {
      0: {
          items: 1
      },
      600: {
          items: 3
      },
      1000: {
          items: 5
      }
  }
});

// Example starter JavaScript for disabling form submissions if there are invalid fields
(function () {
    'use strict'
  
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation')
  
    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
      .forEach(function (form) {
        form.addEventListener('submit', function (event) {
          if (!form.checkValidity()) {
            event.preventDefault()
            event.stopPropagation()
          }
  
          form.classList.add('was-validated')
        }, false)
      })
  })();
$(' #news2-section2 .karusel').owlCarousel({
   center:true,
    items: 3,
    loop: true,
    autoplay:true,
    margin:20,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 1
        },
        1000: {
            items: 3
        }
    }
  });
$('.owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    items:4,
    nav:true,
    dots:false,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:3
        },
        1000:{
            items:5
        }
    }
});

$("#career1 .panel-title a").click(function(){  
    $("#career1 .panel-title a").removeClass("active");
    $(this).addClass("active");     
});


