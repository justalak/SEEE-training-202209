
function myFunction() {
    const formpage = document.getElementById("formpage")
    const list1 = formpage.classList
    list1.add("hidden");
    const inforpage = document.getElementById("inforpage")
    const list2 = inforpage.classList
    list2.remove("hidden");
    const formData = new FormData(document.querySelector('form'))
    const nameElements = document.getElementsByClassName("Name");
    const h1tag = nameElements[0];
    const pNumElement = document.getElementsByClassName("PNumber")[0];
    const emailElement = document.getElementsByClassName("Email")[0];
    const addressElement = document.getElementsByClassName("Address")[0];
    let firstname= "";
    for (const pair of formData.entries()) {
        console.log(pair[0]+':'+pair[1]);
        if(pair[0] === "fname"){
            firstname= pair[1];
        }
        if(pair[0] === "lname"){
            const fullname = firstname + " " + pair[1];
            h1tag.innerHTML = fullname;
        }
        if(pair[0] === "pnumber"){
            pNumElement.innerHTML = pair[1].slice(0,-4)+'xxxx';
        }
        if(pair[0] === "email"){
            emailElement.innerHTML = pair[1];
        }
        if(pair[0] === "address"){
            addressElement.innerHTML = pair[1];
        }
        
    }
}