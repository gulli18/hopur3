// Write your JavaScript code.
$( document ).ready(function() {

    $("#bottom-nav-books").mouseover(function() {
        $("#popup-container").toggle();
        $("#popup-container h4 a").text("Books");
    });

    $("#popup-container").mouseleave(function() {
        $("#popup-container").toggle();
    });

    $("#bottom-nav-audio").mouseover(function() {
        $("#popup-container").toggle();
        $("#popup-container h4 a").text("Audiobooks");
    })

});