$(document).ready(function () {

 
    $('#createModal').on('show.bs.modal', function () {
        $('#createCode').val('');
        $('#createName').val('');
        $('#createTeacher').val('');
        $('#createUnits').val('');
        $('#createError').text('').hide();
    });

    $('#saveCreateBtn').on('click', function () {
        var code = $('#createCode').val().trim().toUpperCase();
        var name = $('#createName').val().trim();
        var teacher = $('#createTeacher').val().trim();
        var units = parseInt($('#createUnits').val()) || 3;

        if (!code || !name) {
            $('#createError').text('Course Code and Course Name are required.').show();
            return;
        }
        $('#createError').hide();

        Courses.create(
            { courseCode: code, courseName: name, assignedTeacher: teacher, units: units },
            function () { $('#createModal').modal('hide'); },
            function (msg) { $('#createError').text(msg).show(); }
        );
    });

    $('.btn-edit').on('click', function () {
        var id = $(this).data('id');
        Courses.getById(id, function (c) {
            $('#editId').val(c.id);
            $('#editCode').val(c.courseCode);
            $('#editName').val(c.courseName);
            $('#editTeacher').val(c.assignedTeacher);
            $('#editUnits').val(c.units);
            $('#editError').text('').hide();
            $('#editModal').modal('show');
        });
    });

    $('#saveEditBtn').on('click', function () {
        var id = $('#editId').val();
        var code = $('#editCode').val().trim().toUpperCase();
        var name = $('#editName').val().trim();
        var teacher = $('#editTeacher').val().trim();
        var units = parseInt($('#editUnits').val()) || 3;

        if (!code || !name) {
            $('#editError').text('Course Code and Course Name are required.').show();
            return;
        }
        $('#editError').hide();

        Courses.edit(
            { id: Number(id), courseCode: code, courseName: name, assignedTeacher: teacher, units: units },
            function () { $('#editModal').modal('hide'); },
            function (msg) { $('#editError').text(msg).show(); }
        );
    });

    $('.btn-delete').on('click', function () {
        $('#deleteId').val($(this).data('id'));
        $('#deleteCourseName').text($(this).data('name'));
        $('#deleteModal').modal('show');
    });

    $('#confirmDeleteBtn').on('click', function () {
        Courses.remove($('#deleteId').val(), function () {
            $('#deleteModal').modal('hide');
        });
    });

});