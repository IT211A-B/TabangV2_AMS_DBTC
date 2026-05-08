$(document).ready(function () {

    $('#createModal').on('show.bs.modal', function () {
        $('#createName').val('');
        $('#createSubject').val('');
        $('#createEmail').val('');
        $('#createPhone').val('');
        $('#createStatus').val('');
        $('#createError').text('').hide();
    });

    $('#saveCreateBtn').on('click', function () {
        var name = $('#createName').val().trim();
        var subject = $('#createSubject').val().trim();
        var email = $('#createEmail').val().trim();
        var phone = $('#createPhone').val().trim();
        var status = $('#createStatus').val();

        if (!name || !subject || !status) {
            $('#createError').text('Name, Subject and Status are required.').show();
            return;
        }
        $('#createError').hide();

        Teachers.create(
            { name: name, subject: subject, email: email, phone: phone, status: status },
            function () { $('#createModal').modal('hide'); },
            function (msg) { $('#createError').text(msg).show(); }
        );
    });

    $('.btn-edit').on('click', function () {
        var id = $(this).data('id');
        Teachers.getById(id, function (t) {
            $('#editId').val(t.id);
            $('#editName').val(t.name);
            $('#editSubject').val(t.subject);
            $('#editEmail').val(t.email);
            $('#editPhone').val(t.phone);
            $('#editStatus').val(t.status);
            $('#editError').text('').hide();
            $('#editModal').modal('show');
        });
    });

    $('#saveEditBtn').on('click', function () {
        var id = $('#editId').val();
        var name = $('#editName').val().trim();
        var subject = $('#editSubject').val().trim();
        var email = $('#editEmail').val().trim();
        var phone = $('#editPhone').val().trim();
        var status = $('#editStatus').val();

        if (!name || !subject || !status) {
            $('#editError').text('Name, Subject and Status are required.').show();
            return;
        }
        $('#editError').hide();

        Teachers.edit(
            { id: Number(id), name: name, subject: subject, email: email, phone: phone, status: status },
            function () { $('#editModal').modal('hide'); },
            function (msg) { $('#editError').text(msg).show(); }
        );
    });

    $('.btn-delete').on('click', function () {
        $('#deleteId').val($(this).data('id'));
        $('#deleteTeacherName').text($(this).data('name'));
        $('#deleteModal').modal('show');
    });

    $('#confirmDeleteBtn').on('click', function () {
        Teachers.remove($('#deleteId').val(), function () {
            $('#deleteModal').modal('hide');
        });
    });

});