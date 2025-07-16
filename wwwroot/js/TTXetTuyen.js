document.addEventListener("DOMContentLoaded", function () {
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
