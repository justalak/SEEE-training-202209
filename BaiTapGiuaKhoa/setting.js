const button = document.getElementById("btn");
const cv = document.getElementById("trangcanhan");
const form = document.getElementById("dienthongtin");
const tendangnhap = document.getElementById("tendangnhap");
const tendangnhapcv = document.getElementById("tendangnhapcv");
const emailcv = document.getElementById("emailcv");
const email = document.getElementById("email");
const telcv = document.getElementById("telcv");
const tel = document.getElementById("tel");
const addresscv = document.getElementById("addresscv");
const address = document.getElementById("address");
button.onclick = function(e) {
    console.log(tendangnhap.value);
    tendangnhapcv.innerHTML = "Name : " + tendangnhap.value;
    emailcv.innerHTML = "Email : " + email.value;
    telcv.innerHTML = "Tel : " + tel.value;
    addresscv.innerHTML = "Address : " + address.value;
    //tendangnhapcv.va = tendangnhap.value();
    //tendangnhapcv.innerTextHTML(tendangnhap.value);
    cv.style.display = "block";
    cv.style.zIndex = 1;
    form.style.display = "none";
    e.preventDefault();
};