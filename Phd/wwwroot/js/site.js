// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function setDictionaryLists(url, idElement) {
    $.getJSON(url, function (data) {
        var html = '';
        var len = data.length;
        for (var i = 0; i < len; i++) {
            html += '<option value="' + data[i].id + '">' + data[i].orderNumber + '</option>';
        }
        $(idElement).append(html);
    });
}

function setMajors(url, idElement) {
    $.getJSON(url, function (data) {
        var html = '';
        var len = data.length;
        for (var i = 0; i < len; i++) {
            html += '<option value="' + data[i].majorCypher + '">' + data[i].majorCypher + '</option>';
        }
        $(idElement).append(html);
    });
}