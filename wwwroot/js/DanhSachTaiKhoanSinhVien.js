// Chọn hoặc bỏ chọn tất cả checkbox
function toggleAll(masterCheckbox) {
    const checkboxes = document.querySelectorAll('input[name="chonSinhVien"]');
    checkboxes.forEach(cb => cb.checked = masterCheckbox.checked);
}

// In bảng dữ liệu
function printTable() {
    const tableHtml = document.querySelector('.bang-tai-khoan-sinh-vien').innerHTML;
    const originalContent = document.body.innerHTML;

    document.body.innerHTML = `
        <html>
        <head>
            <title>In danh sách tài khoản sinh viên</title>
        </head>
        <body>
            ${tableHtml}
        </body>
        </html>
    `;

    window.print();
    document.body.innerHTML = originalContent;
}
