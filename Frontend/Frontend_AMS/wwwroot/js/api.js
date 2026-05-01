conts API_URL = ""//PS: I will set this in the future, but for now, I will just use relative paths

const StudentAPI = {
    getAll: function () {
        return $.get(API_URL);
    },

    create: function (student) {
        return $.ajax({
            url: API_URL,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(student)
        });
    },

    update: function (student) {
        return $.ajax({
            url: `${API_URL}/${student.id}`,
            method: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(student)
        });
    },

    delete: function (id) {
        return $.ajax({
            url: `${API_URL}/${id}`,
            method: 'DELETE'
        });
    }
};