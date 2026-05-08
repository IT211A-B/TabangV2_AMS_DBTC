$(document).ready(function () {

    $('#createModal').on('show.bs.modal', function () {
        $('#createName').val('');
        $('#createEmail').val('');
        $('#createCourse').val('');
        $('#createYear').val('');
        $('#createStatus').val('');
        $('#createError').text('').hide();
    });

    $('#saveCreateBtn').on('click', function () {
        var name = $('#createName').val().trim();
        var course = $('#createCourse').val();
        var year = $('#createYear').val();
        var email = $('#createEmail').val().trim();
        var status = $('#createStatus').val();

        if (!name || !course || !year || !status) {
            $('#createError').text('Please fill in all required fields.').show();
            return;
        }
        $('#createError').hide();


        Students.create(
            { name: name, course: course, yearLevel: year, email: email, status: status },
            function () { $('#createModal').modal('hide'); },
            function (msg) { $('#createError').text(msg).show(); }
        );
    });

    $('.btn-edit').on('click', function () {
        var id = $(this).data('id');
        Students.getById(id, function (s) {
            $('#editId').val(s.id);
            $('#editName').val(s.name);
            $('#editCourse').val(s.course);
            $('#editYear').val(s.yearLevel);
            $('#editEmail').val(s.email);
            $('#editStatus').val(s.status);
            $('#editError').text('').hide();
            $('#editModal').modal('show');
        });
    });

    $('#saveEditBtn').on('click', function () {
        var id = $('#editId').val();
        var name = $('#editName').val().trim();
        var course = $('#editCourse').val();
        var year = $('#editYear').val();
        var email = $('#editEmail').val().trim();
        var status = $('#editStatus').val();

        if (!name || !course || !year || !status) {
            $('#editError').text('Please fill in all required fields.').show();
            return;
        }
        $('#editError').hide();

        Students.edit(
            { id: Number(id), name: name, course: course, yearLevel: year, email: email, status: status },
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
        Students.remove($('#deleteId').val(), function () {
            $('#deleteModal').modal('hide');
        });
    });

});