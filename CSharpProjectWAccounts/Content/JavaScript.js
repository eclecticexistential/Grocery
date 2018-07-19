$(document).ready(function () {
    $("#meat").hide();
    $("#veges").hide();
    $("#other").hide();
    $(".check_meat").click(function () {
        if ($(this).is(":checked")) {
            $("#meat").show();
        }
        else {
            $("#meat").hide();
        }
    });
    $(".check_veges").click(function () {
        if ($(this).is(":checked")) {
            $("#veges").show();
        }
        else {
            $("#veges").hide();
        }
    });
    $(".check_other").click(function () {
        if ($(this).is(":checked")) {
            $("#other").show();
        }
        else {
            $("#other").hide();
        }
    });
});