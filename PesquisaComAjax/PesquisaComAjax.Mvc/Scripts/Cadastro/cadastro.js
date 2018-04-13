function OnSuccess(data) {
    var dados = JSON.parse(data);

    $("#divErros").append('<ul id="erros"></ul>')

    if (dados[0].Errors != undefined) {
        for (var i = 0; i < dados.length; ++i) {
            $("#erros").append('<li>' + dados[i].Errors[0].ErrorMessage + '</li>');
        }

        return;
    }
    
    document.forms[0].reset()
    $("#erros").remove()
    toastr.success(dados, 'Aplicação');
};

// <script src="~/Scripts/jquery.unobtrusive-ajax.js"></script>