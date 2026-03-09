function ghiNhanDangNhap() {
    fetch('https://api.ipify.org?format=json')
        .then(res => res.json())
        .then(data => {
            const ip = data.ip;
            const thietBi = navigator.userAgent;
            const thoiGian = new Date().toLocaleString();

            const noiDung = `🕒 ${thoiGian}\nIP: ${ip}\nThiết bị: ${thietBi}`;

            fetch('/Account/LuuLichSuDangNhap', {
                method: 'POST',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                body: 'noiDung=' + encodeURIComponent(noiDung)
            });
        });
}

document.addEventListener('DOMContentLoaded', ghiNhanDangNhap);
