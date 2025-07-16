// footer.js

document.addEventListener("DOMContentLoaded", () => {
    console.log("✅ Footer JS initialized");

    // Back-to-top button (nếu bạn có thêm nút #back-to-top vào layout)
    const scrollBtn = document.getElementById("back-to-top");
    if (scrollBtn) {
        // Hiện/ẩn nút khi cuộn
        window.addEventListener("scroll", () => {
            if (window.scrollY > 300) {
                scrollBtn.style.display = "block";
            } else {
                scrollBtn.style.display = "none";
            }
        });
        // Sự kiện click cuộn lên đầu trang
        scrollBtn.addEventListener("click", () => {
            window.scrollTo({ top: 0, behavior: "smooth" });
        });
    }

    // Các social-icon có thể bật tooltip
    const socialIcons = document.querySelectorAll(".social-icon");
    socialIcons.forEach(icon => {
        icon.addEventListener("mouseenter", () => {
            icon.style.transform = "scale(1.1)";
        });
        icon.addEventListener("mouseleave", () => {
            icon.style.transform = "";
        });
    });

    // Nếu muốn bắt sự kiện click vào hotline để gọi
    const hotlineLinks = document.querySelectorAll("a[href^='tel:']");
    hotlineLinks.forEach(link => {
        link.addEventListener("click", () => {
            console.log("Calling hotline:", link.getAttribute("href"));
        });
    });

    // Tùy biến thêm: Ví dụ bật iframe Facebook khi scroll đến
    const fbEmbed = document.querySelector(".facebook-embed iframe");
    if (fbEmbed) {
        const observer = new IntersectionObserver(entries => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    // khi phần fanpage vào viewport, có thể reload src để tiết kiệm băng thông
                    const src = fbEmbed.getAttribute("data-src");
                    if (src && fbEmbed.src !== src) {
                        fbEmbed.src = src;
                    }
                    observer.disconnect();
                }
            });
        });
        // để fbEmbed có data-src chứ src ban đầu
        // fbEmbed.setAttribute("data-src", fbEmbed.src);
        // fbEmbed.src = "";
        observer.observe(fbEmbed);
    }
});
