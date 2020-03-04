var urlController = '/equipamiento/Equipo';
var tblTipoequipo;
$(function () {


    $("#btnGuardar").click(function () {

        var dataJson = $("#frmEquipo").values();
        var url = `${urlController}/Create`;
        if (dataJson.Equicodi) {
            url = `${urlController}/Edit/${dataJson.Equicodi}`;
        }

        $.ajax({
            url: url,
            type: 'POST',
            datatype: 'json',
            data: dataJson
        })
            .done(function (data, textStatus, jqXHR) {
                obtenerListaEquipos();
                toastr.success('Se ejecutó correctamente.', 'Éxito', { timeOut: 5000 });
                $('#modalEquipo').modal('hide');
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                toastrMensajeError(jqXHR);
                impimirErrorValidacion(jqXHR, "contentError");

            });

    });

    tblTipoequipo = $('#tblEquipo').DataTable({
        pageLength: 25,
        columns: [
            { data: "Equicodi", width: "5%" },
            { data: "Equinombre", width: "20%" },
            { data: "Equiabrev", width: "10%" },
            { data: "Topnombre", width: "20%" },
            { data: "Tequinomb", width: "20%" },
            { data: "Emprnomb", width: "20%" },
            {
                render: function (data, type, row) {
                    return `<a onclick="editarEquipo(${row.Equicodi});"><i class="fa fa-pencil-square-o text-warning"></i></a> <a onclick="eliminarEquipo(${row.Equicodi});"><i class="fa fa-trash text-danger"></i></a>`;
                }
            }
        ],
        language: LanguejeSpanishDatatable,
        filter: false,
        info: false,
        paging: false
    });

    $("#cboEstado").change(function () {
        obtenerListaEquipos();
    });

    $('#modalEquipo').on('hidden.bs.modal', function (e) {
        limpiarFormulario();
    });

    obtenerListaEquipos();
});


function obtenerListaEquipos() {
    var valEstado = $("#cboEstado").val();

    $.ajax({
        url: `${urlController}/ListaEquipos`,
        type: 'GET',
        datatype: 'json',
        data: {
            estado: valEstado
        }
    })
        .done(function (data, textStatus, jqXHR) {
            var lstEquipo = ListEquipotDTOtoDatattable(data.ListaSeequipo);
            tblTipoequipo.clear().draw();
            tblTipoequipo.rows.add(lstEquipo).draw();
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            toastrMensajeError(jqXHR);
        });
}

function ListEquipotDTOtoDatattable(lstEquipo) {
    var array = new Array();
    jQuery.each(lstEquipo, function () {
        array.push({
            Equicodi: this.Equicodi,
            Equinombre: this.Equinombre,
            Equiabrev: this.Equiabrev,
            Topnombre: this.Setopologia.Topnombre,
            Tequinomb: this.Setipequipo.Tequinomb,
            Emprnomb: this.Siempresa.Emprnomb
        });
    });
    return array;
}

function editarEquipo(id) {

    $("#modalEquipo").modal('show');

    $.get(`${urlController}/Details/${id}`)
        .done(function (data, textStatus, jqXHR) {
            limpiarFormulario();
            $("#frmEquipo").values(data.Seequipo);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            toastrMensajeError(jqXHR);
        });
}


function eliminarEquipo(id) {
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
                            obtenerListaEquipos();
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
    $("#frmEquipo").trigger('reset');
    $("input[name=Equicodi]").val(null);
}
