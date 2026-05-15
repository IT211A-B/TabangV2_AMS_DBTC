window.Student = (function () {

    var yearMap = {
        '1': '1st Year',
        '2': '2nd Year',
        '3': '3rd Year',
        '4': '4th Year'
    };

    function statusBadge(status) {
        var cls = status === 'Present' ? 'badge-green' :
            status === 'Late' ? 'badge-amber' :
                'badge-red';
        return '<span class="badge ' + cls + '">' + status + '</span>';
    }

    function courseBadge(course) {
        return '<span class="badge badge-blue">' + course + '</span>';
    }

    function renderTable(data) {

        var $tbody = $('#studentTableBody');

        $tbody.empty();

        if (!data || data.length === 0) {

            $tbody.html(
                '<tr>' +
                '<td colspan="7" class="text-center text-muted py-3">' +
                'No students found.' +
                '</td>' +
                '</tr>'
            );

            return;
        }

        $.each(data, function (i, s) {

            $tbody.append(
                '<tr>' +
                '<td>' + s.id + '</td>' +

                '<td>' +
                '<strong>' + s.name + '</strong>' +
                '</td>' +

                '<td>' +
                courseBadge(s.course) +
                '</td>' +

                '<td>' +
                (yearMap[s.yearLevel] || s.yearLevel) +
                '</td>' +

                '<td>' +
                s.email +
                '</td>' +

                '<td>' +
                statusBadge(s.status) +
                '</td>' +

                '<td>' +
                '<button class="btn btn-sm btn-warning me-1 btn-edit" data-id="' + s.id + '">' +
                'Edit' +
                '</button>' +

                '<button class="btn btn-sm btn-danger btn-delete" data-id="' + s.id + '" data-name="' + s.name + '">' +
                'Delete' +
                '</button>' +
                '</td>' +
                '</tr>'
            );

        });
    }
    function load() {

        $.ajax({
            url: 'http://localhost:5294/api/Student',
            type: 'GET',

            success: function (data) {
                renderTable(data);
            },

            error: function () {

                $('#studentTableBody').html(
                    '<tr>' +
                    '<td colspan="7" class="text-center text-muted">' +
                    'Failed to load students.' +
                    '</td>' +
                    '</tr>'
                );

            }
        });
    }

    function getById(id, callback) {

        $.ajax({
            url: 'http://localhost:5294/api/Student/' + id,
            type: 'GET',

            success: function (data) {
                callback(data);
            },

            error: function () {
                alert('Could not load student data.');
            }
        });
    }

    function create(payload, onSuccess, onError) {

        $.ajax({
            url: 'http://localhost:5294/api/Student',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(payload),

            success: function (res) {

                if (res.success) {
                    onSuccess();
                    load();
                }

            },

            error: function () {
                onError('Failed to add student.');
            }
        });
    }

    function edit(payload, onSuccess, onError) {

        $.ajax({
            url: 'http://localhost:5294/api/Student',
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(payload),

            success: function (res) {

                if (res.success) {
                    onSuccess();
                    load();
                }

            },

            error: function () {
                onError('Failed to update student.');
            }
        });
    }

    function remove(id, onSuccess) {

        $.ajax({
            url: 'http://localhost:5294/api/Student/' + id,
            type: 'DELETE',

            success: function (res) {

                if (res.success) {
                    onSuccess();
                    load();
                }

            },

            error: function () {
                alert('Failed to delete student.');
            }
        });
    }

    });
    return {
        load: load,
        getById: getById,
        create: create,
        edit: edit,
        remove: remove,
        renderTable: renderTable
    };

})();