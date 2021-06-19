$(document).ready(function () {
    $('.delCategoria').on('click', function () {
        var nomeDaCategoria = $(this).data("categoria")
        confirm("Deseja realmente excluir a categoria " + nomeDaCategoria + "?");
    });

    $('.delColaborador').on('click', function () {
        var nomeDoColaborador = $(this).data("colaborador")
        confirm("Deseja realmente excluir o colaborador " + nomeDoColaborador + "?");
    });
});