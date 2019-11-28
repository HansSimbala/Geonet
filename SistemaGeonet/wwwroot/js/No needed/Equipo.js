var promesa = new Promise((resolve, reject) => {

});
class Equipo {
    constructor(nombre, marca, modelo, numero_serie, descripcion, categoria, action) {
        this.nombre = nombre;
        this.marca = marca;
        this.modelo = modelo;
        this.numero_serie = numero_serie;
        this.descripcion = descripcion;
        this.categoria = categoria;
        this.action = action;
    }
    getCategorias(id, funcion) {
        var action = this.action;
        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: {},
            success: (response) => {
                document.getElementById('CategoriaEquipo').options[0] = new Option("Seleccionar una categoria", 0);
                if (0 < response.length) {
                    for (var i = 0; i < response.length; i++) {
                        if (funcion == 0) {
                            document.getElementById('CategoriaEquipo').options[count] = new Option(response[i].nombre, response[i].idCategoria);
                            count++;
                        } else {
                            if (id == response[i].idCategoria) {
                                document.getElementById('CategoriaEquipo').options[0] = new Option(response[i].nombre, response[i].idCategoria);
                                document.getElementById('CategoriaEquipo').selectedIndex = 0;
                                break;
                            }
                        }
                        
                    }
                }
            }
        });
    }

    agregarEquipos(id, funcion) {
        if (this.categoria == "0") {
            document.getElementById("mensaje").innerHTML = "Seleccione una categoria";
        } else {
            var nombre = this.nombre;
            var marca = this.marca;
            var modelo = this.modelo;
            var numero_serie = this.numero_serie;
            var descripcion = this.descripcion;
            var categoria = this.categoria;
            var action = this.action;
            $.ajax({
                type: "POST",
                url: action,
                data: { id, nombre, marca, modelo, numero_serie, descripcion, categoria, funcion },
                success: (response) => {
                    if ("Guardar" == response[0].code) {
                        this.restablecer();
                    } else {
                        document.getElementById("mensaje").innerHTML = "Equipo no se puede guardar";
                    }
                }
            });
        }
    }
    editarCurso(id, funcion) {
        var nombre, marca, modelo, descripcion, numero_serie, descripcion, categoria;
        var action = this.action;
        promesa.then(data => {
            nombre = data.nombre;
            marca = data.marca;
            modelo = data.modelo;
            numero_serie = data.numero_serie;
            descripcion = data.descripcion;
            categoria = data.categoria;
            $.ajax({
                type: 'POST',
                url: action,
                data: { id, nombre, marca, modelo, numero_serie, descripcion, categoria, funcion  },
                success: (response) => {
                    if (response[0].code == "Save") {
                        this.restablecer();
                    }
                }
            });
        })
    }
    getEquipos(id, funcion) {
        var action = this.action;
        $.ajax({
            type: 'POST',
            url: action,
            data: { id },
            success: (response) => {
                document.getElementById("Nombre").value = response[0].nombre;
                document.getElementById("Marca").value = response[0].marca;
                document.getElementById("Modelo").value = response[0].modelo;
                document.getElementById("NumeroSerie").value = response[0].numero_serie;
                document.getElementById("Descripcion").value = response[0].descripcion;
                getCategorias(response[0].idCategoria, 1);
            }
        });
    }
    restablecer() {
        document.getElementById("Nombre").value = "";
        document.getElementById("Marca").value = "";
        document.getElementById("Modelo").value = "";
        document.getElementById("NumeroSerie").value = "";
        document.getElementById("Descripcion").value = "";
        document.getElementById("mensaje").innerHTML = "";
        document.getElementById("CategoriaEquipo").selectedIndex = 0;
        $('#myModal').modal('hide');
        window.location.href = "https://localhost:44301/Equipoes";
    }
    clean() {
        document.getElementById("Nombre").value = "";
        document.getElementById("Marca").value = "";
        document.getElementById("Modelo").value = "";
        document.getElementById("NumeroSerie").value = "";
        document.getElementById("Descripcion").value = "";
        document.getElementById("mensaje").innerHTML = "";
        document.getElementById("CategoriaEquipo").selectedIndex = 0;
        $('#myModal').modal('hide');
    }
    GetEquipo(equipo) {
        document.getElementById("").value = "";
    }
}





            //if (this.nombre = "") {
            //    document.getElementById("Nombre").focus();
            //} else {
            //    if (this.marca = "") {
            //        document.getElementById("Marca").focus();
            //    } else {
            //        if (this.modelo = "") {
            //            document.getElementById("Modelo").focus();
            //        } else {
            //            if (this.numero_serie = "") {
            //                document.getElementById("NumeroSerie").focus();
            //            } else {
            //                if (this.descripcion = "") {
            //                    document.getElementById("Descripcion").focus();
            //                } else {
            //                    if (this.categoria == "0") {
            //                        document.getElementById("mensaje").innerHTML = "Seleccione una categoria";
            //                    } else {
            //                        var nombre = this.nombre;
            //                        var marca = this.marca;
            //                        var modelo = this.modelo;
            //                        var numero_serie = this.numero_serie;
            //                        var descripcion = this.descripcion;
            //                        var categoria = this.categoria;
            //                        var action = this.action;
            //                        console.log(nombre);
            //                        $.ajax({
            //                            type: "POST",
            //                            url: action,
            //                            data: { id, nombre, marca, modelo, numero_serie, descripcion, categoria, funcion },
            //                            success: (response) => {
            //                                if ("Guardar" == response[0].code) {
            //                                    this.restablecer();
            //                                } else {
            //                                    document.getElementById("mensaje").innerHTML = "Equipo no se puede guardar";
            //                                }
            //                            }
            //                        });
            //                    }
            //                }
            //            }
            //        }
            //    }
