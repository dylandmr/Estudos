var tempoInicial = $("#tempo-digitacao").text();
var campo = $(".campo-digitacao");

$(function(){
    atualizaTamanhoFrase();
    inicializaContadores();
    inicializaCronometro();
    inicializaMarcadores();
    $("#botao-reiniciar").click(reiniciaJogo);
});

function reiniciaJogo() {
    campo.attr("disabled", false);
    campo.val("");
    campo.toggleClass("gameover");
    campo.removeClass("campo-certo");
    campo.removeClass("campo-errado");
    $("#tempo-digitacao").text(tempoInicial);
    $("#contador-palavras").text("0");
    $("#contador-caracteres").text("0");
    inicializaCronometro();
}

function atualizaTamanhoFrase() {
    var frase = $(".frase").text();
    var contPalavras = frase.split(" ").length;
    var tamanhoFrase = $("#tamanho-frase").text(contPalavras);
}

function inicializaContadores() {
    campo.on("input", function () {
        $("#contador-palavras").text(campo.val().split(/\S+/).length - 1);
        $("#contador-caracteres").text(campo.val().replace(/\s+/g, "").length);
    });
}

function inicializaCronometro() {
    $("#botao-reiniciar").attr("disabled", true);
    var tempoRestante = $("#tempo-digitacao").text();
    campo.one("focus", function () {
        var contador = setInterval(function () {
            tempoRestante--;
            $("#tempo-digitacao").text(tempoRestante);
            if (tempoRestante < 1) {
                campo.attr("disabled", true);
                clearInterval(contador);
                $("#botao-reiniciar").removeAttr("disabled");
                campo.toggleClass("gameover");
            }
        }, 1000);
    });
}

function inicializaMarcadores() {
    var frase = $(".frase").text();
    campo.on("input", function () {
        if (frase.startsWith(campo.val())) {
            campo.addClass("campo-certo");
            campo.removeClass("campo-errado");
        }
        else {
            campo.addClass("campo-errado");
            campo.removeClass("campo-certo");
        }
    });
}
