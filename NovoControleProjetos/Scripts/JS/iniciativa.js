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

    $("#cad-iniciativa").click(() => {

        var nome = $("#projeto").val();

        $.post("/Iniciativa/_InsertIniciativa", { nome: nome }, function (data) {
            var id = data;
            window.location.href = "/Iniciativa/Create/" + id;
        });

    });

    $("#update-iniciativa").click(function() {
        
        var iniciativa = {

            Id_Iniciativa: $("#nome-projeto").attr("data-id"),
            Nome_Iniciativa: $("#nome-projeto").val(),
            Num_Iniciativa: $("#iniciativa").val(),
            cod_departamento: $("#id_departamento").val(),
            Esteira: $("#id_esteira").val(),
            cod_farol: $("#farol").val().split(' ')[0],
            cod_etapa: $("#etapa").val(),
            CPF: $("#cpf-iniciativa").val(),
            VPL: $("#vpl").val(),
            cod_orcamento: 1,
            cod_CETI: 1,
            cod_comissao_varejo: 1,
            cod_jornada: 1,
            cod_mega: 1,
            cod_visita: 1,
            cod_canal: 1,
            TF_versao_agencia: $("#tf-versao-agencia").val(),
            TF_versao_PA: $("#tf-versao-pa").val(),
            cod_prioritario: 1,
            cod_dt: 1,
            cod_replanejamento: 1,
            responsavel_neg: $("#responsavel-neg").val(),
            responsavel_DS: $("#responsavel-ds").val(),
            resumo_iniciativa: ""
        };

        $.ajax({
            type: "POST",
            cache: false,
            data: { model: iniciativa },
            url: "/Iniciativa/Create",
            success: function (data) {
                window.location.href = "/Home/Index";
            }
        })



    });



});