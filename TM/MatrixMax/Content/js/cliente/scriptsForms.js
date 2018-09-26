//$(document).ready(function () {
//    $("#FormEnderecoPessoa").validate({
//        rules: {
//            "produto.Nome": {
//                required: true,
//                minlength: 5,
//                maxlength: 50
//            },
//            "produto.PrecoRecarga": {
//                required: "#TogglePrecoRecargaAdd:checked",
//                valorPrecos: true
//            },
//        },
//        messages: {
//            "produto.Nome": {
//                required: "Informe um nome.",
//                minlength: "O nome deve ter no mínimo 5 caracteres.",
//                maxlength: "O nome deve ter no máximo 50 caracteres."
//            },
//        errorPlacement: function (label, element) {
//            label.addClass('alert alert-danger erroAdd');
//            label.prop("role", "alert");
//            label.insertAfter(element);
//        },
//        wrapper: 'div',
//        errorClass: 'campoInvalido',
//        highlight: function (element, errorClass) {
//            $(element).addClass(errorClass);
//        },
//        unhighlight: function (element, errorClass) {
//            $(element).removeClass(errorClass);
//        },
//    });

//    $('#precoUnitarioAdd').mask("000,00", { reverse: true });

//    jQuery.validator.addMethod("estoqueInicial", function (value, element) {
//        return this.optional(element) || (Number.parseInt(value) >= 1 && Number.parseInt(value) <= 100);
//    }, 'Informe um valor de estoque válido (mínimo 1, máximo 100).');

//    jQuery.validator.addMethod("valorPrecos", function (value, element) {
//        return this.optional(element) || (Number.parseFloat(value.replace(',', '.')) >= 1);
//    }, 'Informe um preço válido (Mínimo R$1,00).');

//});

$("#radioPessoaJuridica").change(function () {
    if ($(this).is(':checked')) alert("checked");
    $(".inputsJuridicos").toggle();
});

$("#radioPessoaFisica").change(function () {
    if ($(this).is(':checked')) alert("checked");
    $(".inputsJuridicos").toggle();
});