﻿function FiltraPorCategoria() {
    if ($('#FiltroCategorias').val() > 0) {
        tabelaprodutos.column(1).search($('#FiltroCategorias').val()).draw();
    } else {
        tabelaprodutos.columns().search('').draw();
    }
}

function processaAtivoDesativo() {
    if ($('input:radio[name=opcaoAtivoDesativo]:checked').val() == 'ativa') {
        $('#RadioDesativos').removeClass('btn-danger').addClass('btn-secondary');
        $('#RadioAtivos').addClass('btn-success');
        tabelaprodutos.clear().destroy();
        tabelaprodutos = $('#bootstrap-data-table').DataTable(ativados);
    };
    if ($('input:radio[name=opcaoAtivoDesativo]:checked').val() == 'desativa') {
        $('#RadioAtivos').removeClass('btn-success').addClass('btn-secondary');
        $('#RadioDesativos').addClass('btn-danger');
        tabelaprodutos.clear().destroy();
        tabelaprodutos = $('#bootstrap-data-table').DataTable(desativados);
    };
}

function apagaProduto() {
    var ids = [];
    $.each(tabelaprodutos.rows('.selected').data(), function () {
        ids.push(this["Id"]);
    });
    var params = { ids: ids };
    $.post("/Produto/Desativa", params, atualizaPaginaRemover);
}

function reativaProduto() {
    var ids = [];
    $.each(tabelaprodutos.rows('.selected').data(), function () {
        ids.push(this["Id"]);
    });
    var params = { ids: ids };
    $.post("/Produto/Ativa", params, atualizaPaginaReativar);
}

function atualizaPaginaReativar(resposta) {
    if (resposta.ativou == true) {
        $('#fechaModalReativar').click(); $('#fechaModalReativar').click();
        tabelaprodutos.ajax.reload();
        $("#mensagensContainer").append(
            '<div class="col-sm-12" id="msgProdutoReativado">'
            + '<div class="sufee-alert alert with-close alert-success alert-dismissible fade show">'
            + '<span class="badge badge-pill badge-success">sucesso</span> Produto(s) reativado(s).'
            + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
            + '<span aria-hidden="true">&times;</span>'
            + '</button>'
            + '</div>'
            + '</div>');
    }
}

function atualizaPaginaRemover(resposta) {
    if (resposta.apagou == true) {
        $('#fechaModalRemover').click(); $('#fechaModalRemover').click();
        tabelaprodutos.ajax.reload();
        $("#mensagensContainer").append(
            '<div class="col-sm-12" id="msgProdutoRemovido">'
            + '<div class="sufee-alert alert with-close alert-danger alert-dismissible fade show">'
            + '<span class="badge badge-pill badge-danger">sucesso</span> Produto(s) removido(s).'
            + '<button type="button" class="close" data-dismiss="alert" aria-label="Close">'
            + '<span aria-hidden="true">&times;</span>'
            + '</button>'
            + '</div>'
            + '</div>');
    }
}

function pegaDados() {
    var dados = tabelaprodutos.rows('.selected').data();
    if (dados.length == 1) {
        if (dados[0].Ativo == true) {
            $('#dialogoDesativar').text("Deseja realmente remover " + dados[0].Nome + "?");
        } else {
            $('#dialogoReativar').text("Reativar o produto " + dados[0].Nome + "?");
        }
    } else {
        var listadenomes = "<br/><br/>" + dados[0].Nome;
        for (var i = 1; i < dados.length; i++) {
            listadenomes += "<br/>" + dados[i].Nome;
        }
        if (dados[0].Ativo == true) {
            $('#dialogoDesativar').html("Deseja realmente remover os produtos selecionados? " + listadenomes);
        } else {
            $('#dialogoReativar').html("Reativar produtos selecionados? " + listadenomes);
        }
    }
}

