function createOrden(IdCarrito) {
    var IdCarritoOrden;
    var IdUsuario = 0;
    var precioTotal = 0;
    var estado = 1;

    $.ajax({
        type: 'POST',
        url: "/CarritoOrdens/CrearCarritoOrden",
        data: {
            IdUsuario,
            precioTotal,
            estado,
        },
        success: function (response) {
            console.log(response);
            IdCarritoOrden = response;
            $.ajax({
                type: 'POST',
                url: "/DetallePedido/EditarCarrito",
                data: {
                    IdCarrito,
                    IdCarritoOrden
                },
                success: function (response) {
                    console.log(response);
                    window.location.replace("../OrdenPedido/Create?id=" + IdCarritoOrden);
                },
            });
        },
    });
}