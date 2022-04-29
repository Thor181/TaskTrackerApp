$(document).ready(function () {
    //show three-dot popup
    $(".three-dot-div").click(function () {
        if (!$(this).hasClass('popupIsExist')) {
            $('.popUp-view').css('opacity', '0').css('visibility', 'hidden');
            $('.three-dot-div.popupIsExist').removeClass('popupIsExist');
            $(this).addClass('popupIsExist');
            $(this).find('.popUp-view').css('opacity', '1').css('visibility', 'visible');
        }
        else {
            $('.popUp-view').css('opacity', '0').css('visibility', 'hidden');
            $(this).removeClass('popupIsExist');
        }
    });
    //close three-dot popup
    $('*').click(function (e) {
        if (e.target !== e.currentTarget) return;
        if ($('.popupIsExist').length) {
            $('.popUp-view').css('opacity', '0').css('visibility', 'hidden');
            $('*').removeClass('popupIsExist');
        }
    });
});