function pegaCategoriasEMarcas(form) {
    $.getJSON("/Categoria/getCategorias", null, function (data) {
        $("#categoria" + form + " option").remove();
        $("#categoria" + form).append(
            $("<option></option>")
                .text("Selecione...")
                .val("")
        );

        var dados = (form == 'Editar') ? dados = tabelaprodutos.rows(indexproduto).data() : null;
        $.each(data.Categorias, function (index, item) {
            if (dados != null && (item.Id == dados[0].Subcategoria.CategoriaId)) {
                $("#categoria" + form).append(
                    $("<option selected></option>")
                        .text(item.Nome)
                        .val(item.Id)
                );
                $("#categoria" + form).val(dados[0].Subcategoria.CategoriaId).change();
            }
            else {
                $("#categoria" + form).append(
                    $("<option></option>")
                        .text(item.Nome)
                        .val(item.Id)
                );
            }
        });
    });

    $.getJSON("/Marca/getMarcas", null, function (data) {
        $("#Marca" + form + " option").remove();
        $("#Marca" + form).append(
            $("<option></option>")
                .text("Selecione...")
                .val("")
        );

        var dados = (form == 'Editar') ? dados = tabelaprodutos.rows(indexproduto).data() : null;

        $.each(data.Marcas, function (index, item) {
            if (dados != null && (item.Id == dados[0].MarcaId)) {
                $("#Marca" + form).append(
                    $("<option selected></option>")
                        .text(item.Nome)
                        .val(item.Id)
                );
                $("#Marca" + form).val(dados[0].MarcaId).change();
            }
            else {
                $("#Marca" + form).append(
                    $("<option></option>")
                        .text(item.Nome)
                        .val(item.Id)
                );
            }
        });
    });
}

function pegaSubcategorias(form) {
    var categoriaId = $("#categoria" + form).val();
    if (categoriaId == 0) {
        $("#subcategoria" + form + " option").remove();
        $("#subcategoria" + form).prop("disabled", true);
        $("#subcategoria" + form).append(
            $("<option></option>")
                .text("Selecione...")
                .val("")
        );
    }
    else {
        $.getJSON("/Categoria/getSubcategorias/" + categoriaId, null, function (data) {
            $("#subcategoria" + form + " option").remove();
            $("#subcategoria" + form).prop("disabled", false);
            $("#subcategoria" + form).append(
                $("<option></option>")
                    .text("Selecione...")
                    .val("")
            );
            var dados = (form == 'Editar') ? dados = tabelaprodutos.rows(indexproduto).data() : null;
            $.each(data.Subcategorias, function (index, item) {
                if (dados != null && (item.Id == dados[0].SubcategoriaId)) {
                    $("#subcategoria" + form).append(
                        $("<option selected></option>")
                            .text(item.Nome)
                            .val(item.Id)
                    );
                    $("#subcategoria" + form).val(dados[0].SubcategoriaId).change();
                } else {
                    $("#subcategoria" + form).append(
                        $("<option></option>")
                            .text(item.Nome)
                            .val(item.Id)
                    );
                }
            });
        });
    }
}

function populaEditar() {
    pegaCategoriasEMarcas('Editar');
    var dados = tabelaprodutos.rows(indexproduto).data();
    $('#IdEditar').val(dados[0].Id);
    $('#nomeEditar').val(dados[0].Nome);
    document.getElementById('nomeEditar').defaultValue = dados[0].Nome;
    $('#estoqueEditar').val(dados[0].Estoque);
    document.getElementById('estoqueEditar').defaultValue = dados[0].Estoque;
    $('#precoUnitarioEditar')
        .val($('#precoUnitarioEditar')
            .masked(Number
                .parseFloat(dados[0].PrecoUnitario)
                .toFixed(2)));
    document.getElementById('precoUnitarioEditar').defaultValue = $('#precoUnitarioEditar')
        .masked(Number
            .parseFloat(dados[0].PrecoUnitario)
            .toFixed(2));
    if (dados[0].PrecoRecarga != null) {
        $("#TogglePrecoRecargaEditar").prop('checked', true).change();
        $('#precoRecargaEditar').val($('#precoRecargaEditar')
            .masked(Number
                .parseFloat(dados[0].PrecoRecarga)
                .toFixed(2)));
        document.getElementById('precoRecargaEditar').defaultValue = dados[0].PrecoRecarga;
    } else {
        document.getElementById('precoRecargaEditar').defaultValue = "Desabilitado";
    }

    if (dados[0].PrecoTroca != null) {
        $("#TogglePrecoTrocaEditar").prop('checked', true).change();
        $('#precoTrocaEditar').val($('#precoTrocaEditar')
            .masked(Number
                .parseFloat(dados[0].PrecoTroca)
                .toFixed(2)));
        document.getElementById('precoTrocaEditar').defaultValue = dados[0].PrecoTroca;
    } else {
        document.getElementById('precoTrocaEditar').defaultValue = "Desabilitado";
    }
}

function processaTogglePrecos(preco, form) {
    if ($('#TogglePreco' + preco + form).prop('checked') == true) {
        $('#preco' + preco + form).prop('disabled', false);
        $('#preco' + preco + form).val("00,00");
    } else {
        $('#preco' + preco + form).prop('disabled', true);
        $('#preco' + preco + form).val("Desabilitado");
        $('#preco' + preco + form).removeClass("campoInvalido");
    }
}