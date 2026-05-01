function openEditModal(id, name, course, year, email, status) {
    document.getElementById("editId").value = id;
    document.getElementById("editName").value = name;
    document.getElementById("editCourse").value = course;
    document.getElementById("editYear").value = year;
    document.getElementById("editEmail").value = email;
    document.getElementById("editStatus").value = status;

    var modal = new bootstrap.Modal(document.getElementById('editModal'));
    modal.show();
}

function openDeleteModal(id) {
    document.getElementById("deleteId").value = id;

    var modal = new bootstrap.Modal(document.getElementById('deleteModal'));
    modal.show();
}