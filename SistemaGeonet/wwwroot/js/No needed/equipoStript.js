// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});

//MODAL
$('#myModal').on('shown.bs.modal', function () {
    $('#Nombre').trigger('focus')
})


///////////////////////////////////////////////////////////////////
var funcion = 0, idEquipo;
var getCategorias = (id, fun) => {
    var action = 'Equipoes/getCategorias';
    var equipos = new Equipo("", "", "", "", "", "", action);
    equipos.getCategorias(id, fun);
}
var agregarEquipo = () => {
    if (funcion == 0) {
        action = 'Equipoes/agregarEquipos';
    } else {
        action = 'Equipoes/editarEquipos';
    }
    var nombre = document.getElementById("Nombre").value;
    var marca = document.getElementById("Marca").value;
    var modelo = document.getElementById("Modelo").value;
    var numero_serie = document.getElementById("NumeroSerie").value;
    var descripcion = document.getElementById("Descripcion").value;
    var categorias = document.getElementById("CategoriaEquipo");
    var categoria = categorias.options[categorias.selectedIndex].value;
    var equipos = new Equipo(nombre, marca, modelo, numero_serie, descripcion, categoria, action);
    equipos.agregarEquipos(idEquipo, funcion);
    funcion = 0;
}
var editarEquipo = (id, fun) => {
    funcion = fun;
    idEquipo = id;
    var action = 'Equipoes/getEquipos';
    var equipos = new Equipo("", "", "", "", "", "", action);
    equipos.getEquipos(id, fun);
}
var eliminarEquipo = (id) => {
    idEquipo = id;
    var action = 'Equipoes/eliminarEquipos';
    var equipos = new Equipo("", "", "", "", "", "", action);
    equipos.eliminarEquipo(id);
}
$().ready(() => {
    var URLactual = window.location;
    switch (URLactual.pathname) {
        case "/Equipoes":
            getCategorias(0, 0);
            break;
    }
})
var restablecer = () => {
    var equipos = new Equipo("", "", "", "", "", "", "");
    equipos.restablecer();
}
