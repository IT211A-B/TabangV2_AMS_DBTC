$(document).ready(function () {

    loadTeachers();

    // LOAD TEACHERS
    function loadTeachers() {

        TeacherApi.getAll(

            function (data) {

                renderTable(data);
            },

            function () {

                $('#teacherTableBody').html(

                    '<tr>' +
                    '<td colspan="7" class="text-center text-danger py-3">' +
                    'Failed to load teachers.' +
                    '</td>' +
                    '</tr>'
                );
            }
        );
    }

    // STATUS BADGE
    function statusBadge(status) {

        let cls =
            status === 'Active'
                ? 'badge-green'
                : status === 'On Leave'
                    ? 'badge-amber'
                    : status === 'Absent'
                        ? 'badge-red'
                        : 'badge-secondary';

        return '<span class="badge ' + cls + '">' + status + '</span>';
    }

    // RENDER TABLE
    function renderTable(data) {

        const $tbody = $('#teacherTableBody');

        $tbody.empty();

        if (!data || data.length === 0) {

            $tbody.html(

                '<tr>' +
                '<td colspan="7" class="text-center text-muted py-3">' +
                'No teachers found.' +
                '</td>' +
                '</tr>'
            );

            return;
        }

        $.each(data, function (i, t) {

            $tbody.append(

                '<tr>' +

                '<td>' + t.id + '</td>' +

                '<td>' +
                '<strong>' + t.name + '</strong>' +
                '</td>' +

                '<td>' + t.subject + '</td>' +

                '<td>' + (t.email || '-') + '</td>' +

                '<td>' + (t.phone || '—') + '</td>' +

                '<td>' + statusBadge(t.status) + '</td>' +

                '<td>' +

                '<button class="btn btn-sm btn-warning me-1 btn-edit" ' +
                'data-id="' + t.id + '">' +
                'Edit' +
                '</button>' +

                '<button class="btn btn-sm btn-danger btn-delete" ' +
                'data-id="' + t.id + '" ' +
                'data-name="' + t.name + '">' +
                'Delete' +
                '</button>' +

                '</td>' +

                '</tr>'
            );
        });
    }

    // CREATE MODAL
    $('#createModal').on('show.bs.modal', function () {

        $('#createName').val('');

        $('#createSubject').val('');

        $('#createEmail').val('');

        $('#createPhone').val('');

        $('#createStatus').val('');

        $('#createError').text('').hide();
    });

    // SAVE CREATE
    $('#saveCreateBtn').on('click', function () {

        const name =
            $('#createName').val().trim();

        const subject =
            $('#createSubject').val().trim();

        const email =
            $('#createEmail').val().trim();

        const phone =
            $('#createPhone').val().trim();

        const status =
            $('#createStatus').val();

        if (!name || !subject || !status) {

            $('#createError')
                .text('Name, Subject and Status are required.')
                .show();

            return;
        }

        $('#createError').hide();

        const payload = {

            name: name,

            subject: subject,

            email: email,

            phone: phone,

            status: status
        };

        TeacherApi.create(

            payload,

            function () {

                $('#createModal').modal('hide');

                loadTeachers();
            },

            function () {

                $('#createError')
                    .text('Failed to add teacher.')
                    .show();
            }
        );
    });

    // EDIT BUTTON
    $(document).on('click', '.btn-edit', function () {

        const id = $(this).data('id');

        TeacherApi.getById(

            id,

            function (t) {

                $('#editId').val(t.id);

                $('#editName').val(t.name);

                $('#editSubject').val(t.subject);

                $('#editEmail').val(t.email);

                $('#editPhone').val(t.phone);

                $('#editStatus').val(t.status);

                $('#editError').text('').hide();

                $('#editModal').modal('show');
            },

            function () {

                alert('Could not load teacher data.');
            }
        );
    });

    // SAVE EDIT
    $('#saveEditBtn').on('click', function () {

        const id = $('#editId').val();

        const name =
            $('#editName').val().trim();

        const subject =
            $('#editSubject').val().trim();

        const email =
            $('#editEmail').val().trim();

        const phone =
            $('#editPhone').val().trim();

        const status =
            $('#editStatus').val();

        if (!name || !subject || !status) {

            $('#editError')
                .text('Name, Subject and Status are required.')
                .show();

            return;
        }

        $('#editError').hide();

        const payload = {

            id: Number(id),

            name: name,

            subject: subject,

            email: email,

            phone: phone,

            status: status
        };

        TeacherApi.edit(

            id,

            payload,

            function () {

                $('#editModal').modal('hide');

                loadTeachers();
            },

            function () {

                $('#editError')
                    .text('Failed to update teacher.')
                    .show();
            }
        );
    });

    // DELETE BUTTON
    $(document).on('click', '.btn-delete', function () {

        $('#deleteId').val($(this).data('id'));

        $('#deleteTeacherName').text($(this).data('name'));

        $('#deleteModal').modal('show');
    });

    // CONFIRM DELETE
    $('#confirmDeleteBtn').on('click', function () {

        const id = $('#deleteId').val();

        TeacherApi.remove(

            id,

            function () {

                $('#deleteModal').modal('hide');

                loadTeachers();
            },

            function () {

                alert('Failed to delete teacher.');
            }
        );
    });

});