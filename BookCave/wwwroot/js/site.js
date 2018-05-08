// Write your JavaScript code.

$("#winner-button").click(function() {
  $.get("Book/GetWinner", function(data, status){
    setTimeout(function(){
      $("#winner-book").append(data);
    }, 5000);
  });
});