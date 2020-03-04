var urlController = '/equipamiento/Tipoequipo';
var tblTipoequipo;
$(function () {


    $("#btnGuardar").click(function () {

        var dataJson = $("#frmTipoequipo").values();
        var url = `${urlController}/Create`;
        if (dataJson.Tequicodi) {
            url = `${urlController}/Edit/${dataJson.Tequicodi}`;
        }

        $.ajax({
            url: url,
            type: 'POST',
            datatype: 'json',
            data: dataJson
        })
            .done(function (data, textStatus, jqXHR) {
                obtenerListaTopologia();
                toastr.success('Se ejecutó correctamente.', 'Éxito', { timeOut: 5000 });
                $('#modalTipoequipo').modal('hide');
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                toastrMensajeError(jqXHR);
                impimirErrorValidacion(jqXHR, "contentError");
            });
    });

    tblTipoequipo = $('#tblTipoequipo').DataTable({
        pageLength: 25,
        columns: [
            { data: "Tequicodi", width: "10%" },
            { data: "Tequinomb", width: "70%" },
            { data: "Tequiestado", width: "10%" },
            {
                width: "10%",
                render: function (data, type, row) {
                    return `<a onclick="editarTipoequipo(${row.Tequicodi});"><i class="fa fa-pencil-square-o text-warning"></i></a> <a onclick="eliminarTipoequipo(${row.Tequicodi});"><i class="fa fa-trash text-danger"></i></a>`;
                }
            }
        ],
        language: LanguejeSpanishDatatable,
        filter: false,
        info: false,
        paging: false
    });

    $("#cboEstado").change(function () {
        obtenerListaTopologia();
    });

    $('#modalTipoequipo').on('hidden.bs.modal', function (e) {
        limpiarFormulario();
    });

    obtenerListaTopologia();
});


function obtenerListaTopologia() {
    var valEstado = $("#cboEstado").val();

    $.ajax({
        url: `${urlController}/List`,
        type: 'GET',
        datatype: 'json',
        data: {
            estado: valEstado
        }
    })
        .done(function (data, textStatus, jqXHR) {
            tblTipoequipo.clear().draw();
            tblTipoequipo.rows.add(data.ListaSetipequipo).draw();
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            toastrMensajeError(jqXHR);
        });
}



function editarTipoequipo(id) {

    $("#modalTipoequipo").modal('show');

    $.get(`${urlController}/Details/${id}`)
        .done(function (data, textStatus, jqXHR) {
            limpiarFormulario();
            $("#frmTipoequipo").values(data.Setipequipo);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            toastrMensajeError(jqXHR);
        });
}


function eliminarTipoequipo(id) {
    $.confirm({
        title: 'Eliminar!',
        content: '¿Estás seguro?',
        buttons: {
            confirm: {
                text: 'Confirmar',
                btnClass: 'btn-primary',
                action: function () {

                    $.ajax({
                        type: "DELETE",
                        url: `${urlController}/Delete/${id}`
                    })
                        .done(function (data, textStatus, jqXHR) {
                            obtenerListaTopologia();
                            toastr.success('Se ejecutó correctamente.', 'Éxito', { timeOut: 5000 });
                        })
                        .fail(function (jqXHR, textStatus, errorThrown) {
                            toastrMensajeError(jqXHR);
                        });
                }
            },
            cancel: {
                text: 'Cancelar',
                btnClass: 'btn-danger'
            }
        }
    });
}

function limpiarFormulario() {
    $("#frmTipoequipo").trigger('reset');
    $("input[name=Tequicodi]").val(null);
}
