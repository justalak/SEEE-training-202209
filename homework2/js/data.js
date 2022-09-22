var nameData = sessionStorage.getItem("name");
var jobData = sessionStorage.getItem("job")
var phoneData = sessionStorage.getItem("phone");
var emailData = sessionStorage.getItem("email");
var addressData = sessionStorage.getItem("address");
var summaryData = sessionStorage.getItem("summary");

nameData = titleCase(nameData);
document.getElementById('name').outerHTML = `<h4 id="name"><strong>${nameData}</strong></h4>`;
document.title = nameData;

document.getElementById("job").innerHTML = `<h5>${jobData}</h5>`;

document.getElementById('phone').innerHTML= `<span>${phoneData}</span>`;

document.getElementById('email').innerHTML= `<span>${emailData}</span>`;

document.getElementById('adress').innerHTML= `<span>${addressData}</span>`;

document.getElementById('summary').innerHTML= `<p>${summaryData}</p>`;

// document.getElementById('facebookLink').setAttribute('href', `fblink:${facebookLinkData}`);

function titleCase(string) {
    let sentence = string.toLowerCase().split(" ");
    for (var i = 0; i < sentence.length; i++) {
        sentence[i] = sentence[i][0].toUpperCase() + sentence[i].slice(1);
    }
    return sentence.join(" ");
}

console.log(nameData);
