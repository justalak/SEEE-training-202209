
function Validate (formSelector) {
    var formElement = document.querySelector(formSelector);
    var formRules = {};

    function getParents(element, selector){
        while (element.parentElement) {
            if( element.parentElement.matches(selector) ){
                return element.parentElement;
            }
            element = element.parentElement;
        }
    }

    var validateRules = {
        required: function (value) {
            return value ? undefined : 'Please fill in';
        },
        email: function (value) {
            var regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return regex.test(value) ? undefined : `Please fill your email in`;
        },
        length: function (number) {
            return function (value) {
                return value.length == number ? undefined : `Phone number must have ${number} digits`;
            }
        }
    }

    if(formElement){
        var inputs = formElement.querySelectorAll('[name][rules]');
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

            // listen event
            input.onblur = handelValidate;
            input.oninput = handelClearError;
        }

        function handelValidate(event) {
            var rules = formRules[event.target.name];
            var errorMessage;
            for(var rule of rules){
                errorMessage = rule(event.target.value);
                if(errorMessage){
                    break;
                }
            }
            if(errorMessage){
                var formGroup = getParents(event.target, '.detail');
                if( formGroup ) {
                    formGroup.classList.add('.invalid');
                    var formMessage = formGroup.querySelector('.report');
                    if( formMessage ){
                        formMessage.innerText = errorMessage;
                    }
                }
            }
            return !errorMessage;
        }

        function handelClearError(event) {
            var formGroup = getParents(event.target, '.detail');
            if( formGroup.classList.contains('.invalid') ) {
                formGroup.classList.remove('.invalid');
                var formMessage = formGroup.querySelector('.report'); 
                if( formMessage ){
                    formMessage.innerText = '';
                }
            }
        }
    }

    var _this = this;

    formElement.onsubmit = function (event) {
        event.preventDefault();
        var inputs = formElement.querySelectorAll('[name][rules]');
        var isValid = true;
        for(var input of inputs){
            if (!handelValidate({ target: input })) {
                isValid = false;
            }
        }
        if(isValid){            
            if(typeof _this.onSubmit === 'function'){
                var enableInput = formElement.querySelectorAll('[name][rules]');
                var formValues = Array.from(enableInput).reduce( function (values, input) {
                    switch( input.type ) {
                        default:
                            values[input.name] = input.value;
                    }
                    return values;
                }, {} );
                _this.onSubmit(formValues);
                formElement.submit();
            }else{
                formElement.submit();
            }
        }
    }
}