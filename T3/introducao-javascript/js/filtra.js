var campoFiltro = document.querySelector("#filtrar-tabela");

campoFiltro.addEventListener("input", function() {
    var pacientes = document.querySelectorAll(".paciente");
    if (this.value.length > 0) {
        pacientes.forEach(function(paciente) {
            var tdNome = paciente.querySelector(".info-nome");
            nome = tdNome.textContent;
            if (campoFiltro.value == nome.substr(0, campoFiltro.value.length)) {
                paciente.classList.remove("invisivel");
            } else {
                paciente.classList.add("invisivel");
            }
            // var expressao = new RegExp(campoFiltro.value, "i");
            // if (!expressao.test(nome)){
            //     paciente.classList.add("invisivel");
            // } else {
            //     paciente.classList.remove("invisivel");
            // }
        });
    } else {
        pacientes.forEach(function(paciente) {
            paciente.classList.remove("invisivel");
        });        
    }
});