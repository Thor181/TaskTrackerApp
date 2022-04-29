$(document).ready(function () {
    $('#addSectionBtn__popup, #addTaskBtn__popup, #addSubtaskBtn__popup').click(function () {
        if ($(this).is($('#addSectionBtn__popup'))) {
            aValidate($("#nameSection"));
        }
        else if ($(this).is($('#addTaskBtn__popup'))) {
            aValidate($("#nameTask, #input-dueDate__popup"));
        }
        else {
            aValidate($("#nameSubtask, #input-dueDate-subtask__popup"));
        }
    });
    function aValidate(input) {
        if (input.val() == null || input.val().trim() === '') {
            $(input).addClass('input-validate').delay(1000).queue(function (next) {
                $(this).removeClass('input-validate');
                next();
            });
        }
        else {
            input.removeClass('input-validate');
        };
    };
    $('#nameSection, #nameTask, #nameSubtask').keypress(function () {
        $(this).removeClass('input-validate');
    });
});