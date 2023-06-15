

/*js liên quan đến trang Layout*/

window.onload = function () {
    var nameUserLink = document.querySelector('.Name_user');
    var loginLink = document.querySelector('.nav_link_login');
    var menu_admin = document.querySelector('.nav_menu_admin');

    // Kiểm tra xem có cookie chứa tên đăng nhập không
    var usernameCookie = getCookie('Username');

    if (usernameCookie !== '') {
        nameUserLink.style.display = 'block';
        loginLink.style.display = 'none';
        nameUserLink.textContent = usernameCookie;
    } else {
        nameUserLink.style.display = 'none';
        loginLink.style.display = 'block';
    }

    // Kiểm tra xem có cookie chứa loại tài khoản không
    var loaitaikhoanCookie = getCookie('Loaitaikhoan');
    //nếu loại tài khoản bằng admin thì sẽ hiển thị giao diện cho riêng admin
    if (loaitaikhoanCookie == 'admin') {
        menu_admin.style.display = 'flex';
    }
    else {
        menu_admin.style.display = 'none'
    }
};

function getCookie(name) {
    var cookieName = name + '=';
    var decodedCookie = decodeURIComponent(document.cookie);
    var cookieArray = decodedCookie.split(';');

    for (var i = 0; i < cookieArray.length; i++) {
        var cookie = cookieArray[i];
        while (cookie.charAt(0) === ' ') {
            cookie = cookie.substring(1);
        }
        if (cookie.indexOf(cookieName) === 0) {
            return cookie.substring(cookieName.length, cookie.length);
        }
    }
    return '';
}

function logout() {
    // Xóa cookie "Username"
    document.cookie = 'Username=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';    //thời gian mà cookie hết hạn để xoá

    // Xóa cookie "Loaitaikhoan"
    document.cookie = 'Loaitaikhoan=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';

    // Chuyển hướng về trang chủ
    window.location.href = "/views/index";
}






//js liên quan đến phần hiện ngày tháng trên layout

// Lấy đối tượng thẻ p chứa ngày hôm nay
var currentDateElement = document.getElementById("current_date");

// Lấy ngày hôm nay
var currentDate = new Date();
var day = currentDate.getDate();
var month = currentDate.getMonth() + 1; // Tháng được đánh số từ 0 đến 11
var year = currentDate.getFullYear();

// Định dạng ngày tháng
var formattedDate = day + "/" + month + "/" + year;

// Gán giá trị ngày hôm nay vào thẻ p
currentDateElement.textContent = formattedDate;





//js giới hạn văn bản trên trang Index

var descriptions = document.querySelectorAll('.news_list_desc_summary');
for (var i = 0; i < descriptions.length; i++) {
    var description = descriptions[i];
    var text = description.textContent;
    if (text.length > 200) {
        description.textContent = text.slice(0, 500) + '...';
    }
}

var titles = document.querySelectorAll('.menuleft_item_link');
for (var i = 0; i < titles.length; i++) {
    var title = titles[i];
    var text = title.textContent;
    if (text.length > 100) {
        title.textContent = text.slice(0, 120) + '...';
    }
}
