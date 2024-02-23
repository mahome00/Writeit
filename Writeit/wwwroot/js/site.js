// Funktionen döljer/visar sammanfattningen
function doljaVisa { 
$(document).ready(function () {
    $("#samman-knapp").click(function () {
        $(".sammanfattning-text").slideToggle();
    });
});
}

