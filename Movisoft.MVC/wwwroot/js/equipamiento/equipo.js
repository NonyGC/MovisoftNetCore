var urlController = '/equipamiento/Equipo';

$(function () {


    $("#btnGuardar").click(function () {

        var dataJson = ConvertFormToJSON("#frmEquipo");
        $.ajax({
            url: `${urlController}/Create`,
            type: 'POST',
            datatype: 'json',
            data: dataJson
        })
            .done(function (data, textStatus, jqXHR) {

                if (ESTADO.Ok === data.Estado) {
                    // Override global options
                    toastr.success('We do have the Kapua suite available.', 'Turtle Bay Resort', { timeOut: 5000 });
                }

            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                toastr.error('I do not think that word means what you think it means.', 'Inconceivable!');
            });
    });
});


