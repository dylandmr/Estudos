var campoFiltro = document.querySelector("#filtrar-tabela");

campoFiltro.addEventListener("input", function() {
    console.log(this.value);
    var pacientes = document.querySelectorAll(".paciente");
    pacientes.forEach(function(paciente) {
        var tdNome = paciente.querySelector(".info-nome");
        nome = tdNome.textContent;
        if (nome != this.value){
            paciente.classList.add(".invisivel");
        } else {
            paciente.classList.remove(".invisivel");
        }
    });
});