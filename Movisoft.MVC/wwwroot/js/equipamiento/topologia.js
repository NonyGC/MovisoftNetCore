var urlController = '/equipamiento/Topologia';
var tblTipoequipo;
$(function () {


    $("#btnGuardar").click(function () {

        var dataJson = $("#frmTopologia").values();
        var url = `${urlController}/Create`;
        if (dataJson.Topcodi) {
            url = `${urlController}/Edit/${dataJson.Topcodi}`;
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
                $('#modalTopologia').modal('hide');
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                toastrMensajeError(jqXHR);
                impimirErrorValidacion(jqXHR, "contentError");
            });
    });

    tblTipoequipo = $('#tblTopologia').DataTable({
        pageLength: 25,
        columns: [
            { data: "Topcodi", width: "10%" },
            { data: "Topnombre", width: "70%" },
            { data: "Topestado", width: "10%" },
            {
                width: "10%",
                render: function (data, type, row) {
                    return `<a onclick="editarTopologia(${row.Topcodi});"><i class="fa fa-pencil-square-o text-warning"></i></a> <a onclick="eliminarTopologia(${row.Topcodi});"><i class="fa fa-trash text-danger"></i></a>`;
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

    $('#modalTopologia').on('hidden.bs.modal', function (e) {
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
            tblTipoequipo.rows.add(data.ListaSetopologia).draw();
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            toastrMensajeError(jqXHR);
        });
}



function editarTopologia(id) {

    $("#modalTopologia").modal('show');

    $.get(`${urlController}/Details/${id}`)
        .done(function (data, textStatus, jqXHR) {
            limpiarFormulario();
            $("#frmTopologia").values(data.Setopologia);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            toastrMensajeError(jqXHR);
        });
}


function eliminarTopologia(id) {
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
    $("#frmTopologia").trigger('reset');
    $("input[name=Topcodi]").val(null);
}
