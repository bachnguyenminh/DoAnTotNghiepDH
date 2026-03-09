// XoaTaiKhoan.js

document.addEventListener("DOMContentLoaded", function () {
    const successAlert = document.querySelector('.alert-success');
    const errorAlert = document.querySelector('.alert-danger');

    if (successAlert) {
        setTimeout(() => successAlert.style.display = 'none', 4000);
    }

    if (errorAlert) {
        setTimeout(() => errorAlert.style.display = 'none', 4000);
    }
});
