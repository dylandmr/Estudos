var criaJogo = function(sprite) {
    var setPalavraSecreta = function(palavra) {
        palavraSeceta = palavra;
        
        geraLacunas(palavraSeceta);

        // etapa++; <- Minha solução. Solução do instrutor:
        proximaEtapa();
    };

    var ganhou = function() {
        return !lacunas.some(l => l === "") && lacunas.length > 0;
    };

    var perdeu = function() {
        return sprite.isFinished();
    };

    var ganhouOuPerdeu = function() {
        return ganhou() || perdeu();
    };

    var reinicia = function() {
        sprite.reset();
        etapa--;
        lacunas = [];
        palavraSeceta = "";
    };
    
    var processaChute = function(chute) {
        if(palavraSeceta.toLowerCase().includes(chute.toLowerCase())) {
            preencheLacunas(chute.toLowerCase());
        } else {
            sprite.nextFrame();
        }
    };

    var preencheLacunas = function(chute) {
        var regexChute = new RegExp(chute, 'gi');
        while(resultado = regexChute.exec(palavraSeceta)) {
            lacunas[resultado.index] = chute; 
        }
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
        getEtapa: getEtapa,
        processaChute: processaChute,
        ganhou: ganhou,
        perdeu: perdeu,
        ganhouOuPerdeu: ganhouOuPerdeu,
        reinicia: reinicia
    }
}