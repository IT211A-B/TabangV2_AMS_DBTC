window.Teacher = (function () {

    //mas chuy ni siya ay 
    function statusBadge(status) {
        var cls = status == 'Active' ? 'badge-green' :
            status == 'On Live' ? 'badge-amber' :
                status == 'Absent' ? 'badge-red';
        return '<span class="badge ' + cls + '">' + status + '</span>'; 
    }

    function renderTable(data) {
        var $tbody = $('#teacherTableBody').empty();

        if (!data || data.length === 0) {
            $tbody.html(
                '<tr><td colspan="7" class="text-center text-muted py-3">No teachers found.</td></tr>'
            );
            return;
        }

        $.each(data, function (i, t) {
            $tbody.append(
                '<tr>' +
                '<td>' + t.id + '</td>' +
                '<td><strong>' + t.name + '</strong></td>' +
                '<td>' + t.subject + '</td>' +
                '<td>' + t.email + '</td>' +
                '<td>' + (t.phone || '—') + '</td>' +
                '<td>' + statusBadge(t.status) + '</td>' +
                '<td>' +
                '<button class="btn btn-sm btn-warning me-1 btn-edit" data-id="' + t.id + '">Edit</button>' +
                '<button class="btn btn-sm btn-danger btn-delete" data-id="' + t.id + '" data-name="' + t.name + '">Delete</button>' +
                '</td>' +
                '</tr>'
            );
        });
    }
    function load() {
        $.ajax({
            url: 'http://localhost:5294/api/Teacher',
            type: 'GET',
            success: function (data) {
                renderTable(data);
            },
            error: function () {
                $('#teacherTableBody').html(
                    '<tr><td colspan="7" class="text-center text-muted">Failed to load teachers.</td></tr>'
                );
            }
        });
    }
    function create(payload, onSuccess, onError) {
        $.ajax({
            url: 'http://localhost:5294/api/Teacher',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(payload),
            success: function (res) {
                if (res.success) {
                    onSuccess();
                    load();
                }
            },
            error: function () {
                onError('Failed to add teacher. Please try again.');
            }
        });
    }

    function edit(payload, onSuccess, onError) {
        $.ajax({
            url: 'http://localhost:5294/api/Teacher',
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(payload),
            success: function (res) {
                if (res.success) {
                    onSuccess();
                    load();
                }
            },
            error: function () {
                onError('Failed to update teacher. Please try again.');
            }
        });
    }

    function remove(id, onSuccess) {
        $.ajax({
            url: 'http://localhost:5294/api/Teacher/' + id,
            type: 'DELETE',
            success: function (res) {
                if (res.success) {
                    onSuccess();
                    load();
                }
            },
            error: function () {
                alert('Failed to delete teacher.');
            }
        });
    }
    return {
        load: load,
        getById: getById,
        create: create,
        edit: edit,
        remove: remove
    };

})();