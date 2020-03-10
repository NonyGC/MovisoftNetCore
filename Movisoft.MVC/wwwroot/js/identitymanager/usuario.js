﻿$(function () {
    $('#usersTable').DataTable({
        dom: 'Bfrtip',
        select: true,
        buttons: [
            {
                text: "Nuevo",
                action: function (e, dt, button, config) {
                    $('#userError').hide();
                    $('#userForm').trigger('reset');
                    $('#userModal').modal({ backdrop: 'static' });
                }
            },
            {
                extend: "selectedSingle",
                text: "Editar",
                action: function (e, dt, button, config) {
                    var data = dt.row({ selected: true }).data();
                    $('#editError').hide();
                    $('#tabs a:first').tab('show');
                    $('#editForm').trigger('reset');
                    $('#claimsTable tbody tr:not(:first)').remove();

                    $('#editForm input[name=Email]').val(data.Email);
                    $('#editForm input[name=Locked]').prop('checked', data.LockedOut);
                    $('#editForm input[name=Id]').val(data.Id);

                    $.each(data.Roles, function (index, value) {
                        $('#editForm :checkbox[value=' + value + ']').prop('checked', true);
                    });

                    $.each(data.Claims, function (index, value) {
                        $('#claimsTable tbody').append('<tr><td data-field="Key">' + value.Key + '</td>' +
                            '<td data-field="Value">' + value.Value + '</td><td><a class="removeClaim btn btn-sm btn-danger" href="#">Remover</a></td></tr>');
                    });

                    $('#editModal').modal({ backdrop: 'static' });
                }
            },
            {
                extend: "selectedSingle",
                text: "Eliminar",
                action: function (e, dt, button, config) {

                    $.confirm({
                        title: 'Eliminar!',
                        content: '¿Estás seguro?',
                        buttons: {
                            confirm: {
                                text: 'Confirmar',
                                btnClass: 'btn-primary',
                                action: function () {

                                    var data = dt.row({ selected: true }).data();

                                    $.ajax({
                                        type: 'DELETE',
                                        url: '/api/DeleteUser',
                                        data: { id: data.Id }
                                    })
                                        .done(delDone)
                                        .fail(delFail);
                                }
                            },
                            cancel: {
                                text: 'Cancelar',
                                btnClass: 'btn-danger'
                            }
                        }
                    });

                }
            },
            {
                extend: "selectedSingle",
                text: "Password",
                action: function (e, dt, button, config) {
                    var data = dt.row({ selected: true }).data();
                    $('#pwdError').hide();
                    $('#pwdForm').trigger('reset');
                    $('#pwdForm input[name=Id]').val(data.Id);
                    $('#pwdModal').modal({ backdrop: 'static' });
                }
            }
        ],
        "createdRow": function (row, data) {
            if (data.LockedOut)
                $(row).addClass('table-danger');
        },
        language: LanguejeSpanishDatatable
    });

    $("#btnAdd").click(function () {
        $("#userForm").submit();
    });

    $("#btnEdit").click(function () {
        $("#editForm").submit();
    });

    $("#btnPass").click(function () {
        $("#pwdForm").submit();
    });
});

$('#claimsTable').on('click', 'a.removeClaim', function () {
    if (confirm('Are you sure?'))
        $(this).closest('tr').remove();
});

$('#addClaim').click(function () {
    if ($('#newType').val() && $('#newValue').val()) {
        $('#claimsTable tbody').append('<tr><td data-field="key">' + $('#newType').val() + '</td>' +
            '<td data-field="value">' + $('#newValue').val() + '</td><td><a class="removeClaim btn btn-sm btn-danger" href="#">Remover</a></td></tr>');
        $('#newType, #newValue').val('');
    }
    else
        alert('Incomplete entry');
});

$("#editForm").submit(function () {
    $('#claimsTable tbody tr:gt(0)').each(function (index, elem) {
        var key = $(this).find('td[data-field=key]');
        key.append($('<input>').attr('name', 'claims[' + index + '][key]').attr('type', 'hidden').val(key.text()));

        var val = $(this).find('td[data-field=value]');
        val.append($('<input>').attr('name', 'claims[' + index + '][value]').attr('type', 'hidden').val(val.text()));
    });
});

function userDone(data, status, xhr) {
    $('#userModal').modal('hide');
    $('#usersTable').DataTable().draw();
}

function userFail(xhr, status, error) {
    $('#userError').html(xhr.responseText || error).fadeIn();
}

function editDone(data, status, xhr) {
    $('#editModal').modal('hide');
    $('#usersTable').DataTable().draw();
}

function editFail(xhr, status, error) {
    $('#editError').html(xhr.responseText || error).fadeIn();
    $('#claimsTable input[type="hidden"]').remove();
}

function delDone(data, status, xhr) {
    $('#usersTable').DataTable().draw();
}

function delFail(xhr, status, error) {
    alert(xhr.responseText || error);
}

function pwdDone(data, status, xhr) {
    $('#pwdModal').modal('hide');
}

function pwdFail(xhr, status, error) {
    $('#pwdError').html(xhr.responseText || error).fadeIn();
}