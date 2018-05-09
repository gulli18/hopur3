// Write your JavaScript code.

$("#winner-button").click(function() {
  $.get("GetWinner", function(data, status){
    console.log(data);
    $("#winner-book").append(data.title);
  });
});