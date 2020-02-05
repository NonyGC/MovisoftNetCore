var urlController = '/equipamiento/Seequipo';

$(function () {

    cargarComboBox("cboTipoequipo", "ObtenerListaTipoEquipos");
    //cargarComboBox("cboTipoequipo", "ObtenerListaTipoEquipos");
    //cargarComboBox("cboTipoequipo", "ObtenerListaTipoEquipos");
});

function cargarComboBox(selector, accion) {
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

