// Write your JavaScript code.
$(document).ready(function(){

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