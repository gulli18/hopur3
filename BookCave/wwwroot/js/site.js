﻿// Write your JavaScript code.

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








































































//shopping cart functions

var cart = [];
loadCart();
CartIconNumber();
displayCart();

$(".add-to-cart").click(function() {

  var bookProperties = $(this).siblings();
  var bookImage = $(this).siblings().first().attr("src");
  var bookTitle = bookProperties[1].innerHTML;
  var bookAuthor = bookProperties[2].innerHTML;
  var bookRating = bookProperties[3].innerHTML;
  var bookFormat = $(this).siblings().first().next().attr("title");
  var bookPrice = bookProperties[4].innerHTML;
  var bookId = $(this).prev().attr("title");
  var bookCount = 1;

  var Book = function(id, title, author, rating, format, price, image, count)
  {
    this.id = id;
    this.title = title;
    this.author = author;
    this.rating = rating;
    this.format = format;
    this.price = price;
    this.image = image;
    this.count = count;
  }

  var book = new Book(bookId, bookTitle, bookAuthor, bookRating, bookFormat, bookPrice, bookImage, bookCount);

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

function removeBookFromCart(book) {
  for(var i in cart) {
    if(cart[i].id === book.id) {
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
 //   itemCopy.total = item.price;
 //   itemCopy.total = (item.price * item.count).toFixed(2);
    cartCopy.push(itemCopy);
  }
  return cartCopy;
}

function saveCart() {
  localStorage.setItem('ShoppingCart', JSON.stringify(cart));
}

function loadCart() {
  cart = JSON.parse(localStorage.getItem('ShoppingCart'));
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
  }
  else {
    $("#cart-header").html("Shopping cart:");
  }

  var output = "";
  
  for(var i in cartArray) {
    output += "<div>" + "<img src='" + cartArray[i].image + "' alt='book-cover'>" + 
              "<p>" + cartArray[i].title + "</p>" + 
              "<p>" + cartArray[i].author + "</p>" +
              "<p>" + cartArray[i].rating + "</p>" +
              "<p>" + cartArray[i].format + "</p>" +
              "<p>" + cartArray[i].price + "</p>" +
              "<p>" + cartArray[i].count + "</p>" + 
              "<div>" + 
              "<button type='button' class='delete-item btn btn-danger' data-id='" + cartArray[i].id + 
              "'>Remove</button>" + "</div>" + "</div>";
  }
  $("#show-cart").html(output);
}

//glyphicon shopping cart icon

function CartIconNumber () {
  console.log('clicked');
  $("#number-of-cartitems").html(countCart());
};
