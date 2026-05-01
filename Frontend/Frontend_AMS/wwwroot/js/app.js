$(document).ready(function () {

    loadStudents();

    // SEARCH
    $('#searchInput').on('keyup', function () {
        const val = $(this).val().toLowerCase();
        $('#studentTableBody tr').filter(function () {
            $(this).toggle($(this).text().toLowerCase().includes(val));
        });
    });

    // CREATE
    $('#saveCreateBtn').on('click', function () {
        const student = getCreateFormData();

        if (!validateStudent(student)) return;

        StudentAPI.create(student)
            .done(function () {
                $('#createModal').modal('hide');
                resetCreateForm();
                loadStudents();
                showToast('Student added!', 'success');
            })
            .fail(function () {
                showToast('Failed to add.', 'danger');
            });
    });

    // EDIT
    $('#saveEditBtn').on('click', function () {
        const student = getEditFormData();

        if (!validateStudent(student)) return;

        StudentAPI.update(student)
            .done(function () {
                $('#editModal').modal('hide');
                loadStudents();
                showToast('Updated!', 'success');
            })
            .fail(function () {
                showToast('Failed to update.', 'danger');
            });
    });

    // DELETE
    $('#confirmDeleteBtn').on('click', function () {
        const id = $('#deleteId').val();

        StudentAPI.delete(id)
            .done(function () {
                $('#deleteModal').modal('hide');
                loadStudents();
                showToast('Deleted!', 'success');
            })
            .fail(function () {
                showToast('Failed to delete.', 'danger');
            });
    });
});