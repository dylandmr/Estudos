var criaJogo = function() {
    var setPalavraSecreta = function(palavra) {
        palavraSeceta = palavra;
        
        geraLacunas(palavraSeceta);

        // etapa++; <- Minha solução. Solução do instrutor:
        proximaEtapa();
    };
    
    var proximaEtapa = function() {
        etapa++;
    };

    var geraLacunas = function(palavra){
        // for (letra in palavra){
        //     lacunas.push("");
        // } <- Minha solução. Sugestão do instrutor:
        lacunas = Array(palavraSeceta.length).fill("");
    };

    var getLacunas = function() {
        return lacunas;
    };

    var getEtapa = function() {
        return etapa;
    };

    var etapa = 1;
    var lacunas = [];
    var palavraSeceta;

    return {
        setPalavraSecreta: setPalavraSecreta,
        getLacunas: getLacunas,
        getEtapa: getEtapa
    }
}