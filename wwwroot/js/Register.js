document.addEventListener("DOMContentLoaded", function () {
    // Địa chỉ hành chính
    axios.get("https://raw.githubusercontent.com/kenzouno1/DiaGioiHanhChinhVN/master/data.json")
        .then(res => {
            const data = res.data;
            const city = document.getElementById("city");
            data.forEach(x => city.add(new Option(x.Name, x.Id)));

            city.onchange = () => {
                const district = document.getElementById("district");
                const ward = document.getElementById("ward");
                district.length = 1;
                ward.length = 1;
                document.getElementById("tenTinh").value = city.selectedOptions[0].text;

                const selectedCity = data.find(n => n.Id === city.value);
                selectedCity?.Districts.forEach(d => district.add(new Option(d.Name, d.Id)));
            };

            document.getElementById("district").onchange = () => {
                const ward = document.getElementById("ward");
                ward.length = 1;
                document.getElementById("tenQuan").value = document.getElementById("district").selectedOptions[0].text;

                const selectedCity = data.find(n => n.Id === city.value);
                const selectedDistrict = selectedCity?.Districts.find(n => n.Id === district.value);
                selectedDistrict?.Wards.forEach(w => ward.add(new Option(w.Name, w.Id)));
            };

            document.getElementById("ward").onchange = () =>
                document.getElementById("tenPhuong").value = document.getElementById("ward").selectedOptions[0].text;
        });

    // Toggle password visibility
    document.querySelectorAll('.toggle-password').forEach(icon => {
    icon.addEventListener('click', function () {
        const targetInput = document.querySelector(this.getAttribute('data-target'));
        const eyeIcon = this.querySelector('i');

        if (targetInput.type === "password") {
            targetInput.type = "text";
            eyeIcon.classList.replace('bi-eye-slash', 'bi-eye');
        } else {
            targetInput.type = "password";
            eyeIcon.classList.replace('bi-eye', 'bi-eye-slash');
        }
    });
});

});
