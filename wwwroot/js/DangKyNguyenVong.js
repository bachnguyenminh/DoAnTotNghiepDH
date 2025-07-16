document.addEventListener("DOMContentLoaded", function () {
    const selects = document.querySelectorAll(".nghe-select");

    selects.forEach(select => {
        select.addEventListener("change", function () {
            const index = parseInt(this.dataset.index);
            const selectedOption = this.options[this.selectedIndex];
            const maNghe = selectedOption.getAttribute("data-manghe") || "";

            const maNgheInput = document.querySelector(`input[name="MaNghe${index}"]`);
            if (maNgheInput) {
                maNgheInput.value = maNghe;
            }

            // Hiện khối nguyện vọng tiếp theo
            const nextBlock = document.getElementById(`nv-block-${index + 1}`);
            if (this.value && nextBlock) {
                nextBlock.classList.remove("d-none");
            }
        });

        // Gọi 1 lần để set mã nếu có sẵn
        select.dispatchEvent(new Event("change"));
    });
});
