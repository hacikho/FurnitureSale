$(document).ready(function () {
    $('.zoom').hover(function () {
        $(this).addClass('transition');
    }, function () {
        $(this).removeClass('transition');
    });
});




$(".thumbnail-img").hover(
    function () {

        $(".big-img").revomeClass("hide");
    }
);

