var nameData = sessionStorage.getItem("name");
var phoneData = sessionStorage.getItem("phone");
var emailData = sessionStorage.getItem("email");
var addressData = sessionStorage.getItem("address").replace(/[.,\/#!$%\^&\*;:{}=\-_`~()] /g, '+');

nameData = titleCase(nameData);
document.getElementById('name').outerHTML = `<h1 id="name"><strong>${nameData}</strong></h1>`;
document.title = nameData;

document.getElementById('phone').setAttribute('href', `tel:${phoneData}`);

document.getElementById('email').setAttribute('href', `mailto:${emailData}`);

document.getElementById('address').setAttribute('href', `https://www.google.com/maps/place/${addressData}+Việt+Nam`);

function titleCase(string) {
    let sentence = string.toLowerCase().split(" ");
    for (var i = 0; i < sentence.length; i++) {
        sentence[i] = sentence[i][0].toUpperCase() + sentence[i].slice(1);
    }
    return sentence.join(" ");
}

console.log(nameData);