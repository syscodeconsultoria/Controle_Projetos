$(document).ready(function () {

    

    $("#farol").change(function () {
        
        var background = $("#farol option:selected").val().split(' ')[1];
        var font = "";
        var title = $("#farol option:selected").text();

        if (background === 'yellow' || background === 'white') {
            font = 'black';
        } else if (title === "") {
            background = 'white';
            
        }
        else {
            font = 'white';
        }
        $(this).css("background", background).css("color", font);
        $("#farol option").css("background", "white").css("color", "black");
    });

   

})