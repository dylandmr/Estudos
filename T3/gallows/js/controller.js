$(function() {
    criaController(
        criaJogo(
            createSprite(".sprite")
        )
    ).inicia();
});

var criaController = function(jogo){
    var $entrada = $(".entrada");
    var $lacunas = $(".lacunas");

    var exibeLacunas = function () {
        $lacunas.empty(); //<- Correção instrutor, esqueci deste comando.
        var listaLacunas = [];
        $.each(jogo.getLacunas(), function(i, lacuna){
            // listaLacunas.push($("<li>").addClass("lacuna")); <- Minha resposta. Esqueci de setar o texto:
            listaLacunas.push($("<li>").addClass("lacuna").text(lacuna));
        });
        $lacunas.append(listaLacunas);
    };
   
    var mudaPlaceHolder = function (texto) {
        // $entrada.attr("placeholder", "Chute"); <- Minha resposta. Esqueci do parâmetro. Correção:
        $entrada.attr("placeholder", texto);
        $entrada.val("");
    };

    var guardaPalavraSecreta = function () {
        // jogo.setPalavraSecreta($entrada.val()); <- Minha solução. Sugestão instrutor:
        jogo.setPalavraSecreta($entrada.val().trim());
        exibeLacunas();
        mudaPlaceHolder('Chute');
    };

    var leChute = function() {
        // jogo.processaChute($entrada.val());
        // exibeLacunas(); <- Minha solução. Faltaram algumas coisas. Correção instrutor:
        jogo.processaChute($entrada.val().trim().substr(0,1));
        $entrada.val("");
        exibeLacunas();

        if (jogo.ganhouOuPerdeu()){
            // if (jogo.ganhou()) {
            //     alert("Você ganhou!");
            // } else {
            //     alert("Tente novamente!");
            // }
            // jogo.reinicia();
            // exibeLacunas(); <- Minha resposta, faltando algumas coisas - Correção:
            setTimeout(function (){
                if (jogo.ganhou()) {
                    alert("Você ganhou!");
                } else {
                    alert("Tente novamente!");
                }
                reinicia();
            }, 200);
        }
    };

    var reinicia = function() {
        jogo.reinicia();
        $lacunas.empty();
        mudaPlaceHolder("Palavra secreta");    
    };

    var inicia = function () {
        $entrada.keypress(function (event) {
            if (event.which == 13) {
                switch (jogo.getEtapa()) {
                    case 1:
                        guardaPalavraSecreta();
                        break;
                    case 2:
                        leChute();
                        break;
                }
            }
        });
    }; 
    return { inicia: inicia };
};    