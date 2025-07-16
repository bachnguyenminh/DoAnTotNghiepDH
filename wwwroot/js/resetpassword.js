document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('.toggle-password').forEach(icon => {
        icon.addEventListener('click', function () {
            const targetInput = document.querySelector(this.getAttribute('data-target'));
            const eyeIcon = this.querySelector('i');

            if (targetInput.type === "password") {
                targetInput.type = "text";
                eyeIcon.classList.replace('bi-eye-slash', 'bi-eye');
            } else {
                targetInput.type = "password";
                eyeIcon.classList.replace('bi-eye', 'bi-eye-slash');
            }
        });
    });
});
