function refreshHistory() {
    $.ajax({
        url: "/Home/ShowHistoryTable?terminalId=" + $("input[name=terminalId]").val(),
        dataType: "html",
        type: "GET",
        success: function (data) {
            $("#history").html(data);
        }
    });
}

function sendAjaxForm(form, url) {
    $.ajax({
        url: url,
        type: "GET",
        dataType: "html",
        data: $("#" + form).serialize()
    });
}

$(document).ready(function () {
    refreshHistory();
});

$(".dropdownOption").click(function () {
    $("#dropdownMenuButton1").text($(this).children().text())
});

$("#submit").click(function () {
    setTimeout(() => {
        refreshHistory();
    }, 100);
    sendAjaxForm('mainForm', '/Home/Index/');

    $("#dropdownMenuButton1").text("Выберите действие...");
    $("#params").html("");
    return false;
});

$("input[name='terminalId']").on("keyup change", function () {
    refreshHistory();
});