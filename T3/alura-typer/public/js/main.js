var tempoInicial = $("#tempo-digitacao").text();
var campo = $(".campo-digitacao");

$(function(){
    atualizaTamanhoFrase();
    inicializaContadores();
    inicializaCronometro();
    $("#botao-reiniciar").click(reiniciaJogo);
});

function reiniciaJogo() {
    campo.attr("disabled", false);
    campo.val("");
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
            console.log(tempoRestante);
            $("#tempo-digitacao").text(tempoRestante);
            if (tempoRestante < 1) {
                campo.attr("disabled", true);
                clearInterval(contador);
                $("#botao-reiniciar").removeAttr("disabled");
            }
        }, 1000);
    });
}