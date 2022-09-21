function validate() {
    var u = document.getElementById("Full_name").value;
    var p1 = document.getElementById("Date_of_birth").value;
    var p2 = document.getElementById("Phone_number").value;
    var p3 = document.getElementById("Email").value;
    var p4 = document.getElementById("Address").value;

var check = document.getElementById("sub")
check.onsubmit = function (e) {
    if (u == "") {
        e.preventDefault()
        alert("Input your name!");
 
        return false;
    }
    if (p1 == "") {
        e.preventDefault()
        alert("Input your date of birth!");
        
        return false;
    }
    if (p2 == "") {
        e.preventDefault()
        alert("Input your Phone number!");
        
        return false;
    }
    if (p3 == "") {
        e.preventDefault()
        alert("Input your Email!");
        
        return false;
    }
    if (p4 == "") {
        e.preventDefault()
        alert("Input your Address!");
        
        return false;
    }
}
   


   getInfor();

    return true
}
function getInfor() {
    var u = document.getElementById("Full_name").value;
    var p1 = document.getElementById("Date_of_birth").value;
    var p2 = document.getElementById("Phone_number").value;
    var p3 = document.getElementById("Email").value;
    var p4 = document.getElementById("Address").value;
    // var p5 = document.getElementById("Picture").value;
   
   localStorage.setItem('user-name',u)
   localStorage.setItem('user-Date_of_birth',p1)
   localStorage.setItem('user-Phone_number',p2)
   localStorage.setItem('user-Email',p3)
   localStorage.setItem('user-Address',p4)
//    localStorage.setItem('user-Picture',URL.createObjectURL(p5))
}


