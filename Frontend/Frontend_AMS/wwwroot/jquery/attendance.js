$(document).ready(function () {

    loadAttendance();

    // LOAD TABLE
    function loadAttendance() {

        AttendanceApi.getAll(

            function (data) {

                renderTable(data);
            },

            function () {

                $('#attendanceTableBody').html(

                    '<tr>' +
                    '<td colspan="7" class="text-center text-danger">' +
                    'Failed to load attendance records.' +
                    '</td>' +
                    '</tr>'
                );
            }
        );
    }

    // RENDER TABLE
    function renderTable(data) {

        let rows = '';

        if (!data || data.length === 0) {

            rows =
                '<tr>' +
                '<td colspan="7" class="text-center text-muted">' +
                'No attendance records found.' +
                '</td>' +
                '</tr>';

            $('#attendanceTableBody').html(rows);

            return;
        }

        data.forEach(a => {

            rows +=
                '<tr>' +

                '<td>' + a.studentsId + '</td>' +

                '<td>' + formatDate(a.date) + '</td>' +

                '<td>' +
                '<strong>' + a.fullName + '</strong>' +
                '</td>' +

                '<td>' + (a.course || '-') + '</td>' +

                '<td>' + statusBadge(a.status) + '</td>' +

                '<td>' + (a.remarks || '-') + '</td>' +

                '<td>' +

                '<button class="btn btn-warning btn-sm btn-edit" ' +
                'data-id="' + a.studentsId + '">' +
                'Edit' +
                '</button> ' +

                '<button class="btn btn-danger btn-sm btn-delete" ' +
                'data-id="' + a.studentsId + '" ' +
                'data-name="' + a.fullName + '">' +
                'Delete' +
                '</button>' +

                '</td>' +

                '</tr>';
        });

        $('#attendanceTableBody').html(rows);
    }

    // STATUS BADGE
    function statusBadge(status) {

        let cls = status === 'Present'
            ? 'badge-green'
            : status === 'Absent'
                ? 'badge-red'
                : 'badge-amber';

        return '<span class="badge ' + cls + '">' + status + '</span>';
    }

    // FORMAT DATE
    function formatDate(dateStr) {

        return dateStr
            ? dateStr.split('T')[0]
            : '';
    }

    // CREATE
    $('#saveCreateBtn').on('click', function () {

        const payload = {

            fullName: $('#createStudent').val() || '',

            course: $('#createCourse').val() || '',

            date: $('#createDate').val() || '',

            status: $('#createStatus').val() || 'Present',

            remarks: $('#createRemarks').val() || ''
        };

        AttendanceApi.create(

            payload,

            function () {

                $('#createModal').modal('hide');

                loadAttendance();
            },

            function () {

                alert('Failed to create attendance.');
            }
        );
    });

    // EDIT BUTTON
    $(document).on('click', '.btn-edit', function () {
        const id = $(this).data('id');

        AttendanceApi.getById(
            id,
            function (a) {
                $('#editId').val(a.studentsId);
                $('#editStudent').val(a.fullName);
                $('#editCourse').val(a.course);
                $('#editDate').val(formatDate(a.date));
                $('#editStatus').val(a.status);
                $('#editRemarks').val(a.remarks);
                $('#editModal').modal('show');
            },
            function (xhr) {
                console.error('Error:', xhr.responseText);
                alert('Failed to load attendance.');
            }
        );
    });

    // SAVE EDIT
    $('#saveEditBtn').on('click', function () {

        const id = $('#editId').val();

        const payload = {

            studentsId: Number(id),

            fullName: $('#editStudent').val(),

            course: $('#editCourse').val(),

            date: $('#editDate').val(),

            status: $('#editStatus').val(),

            remarks: $('#editRemarks').val()
        };

        AttendanceApi.edit(

            id,

            payload,

            function () {

                $('#editModal').modal('hide');

                loadAttendance();
            },

            function () {

                alert('Failed to update attendance.');
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

        AttendanceApi.remove(

            id,

            function () {

                $('#deleteModal').modal('hide');

                loadAttendance();
            },

            function () {

                alert('Failed to delete attendance.');
            }
        );
    });

});