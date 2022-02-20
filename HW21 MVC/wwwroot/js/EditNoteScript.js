document.addEventListener('DOMContentLoaded', app);
let submit;
var isFormAllCorrect = new Map();
let tableInfo;
let count = 0;
let atributes = new Map();
let formdiv;
let headers;
let Tabledata;

//Validation module
//Evaluates text input fields
let txtvalidation = function (event)
{
    let element = event.target;

    let text = element.value;

    let Iscorrect = true;

    for (var i = 0; i < text.length; i++) {
        if (!Number.isNaN(parseFloat(text[i]))) {
            Iscorrect = false;
            break;
        }
    }

    insertToDictionary(element.id, Iscorrect, isFormAllCorrect);
    
    if (Iscorrect) {
        element.className = 'correctinp';
    }
    else {
        element.className = 'errorinp';
    }

    ShouldSubmitBeEnabled(isFormAllCorrect, submit);   
}
//Evaluates number validation fields
let numbervalidation = function (event)
{
    let elem = event.target;
    let text = elem.value.replaceAll(' ', '');
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
    
    insertToDictionary(elem.id, IsCorect, isFormAllCorrect);

    if (IsCorect) {
        elem.className = 'correctinp';
    }
    else {
        elem.className = 'errorinp';
    }

    ShouldSubmitBeEnabled(isFormAllCorrect, submit);

}
//Evaluates number-text validation fields
let numbtextvalidation = function (event) {
    let element = event.target;

    element.className = 'correctinp';

    insertToDictionary(element.id, true, isFormAllCorrect);

    ShouldSubmitBeEnabled(isFormAllCorrect, submit);
}
//Insert [key value] pair if value differs from existing value in dictionary
function insertToDictionary(id, value, corDictio) {
    
    if (corDictio.get(id) != value) {
        corDictio.set(id, value);
    }
    
}
//Desides wether submit button must be enabled
function ShouldSubmitBeEnabled(corDictio, submitelem)
{
    let isCorrect = true;

    for (let [key, value] of corDictio) {
        if (!value) {
            isCorrect = false;
        }
    }

    submitelem.disabled = !isCorrect;

    if (isCorrect) {
        submitelem.className = 'submit';        
    }
    else {
        submitelem.className = 'subdisabled';        
    }

}

//Validation module

//Will get the DOM components of a table and pars them 
function app() {
    formdiv = document.querySelector('.formEdit');
    formdiv.className = 'form';
    SetFunctionToElement('addform', 'click', onEditClick);

    tableInfo = document.getElementById('parstable');

    let tBody = tableInfo.children; //Tbody

    let tableRowCollection = tBody[0].children;// table rows collection

     headers = tableRowCollection[0].children;//table rows headers

     Tabledata = tableRowCollection[1].children;//table rows data

    for (let i = 1; i < headers.length; i++) {
        isFormAllCorrect.set(headers[i].innerText, true);
        count++;
    }

    
}

//Event that will be fired when edit button is pressed
//It will create and fill form for editing Note
var onEditClick = (event) => {

    let elem = event.target;
    elem.hidden = true;

    let a = document.getElementById('addform');

    a.hidden = true;

    //Create form
    atributes.set('action', '/Admin/Admin/EditNote/id=' + Tabledata[0].innerText);
    atributes.set('method', 'post');
    let form = CreateElem('form', undefined, atributes, undefined, undefined);
    atributes.clear();
    //Create form
    for (let i = 1; i < headers.length; i++) {
        switch (headers[i].innerText) {
            case 'Phone':
                AddFormElementToForm(form, headers[i].innerText, true, 'change', numbervalidation, Tabledata[i].innerText);
                break;
            case 'Adress':
            case 'Description':
                AddFormElementToForm(form, headers[i].innerText, false, 'change', numbtextvalidation, Tabledata[i].innerText);
                break;
            default:
                AddFormElementToForm(form, headers[i].innerText, true, 'change', txtvalidation, Tabledata[i].innerText);
                break;
        }
    }

    let paragraph = CreateElem('p');

    atributes.set('type', 'submit');
    atributes.set('name', 'Edit');
    atributes.set('value', 'Edit Note');
    submit = CreateElem('input', 'submit', atributes);
    atributes.clear();

    paragraph.appendChild(submit);

    form.appendChild(paragraph);

    formdiv.appendChild(form);
}

//Adds element to form in DOM 
function AddFormElementToForm(formItem, inputName_ID, inpArea = true, event, func, value = "",
    cols = 70, rows = 3, wrap = 'soft')
{
    formItem.appendChild(CreateFormItem(inputName_ID, inpArea,
        event, func, value, cols, rows, wrap));
}
//Creates label-input objects
function CreateFormItem(inputName_ID, inpArea = true, event, func, value = "",
cols, rows, wrap) {
    //Create div form item
    let formItemDiv = CreateElem('div', 'formitem');

    //Create label
    let label = CreateElem('label');
    label.innerText = "Enter " + inputName_ID +": ";
    //Create label
    //Create Border
    let border = CreateElem('br');
    //Create Input or TextArea
    let input

    if (inpArea) { //Input
        atributes.set('type', 'text');
        atributes.set('name', inputName_ID);
        atributes.set('id', inputName_ID);
        atributes.set('value', value);
        input = CreateElem('input', undefined, atributes, event, func);
        atributes.clear();
    }
    else { //Area
        atributes.set('name', inputName_ID);
        atributes.set('id', inputName_ID);
        atributes.set('rows', rows);
        atributes.set('cols', cols);
        atributes.set('wrap', wrap);
        input = CreateElem('textarea', undefined, atributes, event, func);
        input.innerText = value;
        atributes.clear();
    }
    
    //Create InputorTextArea
    
    //Assembl element
    formItemDiv.appendChild(label);
    formItemDiv.appendChild(border);
    formItemDiv.appendChild(input);
    formItemDiv.appendChild(border);    
    //Assembly element
    return formItemDiv;
}
//Sets propriate function to element according to id
function SetFunctionToElement(id, event, func) {
    let element = document.getElementById(id);
    element.addEventListener(event, func);
}
//Creates Element
function CreateElem(tagName, classname = undefined,
    atribs = undefined, event = undefined, func = undefined) {
    
    let element = document.createElement(tagName);

    if (classname != undefined) {
        element.className = classname;
    }

    if (atribs != undefined && atribs.size != 0) {
        for (let [key, value] of atribs) {
            element.setAttribute(key, value);
        }
    }

    if (event != undefined && func != undefined) {
        element.addEventListener(event, func);
    }

    return element;
}





