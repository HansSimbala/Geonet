function agregarCarrito(IdEquipo, cantidad) {
    var hasOrden = 0;
    var IdCarrito = 1;
    var cantidad = document.getElementById(cantidad).value;
    $.ajax({
        type: 'POST',
        url: "/DetallePedido/Agregar",
        data: {
            hasOrden,
            IdCarrito,
            IdEquipo,
            cantidad
        },
        success: function (response) {
            console.log(response);
        },
    });
}