
function Validate (idForm) {

    function onSubmit(data){
        sessionStorage.setItem("name", data.name);
        sessionStorage.setItem("phone", data.phone);
        sessionStorage.setItem("email", data.email);
        sessionStorage.setItem("address", data.address);
    }

    var formElement = document.querySelector(idForm);
    var formRules = {};

    // defind rules
    var validateRules = {
        required: function (value) {
            return value ? undefined : 'Please fill in';
        },
        email: function (value) {
            var regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return regex.test(value) ? undefined : `Please check your email`;
        },
        length: function (number) {
            return function (value) {
                return value.length == number ? undefined : `Phone number must have ${number} digits`;
            }
        }
    }

    // get all rules of elements
    var inputs = formElement.querySelectorAll("[rules]");
    for(var input of inputs){
        var rules = input.getAttribute('rules').split('|');
        for(var rule of rules){
            var ruleInfo;
            var isRuleHasValue = rule.includes(':');
            if(isRuleHasValue){
                ruleInfo = rule.split(':');
                rule = ruleInfo[0];
            }
            var ruleFunc = validateRules[rule];
            if(isRuleHasValue){
                ruleFunc = ruleFunc(ruleInfo[1]);
            }
            if(Array.isArray(formRules[input.name])){
                formRules[input.name].push(ruleFunc);
            }else {
                formRules[input.name] = [ruleFunc];
            }
        }

        // listen event -> validate
        input.onblur = formValidator;       // when blur -> valadate mesage

        input.oninput = function (event) {  // remove validate mess when true
            var inputGroup = event.target.parentElement;
            if( inputGroup.classList.contains('.invalid') ) {
                inputGroup.classList.remove('.invalid');
                var formMessage = inputGroup.querySelector('.mess'); 
                if( formMessage ){
                    formMessage.innerText = '';
                }
            }
        };
    }

    function formValidator(event) {
        var rules = formRules[event.target.name];
        var errorMessage;
        for(var rule of rules){
            errorMessage = rule(event.target.value);
            if(errorMessage){
                break;
            }
        }
        if(errorMessage){
            var inputGroup = event.target.parentElement;
            if( inputGroup ) {
                inputGroup.classList.add('.invalid');
                var formMessage = inputGroup.querySelector('.mess');
                if( formMessage ){
                    formMessage.innerText = errorMessage;
                }
            }
        }
        return !errorMessage;
    }

    // action submit
    formElement.onsubmit = function (event) {
        event.preventDefault();
        var inputs = formElement.querySelectorAll('[rules]');
        var isValid = true;
        for(var input of inputs){
            if (!formValidator({ target: input })) {
                isValid = false;
            }
        }
        if(isValid){            
            if(typeof onSubmit === 'function'){
                var enableInput = formElement.querySelectorAll('[rules]');
                var inputValues = Array.from(enableInput).reduce( function (values, input) {
                    values[input.name] = input.value;
                    return values;
                }, {} );
                onSubmit(inputValues);
                formElement.submit();
            }else{
                formElement.submit();
            }
        }
    }
}