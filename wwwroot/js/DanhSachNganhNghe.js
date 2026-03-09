function printTable() {
    var divContents = document.getElementById("bangNganhNghe").outerHTML;
    var a = window.open('', '', 'height=600, width=800');
    a.document.write('<html><head><title>In bảng ngành nghề</title>');
    a.document.write('<style>table {width: 100%; border-collapse: collapse;} th, td {border: 1px solid black; padding: 8px; text-align: center;}</style>');
    a.document.write('</head><body>');
    a.document.write('<h3>Danh sách ngành nghề</h3>');
    a.document.write(divContents);
    a.document.write('</body></html>');
    a.document.close();
    a.print();
}
