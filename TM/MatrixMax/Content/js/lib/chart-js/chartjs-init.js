( function ( $ ) {
    "use strict";


    //bar chart
    var ctx = document.getElementById( "barChart" );
    //    ctx.height = 200;
    var myChart = new Chart( ctx, {
        type: 'bar',
        data: {
            labels: [ "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho" ],
            datasets: [
                {
                    label: "2018",
                    data: [ 65, 59, 80, 81, 56, 55, 40 ],
                    borderColor: "#4C9950",
                    borderWidth: "0",
                    backgroundColor: "#4CAF50"
                            },
                {
                    label: "2017",
                    data: [ 28, 48, 40, 19, 86, 27, 90 ],
                    borderColor: "rgba(0,0,0,0.09)",
                    borderWidth: "0",
                    backgroundColor: "rgba(0,0,0,0.07)"
                            }
                        ]
        },
        options: {
            scales: {
                yAxes: [ {
                    ticks: {
                        beginAtZero: true
                    }
                                } ]
            }
        }
    } );


    //pie chart
    var ctx = document.getElementById( "pieChart" );
    ctx.height = 300;
    var myChart = new Chart( ctx, {
        type: 'pie',
        data: {
            datasets: [ {
                data: [ 100, 300, 20 ],
                backgroundColor: [
                                    "#4CAF50",
                                    "#330000",
                                    "#CCCCCC"
                                ],
                hoverBackgroundColor: [
                                    "#4CAF50",
                                    "#330000",
                                    "#CCCCCC"
                                ]

                            } ],
            labels: [
                            "cartuchos",
                            "periféricos",
                            "toners"
                        ]
        },
        options: {
            responsive: true
        }
    } );



} )( jQuery );