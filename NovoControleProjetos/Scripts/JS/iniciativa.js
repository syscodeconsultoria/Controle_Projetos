
var background = $('#farol :selected').data('cor');
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


$("#farol").css("background", background).css("color", font);
$("#farol option").css("background", "white").css("color", "black");

$(document).ready(function () {


    var id_comentario_farol = null;

    $("#id-etapa").change(function () {
        //criar inteligencia para quando alterar
        //etapa atual, checkar no etapas, dentro de detalhes
    });

    $("#ux").change(function () {
        $('#ux option[selected]').remove();
    });

    $("#jornada-analisada").change(function () {
        $('#jornada-analisada option[selected]').remove();
    });

    $("#usabilidade").change(function () {
        $('#usabilidade option[selected]').remove();
    });

    $("#farol").change(function () {


        $('#farol option[selected]').remove();


        var background = $('#farol :selected').data('cor');

        //$("#farol option:selected").val().split(' ')[1];
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

        var id_farol = $("#farol").val().split(' ')[0];
        var id_iniciativa = $("#nome-projeto").attr("data-id");

        //$("#comentario-farol").val().remove();

        $.get("/Farol/BuscaFarolJS", { id_iniciativa: id_iniciativa, id_farol: id_farol }, function (data) {
                 
          
            id_comentario_farol = $("#id-comentario-farol").val();

            if (data.Comentario_Farol === "null") {
                $('#comentario-farol').val("");
            }
            
            $('#comentario-farol').val(data.Comentario_Farol);
           
            
        });

    });

    $("#cad-iniciativa").click(function () {

        var nome = $("#projeto").val();

        $.post("/Iniciativa/_InsertIniciativa", { nome: nome }, function (data) {
            var id = data;
            window.location.href = "/Iniciativa/EditaIniciativa?id=" + id;
        });

    });

    $("#update-iniciativa").click(function () {

        var _iniciativa = {

            Id_Iniciativa: $("#nome-projeto").attr("data-id"),
            Nome_Iniciativa: $("#nome-projeto").val(),
            Num_Iniciativa: $("#num-iniciativa").val(),
            id_departamento: $("#id-departamento").val(),
            data_aprovacao: $("#data-aprovacao").val(),
            id_farol: $("#farol").val().split(' ')[0],
            id_esteira: $("#id-esteira").val(),
            id_etapa: $("#id-etapa").val(),
            data_piloto: $("#data-piloto").val(),
            data_plenouso: $("#pleno-uso").val(),
            data_comunicacao: $("#data-comunicacao").val(),

            CPF: $("#cpf-iniciativa").val(),


            //VPL: $("#vpl").val(),
            //cod_orcamento: 1,
            id_ceti: $("#id-ceti").val(),
            //cod_comissao_varejo: 1,
            //cod_jornada: 1,
            id_mega: $("#id-mega").val(),
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
            beneficio_iniciativa: $("#beneficio-iniciativa").val(),
            id_replanejamento: $("#id-replanejamento").val(),
            id_visita: $("#id-visita").val()

        };

        var _farol = {

            id_farol: $("#farol").val().split(' ')[0],
            comentario_farol: $('#comentario-farol').val(),
            id_comentario_farol: id_comentario_farol

        };


        var _visita = {
            id_visita: $("#id-visita").val(),
            data_visita: $("#data-visita").val(),
            cod_agencia: $("#cod-agencia").val(),
            nome_agencia: $("#cod-agencia option:selected").text()
            //responsavel_visita: $("#responsavel-visita").val(),
            //comentario_visita: $("#comentario-visita").val()
        };

        var _jornada = {
            ux: $("#ux").val(),
            varejo_acompanhou: $("#jornada-analisada").val(),
            comentario_jornada: $("#comentario-jornada").val()
        };

        var _ceti = {
            total_aprovado_ceti: $("#total-aprovado-ceti").val(),
            data_ceti: $("#data-ceti").val()
        };


        var _orcamento = {



            id_orcamento: $("#id-orcamento").val(),
            total_aprovado: $("#total-aprovado").val(),
            total_realizado: $("#total-realizado").val(),
            total_contratado: $("#total-contratado").val()
        };

        var _replanejamento = {
            id_replanejamento: $("#id-replanejamento").val(),
            data_replanejamento: $("#data-replanejamento").val(),
            motivo_replanejamento: $("#motivo-replanejamento").val()
        };

        var _mvp = {
            Id_Mvp: $("#id-mvp").val(),
            Nome_Mvp: $('#mvp-nome').val(),
            Dt_Mvp: $('#mvp-entrega').val(),
            Id_Iniciativa: $("#nome-projeto").attr("data-id"),

            Id_Mvp1: $("#id-mvp1").val(),
            Nome_Mvp1: $('#mvp-nome-um').val(),
            Dt_Mvp1: $('#mvp-entrega-um').val(),
            Id_Iniciativa1: $("#nome-projeto").attr("data-id"),

            Id_Mvp2: $("#id-mvp2").val(),
            Nome_Mvp2: $('#mvp-nome-dois').val(),
            Dt_Mvp2: $('#mvp-entrega-dois').val(),
            Id_Iniciativa2: $("#nome-projeto").attr("data-id")
        };

        function getEtapas() {
            var searchIDs = $("input[name='check-etapa']:checked").map(function () {
                var _data_inicio = $("#inicio-" + $(this).val()).val();
                var _data_fim = $("#fim-" + $(this).val()).val();
                return { id_etapa: $(this).val(), dt_inicio: _data_inicio, dt_fim: _data_fim };
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
                replanejamento: _replanejamento,
                farol: _farol,
                mvp: _mvp
            },

            url: "/Iniciativa/Create",
            success: function (data) {

                window.location.href = "/Home/Index";
                //window.location.reload(true);
            },
            error: function (data) {

                window.location.href = "/Iniciativa/ErroAmigavel";
            }

        });

    });
});