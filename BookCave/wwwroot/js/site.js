﻿// Write your JavaScript code.
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
        $("#popup-container #book-top a").attr("href","http://localhost:5000/Book/Top10RatedAudio");
        $("#subject-list #advent").attr("href","http://localhost:5000/book/genreaudio?genre=Adventure");
        $("#subject-list #bio").attr("href","http://localhost:5000/book/genreaudio?genre=Biography");
        $("#subject-list #com").attr("href","http://localhost:5000/book/genreaudio?genre=Comedy");
        $("#subject-list #horr").attr("href","http://localhost:5000/book/genreaudio?genre=Horror");
        $("#subject-list #rom").attr("href","http://localhost:5000/book/genreaudio?genre=Romance");
        $("#subject-list #sci").attr("href","http://localhost:5000/book/genreaudio?genre=Sci-fi");
        $("#subject-list #sport").attr("href","http://localhost:5000/book/genreaudio?genre=Sport");
        $("#subject-list #thril").attr("href","http://localhost:5000/book/genreaudio?genre=Thriller");
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

  if (location.href == "http://localhost:5000/Book/chooseforme") {
    getwinner();
  };
  
  function getwinner() {
    $.get("GetWinner", function(data, status) {
      $("#winner-title").text('');
      $("#winner-author").text('');
      $("#winner-rating").text('');
      $("#winner-price").text('');
      $("#winner-format").text('');

      $("#winner-image").attr("src", data.image);
      $("#winner-title").append(data.title);
      $("#winner-author").append(data.author);
      $("#winner-rating").append(data.rating);
      $("#winner-price").append(data.price);
      $("#winner-format").append(data.format);
    });
  };

  $("#winner-button").click(getwinner);















// Shopping cart functions
var cart = [];

loadCart();
CartIconNumber();
displayCart();

$(".add-to-cart").click(function() {

  var bookId = $(".book-title").attr("title");
  var bookImage = $(".book-image").attr("src");
  var bookTitle = $(".book-title").html();
  var bookAuthor = $(".book-author").html();
  var bookFormat = $(".book-price").attr("title");
  var bookPrice = $(".book-price").html();
  var test = $(".book-title");
  var bookCount = 1;

  var Book = function(id, title, author, format, price, image, count)
{
  this.id = id;
  this.title = title;
  this.author = author;
  this.format = format;
  this.price = price;
  this.image = image;
  this.count = count;
}

  var book = new Book(bookId, bookTitle, bookAuthor, bookFormat, bookPrice, bookImage, bookCount);
  console.log(test);
  console.log(bookId);
  console.log(bookImage);
  console.log(bookTitle);
  console.log(bookAuthor);
  console.log(bookFormat);
  console.log(bookPrice);
  console.log(bookCount);

  console.log(book);
  addToCart(book);
  CartIconNumber();
  console.log(cart);
});

$("#show-cart").on('click', ".delete-item", function() {
  console.log('clicked');
  var removeId = $(this).attr("data-id");
  removeBookFromCartAll(removeId);
  CartIconNumber();
  displayCart();
});

$("#show-cart").on('click', ".plus-item", function() {
  var plusId = $(this).attr("data-id");
  plusCartItem(plusId);
  CartIconNumber();
  displayCart();
})

$("#show-cart").on('click', ".subtract-item", function() {
  var subtractId = $(this).attr("data-id");
  removeBookFromCart(subtractId);
  CartIconNumber();
  displayCart();
})

$("#clear-button").click(function(event) {
  clearCart();
  displayCart();
})

function addToCart(book) {
  for(var i in cart) {
    if(cart[i].id === book.id) {
      cart[i].count ++;
      saveCart();
      return;
    }
  }
  cart.push(book);
  saveCart();
}
function plusCartItem(id) {
  for(var i in cart) {
    if(cart[i].id === id) {
      cart[i].count++;
      saveCart();
      return;
    }
  }
}

function removeBookFromCart(id) {
  for(var i in cart) {
    if(cart[i].id === id) {
      cart[i].count--;
      if(cart[i].count == 0) {
        cart.splice(i, 1);
      }
      break;
    }
  }
  saveCart();
}

function removeBookFromCartAll(id) {
  for(var i in cart) {
    if(cart[i].id === id) {
      cart.splice(i, 1);
      break;
    }
  }
  saveCart();
}

function clearCart() {
  cart = [];
  saveCart();
  CartIconNumber();
}

function countCart() {
  var totalCount = 0;
  for(var i in cart) {
    totalCount += cart[i].count;
  }
  return totalCount;
}

function cartTotalCost() {
  var totalCost = 0;
  for(var i in cart) {
    totalCost += cart[i].price * cart[i].count;
  }
  return totalCost.toFixed(2);
}

function listCart() {
  var cartCopy = [];
  for(var i in cart) {
    var item = cart[i];
    var itemCopy = {};
    for(var p in item) {
      itemCopy[p] = item[p];
    }
    itemCopy.total = (item.price * item.count).toFixed(2);
    cartCopy.push(itemCopy);
  }
  return cartCopy;
}

function saveCart() {
  localStorage.setItem('ShoppingCart', JSON.stringify(cart));
}

function loadCart() {
  cart = JSON.parse(localStorage.getItem('ShoppingCart'));
  if(cart == null) {
    cart = [];
  }
}

//code for Cart/Index

/*$("#display").click(function(event) {
  event.preventDefault();
  displayCart();
});*/

function displayCart() {
  var cartArray = listCart();

  if(countCart() === 0) {
    $("#cart-header").html("Shopping cart is empty!");
    $("#clear-button").toggle();
    $("#checkout").toggle();
  }
  else {
    $("#cart-header").html("Shopping cart:");
  }

  var output = "";
  
  for(var i in cartArray) {
    output += "<div>" + "<img src='" + cartArray[i].image + "' alt='book-cover'>" + 
              "<p>" + cartArray[i].title + "</p>" + 
              "<p>" + cartArray[i].author + "</p>" +
              "<p>" + cartArray[i].format + "</p>" +
              "<p>" + cartArray[i].price + "</p>" +
              "<p>" + cartArray[i].count + "</p>" + 
              "<div>" + 
              "<button type='button' class='plus-item btn btn-success' data-id='" + cartArray[i].id + 
              "'>+</button>" +
              "<button type='button' class='subtract-item btn btn-danger' data-id='" + cartArray[i].id + 
              "'>-</button>" +
              "<button type='button' class='delete-item btn btn-danger' data-id='" + cartArray[i].id + 
              "'>Remove</button>" + "</div>" + "</div>";
  }
  $("#show-cart").html(output);
}

//glyphicon shopping cart icon

function CartIconNumber () {
  $("#number-of-cartitems").html(countCart());
};

});