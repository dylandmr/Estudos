$(function () {
    $("#clienteVenda").select2({
        ajax: {
            url: "/Cliente/BuscaClienteVenda",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    q: params.term
                };
            },
            processResults: function (data, params) {
                return {
                    results: data.results,
                }
            }
        },
        placeholder: 'Buscar...',
        language: {
            searching: function () {
                return "Buscando...";
            },
            inputTooShort: function (args) {
                return "Pesquise o cliente pelo nome";
            },
            noResults: function () {
                return "Nenhum resultado encontrado";
            },
        },
        minimumInputLength: 1,
        theme: "boostrap"
    });

    $("#produtosVenda").select2({
        theme: "bootstrap",
        placeholder: "Selecione um produto",
        dropdownCssClass: "dropdownSelect2"
    });

    $(".select2-selection__rendered").addClass("rounded").addClass("form-control");
    $(".select2-selection select2-selection--single").addClass("rounded").addClass("form-control");

    $("#toggleDesconto").click(function () {
        if ($(this).prop("checked")) {
            $("#opcoesDesconto").fadeIn();
            $("#valorDesconto").prop("disabled", false);   
        } else {
            $("#opcoesDesconto").fadeOut();
        }
    });

    $("input[name='radioDesconto']").click(function () {
        if ($(this).prop("checked")) {
            if ($(this).prop("id") === "descontoFixo") {
                $("#valorDesconto").prop("disabled", false).fadeIn();
                $("#porcentagemDesconto").prop("disabled", true).fadeOut();
            }
            else {
                $("#porcentagemDesconto").prop("disabled", false).fadeIn();
                $("#valorDesconto").prop("disabled", true).fadeOut();
            }
        } else {
            $("#valorDesconto").prop("disabled", true);
            $("#porcentagemDesconto").prop("disabled", true);
        } 
    });

    $("#formaDePagamento").change(function () {
        if ($(this).val() == 3) {
            $("#bandeiraCartao").prop("disabled", false);
            $("#opcoesCartao").fadeIn();
        } else {
            $("#opcoesCartao").fadeOut();
            $("#bandeiraCartao").prop("disabled", true);
            $("#parcelasCartao").prop("disabled", true);
        }
    });

    $("input[name='radioDebitoCredito']").click(function () {
        if ($(this).prop("checked")) {
            if ($(this).prop("id") === "cartaoDebito") {
                $("#parcelasCartao").prop("disabled", true).fadeOut();
            }
            else {
                $("#parcelasCartao").prop("disabled", false).fadeIn();
            }
        }
    });

    $("#produtosVenda").change(function () {
        var dadosProduto = $(this).val().match(/id=(.*)&pun=(.*)&prec=(.*)&ptr=(.*)/);
        produto.id = dadosProduto[1];
        produto.precoUnitario = dadosProduto[2];
        produto.precoRecarga = dadosProduto[3];
        produto.precoTroca = dadosProduto[4];
        //var person = { firstName: "John", lastName: "Doe", age: 46 };
        $("#detalhesProdutoVenda").fadeIn();
    });
});

var produtos = [];

var produto = {
    id: "",
    quantidade: "",
    precoUnitario: "",
    precoRecarga: "",
    precoTroca: ""
};