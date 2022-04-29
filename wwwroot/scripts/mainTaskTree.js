
$(document).ready(function () {
    $('.item-attributes').addClass('hidden-item');

    $('.span-section, .span-task, .span-subtask').click(function () {
        let descr = $(this).find('.em-description').text();
        setText(this.innerText, descr);
        if ($(this).hasClass('span-task') || $(this).hasClass('span-subtask')) {

            $('.item-attributes').removeClass('hidden-item');

            let dateReg = $(this).find('.em-date-register').text();
            $('.attr-date-register').find('.item-attr-value').text(dateReg);

            let status = $(this).find('.em-status').text();
            let statusId = $(this).find('.em-status-id').text();
            let attrValue = $('.attr-status').find('.item-attr-value').text(status);

            if (statusId == "2") {
                $(attrValue).css('color', '#52affe');
            }
            else if (statusId == "3") {
                $(attrValue).css('color', 'orange');
            }
            else if (statusId == "4") {
                $(attrValue).css('color', 'green');
            }
            else {
                $(attrValue).css('color', 'black');
            }

            let labor = $(this).find('.em-labor').text();
            $('.attr-labor').find('.item-attr-value').text(labor);

            let dateExec = $(this).find('.em-date-exec').text();
            $('.attr-date-execution').find('.item-attr-value').text(dateExec);

            let actualDate = $(this).find('.em-actual-date').text();
            $('.attr-actual-date').find('.item-attr-value').text(actualDate);

            let actualDateExec = $(this).find('.em-actual-time-exec').text();
            $('.attr-actual-date-execution').find('.item-attr-value').text(actualDateExec);

            if ($(this).hasClass('span-subtask')) {
                hide($('.attr-performers-list'));
            } else {
                let performersList = $(this).find('.em-performers-list').text();
                $('.attr-performers-list').removeClass('hidden-item');
                $('.attr-performers-list').find('.item-attr-value').text(performersList);
            }

        }
        else if ($(this).hasClass('span-section')) {
            hide($('.item-attributes'));

        }
    });

    function setText(title, description) {
        $('#mainTitle').text(title);
        $('#mainDescription').text(description);
    }

    function hide(item) {
        $(item).addClass('hidden-item');
    }
});