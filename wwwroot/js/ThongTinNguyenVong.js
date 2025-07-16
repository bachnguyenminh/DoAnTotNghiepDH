// File: ThongTinNguyenVong.js

// Chạy khi trang đã tải xong
$(document).ready(function () {
    // Example: Thêm sự kiện cho các trạng thái nguyện vọng
    $('.nguyen-vong-status span').on('click', function () {
        alert('Trạng thái nguyện vọng: ' + $(this).text());
    });

    // Example: Thêm sự kiện cho nút "Xem chi tiết"
    $('.btn-primary').on('click', function (e) {
        e.preventDefault();
        alert('Chuyển đến trang chi tiết...');
        // Bạn có thể thêm hành động chuyển trang ở đây, ví dụ:
        // window.location.href = $(this).attr('href');
    });
});
