$("#anima").click(function() {
    if ($("#firstCol").css('width') > '10%') {
        $("#firstCol").css('width', '10%')
    }
    else {
        $("#firstCol").css('width', '20%')
    }
});