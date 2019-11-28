function getPago() {
    var idMetodoPago = document.getElementById("IdMetodoPago").value;
    var tarjeta = document.getElementById("Tarjeta");
    var voucher = document.getElementById("Voucher");
    if (idMetodoPago == 1) {
        tarjeta.style.display = 'block';
        voucher.style.display = 'none';
    } else {
        tarjeta.style.display = 'none';
        voucher.style.display = 'block';
    }
}

function ordenarPedido() {

    var url_string = window.location.href;
    var url = new URL(url_string);
    var id = url.searchParams.get("id");
    console.log(id);
    var IdCarritoOrden = id;
    var IdPago = 0;
    var fechapedido = document.getElementById("IdFechaEnvio").value;
    var direccion = document.getElementById("IdDireccion").value;;
    var telefono = document.getElementById("IdTelefono").value;;
    var email = document.getElementById("IdCorreo").value;;
    var IdMetodoPago = document.getElementById("IdMetodoPago").value;
    console.log("metodo"+IdMetodoPago);

    if (IdMetodoPago == 1) {
        var numeroTarjeta = document.getElementById("cardnumber").value;
        var cvv = document.getElementById("securitycode").value;
        var FechaVencimiento = document.getElementById("expirationdate").value;
        $.ajax({
            type: 'POST',
            url: "/Tarjetas/Agregar",
            data: {
                numeroTarjeta,
                cvv,
                FechaVencimiento
            },
            success: function (response) {
                IdPago = response;
                $.ajax({
                    type: 'POST',
                    url: "/OrdenPedidoes/Agregar",
                    data: {
                        IdCarritoOrden,
                        fechapedido,
                        direccion,
                        telefono,
                        email,
                        IdMetodoPago,
                        IdPago
                    },
                    success: function (response) {
                        Swal.fire(
                            'Pago Realizado',
                            'Transacción exitosa',
                            'success'
                        ).then((result) => {
                            if (result.value) {
                                window.location.replace("../OrdenPedidoes/Index");
                            }
                        })
                        console.log(response);
                    },
                });
            },
        });
    }
    else if (IdMetodoPago == 2) {
        var foto = document.getElementById("idFoto").value;
        console.log(foto);

        $.ajax({
            type: 'POST',
            url: "/Vouchers/Agregar",
            data: {
                foto
            },
            success: function (response) {
                IdPago = response;
                $.ajax({
                    type: 'POST',
                    url: "/OrdenPedidoes/Agregar",
                    data: {
                        IdCarritoOrden,
                        fechapedido,
                        direccion,
                        telefono,
                        email,
                        IdMetodoPago,
                        IdPago
                    },
                    success: function (response) {
                        Swal.fire(
                            'Solicitud enviada',
                            'Validar la transacción con el proveedor.',
                            'success'
                        ).then((result) => {
                            if (result.value) {
                                window.location.replace("../OrdenPedidoes/Index");
                            }
                        })
                        console.log(response);
                    },
                });
            },
        });
    } else {
        document.getElementById("message").innerHTML = "Seleccionar un método de pago.";
        document.getElementById("message").style.color = "#ff0000";
        return;
    }
}