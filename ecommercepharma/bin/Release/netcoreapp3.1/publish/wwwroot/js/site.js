// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {

    function showDataItem(data) {
        var target = $('#itemData');
        target.empty();
        target.show();
        target.append('<table>');
        if (data.items.length > 0) {
            data.items.forEach((item) => {
                target.append('<tr><td>Nombre articulo: </td><td>' + item.name + '</td></tr>');
                target.append('<tr><td>Precio : </td><td>' + item.price + 'C$</td></tr>');
                target.append('<tr><td>Cantidad disponible : </td><td>' + item.stock + '</td></tr>');
                target.append('<tr><td>Descripcion: </td><td>' + item.description + '</td></tr>');
                target.append('<tr><td>Detalles : </td><td>' + item.detail + '</td></tr>');
            });
        } else {
            target.append('<div>No existen articulos por el momento</div>');
        }
        target.append('</table>');
    }

    //$.ajax({
    //    url: '/Home/GetItemList',
    //    type: 'GET',
    //    beforeSend: function () {
    //        $('#itemData').hide();
    //        $('#loadingItemData').show();
    //    },
    //    complete: function () {
    //        $('#loadingItemData').hide();
    //    },
    //    success: function (data) {
    //        if (data) {
    //            showDataItem(data);
    //        } else {

    //        }
    //    }
    //});
});
