var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblConsumo").DataTable({
        "ajax": {
            "url": "/consumoDiarios/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "fechaString", "width": "20%" },
            { "data": "caloriasTotales", "width": "20%" },
            {
                "data": "consumoDiario_Id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/ConsumoDiarios/AdministrarConsumoDiario/${data}" class="btn btn-outline-primary" style="cursor:pointer; width:100px;">
                                <i class="far fa-edit"></i>
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Alimentos/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                <i class="far fa-trash-alt"></i>
                                </a>
                            </div>
                            `;
                }, "width": "30%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}


