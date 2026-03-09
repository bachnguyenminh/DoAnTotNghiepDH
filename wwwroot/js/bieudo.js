function renderBieuDo(tuVanData, taiKhoanData) {
    drawChart('tuVanChart', tuVanData, '📈 Tư vấn tuyển sinh', 'rgba(54, 162, 235, 0.8)');
    drawChart('taiKhoanChart', taiKhoanData, '📈 Tài khoản tạo mới', 'rgba(75, 192, 192, 0.8)');
}

function drawChart(canvasId, data, label, color) {
    const ctx = document.getElementById(canvasId).getContext('2d');
    const labels = data.map(x => x.Ngay);
    const values = data.map(x => x.SoLuong);

    new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: label,
                data: values,
                backgroundColor: color,
                borderColor: color,
                fill: true,
                tension: 0.3,
                pointRadius: 4
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { display: true },
                tooltip: { enabled: true }
            },
            scales: {
                y: { beginAtZero: true }
            }
        }
    });
}
