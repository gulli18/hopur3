// Write your JavaScript code.
$( document ).ready(function() {
    var show = false;
    $("#bottom-nav-books").mouseover(function() {
        if (!show) {
            $("#popup-container").show();
        }
        show = true;
        $("#popup-container h4 a").text("Books");
    });

    $("#popup-container").mouseleave(function() {
        $("#popup-container").hide();
        show = false;
    });

    $("#bottom-nav-audio").mouseover(function() {
        if (!show) {
            $("#popup-container").show();
        }
        $("#popup-container h4 a").text("Audiobooks");
    })

});