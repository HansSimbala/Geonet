$(document).ready(function(){

    $(".yes").on('click',function(){
        $("#txtContraseña").removeAttr( "type");
        $(".no").removeClass("d-none");
        $(".yes").addClass("d-none")
    });
    $(".no").on('click',function(){
        $("#txtContraseña").attr( "type","password");
        $(".yes").removeClass("d-none");
        $(".no").addClass("d-none")
    });
        
    
});