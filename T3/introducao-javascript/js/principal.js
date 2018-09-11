//alert("Hello world!1");
console.log("Carregado principal.js");
var titulo = document.querySelector(".titulo");
console.log(titulo);
console.log(titulo.textContent);
titulo.textContent = "Aparecida Nutricionista";
//erro

var pacientes = document.querySelectorAll(".paciente");
for (var i = 0; i < pacientes.length; i++ ){
    var paciente = pacientes[i];
    
    var tdPeso = paciente.querySelector(".info-peso");
    var peso = tdPeso.textContent;

    var tdAltura = paciente.querySelector(".info-altura");
    var altura = tdAltura.textContent;

    var tdImc = paciente.querySelector(".info-imc");

    var pesoValido = true;
    var alturaValida = true;

    if(peso < 0 || peso > 500 ){
        //paciente.style.backgroundColor = "lightcoral";
        paciente.classList.add("paciente-invalido");
        tdPeso.textContent = "Peso inválido."; 
        pesoValido = false;
    }

    if(altura < 0 || altura > 3){
        //paciente.style.backgroundColor = "lightcoral";
        paciente.classList.add("paciente-invalido");
        tdAltura.textContent = "Altura inválida.";
        alturaValida = false;
    }

    if(pesoValido && alturaValida) {
        var imc = peso/(altura*altura); // 100/(2.00*2.00) // 100/4.00 = 25

        tdImc.textContent = imc.toFixed(2);
    } else {
        tdImc.textContent = "Altura e/ou peso inválido(s)!"
    }
}

//titulo.addEventListener("click", mostraMensagem); <- função nomeada

//function mostraMensagem() {
//    console.log("clicou no título!");
//}

titulo.addEventListener("click", function() {
    console.log("clicou no título ;)");
}); //<- FUNÇÃO ANÔNIMA


var botaoAdicionar = document.querySelector("#adicionar-paciente");

botaoAdicionar.addEventListener("click", function(event) {
    event.preventDefault();
    
    var form = document.querySelector("#form-adiciona");
    
    var nome = form.nome.value;
    var peso = form.peso.value;
    var altura = form.altura.value;
    var gordura = form.gordura.value;
    
    var pacienteTr = document.createElement("tr");
    var nomeTd = document.createElement("td");
    var pesoTd = document.createElement("td");
    var alturaTd = document.createElement("td");
    var gorduraTd = document.createElement("td");
    var imcTd = document.createElement("td");
    
    nomeTd.textContent = nome;
    pesoTd.textContent = peso;
    alturaTd.textContent = altura;
    gorduraTd.textContent = gordura;
    
    pacienteTr.appendChild(nomeTd);
    pacienteTr.appendChild(pesoTd);
    pacienteTr.appendChild(alturaTd);
    pacienteTr.appendChild(gorduraTd);
    
    var tabela = document.querySelector("#tabela-pacientes");
    
    tabela.appendChild(pacienteTr);
});