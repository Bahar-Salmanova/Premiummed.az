let faqItems = document.querySelectorAll(".faq .item .title");

faqItems.forEach((elem) => {
    elem.addEventListener("click", function () {
        this.parentNode.classList.toggle("show");
    });
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
})
