var tabelacategorias = $('#bootstrap-data-table-Categorias').DataTable(
    {
        dom: 'Biltp',
        select: true,
        "language":
            {
                "info": "Total: _TOTAL_ categoria(s) - Página _PAGE_ de _PAGES_.",
                "zeroRecords": "Nenhum resultado encontrado.",
                "infoEmpty": "Mostrando 0 categorias.",
                "infoFiltered": "(Filtrado de _MAX_ itens.)",
                "decimal": ",",
                "thousands": ".",
                "search": "",
                "loadingRecords": "Carregando...",
                "processing": "Processando...",
                "paginate": {
                    "first": "Primeira",
                    "last": "Última",
                    "next": "Próxima",
                    "previous": "Anterior"
                },
                "lengthMenu": "Categorias por página:  _MENU_",
                select: {
                    rows: {
                        _: "%d categorias selecionadas.",
                        0: "Clique em uma categoria para selecioná-la.",
                        1: "1 categoria selecionada."
                    }
                }
            },
        "ajax": {
            "url": "/Categoria/getCategorias",
            "type": "GET",
            "datatype": "json",
        },
        columns: [
            { data: "Id", visible: true, searchable: false, orderable: false },
            { data: "Nome", visible: true, searchable: true, orderable: true }
        ],
        buttons: [
            { extend: 'selected', text: '<button type="button" class="btn btn-success mb-1 rounded" id="BotaoAtivarCategorias" disabled>Ativar selecionadas <i class="fa fa-check"></i></button>' },
            { extend: 'selected', text: '<button type="button" class="btn btn-danger rounded" id="BotaoDesativarCategorias">Desativar selecionadas <i class="fa fa-ban"></i></button>' }
        ],
    }
);

var tabelasubcategorias = $('#bootstrap-data-table-Subcategorias').DataTable(
    {
        dom: 'Biltp',
        select: true,
        "language":
            {
                "info": "Total: _TOTAL_ subcategoria(s) - Página _PAGE_ de _PAGES_.",
                "zeroRecords": "Nenhum resultado encontrado.",
                "infoEmpty": "Mostrando 0 subcategorias.",
                "infoFiltered": "(Filtrado de _MAX_ itens.)",
                "decimal": ",",
                "thousands": ".",
                "search": "",
                "loadingRecords": "Carregando...",
                "processing": "Processando...",
                "paginate": {
                    "first": "Primeira",
                    "last": "Última",
                    "next": "Próxima",
                    "previous": "Anterior"
                },
                "lengthMenu": "Subcategorias por página:  _MENU_",
                select: {
                    rows: {
                        _: "%d subcategorias selecionadas.",
                        0: "Clique em uma subcategoria para selecioná-la.",
                        1: "1 subcategoria selecionada."
                    }
                }
            },
        "ajax": {
            "url": "/Categoria/getTodasAsSubcategorias",
            "type": "GET",
            "datatype": "json",
        },
        columns: [
            { data: "Id", visible: true, searchable: false, orderable: false },
            { data: "Nome", visible: true, searchable: true, orderable: true },
            { data: "Categoria", visible: true, searchable: false, orderable: false },
            { data: "CategoriaId", visible: false, searchable: true }
        ],
        buttons: [
            { extend: 'selected', text: '<button type="button" class="btn btn-success mb-1 rounded" id="BotaoAtivarSubcategorias" disabled>Ativar selecionadas <i class="fa fa-check"></i></button>' },
            { extend: 'selected', text: '<button type="button" class="btn btn-danger rounded" id="BotaoDesativarSubcategorias">Desativar selecionadas <i class="fa fa-ban"></i></button>' }
        ],
    }
);