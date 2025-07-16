// TuVan.js

// Không cần class active nếu chỉ muốn hover
document.addEventListener("DOMContentLoaded", function () {
    const links = document.querySelectorAll(".menu-header a");

    links.forEach(link => {
        link.addEventListener("mouseover", () => {
            link.style.cursor = "pointer";
        });

        link.addEventListener("click", (e) => {
            // Ngăn không giữ hiệu ứng sau click
            e.currentTarget.blur();
        });
    });
});
