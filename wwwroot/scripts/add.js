$(document).ready(function () {
    //Add section
    $("#addSectionBtn").click(function () {
        let pop = $('.popup-add-section');
        pop.find('.display-6').text("Добавление раздела");
        pop.find('.popup-form').attr('action', '/Home/AddSection');
        showElement(pop);
    });
    $('.popup-add-section-background').click(function (e) {
        if (e.target !== e.currentTarget) return;
        $('.popup-add-section').css('visibility', 'hidden').css('opacity', '0');
        $('#nameSection').val("");
        $('#descriptionSection').val("");
    });
    //Add task
    $(".btn-add-task").click(function () {
        let idParent = $(this).find('.em-hidden').text();
        let popup = $('.popup-add-task');
        popup.find('.display-6').text("Добавление задачи");

        popup.find('.em-hidden').val(idParent);
        popup.find('.popup-form').attr('action', '/Home/AddTask');
        showElement($('.popup-add-task'));
    });
    $('.popup-add-task-background').click(function (e) {
        if (e.target !== e.currentTarget) return;
        hideElement($('.popup-add-task'));
        $('#nameTask').val("");
        $('#descriptionTask').val("");
        $('.input-date').val("");
        $('#performersList').val("");
    });
    //AddSubtask
    $('.btn-add-subtask').click(function () {
        let idParentSubtask = $(this).find('.em-hidden').text();
        let popup = $('.popup-add-subtask');
        popup.find('.display-6').text("Добавление подзадачи");
        popup.find('.em-hidden').val(idParentSubtask);
        popup.attr('action', '/Home/AddSubtask');
        showElement($('.popup-add-subtask'));
    });
    $('.popup-add-subtask-background').click(function (e) {
        if (e.target !== e.currentTarget) return;
        hideElement($('.popup-add-subtask'));
        $('#nameSubtask').val("");
        $('#descriptionSubtask').val("");
        $('.input-date').val("");
        $('#performersList').val("");
    });

    function hideElement(item) {
        item.css('visibility', 'hidden').css('opacity', '0');
    };
    function showElement(item) {
        item.css('visibility', 'visible').css('opacity', '1');
    };

});