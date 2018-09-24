var tabelamarcas = $('#bootstrap-data-table-Marcas').DataTable(
    {
        dom: 'Biltp',
        select: true,
        "language":
            {
                "info": "Total: _TOTAL_ marcas(s) - Página _PAGE_ de _PAGES_.",
                "zeroRecords": "Nenhum resultado encontrado.",
                "infoEmpty": "Mostrando 0 marcas.",
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
                "lengthMenu": "Marcas por página:  _MENU_",
                select: {
                    rows: {
                        _: "%d marcas selecionadas.",
                        0: "Clique em uma marca para selecioná-la.",
                        1: "1 marca selecionada."
                    }
                }
            },
        "ajax": {
            "url": "/Marca/getMarcas",
            "type": "GET",
            "datatype": "json",
        },
        columns: [
            { data: "Id", visible: true, searchable: false, orderable: false },
            { data: "Nome", visible: true, searchable: true, orderable: true }
        ],
        buttons: [
            { extend: 'selected', text: '<button type="button" class="btn btn-success mb-1 rounded" id="BotaoAtivarMarcas" disabled>Ativar selecionadas <i class="fa fa-check"></i></button>' },
            { extend: 'selected', text: '<button type="button" class="btn btn-danger rounded" id="BotaoDesativarMarcas">Desativar selecionadas <i class="fa fa-ban"></i></button>' }
        ],
    }
);