

$(function () {

    setTopbarDate();

});

// SET DATE
function setTopbarDate() {

    const today = new Date();

    const options = {

        day: 'numeric',
        month: 'numeric',
        year: 'numeric'
    };

    $('#topbar-date').text(

        today.toLocaleDateString('en-PH', options)
    );
}


function filterTable(inputId, tbodyId) {

    $(`#${inputId}`)

        // PREVENT DUPLICATE EVENTS
        .off('input')

        // SEARCH EVENT
        .on('input', function () {

            const value =

                $(this)
                    .val()
                    .toLowerCase();

            $(`#${tbodyId} tr`).each(function () {

                const rowText =

                    $(this)
                        .text()
                        .toLowerCase();

                // SHOW/HIDE ROW
                $(this).toggle(

                    rowText.includes(value)
                );
            });
        });
}