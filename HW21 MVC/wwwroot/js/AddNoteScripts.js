
var corDictio = new Map();// Dictionary that will indicate that the form is right

var submitelem;//Submit button

var count = 0;//Count of inputs

document.addEventListener('DOMContentLoaded', app)//Add EventListener to DOM HTML object
//

//Sets validate function to a propriate DOM object according to a class name in Styles.css
function SetValidatorByClassName(className, event, validator)
{
    let ElemList = document.querySelectorAll(className);

    for (let i = 0; i < ElemList.length; i++) {
        ElemList[i].addEventListener(event, validator);
        count += 1;
    }
}
//Set the propriate validation function to a DOM objects
 function app()
 {
     submitelem = document.querySelector('.submit');

     submitelem.disabled = true;

     submitelem.className = 'subdisabled';

     SetValidatorByClassName('.numbinp', 'change', numbervalid);

     SetValidatorByClassName('.textinp', 'change', textvalid);

     SetValidatorByClassName('.numbtxt', 'change', txtnumbervalid);    
}
//Inserts key value pair to dictionary
function insertToArray(id, value, corDictio) {
    if (!corDictio.has(id)) {
        corDictio.set(id, value);
    }
    else {
        if (corDictio.get(id) != value) {
            corDictio.set(id, value);
        }
    }
}

//Checks wether submit button must be enabled
function ShouldSubmitBeEnabled(corDictio, count, submitelem ) {        
    if (corDictio.size != count) {
        
        return;
    }
            
    let isFormCorrect = false;

    for (var [key, value] of corDictio)
    {
        if (value == false) {
            isFormCorrect = false;
            break;
        }
        else {
            isFormCorrect = true;
        }
    }

    submitelem.disabled = !isFormCorrect;

    if (isFormCorrect) {
        submitelem.className = 'submit';
    }
    else {
        submitelem.className = 'subdisabled';
    }

    
}
//Evaluates text and number inputs
var txtnumbervalid = function TxtNumbValidation(event) {
    let element = event.target;

    element.className = 'correctinp';

    insertToArray(element.id, true, corDictio);

    ShouldSubmitBeEnabled(corDictio, count, submitelem);
}

//Evaluates text input fields
var textvalid = function ValidateText(event)
{    
    let element = event.target;

    let text = element.value;

    let Iscorrect = true;
    
    for (var i = 0; i < text.length; i++)
    {
        if (!Number.isNaN(parseFloat(text[i])))
        {
            Iscorrect = false;
            break;
        }          
    }

    insertToArray(element.id, Iscorrect, corDictio);

    if (Iscorrect)
    {
        element.className = 'correctinp';
    }
    else
    {
        element.className = 'errorinp';
    }

    ShouldSubmitBeEnabled(corDictio, count, submitelem);
}
//Evaluates numbers input
var numbervalid = function ValidatePhone(event)
{
    let element = event.target;
    let text = element.value.replaceAll(' ', '');
    let IsCorect = true;
    let i;

    if (text.length > 20) {
        IsCorect = false;
    }
    else {
        if (text[0] == '+') {
            i = 1;
        }
        else {
            i = 0;
        }

        for (; i < text.length; i++) {
            if (Number.isNaN(parseFloat(text[i]))) {
                IsCorect = false;
                break;
            }
        }
    }
    
    insertToArray(element.id, IsCorect, corDictio);

    if (IsCorect) {
        element.className = 'correctinp';
    }
    else {
        element.className = 'errorinp';
    }

    ShouldSubmitBeEnabled(corDictio, count, submitelem);
}



