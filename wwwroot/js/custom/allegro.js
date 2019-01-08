﻿$(document).ready(function () {

    $("#maincategories").change(function () {
        $('#category2').find('option').remove().end().append('<option  selected=""> - Wybierz kateogrię - </option>').val('kategoria');
        var url = '@Url.Content("~/")' + 'AllegroAuctions/GetChildCategories';
        var ddlsource = "#mark";

        $.getJSON(url, { id: $('#maincategories').val() }, function (data) {
            var items = ' ';
            $("#category2").empty();
            $.each(data, function (i, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $('#category2').html(items);
        })
    });

});