$(document).ready(function () {

    loadStudents();

    const yearMap = {

        '1': '1st Year',
        '2': '2nd Year',
        '3': '3rd Year',
        '4': '4th Year'
    };

    // LOAD STUDENTS
    function loadStudents() {

        StudentApi.getAll(

            function (data) {

                renderTable(data);
            },

            function () {

                $('#studentTableBody').html(

                    '<tr>' +
                    '<td colspan="7" class="text-center text-danger py-3">' +
                    'Failed to load students.' +
                    '</td>' +
                    '</tr>'
                );
            }
        );
    }

    // STATUS BADGE
    function statusBadge(status) {

        let cls =
            status === 'Present'
                ? 'badge-green'
                : status === 'Late'
                    ? 'badge-amber'
                    : 'badge-red';

        return '<span class="badge ' + cls + '">' + status + '</span>';
    }

    // COURSE BADGE
    function courseBadge(course) {

        return '<span class="badge badge-blue">' + course + '</span>';
    }

    // RENDER TABLE
    function renderTable(data) {

        const $tbody = $('#studentTableBody');

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

                '<td>' + courseBadge(s.course) + '</td>' +

                '<td>' +
                (yearMap[s.yearLevel] || s.yearLevel) +
                '</td>' +

                '<td>' + (s.email || '-') + '</td>' +

                '<td>' + statusBadge(s.status) + '</td>' +

                '<td>' +

                '<button class="btn btn-sm btn-warning me-1 btn-edit" ' +
                'data-id="' + s.id + '">' +
                'Edit' +
                '</button>' +

                '<button class="btn btn-sm btn-danger btn-delete" ' +
                'data-id="' + s.id + '" ' +
                'data-name="' + s.name + '">' +
                'Delete' +
                '</button>' +

                '</td>' +

                '</tr>'
            );
        });
    }

    // CREATE MODAL
    $('#createModal').on('show.bs.modal', function () {

        $('#createName').val('') || 'dominic';

        $('#createEmail').val('') || 'domsocarol@gmail.com';

        $('#createCourse').val('') || 'cs12';
        
        $('#createYear').val('') || '2nd year';

        $('#createStatus').val('') || 'Present';

        $('#createError').text('').hide();
    });

    // SAVE CREATE
    $('#saveCreateBtn').on('click', function () {

        const name =
            $('#createName').val().trim();

        const course =
            $('#createCourse').val();

        const year =
            $('#createYear').val();

        const email =
            $('#createEmail').val().trim();

        const status =
            $('#createStatus').val();

        if (!name || !course || !year || !status) {

            $('#createError')
                .text('Please fill in all required fields.')
                .show();

            return;
        }

        $('#createError').hide();

        const payload = {

            name: name,

            course: course,

            yearLevel: year,

            email: email,

            status: status
        };

        StudentApi.create(

            payload,

            function () {

                $('#createModal').modal('hide');

                loadStudents();
            },

            function () {

                $('#createError')
                    .text('Failed to add student.')
                    .show();
            }
        );
    });

    // EDIT BUTTON
    $(document).on('click', '.btn-edit', function () {

        const id = $(this).data('id');

        StudentApi.getById(

            id,

            function (s) {

                $('#editId').val(s.id);

                $('#editName').val(s.name);

                $('#editCourse').val(s.course);

                $('#editYear').val(s.yearLevel);

                $('#editEmail').val(s.email);

                $('#editStatus').val(s.status);

                $('#editError').text('').hide();

                $('#editModal').modal('show');
            },

            function () {

                alert('Could not load student data.');
            }
        );
    });

    // SAVE EDIT
    $('#saveEditBtn').on('click', function () {

        const id = $('#editId').val();

        const name =
            $('#editName').val().trim();

        const course =
            $('#editCourse').val();

        const year =
            $('#editYear').val();

        const email =
            $('#editEmail').val().trim();

        const status =
            $('#editStatus').val();

        if (!name || !course || !year || !status) {

            $('#editError')
                .text('Please fill in all required fields.')
                .show();

            return;
        }

        $('#editError').hide();

        const payload = {

            id: Number(id),

            name: name,

            course: course,

            yearLevel: year,

            email: email,

            status: status
        };

        StudentApi.edit(

            id,

            payload,

            function () {

                $('#editModal').modal('hide');

                loadStudents();
            },

            function () {

                $('#editError')
                    .text('Failed to update student.')
                    .show();
            }
        );
    });

    // DELETE BUTTON
    $(document).on('click', '.btn-delete', function () {

        $('#deleteId').val($(this).data('id'));

        $('#deleteStudentName').text($(this).data('name'));

        $('#deleteModal').modal('show');
    });

    // CONFIRM DELETE
    $('#confirmDeleteBtn').on('click', function () {

        const id = $('#deleteId').val();

        StudentApi.remove(

            id,

            function () {

                $('#deleteModal').modal('hide');

                loadStudents();
            },

            function () {

                alert('Failed to delete student.');
            }
        );
    });

});