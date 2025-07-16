document.addEventListener("DOMContentLoaded", function () {
    // Ẩn/hiện ảnh đã chọn
    const previewImage = (inputId, previewId) => {
        const input = document.getElementById(inputId);
        const preview = document.getElementById(previewId);

        input?.addEventListener("change", function () {
            const file = this.files[0];
            if (file) {
                const reader = new FileReader();
                reader.onload = function (e) {
                    preview.src = e.target.result;
                    preview.style.display = "block";
                };
                reader.readAsDataURL(file);
            }
        });
    };

    // Gọi cho 3 ảnh
    previewImage("AnhCaNhan", "PreviewAnhCaNhan");
    previewImage("AnhCCCDMatTruoc", "PreviewAnhCCCDMatTruoc");
    previewImage("AnhCCCDMatSau", "PreviewAnhCCCDMatSau");

    // Cập nhật dropdown dân tộc và nơi cấp (nếu dùng select2 hay dropdown động)
    const tonGiaoInput = document.getElementById("TonGiao");
    if (tonGiaoInput) {
        tonGiaoInput.addEventListener("input", () => {
            tonGiaoInput.value = tonGiaoInput.value.trim();
        });
    }

    // Ngăn người dùng nhập ngày hết hạn nhỏ hơn ngày cấp
    const ngayCapInput = document.getElementById("NgayCap");
    const ngayHetHanInput = document.getElementById("NgayHetHan");

    if (ngayCapInput && ngayHetHanInput) {
        ngayCapInput.addEventListener("change", () => {
            ngayHetHanInput.min = ngayCapInput.value;
        });
    }
});
