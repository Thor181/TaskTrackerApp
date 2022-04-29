$(document).ready(function () {
    $('.em-status-id').each(function () {
        if ($(this).text() == "4") {
            $(this).parent().css('text-decoration', 'line-through');
        }
    });
});