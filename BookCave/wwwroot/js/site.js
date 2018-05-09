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
        $("#book-top").attr("asp-action","Top10RatedAudio");
    });

  $("#winner-button").click(function() {
    $.get("GetWinner", function(data, status){
      console.log(data);
      $("#winner-book").append(data.title);
    });
  });

  $("#authorsInput").on("keyup", function() {
    var value = $(this).val().toLowerCase();
    $("#authorsTable tr").filter(function() {
      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
  });

});