window.Atttendance = (function () {
    function statusBadge(status) {
        var cls = status === 'Present' ? 'badge-green'
            : status === 'Absent' ? 'badge-red'
                : 'badge-amber'; // Late
        return '<span class="badge ' + cls + '">' + status + '</span>';
    }
    function formatDate(dateStr) {
        return dateStr ? dateStr.split('T')[0] : '';
    }

    function renderTable(data) {
        var $tbody = $('#attendanceTableBody').empty();

        if (!data || data.length === 0) {
            $tbody.html(
                '<tr><td colspan="7" class="text-center text-muted py-3">No attendance records found.</td></tr>'
            );
            return;
        }

        $.each(data, function (i, a) {
            $tbody.append(
                '<tr>' +
                '<td>' + a.id + '</td>' +
                '<td>' + formatDate(a.date) + '</td>' +
                '<td><strong>' + a.studentName + '</strong></td>' +
                '<td><span class="badge badge-blue">' + a.course + '</span></td>' +
                '<td>' + statusBadge(a.status) + '</td>' +
                '<td>' + (a.remarks || '—') + '</td>' +
                '<td>' +
                '<button class="btn btn-sm btn-warning me-1 btn-edit" data-id="' + a.id + '">Edit</button>' +
                '<button class="btn btn-sm btn-danger btn-delete" data-id="' + a.id + '" data-name="' + a.studentName + '">Delete</button>' +
                '</td>' +
                '</tr>'
            );
        });
    }
    function load() {
        $.ajax({
            url: 'http://localhost:5294/api/Attendance',
            type: 'GET',
            success: function (data) {
                renderTable(data);
            },
            error: function () {
                $('#attendanceTableBody').html(
                    '<tr><td colspan="7" class="text-center text-muted">Failed to load records.</td></tr>'
                );
            }
        });
    }

    function create(payload, onSuccess, onError) {
        $.ajax({
            url: 'http://localhost:5294/api/Attendance',
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
                onError('Failed to save record. Please try again.');
            }
        });
    }

    function edit(payload, onSuccess, onError) {
        $.ajax({
            url: 'http://localhost:5294/api/Attendance',
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
                onError('Failed to update record. Please try again.');
            }
        });
    }

    function remove(id, onSuccess) {
        $.ajax({
            url: 'http://localhost:5294/api/Attendance' + id,
            type: 'DELETE',
            success: function (res) {
                if (res.success) {
                    onSuccess();
                    load();
                }
            },
            error: function () {
                alert('Failed to delete record.');
            }
        });
});