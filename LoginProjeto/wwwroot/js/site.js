// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.close-alert').click(function () {
    $('.alert').hide('hide');

});
window.onload = function () {

    var form = document.getElementById("my_form");
    var onsubmit = function (event) {
        event.preventDefault();

        if (!validar()) {
            //chame as funções para valores não válidos
        } else {
            form.submit();
        }
    }

    form.addEventListener("submit", onsubmit);
}

function validar() {
    var campo1 = document.getElementById('Senha').value;
    var campo2 = document.getElementById('CSenha').value;

    if (campo1 != campo2) {
        alert('Senha e Confirmação estão diferentes , por favor insira Senhas iguais');
        return false; //Parar a execucao
    }
    return true;
}