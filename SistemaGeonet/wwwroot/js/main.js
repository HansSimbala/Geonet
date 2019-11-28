
function myFunction() {
    localStorage.removeItem('IncrementoCarrito');
    cart = $('.nav-link');
    var cartItems = cart.find('span');
    console.log("ppp");
    console.log(cartItems);
    text = parseInt(cartItems.text()) + 1;
    cartItems.text(text);
    localStorage.setItem("IncrementoCarrito", JSON.stringify(text));
    
} 


function FuntionDecreciente() {
    cart = $('.nav-link');
    var cartItems = cart.find('span');
    console.log("ppp");
    console.log(cartItems);
    text = parseInt(cartItems.text()) - 1;
    cartItems.text(text);
    localStorage.setItem("IncrementoCarrito", JSON.stringify(text));
}
function FuntionPago() {
    cart = $('.nav-link');
    var cartItems = cart.find('span');
    cartItems.text("");
}
function FuntionOrden() {
    cart = $('.nav-link');
    var cartItems = cart.find('span');
    localStorage.removeItem("IncrementoCarrito");
    cartItems.text(localStorage.removeItem("IncrementoCarrito"));//limpiar storage

}

if (localStorage.getItem("IncrementoCarrito") != 0 && localStorage.getItem("IncrementoCarrito") !== "undefined" && localStorage.getItem("IncrementoCarrito") !== undefined
    && localStorage.getItem("IncrementoCarrito") !== null && localStorage.getItem("IncrementoCarrito") !== NaN && !isNaN(localStorage.getItem("IncrementoCarrito"))) {
    cart = $('.nav-link');
    var cartItems = cart.find('span');
    console.log(cartItems);
    cartItems.text(localStorage.getItem("IncrementoCarrito"));
} 

if (typeof (Storage) !== "undefined") {
    // LocalStorage disponible
    console.log("bien");
} else {
    console.log("mal");
}
