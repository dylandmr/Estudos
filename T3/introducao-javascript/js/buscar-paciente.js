var botaoBuscar = document.querySelector("#buscar-pacientes");

botaoBuscar.addEventListener("click", function() {
    var xhr = new XMLHttpRequest(); //Objeto para requisições assíncronas em JS! - Antigamente só XML, hoje para vários formatos.
    
    xhr.open("GET", "http://api-pacientes.herokuapp.com/pacientes");
    //Abre a requisição com Método e URL. Não faz a requisição ainda!
    xhr.send();
    //De fato envia a requisição.

    xhr.addEventListener("load", function() {
    //Evento LOAD - Quando a requisição tiver carregada
        console.log(xhr.responseText); //ResponseText
    });
});