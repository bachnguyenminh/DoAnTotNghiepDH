document.addEventListener('DOMContentLoaded', function () {
    const toggleIcon = document.getElementById('togglePassword');
    const passwordInput = document.getElementById('MatKhau');

    if (toggleIcon && passwordInput) {
        toggleIcon.addEventListener('click', function () {
            const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
            passwordInput.setAttribute('type', type);
            this.classList.toggle('fa-eye-slash');
        });
    }
});
