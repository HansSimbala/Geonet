
$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});

//MODAL
$('#myModal').on('shown.bs.modal', function () {
    $('#Nombre').trigger('focus')
})

//ACTUALIZAR EQUIPO EN MODAL
var items;
var nombre;
var contacto;
var pais;
var direccion;
var id;
var funct;
var message;
var action;
//OBTIENE DATOS DEL MODAL
var getDataAjax = (id) => {
    $("#message").text("");
    action = "Proveedors/EditAjax";
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: (response) => {
            console.log(response);
            OnSuccess(response);
        }
    });
}

var OnSuccess = (response) => {
    items = response;
    action = "Proveedors/EditProveedorAjax";
    funct = "edit";
    $.each(items, (index, val) => {
        $("input[name=idProveedor]").val(val.idProveedor);
        $("input[name=nombre]").val(val.nombre);
        $("input[name=contacto]").val(val.contacto);
        $("input[name=pais]").val(val.pais);
        $("input[name=direccion]").val(val.direccion);
    });


    /*For Detail modal*/
    $.each(items, (index, val) => {
        $("#nameDetail").text("Detalles del Proveedor " + val.idProveedor);
        $("#nombreProveedor").text("Nombre: " + val.nombre);
        $("#contactoProveedor").text("Contacto: " + val.contacto);
        $("#paisProveedor").text("Dirección: " + val.pais);
        $("#direccionProveedor").text("País: " + val.direccion);
    });
    //For Delete Modal
    $.each(items, (index, val) => {
        $("#nomProveedor").text("Está por eliminar el proveedor (" + val.idProveedor + ") " + val.nombre + ".");
        $("#nomProveedor1").text("¿Desea continuar?");
        $("input[name=idProveedor]").val(val.idProveedor);
    });
}
//SETEA MODAL
var setDataProveedor = () => {
    action = "Proveedors/EditProveedorAjax";
    id = $('input[name=idProveedor]')[0].value;
    nombre = $('input[name=nombre]')[0].value;
    contacto = $("input[name=contacto]")[0].value;
    pais = $("input[name=pais]")[0].value;
    direccion = $("input[name=direccion]")[0].value;

    $.ajax({
            type: "POST",
            url: action,
            data: { id, nombre, contacto, pais, direccion, funct },
            success: (response) => {
                if (message = "Guardar") {
                    window.location.href = "https://localhost:44301/Proveedors";
                }}
        });
    
}
//DELETE MODAL
function deleteProveedor(action) {
    var id = $('input[name=idProveedor]')[0].value;
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            if (response = "Si") {
                window.location.href = "https://localhost:44301/Proveedors";
            }
        }
    });
}

//INSERT
var inputClean = () => {
    funct = "add";
    $("#message").text("");
    $("input[name=nombre]").val("");
    $("input[name=contacto]").val("");
    $("input[name=pais]").val("");
    $("input[name=direccion]").val("");
    $("#Nombre").focus();
}
