document.addEventListener("DOMContentLoaded", function () {
    const khuVucSelect = document.getElementById("KhuVucUuTien");
    const doiTuongSelect = document.getElementById("DoiTuongUuTien");
    const diemKhuVucInput = document.getElementById("DiemKhuVucUuTien");
    const diemDoiTuongInput = document.getElementById("DiemDoiTuongUuTien");

    function tinhDiemKhuVuc(value) {
        switch (value) {
            case "KV1": return "0.75";
            case "KV2": return "0.25";
            case "KV3": return "0";
            default: return "";
        }
    }

    function tinhDiemDoiTuong(value) {
        switch (value) {
            case "01": return "2";
            case "02": return "1.5";
            case "03": return "1";
            case "04": return "0.5";
            case "05": return "0.5";
            case "06": return "0.5";
            case "07": return "0.5";
            default: return "";
        }
    }

    function capNhatDiemUuTien() {
        if (khuVucSelect && diemKhuVucInput) {
            diemKhuVucInput.value = tinhDiemKhuVuc(khuVucSelect.value);
        }
        if (doiTuongSelect && diemDoiTuongInput) {
            diemDoiTuongInput.value = tinhDiemDoiTuong(doiTuongSelect.value);
        }
    }

    if (khuVucSelect) khuVucSelect.addEventListener("change", capNhatDiemUuTien);
    if (doiTuongSelect) doiTuongSelect.addEventListener("change", capNhatDiemUuTien);

    // Gọi cập nhật khi load trang để điền sẵn nếu dữ liệu cũ
    capNhatDiemUuTien();
})
    // Select các phần tử liên quan đến chứng chỉ và đánh giá năng lực
    const ccSelect = document.getElementById("ChungChi");
    const dgSelect = document.getElementById("DanhGiaNangLuc");
    const ccGroup = document.getElementById("diemChungChiGroup");
    const dgGroup = document.getElementById("diemDanhGiaGroup");

    // Checkbox giống lớp 10
    const chk11 = document.getElementById("chkGiongLop10_11");
    const chk12 = document.getElementById("chkGiongLop10_12");
    const lop11Inputs = document.getElementById("lop11Inputs");
    const lop12Inputs = document.getElementById("lop12Inputs");

    // Hiển thị hoặc ẩn nhóm điểm chứng chỉ
    function toggleDiemChungChi() {
        if (ccSelect && ccGroup) {
            const val = ccSelect.value.trim();
            ccGroup.style.display = (val === "Không có" || val === "") ? "none" : "block";
        }
    }

    // Hiển thị hoặc ẩn nhóm điểm đánh giá năng lực
    function toggleDiemDanhGia() {
        if (dgSelect && dgGroup) {
            const val = dgSelect.value.trim();
            dgGroup.style.display = (val === "Không có" || val === "") ? "none" : "block";
        }
    }

    // Ẩn/hiện input nhóm lớp theo checkbox
    function toggleLopGroup(checkbox, inputGroup) {
        if (checkbox && inputGroup) {
            inputGroup.style.display = checkbox.checked ? "none" : "flex";
        }
    }

    // Sự kiện ban đầu
    toggleDiemChungChi();
    toggleDiemDanhGia();
    toggleLopGroup(chk11, lop11Inputs);
    toggleLopGroup(chk12, lop12Inputs);

    // Gắn sự kiện thay đổi cho dropdown và checkbox
    if (ccSelect) ccSelect.addEventListener("change", toggleDiemChungChi);
    if (dgSelect) dgSelect.addEventListener("change", toggleDiemDanhGia);

    if (chk11) chk11.addEventListener("change", () => toggleLopGroup(chk11, lop11Inputs));
    if (chk12) chk12.addEventListener("change", () => toggleLopGroup(chk12, lop12Inputs));

    // Thông báo thành công (tự ẩn sau 5s)
    const successAlert = document.getElementById("success-alert");
    if (successAlert) {
        successAlert.style.display = "block";
        window.scrollTo({ top: 0, behavior: "smooth" });
        setTimeout(() => {
            successAlert.style.display = "none";
        }, 5000);
    }
});
