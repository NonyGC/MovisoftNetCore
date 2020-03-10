const ESTADO = Object.freeze({ Ok: 1, Error: 0 });

const LanguejeSpanishDatatable = {
    "sProcessing": "Procesando...",
    "sLengthMenu": "Mostrar _MENU_ registros",
    "sZeroRecords": "No se encontraron resultados",
    "sEmptyTable": "Ningún dato disponible en esta tabla",
    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
    "sInfoPostFix": "",
    "sSearch": "Buscar:",
    "sUrl": "",
    "sInfoThousands": ",",
    "sLoadingRecords": "Cargando...",
    "oPaginate": {
        "sFirst": "Primero",
        "sLast": "Último",
        "sNext": "Siguiente",
        "sPrevious": "Anterior"
    },
    "oAria": {
        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
    },
    "buttons": {
        "copy": "Copiar",
        "colvis": "Visibilidad"
    }
};

/**
 * Permite llenar select items
 * @param {any} selector selector
 * @param {any} accion accion del controlador
 */
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
            toastrMensajeError(jqXHR);
        });
}


/**
 * obtiene o establece todos los pares de nombre / valor de los controles de entrada secundarios
 * @param {any} data Si se incluye, completará todos los controles secundarios
 * @returns {any} elemento si se proporcionaron datos, o matriz de valores si no.
 */
$.fn.values = function (data) {
    var inps = $(this).find(":input").get();

    if (typeof data != "object") {
        // return all data
        data = {};

        $.each(inps, function () {
            if (this.name && (this.checked
                || /select|textarea/i.test(this.nodeName)
                || /text|hidden|password/i.test(this.type))) {
                data[this.name] = $(this).val();
            }
        });
        return data;
    } else {
        $.each(inps, function () {
            if (this.name && data[this.name]) {
                if (this.type == "checkbox" || this.type == "radio") {
                    $(this).prop("checked", (data[this.name] == $(this).val()));
                } else {
                    $(this).val(data[this.name]);
                }
            } else if (this.type == "checkbox") {
                $(this).prop("checked", false);
            }
        });
        return $(this);
    }
};

/**
 * Permite mostrar el error mediante una notificación
 * @param {any} jqXHR objeto XMLHTTPRequest
 */
function toastrMensajeError(jqXHR) {

    switch (jqXHR.status) {
        case 500:
            toastr.error("Error interno del servidor, la ejecución del proceso no finalizó.", 'Error!');
            console.log(jqXHR.responseJSON);
            break;
        case 400:
            toastr.error("No se puede procesar la data enviada, debido a algo que es percibido como un error del cliente", 'Error!');
            break;
        case 401:
            toastr.error("No autorizado", 'Acceso denegado!');
            break;
        case 404:
            toastr.error("No se puede conectar con los servicios.", 'Error!');
            break;
        default:
            toastr.error("Error interno del servidor.", 'Error!');
    }
}

/**
 * Imprimir errores de validacion
 * @param {any} jqXHR objeto XMLHTTPRequest
 * @param {any} content Id Content
 */
function impimirErrorValidacion(jqXHR, content) {

    if (jqXHR.status !== 400) return;

    var responseJson = jqXHR.responseJSON;

    if (responseJson) {
        if (responseJson.hasOwnProperty('IsValid')) {
            if (!responseJson.IsValid) {
                var alertHtml = '<div class="alert alert-danger alert-dismissable"> <button aria-hidden="true" data-dismiss="alert" class="close" type = "button">×</button>';
                alertHtml += '<ul>';
                $.each(responseJson.Errors, function (key, value) {
                    alertHtml += `<li>${value.ErrorMessage}</li>`;
                });
                alertHtml += '</ul> </div>';
                $(`#${content}`).html(alertHtml);
            }
        }
    }
}
