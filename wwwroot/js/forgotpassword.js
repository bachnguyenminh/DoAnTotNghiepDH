document.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');
    const cccd = document.querySelector('input[name="CCCD"]');
    const captcha = document.querySelector('input[name="InputCaptcha"]');

    if (form && cccd && captcha) {
        form.addEventListener('submit', e => {
            if (!/^\d{12}$/.test(cccd.value.trim())) {
                e.preventDefault();
                alert('Vui lòng nhập CCCD hợp lệ (12 chữ số).');
                cccd.focus();
            } else if (captcha.value.trim() === '') {
                e.preventDefault();
                alert('Vui lòng nhập mã xác nhận.');
                captcha.focus();
            }
        });
    }

    const alertBox = document.querySelector('.alert');
    if (alertBox) {
        setTimeout(() => {
            alertBox.classList.add('fade-out');
        }, 4000);
    }
});
