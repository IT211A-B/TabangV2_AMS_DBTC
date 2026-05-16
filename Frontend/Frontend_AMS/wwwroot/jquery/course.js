$(document).ready(function () {

    loadCourses();

    // LOAD COURSES
    function loadCourses() {

        CourseApi.getAll(

            function (data) {

                renderTable(data);
            },

            function () {

                $('#courseTableBody').html(

                    '<tr>' +
                    '<td colspan="6" class="text-center text-danger py-3">' +
                    'Failed to load courses.' +
                    '</td>' +
                    '</tr>'
                );
            }
        );
    }

    // RENDER TABLE
    function renderTable(data) {

        const $tbody = $('#courseTableBody');

        $tbody.empty();

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

                '<td>' + (c.assignedTeacher || '—') + '</td>' +

                '<td>' + c.units + '</td>' +

                '<td>' +

                '<button class="btn btn-sm btn-warning me-1 btn-edit" ' +
                'data-id="' + c.id + '">' +
                'Edit' +
                '</button>' +

                '<button class="btn btn-sm btn-danger btn-delete" ' +
                'data-id="' + c.id + '" ' +
                'data-name="' + c.courseCode + ' — ' + c.courseName + '">' +
                'Delete' +
                '</button>' +

                '</td>' +

                '</tr>'
            );
        });
    }

    // CREATE MODAL
    $('#createModal').on('show.bs.modal', function () {

        $('#createCode').val('') || '';

        $('#createName').val('') || '';

        $('#createTeacher').val('') || '';

        $('#createUnits').val('') || '';

        $('#createError').text('').hide();
    });

    // SAVE CREATE
    $('#saveCreateBtn').on('click', function () {

        const code = $('#createCode')
            .val()
            .trim()
            .toUpperCase();

        const name = $('#createName')
            .val()
            .trim();

        const teacher = $('#createTeacher')
            .val()
            .trim();

        const units =
            parseInt($('#createUnits').val()) || 3;

        if (!code || !name) {

            $('#createError')
                .text('Course Code and Course Name are required.')
                .show();

            return;
        }

        $('#createError').hide();

        const payload = {

            courseCode: code,

            courseName: name,

            assignedTeacher: teacher,

            units: units
        };

        CourseApi.create(

            payload,

            function () {

                $('#createModal').modal('hide');

                loadCourses();
            },

            function () {

                $('#createError')
                    .text('Failed to create course.')
                    .show();
            }
        );
    });

    // EDIT BUTTON
    $(document).on('click', '.btn-edit', function () {

        const id = $(this).data('id');

        CourseApi.getById(

            id,

            function (c) {

                $('#editId').val(c.id);

                $('#editCode').val(c.courseCode);

                $('#editName').val(c.courseName);

                $('#editTeacher').val(c.assignedTeacher);

                $('#editUnits').val(c.units);

                $('#editError').text('').hide();

                $('#editModal').modal('show');
            },

            function () {

                alert('Could not load course data.');
            }
        );
    });

    // SAVE EDIT
    $('#saveEditBtn').on('click', function () {

        const id = $('#editId').val();

        const code = $('#editCode')
            .val()
            .trim()
            .toUpperCase();

        const name = $('#editName')
            .val()
            .trim();

        const teacher = $('#editTeacher')
            .val()
            .trim();

        const units =
            parseInt($('#editUnits').val()) || 3;

        if (!code || !name) {

            $('#editError')
                .text('Course Code and Course Name are required.')
                .show();

            return;
        }

        $('#editError').hide();

        const payload = {

            id: Number(id),

            courseCode: code,

            courseName: name,

            assignedTeacher: teacher,

            units: units
        };

        CourseApi.edit(

            id,

            payload,

            function () {

                $('#editModal').modal('hide');

                loadCourses();
            },

            function () {

                $('#editError')
                    .text('Failed to update course.')
                    .show();
            }
        );
    });

    // DELETE BUTTON
    $(document).on('click', '.btn-delete', function () {

        $('#deleteId').val($(this).data('id'));

        $('#deleteCourseName').text($(this).data('name'));

        $('#deleteModal').modal('show');
    });

    // CONFIRM DELETE
    $('#confirmDeleteBtn').on('click', function () {

        const id = $('#deleteId').val();

        CourseApi.remove(

            id,

            function () {

                $('#deleteModal').modal('hide');

                loadCourses();
            },

            function () {

                alert('Failed to delete course.');
            }
        );
    });

});