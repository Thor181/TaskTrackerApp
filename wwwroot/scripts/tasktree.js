$(document).ready(function () {
    $(".li-section > ul").slideToggle(1);

    $("#taskTree ul li:has('ul')").find('span:first').prepend('<em class="marker"></em>');

    $('#taskTree ul li span').click(function () {
        $("span.current").removeClass('current');
        var span = $('span:first', this.parentNode);

        span.toggleClass('current');
        var li = $(this.parentNode);
        if (!li.next().length) {
            li.find("ul:first > li").addClass('last');
        }
        var ul = $("ul", this.parentNode);
        if (ul.length) {

            ul.slideToggle(300);
            var em = $("em:first", this.parentNode);
            em.toggleClass('open');
        }
    });
});