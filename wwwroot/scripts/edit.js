//edit
$(document).ready(function () {
    //edit Section
    $('.btn-edit-section').click(function () {
        let pop = $('.popup-add-section');
        pop.find('.display-6').text("Редактирование раздела");
        let idSection = $(this).find('.em-hidden').first().text();
        let spanSection = $(this).closest('.three-dot-div').siblings('.span-section')

        pop.find('.popup-form').first().append(`<input class="em-hidden" name="idSection" value="${idSection}"/>`);
        pop.find('.popup-form').attr('action', '/Home/EditSection');

        showElement(pop);
        let title = spanSection.first().clone().children().remove().end().text().trim();

        let description = spanSection.first().find('.em-description').clone().children().remove().end().text().trim();
        console.log(title);

        pop.find('#nameSection').val(title);
        pop.find('#descriptionSection').val(description);

    });
    //edit task
    $('.btn-edit-task').click(function () {
        let pop = $('.popup-add-task');
        let idTask = $(this).find('.em-hidden').first().text();

        pop.find('.popup-form').first().append(`<input class="em-hidden" name="idTask" value="${idTask}"/>`);
        pop.find('.popup-form').attr('action', '/Home/EditTask');

        let spanTask = $(this).closest('.three-dot-div').siblings('.span-task');

        let title = spanTask.first().clone().children().remove().end().text().trim();
        let status = spanTask.find('.em-status-id').text();
        let description = spanTask.first().find('.em-description').clone().children().remove().end().text().trim();
        let date = getDate(spanTask.find('.em-date-exec').text().split(' '));
        let performers = spanTask.find('.em-performers-list').text();

        pop.find('.display-6').text("Редактирование раздела");

        pop.find('#nameTask').val(title);
        pop.find('#descriptionTask').val(description);
        pop.find(`select [value="${status}"]`).attr('selected', 'true');
        pop.find('.input-date').val(date);
        pop.find('#performersList').val(performers);

        showElement(pop);
    });
    //edit subtask
    $('.btn-edit-subtask').click(function () {
        let pop = $('.popup-add-subtask');
        let idSubtask = $(this).find('.em-hidden').first().text();

        pop.find('.popup-form').first().append(`<input class="em-hidden" name="idSubtask" value="${idSubtask}"/>`);
        pop.find('.popup-form').attr('action', '/Home/EditSubtask');

        let spanSubtask = $(this).closest('.three-dot-div').siblings('.span-subtask');

        let title = spanSubtask.first().clone().children().remove().end().text().trim();
        let status = spanSubtask.find('.em-status-id').text();
        let description = spanSubtask.first().find('.em-description').clone().children().remove().end().text().trim();
        let date = getDate(spanSubtask.find('.em-date-exec').text().split(' '));


        pop.find('.display-6').text("Редактирование подзадачи");

        pop.find('#nameSubtask').val(title);
        pop.find('#descriptionSubtask').val(description);
        pop.find(`select [value="${status}"]`).attr('selected', 'true');
        pop.find('.input-date').val(date);

        showElement(pop);
    });

    function getDate(dateAndTime) {
        let date = dateAndTime[0].split('.');
        let time = dateAndTime[1].split(':');
        return `${date[2]}-${nowMonth()}${date[1] - 1}-${date[0]}T${time[0]}:${time[1]}`;
    }

    function nowMonth() {
        const date = new Date();
        return date.getMonth() > 9 ? null : "0";
    };

    function hideElement(item) {
        item.css('visibility', 'hidden').css('opacity', '0');
    };
    function showElement(item) {
        item.css('visibility', 'visible').css('opacity', '1');
    };

    function convertDate(date) {
        return Date.parse(date);
    }
});