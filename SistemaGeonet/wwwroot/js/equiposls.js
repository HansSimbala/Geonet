(function () {
    // Obtiene el id de la tabla para posteriormente agregarle los equipos del Local Storage
    const html = document.getElementById('IdOrden');
    // Obtienen los equipos agregados al carrito del local storage
    console.log(localStorage.getItem("Equipo"));
    var equipo = Array.from(localStorage.getItem("Equipo"));
    equipo = equipo.filter(function (item) {
        return item !== ','
    });
    console.log(equipo);
    // Si existe el valor de ese Id -- cuando no se ha logueado--
    if (html != null) {
        imagencatalogo = "drones.jpg";
        IdDetalleCarrito = "id";
        nombre = "Dron";
        console.log("longitud" + equipo.length);
        for (var i = 0; i < equipo.length; i++) {
            html.insertAdjacentHTML('afterbegin', ' <tr> <td> <figure class="media"> <div class="img-wrap"><img src="../images/drones.jpg" class="img-thumbnail img-sm" width="150px" height="150px"></div> <figcaption class="media-body"> <h6 class="title text-truncate"><strong>DRON</strong></h6> <dl class="param param-inline small"> <dt>Marca: </dt> <dd>MARCA</dd> </dl> <dl class="param param-inline small"> <dt>Descripción: </dt> <dd>DESCRIPCION</dd> </dl> </figcaption> </figure> </td> <td> <input type="number" id="IdCantidadLS" value="1" class="form-control input-number text-center" /> </td> <td> <div class="price-wrap"> <var class="price">USD </var> </div> </td> <td class="text-right"> <button type="button" class="btn btn-outline-danger"><i class="fa fa-trash" aria-hidden="true"></i></button> </td> </tr>')
        }
    } else { // si es que esta logueado agrega al carrito (del usuario) los elementos obtenidos del local storage

    }
})();