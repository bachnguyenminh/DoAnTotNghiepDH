// Đảm bảo mã chạy sau khi trang đã tải xong
document.addEventListener('DOMContentLoaded', function () {

    // Lấy các nút bấm bằng ID
    const printButton = document.getElementById('printBtn');
    const downloadPdfButton = document.getElementById('downloadPdfBtn');
    const formToPrint = document.getElementById('formToPrint');

    /**
     * Chức năng 1: In trực tiếp ra máy in
     */
    if (printButton) {
        printButton.addEventListener('click', function () {
            // Chỉ cần gọi hàm print của trình duyệt
            window.print();
        });
    }

    /**
     * Chức năng 2: Tải xuống dưới dạng file PDF
     */
    if (downloadPdfButton && formToPrint) {
        downloadPdfButton.addEventListener('click', function () {

            // Thay đổi text của nút để thông báo cho người dùng
            downloadPdfButton.innerText = 'Đang xử lý...';
            downloadPdfButton.disabled = true;

            const { jsPDF } = window.jspdf;

            // Sử dụng html2canvas để "chụp ảnh" div chứa phiếu
            html2canvas(formToPrint, {
                scale: 2, // Tăng chất lượng ảnh chụp
                useCORS: true // Cho phép tải ảnh từ nguồn khác (nếu có)
            }).then(canvas => {
                // Lấy dữ liệu ảnh từ canvas
                const imgData = canvas.toDataURL('image/png');

                // Kích thước của trang A4 theo mm
                const pdfWidth = 210;
                const pdfHeight = 297;

                // Tạo một đối tượng PDF mới
                const doc = new jsPDF({
                    orientation: 'portrait', // Dạng dọc
                    unit: 'mm',              // Đơn vị mm
                    format: 'a4'             // Khổ A4
                });

                // Thêm ảnh đã chụp vào file PDF
                // Căn chỉnh ảnh vừa với trang A4
                doc.addImage(imgData, 'PNG', 0, 0, pdfWidth, pdfHeight);

                // Lưu file PDF với tên "Phieu-Dang-Ky.pdf"
                doc.save('Phieu-Dang-Ky-Xet-Tuyen-Thang.pdf');

                // Khôi phục lại trạng thái ban đầu của nút
                downloadPdfButton.innerText = '📄 Tải xuống PDF';
                downloadPdfButton.disabled = false;
            }).catch(error => {
                console.error("Lỗi khi tạo PDF: ", error);
                // Khôi phục nút nếu có lỗi
                downloadPdfButton.innerText = '📄 Tải xuống PDF';
                downloadPdfButton.disabled = false;
            });
        });
    }
});