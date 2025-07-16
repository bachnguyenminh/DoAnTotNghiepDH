function toggleAll(source) {
    document.querySelectorAll('input[name="chonSinhVien"]').forEach(cb => {
        cb.checked = source.checked;
    });
}

document.addEventListener("DOMContentLoaded", function () {

    // Modal Thêm Mới
    const themMoiModal = document.getElementById("themMoiModal");
    if (themMoiModal) {
        themMoiModal.addEventListener("show.bs.modal", () => {
            fetch("/DanhSachTuVan/RenderThemMoiPartial")
                .then(res => res.text())
                .then(html => {
                    document.getElementById("modal-content-them-moi").innerHTML = html;
                });
        });
    }

    // Modal Sửa
    const suaModal = document.getElementById("suaModal");
    if (suaModal) {
        suaModal.addEventListener("show.bs.modal", e => {
            const button = e.relatedTarget;
            const id = button.getAttribute("data-id");
            fetch(`/DanhSachTuVan/RenderSuaPartial?id=${id}`)
                .then(res => res.text())
                .then(html => {
                    document.getElementById("modal-content-sua").innerHTML = html;
                });
        });
    }

    // ✅ In bảng tư vấn
    window.printTable = function () {
        const tableWrapper = document.querySelector('.bang-tu-van-wrapper');
        if (!tableWrapper) return;

        const newWin = window.open('', '_blank');
        const style = `
            <style>
                body { font-family: Arial, sans-serif; margin: 20px; }
                h3 { text-align: center; margin-bottom: 20px; }
                table { width: 100%; border-collapse: collapse; font-size: 13px; }
                th, td { border: 1px solid #000; padding: 6px; text-align: center; }
                th { background-color: #f2f2f2; }
            </style>
        `;

        newWin.document.write(`
            <html><head><title>In bảng</title>${style}</head>
            <body>
                <h3>Danh sách tư vấn tuyển sinh</h3>
                ${tableWrapper.innerHTML}
            </body></html>
        `);

        newWin.document.close();
        newWin.focus();

        setTimeout(() => {
            newWin.print();
            newWin.close();
        }, 500);
    };

    // ✅ Xuất Excel từ bảng HTML
    window.xuatExcelBang = function () {
        const table = document.getElementById("bangTuVan");
        if (!table) return;

        const workbook = XLSX.utils.table_to_book(table, { sheet: "TuVan" });
        XLSX.writeFile(workbook, "DanhSach_TuVan.xlsx");
    };

    // ✅ Xuất PDF từ bảng HTML
    window.xuatPDFBang = function () {
        const { jsPDF } = window.jspdf;
        const doc = new jsPDF('l'); // landscape

        doc.text("Danh sách tư vấn tuyển sinh", 14, 10);
        doc.autoTable({
            html: '#bangTuVan',
            startY: 20,
            styles: {
                fontSize: 8
            }
        });
        doc.save("DanhSach_TuVan.pdf");
    };

    function copyToClipboard(text) {
            navigator.clipboard.writeText(text).then(function () {
                alert('Đã sao chép: ' + text);
            }, function () {
                alert('Không thể sao chép số.');
            });
    }


});
