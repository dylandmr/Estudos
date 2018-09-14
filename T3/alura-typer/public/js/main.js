var frase = $(".frase").text();

var contPalavras = frase.split(" ").length;

var tamanhoFrase = $("#tamanho-frase").text(contPalavras);

var campo = $(".campo-digitacao");

campo.on("input", function(){
    $("#contador-palavras").text(campo.val().split(/\S+/).length-1);
    $("#contador-caracteres").text(campo.val().replace(/\s+/g, "").length);
});