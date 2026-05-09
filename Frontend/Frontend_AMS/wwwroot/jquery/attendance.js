$(document).ready(function () {

    $('#createModal').on('show.bs.modal', function () {
        var today = new Date().toISOString().split('T')[0];
        $('#createDate').val(today);
        $('#createStudent').val('');
        $('#createCourse').val('');
        $('#createStatus').val('');
        $('#createRemarks').val('');
        $('#createError').text('').hide();
    });

    $('#saveCreateBtn').on('click', function () {
        var date = $('#createDate').val();
        var student = $('#createStudent').val().trim();
        var course = $('#createCourse').val();
        var status = $('#createStatus').val();
        var remarks = $('#createRemarks').val().trim();

        if (!date || !student || !course || !status) {
            $('#createError').text('Please fill in all required fields.').show();
            return;
        }
        $('#createError').hide();

        Attendance.create(
            { date: date, studentName: student, course: course, status: status, remarks: remarks },
            function () { $('#createModal').modal('hide'); },
            function (msg) { $('#createError').text(msg).show(); }
        );
    });

    $('.btn-edit').on('click', function () {
        var id = $(this).data('id');
        Attendance.getById(id, function (a) {
            $('#editId').val(a.id);
            $('#editDate').val(a.date ? a.date.split('T')[0] : '');
            $('#editStudent').val(a.studentName);
            $('#editCourse').val(a.course);
            $('#editStatus').val(a.status);
            $('#editRemarks').val(a.remarks);
            $('#editError').text('').hide();
            $('#editModal').modal('show');
        });
    });

    $('#saveEditBtn').on('click', function () {
        var id = $('#editId').val();
        var date = $('#editDate').val();
        var student = $('#editStudent').val().trim();
        var course = $('#editCourse').val();
        var status = $('#editStatus').val();
        var remarks = $('#editRemarks').val().trim();

        if (!date || !student || !course || !status) {
            $('#editError').text('Please fill in all required fields.').show();
            return;
        }
        $('#editError').hide();

        Attendance.edit(
            { id: Number(id), date: date, studentName: student, course: course, status: status, remarks: remarks },
            function () { $('#editModal').modal('hide'); },
            function (msg) { $('#editError').text(msg).show(); }
        );
    });

    $('.btn-delete').on('click', function () {
        $('#deleteId').val($(this).data('id'));
        $('#deleteStudentName').text($(this).data('name'));
        $('#deleteModal').modal('show');
    });

    $('#confirmDeleteBtn').on('click', function () {
        Attendance.remove($('#deleteId').val(), function () {
            $('#deleteModal').modal('hide');
        });
    });

});