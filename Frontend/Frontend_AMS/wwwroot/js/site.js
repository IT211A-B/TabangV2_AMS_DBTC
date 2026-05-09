//top bar date function
$(document).ready(function () {

    var today = new Date();
    var options = { day: 'numeric', month: 'numeric', year: 'numeric', };
    $('#topbar-date').text(today.toLocaleDateString('en-PH', options));
});

function filterTable(inputId, tbodyId) {
    $('#' + inputId).on('keyup', function () {
        var value = $(this).val().toLowerCase();
        $('#' + tbodyId + ' tr').each(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });
}