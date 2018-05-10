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

  $(function() {
      $.currency.configure({
          baseCurreny: "USD",
          rates: {
              "GBP": 0.7454
          }
      });
      $(".convert").click(function() {
          $(".currencies").currency("GBP");
      });
  });

  $('[lang="is"]').hide();
  $("#switch-lang-is").click(function() {
      $('[lang="is"').toggle();
      $('[lang="en"').toggle();
  })

  var buttonclick = 0;
    $("#winner-button").click(function() {
    $.get("GetWinner", function(data, status){
        buttonclick++;

        if(buttonclick > 0) 
        {
            $("#winner-title").text('');
            $("#winner-author").text('');
            $("#winner-rating").text('');
            $("#winner-price").text('');
            $("#winner-format").text('');
        }
            $("#winner-title").append(data.title);
            $("#winner-author").append(data.author);
            $("#winner-rating").append(data.rating);
            $("#winner-price").append(data.price);
            $("#winner-format").append(data.format);
            $("#winner-image").attr("src", data.image);
    });

});


});
