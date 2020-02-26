const ESTADO = Object.freeze({ Ok: 1, Error: 0 });

function CargarSelectItem(selector, accion) {
    $.ajax({
        url: `${urlController}/${accion}`,
        type: 'GET',
        datatype: 'json'
    })
        .done(function (data) {
            $(`#${selector}`).empty().append('<option disabled selected>[Selecionar]</option>');
            $.each(data, function (key, item) {
                $(`#${selector}`).append(new Option(item.value, item.key));
            });
        })
        .fail(function (jqXHR, textStatus, errorThrown) {

        });
}

function ConvertFormToJSON(form) {
    var array = jQuery(form).serializeArray();
    var json = {};

    jQuery.each(array, function () {
        json[this.name] = this.value || '';
    });

    return json;
}