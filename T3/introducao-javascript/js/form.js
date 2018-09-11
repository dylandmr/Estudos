var botaoAdicionar = document.querySelector("#adicionar-paciente");

botaoAdicionar.addEventListener("click", function(event) {
    event.preventDefault();
    
    var form = document.querySelector("#form-adiciona");
    
    var paciente = pegaValuesInputPaciente(form);
    
    var pacienteTr = montaPacienteTr(paciente);
    
    var tabela = document.querySelector("#tabela-pacientes");
    
    tabela.appendChild(pacienteTr);
    
    form.reset();
});

function pegaValuesInputPaciente(form) {
    var paciente = {
        nome: form.nome.value,
        peso: form.peso.value,
        altura: form.altura.value,
        gordura: form.gordura.value,
        imc: calculaImc(form.peso.value, form.altura.value)
    }
    
    return paciente;
}

function montaPacienteTr(paciente) {
    var pacienteTr = document.createElement("tr");
    pacienteTr.classList.add("paciente");
    
    pacienteTr.appendChild(montaTd(paciente.nome, "info-nome"));
    pacienteTr.appendChild(montaTd(paciente.peso, "info-peso"));
    pacienteTr.appendChild(montaTd(paciente.altura, "info-altura"));
    pacienteTr.appendChild(montaTd(paciente.gordura, "info-gordura"));
    pacienteTr.appendChild(montaTd(paciente.imc, "info-imc"));
    
    return pacienteTr;
}

function montaTd(valor, classe) {
    var td = document.createElement("td");
    td.classList.add(classe);
    td.textContent = valor;
    
    return td;
}