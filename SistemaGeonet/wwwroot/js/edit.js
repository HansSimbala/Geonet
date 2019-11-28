function editQuantity(IdDetalleCarrito) {
    var cantidad = document.getElementById(IdDetalleCarrito).value;
    $.ajax({
        type: 'POST',
        url: "/DetalleCarritoes/Editar",
        data: {
            IdDetalleCarrito,
            cantidad
        },
        success: function (response) {
            console.log(response);
        },
    });
}