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

var imc = peso/(altura*altura); // 100/(2.00*2.00) // 100/4.00 = 25

console.log(imc);