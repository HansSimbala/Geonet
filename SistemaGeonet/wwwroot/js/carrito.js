var list = [];
var listDetail = [];
var IdEquipo = "";
var cantidad = "";



function agregarCarritoLS(idEquipo) {
    //const detalleCarrito = Object.create(detalle);
    //detalleCarrito.id = idEquipo;
    //detalleCarrito.cantidad = 3;
    var detalle = {
        id: 'cashier',
        cantidad: 0
    };
    detalle.id = idEquipo;
    detalle.cantidad = 4;
    console.log(detalle);
    //list.push(detalleCarrito);
    //console.log("lista", JSON.stringify(detalle));
    localStorage.setItem('Equipo', JSON.stringify(detalle));
    console.log("lista", JSON.stringify(detalle));

    var value = JSON.parse(localStorage.getItem('Equipo'));

    console.log("local get va " + value);
}

//const detalleCarrito = Object.create(detalle);
//detalleCarrito.id = idEquipo;
//detalleCarrito.cantidad = 3;
//console.log("detalle" + detalleCarrito);
////list.push(JSON.stringify(detalleCarrito));
//// console.log("lista", list);
//localStorage.setItem("Equipo", JSON.stringify(detalleCarrito));

//console.log("local get va" + JSON.parse(localStorage.getItem(("Equipo"))));