function inserePlacar() {
    var corpoTabela = $(".placar").find("tbody");
    var placar = $("#contador-palavras").text();
    var usuario = "Anônimo";

    var linha = criaLinhaPlacar(usuario, placar);

    linha.find(".botao-remover").click(removeLinha);

    corpoTabela.prepend(linha);
}

function criaLinhaPlacar(usuario, placar) {
    var linha = $("<tr>");
    var colunaUsuario = $("<td>").text(usuario);
    var colunaPlacar = $("<td>").text(placar);
    var colunaRemover = $("<td>");
    
    var link = $("<a>").addClass("botao-remover").attr("href", "#");
    var icone = $("<i>").addClass("small").addClass("material-icons").text("delete");
    
    link.append(icone);
    colunaRemover.append(link);
    linha.append(colunaUsuario);
    linha.append(colunaPlacar);
    linha.append(colunaRemover);

    return linha;
}

function removeLinha(event) {
    event.preventDefault();
    $(this).parent().parent().remove();
}