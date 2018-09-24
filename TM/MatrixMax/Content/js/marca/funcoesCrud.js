$(function () {
    $("#BotaoAddMarcas").click(function () {
        $("#DivFormAddMarca").toggle();
    });

    $('#FormAddMarca').ajaxForm({
        dataType: 'json',
        success: function (resposta) {
            if (resposta.adicionou) {
                $('#FormAddMarca').resetForm();
                $('#DivFormAddMarca').toggle();
                tabelamarcas.ajax.reload();
                $("#mensagensContainerMarcas").append(
                    '<div class="col-sm-12" id="msgProdutoAdicionado">'
                    + '<div class="alert  alert-success alert-dismissible fade show" role="alert">'
                    + '<span class="badge badge-pill badge-success">sucesso</span> Marca adicionada.'
                    + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
                    + '<span aria-hidden="true">&times;</span>'
                    + '</button>'
                    + '</div>'
                    + '</div>');
                $("#msgErroMarcaAdd").prop("hidden", true);
            } else {
                $("#msgErroMarcaAdd").prop("hidden", false);
                $("#msgErroMarcaAdd").html("Erro interno: <br/>" + resposta.msg);
            }
        }
    });
});