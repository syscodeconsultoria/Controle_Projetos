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

    $("#cad-iniciativa").click(function () {

        var nome = $("#projeto").val();

        $.post("/Iniciativa/_InsertIniciativa", { nome: nome }, function (data) {
            var id = data;
            window.location.href = "/Iniciativa/Create/" + id;
        });

    });

    $("#update-iniciativa").click(function () {

        var _iniciativa = {

            Id_Iniciativa: $("#nome-projeto").attr("data-id"),
            Nome_Iniciativa: $("#nome-projeto").val(),
            Num_Iniciativa: $("#iniciativa").val(),
            cod_departamento: $("#id_departamento").val(),
            Esteira: $("#id_esteira").val(),
            cod_farol: $("#farol").val().split(' ')[0],
            cod_etapa: $("#etapa").val(),
            CPF: $("#cpf-iniciativa").val(),
            VPL: $("#vpl").val(),
            //cod_orcamento: 1,
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

        var _orcamento = {

            total_aprovado: $("#total_aprovado").val(),
            total_realizado: $("#total_realizado").val(),
            total_contratado: $("#total_contratado").val()

        };

        function getOrigens() {
            var searchIDs = $("input[name='check-origem']:checked").map(function () { 
                return { id_origem: $(this).val() };
            });
            return searchIDs.get();
        }

        function getVerticais() {

            var searchIDs = $("input[name='check-vertical']:checked").map(function () {
                return { id_vertical: $(this).val() };
            });

            return searchIDs.get();
        }

        function getEtapas() {
            var searchIDs = $("input[name='check-etapa']:checked").map(function () {
                var _data_inicio = $("#inicio-" + $(this).val()).val();
                var _data_fim = $("#fim-" + $(this).val()).val();
                return { id_etapa: $(this).val(), data_inicio: _data_inicio, data_fim: _data_fim };
            });
            return searchIDs.get();
        }

        function getCanais() {
            var searchIDs = $("input[name='check-canal']:checked").map(function () {
                var _data_canal = $("#datacanal-" + $(this).val()).val();               
                return { id_canal: $(this).val(), data_canal: _data_canal };
            });
            return searchIDs.get();
        }


        $.ajax({
            type: "POST",
            cache: false,
            data: { iniciativa: _iniciativa, orcamento: _orcamento, etapas: getEtapas(), verticais: getVerticais(), origens: getOrigens(), canais: getCanais() },

            url: "/Iniciativa/Create",
            success: function (data) {
                window.location.href = "/Home/Index";
            }
        });



    });



});