(function ($) {
    //    "use strict";


    /*  Data Table
    -------------*/




    $('#bootstrap-data-table').DataTable({
        dom: '<Bf<t>ilp>',
        //paging: false,
        select: {
            style: 'single',
            info: false
        },
        buttons: [
            { text: '<button type="button" class="btn btn-secondary mb-1" data-toggle="modal" data-target="#ModalAdicionar">Adicionar <i class="fa fa-plus-circle"></i></button>' },
            { extend: 'selectedSingle', text: '<button type="button" class="btn btn-secondary mb-1" data-toggle="modal" data-target="#ModalEditar" onclick="populaEditar()">Editar <i class="fa fa-edit"></i></button>' },
            { extend: 'selectedSingle', text: '<button type="button" class="btn btn-secondary mb-1" data-toggle="modal" data-target="#ModalRemover" onclick="pegaDados()">Desativar <i class="fa fa-minus-circle"></i></button>' }
        ],
        "language":
            {
                "info": "Total: _TOTAL_ produto(s) - Página _PAGE_ de _PAGES_.",
                "zeroRecords": "Nenhum resultado encontrado.",
                "infoEmpty": "Mostrando 0 produtos.",
                "infoFiltered": "(Filtrado de _MAX_ itens.)",
                "decimal": ",",
                "thousands": ".",
                "search": "Buscar produto pelo nome: ",
                "loadingRecords": "Carregando...",
                "processing": "Processando...",
                "paginate": {
                    "first": "Primeira",
                    "last": "Última",
                    "next": "Próxima",
                    "previous": "Anterior"
                },
                "lengthMenu": "Mostrar _MENU_ itens por página.",
            },
        "ajax": {
            "url": "/Produto/getProdutos",
            "type": "GET",
            "datatype": "json",
        },
        columns: [
            { data: "Id", visible: false, searchable: false },
            { data: "Subcategoria.CategoriaId", visible: false, searchable: false },
            { data: "SubcategoriaId", visible: false, searchable: false },
            { data: "PrecoRecarga", visible: false, searchable: false },
            { data: "PrecoTroca", visible: false, searchable: false },
            { data: "MarcaId", visible: false, searchable: false },
            { data: "Nome" },
            {
                data: "PrecoUnitario",
                searchable: false,
                orderable: false,
                render: function (data, type, row) {
                    if (row.PrecoRecarga != null && row.PrecoTroca != null) {
                        return row.PrecoUnitario + " - " + row.PrecoRecarga + " - " + row.PrecoTroca;
                    }
                    else {
                        return row.PrecoUnitario;
                    }
                }
            },
            { data: "Marca.Nome", searchable: false, orderable: false },
            { data: "Estoque", searchable: false, orderable: false },
            {
                data: "Subcategoria.Nome",
                searchable: false,
                orderable: false,
                render: function (data, type, row) {
                    return row.Subcategoria.CategoriaDaSubcategoria.Nome + " - " + row.Subcategoria.Nome;
                }
            },
        ],
        //lengthMenu: [[10, 20, 50, -1], [10, 20, 50, "All"]],
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