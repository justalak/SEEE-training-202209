function Upload() {
    var name = localStorage.getItem("user-name") || 'User Name '
    var date = localStorage.getItem("user-Date_of_birth") || "Date of Birth"
    var phone = localStorage.getItem("user-Phone_number") || "Phone Number"
    var email = localStorage.getItem("user-Email") || "Email"
    var address = localStorage.getItem("user-Address") || "Address"
    var Dob = date.split('-').reverse().join("-")
    // var picture = localStorage.getItem("user-Picture") 
    document.getElementById("user-name").innerText = name;
    document.getElementById('dob').innerHTML = ': ' + Dob;
    document.getElementById("phone").innerHTML = ' : ' + phone;
    document.getElementById("email").innerHTML = ' : ' + email;
    document.getElementById('add').innerHTML = ' : ' + address;
    // document.getElementById('Avatar').src = picture
}
var show_detail = false
var str1 = ""
var str2 = ""
var str3 = ""
function Show_detail1() {
    show_detail = !show_detail
    if (show_detail) {
        str1 = ` <li>Bank management system</li>
                <li> User: Add, view, check, sort</li>
                <li>Admin: Management</li> `

        document.getElementById("list1").innerHTML = str1
        document.getElementById("prjheader1").innerHTML = ""

    }
    else {
        str1 = ""
        document.getElementById("list1").innerHTML = str1
        document.getElementById("prjheader1").innerHTML = "Project 1"

    }
}
function Show_detail2() {
    show_detail = !show_detail
    if (show_detail) {
        str2 = `<li>Car parking system</li>
                <li>User: Pay bill, find available parking place</li>
                <li>Admin: Management</li>`

        document.getElementById("list2").innerHTML = str2
        document.getElementById("prjheader2").innerHTML = ""

    }
    else {
        str2 = ""
        document.getElementById("list2").innerHTML = str2
        document.getElementById("prjheader2").innerHTML = "Project 2"

    }
}
function Show_detail3() {
    show_detail = !show_detail
    if (show_detail) {
        str3 = `<li>Student management system</li>
                <li>User: Class registration, point lookup, search student information,... </li>
                <li>Admin: Management</li>`

        document.getElementById("list3").innerHTML = str3
        document.getElementById("prjheader3").innerHTML = ""

    }
    else {
        str3 = ""
        document.getElementById("list3").innerHTML = str3
        document.getElementById("prjheader3").innerHTML = "Project 3"

    }
}