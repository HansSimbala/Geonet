function eliminar(id){
    Swal.fire({
        title: '¿Seguro que desea eliminar?',
        text: "No podrás revertirlo",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: 'POST',
                url: "/DetalleCarritoes/Eliminar/" + id,
                success: function (response) {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Your work has been saved',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    location.reload();
                },
            });
        }
    })
}