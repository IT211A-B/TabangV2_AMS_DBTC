window.Course = (function () {

    // RENDER TABLE
    function renderTable(data) {

        var $tbody = $('#courseTableBody');

        $tbody.empty();

        // NO DATA
        if (!data || data.length === 0) {

            $tbody.html(
                '<tr>' +
                '<td colspan="6" class="text-center text-muted py-3">' +
                'No courses found.' +
                '</td>' +
                '</tr>'
            );

            return;
        }

        // LOOP DATA
        $.each(data, function (i, c) {

            $tbody.append(
                '<tr>' +

                '<td>' + c.id + '</td>' +

                '<td>' +
                '<span class="badge bg-primary">' +
                c.courseCode +
                '</span>' +
                '</td>' +

                '<td>' +
                '<strong>' + c.courseName + '</strong>' +
                '</td>' +

                '<td>' +
                (c.assignedTeacher || '—') +
                '</td>' +

                '<td>' +
                c.units +
                '</td>' +

                '<td>' +

                '<button class="btn btn-sm btn-warning me-1 btn-edit" data-id="' + c.id + '">' +
                'Edit' +
                '</button>' +

                '<button class="btn btn-sm btn-danger btn-delete" data-id="' + c.id + '" data-name="' + c.courseCode + ' — ' + c.courseName + '">' +
                'Delete' +
                '</button>' +

                '</td>' +

                '</tr>'
            );

        });
    }

    // LOAD ALL COURSES
    function load() {

        $.ajax({
            url: 'http://localhost:5294/api/Course',
            type: 'GET',

            success: function (data) {
                renderTable(data);
            },

            error: function () {

                $('#courseTableBody').html(
                    '<tr>' +
                    '<td colspan="6" class="text-center text-muted">' +
                    'Failed to load courses.' +
                    '</td>' +
                    '</tr>'
                );

            }
        });
    }

    // GET COURSE BY ID
    function getById(id, callback) {

        $.ajax({
            url: 'http://localhost:5294/api/Course/' + id,
            type: 'GET',

            success: function (data) {
                callback(data);
            },

            error: function () {
                alert('Could not load course data.');
            }
        });
    }

    // CREATE COURSE
    function create(payload, onSuccess, onError) {

        $.ajax({
            url: 'http://localhost:5294/api/Course',
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
                onError('Failed to create course.');
            }
        });
    }

    // EDIT COURSE
    function edit(payload, onSuccess, onError) {

        $.ajax({
            url: 'http://localhost:5294/api/Course',
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
                onError('Failed to update course.');
            }
        });
    }

    function remove(id, onSuccess) {

        $.ajax({
            url: 'http://localhost:5294/api/Course' + id,
            type: 'DELETE',

            success: function (res) {

                if (res.success) {
                    onSuccess();
                    load();
                }

            },

            error: function () {
                alert('Failed to delete course.');
            }
        });
    }

    // INITIAL LOAD
    $(document).ready(function () {

        load();

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