function OnSuccess() {
    if ($("#viewResults").length) {
        $("#saveLink").show()
    }
    else {
        $("#saveLink").hide()
    }
}

$(function () {
    $.ajaxSetup({ cache: false });
    $(".saveData").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
})