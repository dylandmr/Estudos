//alert("Hello world!1");
console.log("Carregado principal.js");
var titulo = document.querySelector(".titulo");
console.log(titulo);
console.log(titulo.textContent);
titulo.textContent = "Aparecida Nutricionista";
//erro

//var pacientes = document.querySelectorAll(".paciente");
//var altura = 0; var peso = 0;
//for (var i = 0; i < pacientes.length; i++ ){
//    peso = pacientes.item(i).querySelector(".info-peso").textContent;
//    altura = pacientes.item(i).querySelector(".info-altura").textContent;
//    pacientes.item(i).querySelector(".info-imc").textContent = peso/(altura*altura);
//}

var paciente = document.querySelector("#primeiro-paciente");

var tdPeso = paciente.querySelector(".info-peso");
var peso = tdPeso.textContent;

var tdAltura = paciente.querySelector(".info-altura");
var altura = tdAltura.textContent;

var tdImc = paciente.querySelector(".info-imc");

var pesoValido = true;
var alturaValida = true;

if(peso < 0 || peso > 500 ){
    tdPeso.textContent = "Peso inválido."; 
    pesoValido = false;
}

if(altura < 0 || altura > 3){
    tdAltura.textContent = "Altura inválida.";
    alturaValida = false;
}

if(pesoValido && alturaValida) {
    var imc = peso/(altura*altura); // 100/(2.00*2.00) // 100/4.00 = 25

    tdImc.textContent = imc;
} else {
    tdImc.textContent = "Altura e/ou peso inválido(s)!"
}