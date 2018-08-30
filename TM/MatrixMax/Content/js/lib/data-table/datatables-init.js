(function ($) {
    //    "use strict";


    /*  Data Table
    -------------*/




    $('#bootstrap-data-table').DataTable({
        dom: 'Bfrtip',
        paging: false,
        select: {
            style: 'single',
            info: false
        },
        buttons: [
            { text: '<button type="button" class="btn btn-secondary mb-1" data-toggle="modal" data-target="#ModalAdicionar">Adicionar <i class="fa fa-plus-circle"></i></button>' },
            { extend: 'selectedSingle', text: '<button type="button" class="btn btn-secondary mb-1" data-toggle="modal" data-target="#ModalEditar">Editar <i class="fa fa-edit"></i></button>' },
            { extend: 'selectedSingle', text: '<button type="button" class="btn btn-secondary mb-1" data-toggle="modal" data-target="#ModalRemover" onclick="pegaDados()">Desativar <i class="fa fa-minus-circle"></i></button>' }
        ],
        "language":
            {
                "info": "Mostrando _TOTAL_ produto(s).",
                "zeroRecords": "Nenhum resultado encontrado.",
                "infoEmpty": "Mostrando 0 produtos.",
                "infoFiltered": "(Filtrado de _MAX_ itens.)",
                "decimal": ",",
                "thousands": ".",
                "search": "Buscar produto pelo nome: ",
                "loadingRecords": "Carregando...",
                "processing": "Processando..."
            },
        "ajax": {
            "url": "/Produto/getProdutos",
            "type": "GET",
            "datatype": "json",
        },
        columns: [
            { data: "Id", visible: false, searchable: false },
            { data: "Nome" },
            { data: "PrecoUnitario", searchable: false },
            { data: "Marca.Nome", searchable: false },
            { data: "Estoque", searchable: false },
            {
                data: "Subcategoria.Nome",
                searchable: false,
                render: function (data, type, row) {
                    return row.Subcategoria.CategoriaDaSubcategoria.Nome + " - " + row.Subcategoria.Nome;
                }
            },
        ],
        lengthMenu: [[10, 20, 50, -1], [10, 20, 50, "All"]],
    });



    $('#bootstrap-data-table-export').DataTable({
        dom: 'lBfrtip',
        lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]
    });

    $('#row-select').DataTable({
        initComplete: function () {
            this.api().columns().every(function () {
                var column = this;
                var select = $('<select class="form-control"><option value=""></option></select>')
                    .appendTo($(column.footer()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
            });
        }
    });






})(jQuery);