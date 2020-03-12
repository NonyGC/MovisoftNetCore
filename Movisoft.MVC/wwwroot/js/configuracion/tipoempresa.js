var urlController = '/Configuracion/Tipoempresa';
var tblPrincipal;
$(function () {


    $("#btnGuardar").click(function () {
        $(this).attr("disabled", true);
        guardar();
    });

    tblPrincipal = $('#tblPrincipal').DataTable({
        pageLength: 25,
        columns: [
            { data: "Tempcodi", width: "10%" },
            { data: "Tempdesc", width: "70%" },
            { data: "Tempabrev", width: "10%" },
            {
                width: "10%",
                render: function (data, type, row) {
                    return `<a onclick="editar(${row.Tempcodi});"><i class="fa fa-pencil-square-o text-warning"></i></a> <a onclick="eliminar(${row.Tempcodi});"><i class="fa fa-trash text-danger"></i></a>`;
                }
            }
        ],
        language: LanguejeSpanishDatatable,
        filter: false,
        info: false,
        paging: false
    });


    $('#modal').on('hidden.bs.modal', function (e) {
        limpiarFormulario();
    });
    $('#modal').on('shown.bs.modal', function () {
        $("#btnGuardar").attr("disabled", false);
    });

    listar();
});

function listar() {
    $.ajax({
        url: `${urlController}/List`,
        type: 'GET',
        datatype: 'json'
    })
        .done(function (data, textStatus, jqXHR) {
            tblPrincipal.clear().draw();
            tblPrincipal.rows.add(data).draw();
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            toastrMensajeError(jqXHR);
        });
}

function guardar() {

    var dataJson = $("#frmModal").values();
    var url = `${urlController}/Create`;
    if (dataJson.Tempcodi) {
        url = `${urlController}/Edit/${dataJson.Tempcodi}`;
    }
    $.ajax({
        url: url,
        type: 'POST',
        datatype: 'json',
        data: dataJson
    })
        .done(function(data, textStatus, jqXHR) {
            listar();
            toastr.success('Se ejecutó correctamente.', 'Éxito', { timeOut: 5000 });
            $('#modal').modal('hide');
        })
        .fail(function(jqXHR, textStatus, errorThrown) {
            toastrMensajeError(jqXHR);
            impimirErrorValidacion(jqXHR, "contentError");
        });
}

function editar(id) {

    $("#modal").modal('show');

    $.get(`${urlController}/Details/${id}`)
        .done(function (data, textStatus, jqXHR) {
            limpiarFormulario();
            $("#frmModal").values(data);
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            toastrMensajeError(jqXHR);
        });
}

function eliminar(id) {
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
                        url: `${urlController}/Delete/${id}`,
                        data: {
                            __RequestVerificationToken: getRequestVerificationToken()
                        }

                    })
                        .done(function (data, textStatus, jqXHR) {
                            listar();
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
    $("#frmModal").trigger('reset');
    $("input[name=Tempcodi]").val(null);
}