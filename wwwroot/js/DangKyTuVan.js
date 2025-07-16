document.addEventListener("DOMContentLoaded", () => {
    // 1. Highlight input/select on focus
    document.querySelectorAll('.dk-form input, .dk-form select').forEach(el => {
        el.addEventListener('focus', () => {
            el.style.boxShadow = '0 0 8px rgba(255,165,0,0.8)';
        });
        el.addEventListener('blur', () => {
            el.style.boxShadow = 'none';
        });
    });

    // 2. Auto-hide alert boxes
    ["alertThongBao", "alertLoiTrung"].forEach((id, index) => {
        const el = document.getElementById(id);
        if (el) {
            setTimeout(() => {
                el.style.transition = "opacity 1s";
                el.style.opacity = "0";
                setTimeout(() => el.remove(), 1000);
            }, 3000 + (index * 1000));
        }
    });

    // 3. Smooth form appearance on load
    const form = document.querySelector(".dk-left");
    if (form) {
        form.style.opacity = 0;
        form.style.transform = "translateY(20px)";
        form.style.transition = "all 0.8s ease";
        requestAnimationFrame(() => {
            form.style.opacity = 1;
            form.style.transform = "translateY(0)";
        });
    }

    // 4. Mô tả ngành nghề
    const descriptions = {
        beauty: {
            img: "https://scontent.fhan20-1.fna.fbcdn.net/v/t39.30808-6/507740004_1284757763649848_4197136034148971938_n.jpg?_nc_cat=102&ccb=1-7&_nc_sid=127cfc&_nc_eui2=AeEbGaVobTADuxlkxTuMY633hgKulcleVxyGAq6VyV5XHMVKSnQPrJBrIuyrqy_N_Ob4sWPmvHY7mwrxtuareK_s&_nc_ohc=4p3cX8ucVQwQ7kNvwHortTl&_nc_oc=AdlniGUMgGYrLSBnWkHHmb54s2o_3sA7U2o78amgCsOJToLJvtKzJ5ScU7CUGgvwFOcmQGGuLEm-HwUAzRPJz6Jj&_nc_zt=23&_nc_ht=scontent.fhan20-1.fna&_nc_gid=P_IrNlAPvzYad3u2olH4DA&oh=00_AfSUcxqhFITXl22vDOrp_TfwSgV5mSZbYnVKTrIrpKn00g&oe=687462EE",
            text: "Biến đam mê làm đẹp thành sự nghiệp chuyên nghiệp! Ngành Chăm sóc sắc đẹp mang đến cho bạn kỹ năng spa, trang điểm, thẩm mỹ hiện đại và cơ hội làm việc tại các trung tâm chăm sóc sắc đẹp hàng đầu.Học xong là có thể mở spa riêng hoặc làm việc tại các chuỗi lớn! #Spa #ThamMy #BeautyCare #NgheHot2025 #TuTinToaSang"
        },
        cold: {
            img: "https://scontent.fhan2-4.fna.fbcdn.net/v/t39.30808-6/500377219_1270351648423793_9020966315423932646_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=127cfc&_nc_eui2=AeF_0HQQH7QRzP6m0HLH8ClTBdpw1o6reHcF2nDWjqt4d3jvjIYq16AyP7FvTXujW4OfEilIZoCSrJxrXSJKUl1U&_nc_ohc=Bvm7nLvdI2cQ7kNvwF0Vmcs&_nc_oc=AdnEg_BkodVbs_dEZ_VDadBOFFk81Y5BiDlaMAXVAaG6_ErvTerosE37flFLWfYTlNJzdZqAZSwMPkriXmXDar4h&_nc_zt=23&_nc_ht=scontent.fhan2-4.fna&_nc_gid=Sd21MTo9vsAOpptWg0A3zw&oh=00_AfTv5zipzxx0vwRFL0mq-nxxqsJcj_-qM1ripsURwhOwXg&oe=68745D77",
            text: "Ngành Công nghệ nhiệt lạnh là "trái tim" của ngành công nghiệp hiện đại – từ máy lạnh dân dụng đến hệ thống làm mát công nghiệp. Bạn sẽ được đào tạo kỹ lưỡng để trở thành kỹ sư vận hành, bảo trì hoặc thiết kế hệ thống lạnh chất lượng cao, được các doanh nghiệp săn đón! #KyThuatLanh #DienLanh #CongNgheNong #NgheCoNhuCauCao"
        },
        it: {
            img: "https://scontent.fhan2-4.fna.fbcdn.net/v/t39.30808-6/493378185_1242876217838003_6764214639443226574_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=127cfc&_nc_eui2=AeEH3T2-BkdemcGXgyTCzjTvRJPD7Y3j36JEk8PtjePfojL-sZRZ52TL3WKQDKd52HRBn-gQmo9fH9obQMKDfz9I&_nc_ohc=3m2cojsQ2PcQ7kNvwHWeY9K&_nc_oc=AdmRDETPNh-_1CEOtb-pJhRcfz5WccfJa-tge0vqWFVw3QWjexh-fbt-Q_2RSTaKm1L3SUaDnalVIxeXbFq-TZfk&_nc_zt=23&_nc_ht=scontent.fhan2-4.fna&_nc_gid=43yoZPzPz4tmKQIjQzcN9A&oh=00_AfR_41hRssy09aPTc3yD5-WaJVbOqnGDwSVOI0q_Ye0_8g&oe=68746617",
            text: "Thế giới số gọi tên bạn! Ngành CNTT & Truyền thông cung cấp kỹ năng lập trình, thiết kế phần mềm, bảo mật, AI, và truyền thông số – là nền tảng cho startup, công ty phần mềm, và các tập đoàn công nghệ. Học để trở thành người tạo ra tương lai! #LapTrinh #CNTT #AI #DataScience #NgheCuaTuongLai"
        },
        automation: {
            img: "https://scontent.fhan2-4.fna.fbcdn.net/v/t39.30808-6/500473376_1270351365090488_6536980490667563924_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=127cfc&_nc_eui2=AeEWml_X59eVV_ao_cjq90YPFpF3g-cDzp4WkXeD5wPOnid6a8ToAn_1_5mCF7FxHoErcsiDU8o3Z7hvUFVVQ30U&_nc_ohc=KTqZZ9MZzusQ7kNvwF9CsKT&_nc_oc=AdkLmXPq2_SSrtAYc2V5Wbd6c3xJDkGhVdGjM2pCJq1MXi2DlzIAmTjBWGZCMAW3QKn_PbsP9Ca4i2YY5p-vhPgh&_nc_zt=23&_nc_ht=scontent.fhan2-4.fna&_nc_gid=DfJs5RuSYwxeVgUKTIrHhQ&oh=00_AfTbfmuV94-R-YdYHP7MuxZs7FOVC6cvUQXVKHA_TnoyTA&oe=6874707B",
            text: "Ngành Điện tự động hóa – nơi máy móc làm việc cho bạn. Bạn sẽ làm chủ công nghệ điều khiển, PLC, robot công nghiệp và hệ thống sản xuất thông minh. Cơ hội làm việc tại các nhà máy lớn, khu công nghiệp hiện đại và thu nhập hấp dẫn đang chờ bạn! #Robot #PLC #SmartFactory #TuDongHoa #NgheCongNghiep"
        },
        telecom: {
            img: "https://scontent.fhan2-3.fna.fbcdn.net/v/t39.30808-6/499270950_1262785005847124_995179609704205757_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=127cfc&_nc_eui2=AeHC7ygaIZzYCJARuFNDQi9XYsz2HxCyOwhizPYfELI7CCZN9W-EUxvbGKh3hPxHtrMrPMWMuCSlgeOvL7B88Y89&_nc_ohc=CcK2WW7Yzo0Q7kNvwGogND3&_nc_oc=AdleJ1LIUTb6ZsdVqeE551I1mqB0NB3lfz2LyQ6ZseaWJhDGyW281lQ18PDRnDa44MbgAskWztIgM0tw1nRezMBz&_nc_zt=23&_nc_ht=scontent.fhan2-3.fna&_nc_gid=y-FH6fTEvGmGRzkSBB5jvw&oh=00_AfTYemwjiUjDupdyM71dsP2VzYzKM9ILhi8ulXBRkWl3og&oe=68747403",
            text: "Bạn muốn kết nối thế giới? Ngành Điện tử Viễn thông giúp bạn làm chủ công nghệ truyền dẫn, thiết bị thông minh và mạng lưới toàn cầu. Từ thiết bị 5G đến vệ tinh, bạn sẽ là người tạo ra kết nối cho hàng triệu người! #5G #MangVienThong #DienTuSo #InternetVạnVat #KetNoiToanCau"
        }
    };

    const majorTags = document.querySelectorAll('.major-tags span');
    const detailBox = document.getElementById('major-detail');
    const imgBox = document.getElementById('major-img');
    const descBox = document.getElementById('major-desc');

    let isInitial = true;

    majorTags.forEach(tag => {
        tag.addEventListener('click', () => {
            majorTags.forEach(t => t.classList.remove('active'));
            tag.classList.add('active');

            const id = tag.getAttribute('data-id');
            const info = descriptions[id];
            if (info) {
                imgBox.src = info.img;
                descBox.innerHTML = info.text.replace(/\n/g, "<br>");
                detailBox.style.display = 'flex';

                if (!isInitial) {
                    detailBox.scrollIntoView({ behavior: 'smooth', block: 'center' });
                }
                isInitial = false;
            }
        });
    });

    // 5. Auto-select ngành đầu tiên
    document.addEventListener("DOMContentLoaded", () => {
        const slider = document.getElementById('slider-track');
        const btnLeft = document.getElementById('btn-left');
        const btnRight = document.getElementById('btn-right');
        const scrollAmount = 240; // tùy chiều rộng slider-item + khoảng cách

        btnLeft.addEventListener('click', () => {
            slider.scrollBy({ left: -scrollAmount, behavior: 'smooth' });
        });

        btnRight.addEventListener('click', () => {
            slider.scrollBy({ left: scrollAmount, behavior: 'smooth' });
        });
    });



});

