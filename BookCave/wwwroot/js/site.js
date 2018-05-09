// Write your JavaScript code.

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
