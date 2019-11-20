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
            Num_Iniciativa: $("#num-iniciativa").val(),
            id_departamento: $("#id-departamento").val(),
            //data_aprovacao: $("#data-aprovacao").val(),
            id_farol: $("#farol").val().split(' ')[0],
            id_esteira: $("#id-esteira").val(),            
            id_etapa: $("#id-etapa").val(),
           
            CPF: $("#cpf-iniciativa").val(),
            //VPL: $("#vpl").val(),
            //cod_orcamento: 1,
            //cod_CETI: 1,
            //cod_comissao_varejo: 1,
            //cod_jornada: 1,
            id_mega: $("#mega").val(),
            //cod_visita: 1,
            //cod_canal: 1,
            TF_versao_agencia: $("#tf-versao-agencia").val(),
            TF_versao_PA: $("#tf-versao-pa").val(),
            //cod_prioritario: 1,
            
            //cod_replanejamento: 1,
            responsavel_neg: $("#responsavel-neg").val(),
            responsavel_DS: $("#responsavel-ds").val(),
            resumo_iniciativa: $("#resumo-iniciativa").val(),
            usabilidade: $("#usabilidade").val(),
            beneficio_iniciativa: $("#beneficio-iniciativa").val()
        };

        var _farol = {

            comentario: $('#comentario-farol').val()

        };


        var _visita = {
            data_visita: $("#data-visita").val(),
            agencia_visitada: $("#agencia-visitada").val(),
            responsavel_visita: $("#responsavel-visita").val(),
            comentario_visita: $("#comentario-visita").val()
        };

        var _jornada = {
            ux: $("#ux").val(),
            jornada_analisada: $("#jornada-analisada").val(),
            comentario_jornada: $("#comentario-jornada").val()
        };

        var _ceti = {
            total_aprovado_ceti: $("#total-aprovado-ceti").val(),
            data_ceti: $("#data-ceti").val()
        };

        var _orcamento = {
            total_aprovado: $("#total-aprovado").val(),
            total_realizado: $("#total-realizado").val(),
            total_contratado: $("#total-contratado").val()
        };

        var _replanejamento = {
            data_replanejamento: $("#data-replanejamento").val(),
            motivo_replanejamento: $("#motivo-replanejamento").val()
        };

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

        $.ajax({
            type: "POST",
            cache: false,
            data: {
                iniciativa: _iniciativa,
                orcamento: _orcamento,
                etapas: getEtapas(),
                canais: getCanais(),
                origens: getOrigens(),
                verticais: getVerticais(),
                visita: _visita,
                jornada: _jornada,
                ceti: _ceti,
                replanejamento: _replanejamento
            },

            url: "/Iniciativa/Create",
            success: function (data) {
               
                window.location.href = "/Home/Index";
            },
            error: function (data) {

                window.location.href = "/Iniciativa/ErroAmigavel";
            }
            
        });

    });
});