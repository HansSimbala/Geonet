$(document).ready(function (){
    //value es valor que viene de la base de datos (metodo de carga de estrellas)
    var value = 4,
    i;
    for ( i = 0; i < value; i++) {
        $('.fa-star').eq([i]).addClass('checked');
    }
    //valor es la variable que se guarda cuando seleccionas las estrellas (metodo para guardas estrellas)
    var valor;
    $('#s1').on('click',function(){
        $(".valor").css("color","rgba(173, 169, 169, 0.733)")
        $('#s1').css("color","#080964")
        setvalor= "1"
    })

    $('#s2').on('click',function(){
        $(".valor").css("color","rgba(173, 169, 169, 0.733)")
        $('#s1,#s2').css("color","#080964")        
        valor= "2"
    })

    $('#s3').on('click',function(){
        $(".valor").css("color","rgba(173, 169, 169, 0.733)")
        $('#s1,#s2,#s3').css("color","#080964")
        valor= "3"
    })

    $('#s4').on('click',function(){
        $(".valor").css("color","rgba(173, 169, 169, 0.733)")
        $('#s1,#s2,#s3,#s4').css("color","#080964")
        valor= "4"
    })
    $('#s5').on('click',function(){
        $(".valor").css("color","rgba(173, 169, 169, 0.733)")
        $('#s1,#s2,#s3,#s4,#s5').css("color","#080964")
        valor= "5"
    })
});