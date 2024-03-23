function hidePartyOrSerial(element) {
    $.ajax({
        url: '/Schema/GetSchemaInfo/',
        method: 'get',
        dataType: 'json',
        data: { id: element.selectedOptions[0].value },
        success: function (data) {
            let isSchemaForSerial = data.info.includes("Серийное");

            if (isSchemaForSerial) {
                $('#ProductQuantitiesIds option:selected').each(function () {
                    this.selected = false;
                }).trigger('change');
            }
            else {
                $('#ProductsIds option:selected').each(function () {
                    this.selected = false;
                }).trigger('change');
            }

            document.querySelector('.party').hidden = isSchemaForSerial;
            document.querySelector('.serial').hidden = !isSchemaForSerial;
        }
    });
};

function setVisibility_paragraphs(element) {
    let displayStatus = element.value == '' ? 'none' : 'inline';
    document.getElementById(element.id + 'Paragraphs').style.display = displayStatus;
};

var techRegIdCounter = 0;
var govStandardIdCounter = 0;

function addTechReg() {
    ++techRegIdCounter;

    let node = document.getElementById('rowTemplateTechReg');
    $('#TechRegParagraphs0TechRegId').select2('destroy');
    let clonedNode = node.cloneNode(true);
    prepareNode(clonedNode);

    let table = document.getElementById('tableTemplateTechReg');
    table.append(clonedNode);

    reInitializationSelect2();
    InitializeBtnAnimation();
};

function prepareNode(node) {
    node.id += techRegIdCounter;
    clearInputValue(node);
    changeNodeNames(node);
    setAttributesHiddenTrue(node);
    changeNodeIds(node);
    addDeleteButton(node);
};

function changeNodeNames(node) {
    let idsForChange = [
        '#TechRegParagraphs0TechRegId',
        '#TechRegParagraphs0Paragraphs'
    ];

    let tempElement;
    for (let i = 0; i < idsForChange.length; i++) {
        tempElement = node.querySelector(idsForChange[i]);
        tempElement.name = tempElement.name.replace(0, techRegIdCounter);
    }
};

function setAttributesHiddenTrue(node) {
    let idsForChange = [
        '#TechRegParagraphs0TechRegIdEdit',
        '#TechRegParagraphs0TechRegIdDetails',
        '#TechRegParagraphs0TechRegIdDelete',
        '#TechRegParagraphs0TechRegIdParagraphs'
    ];

    let tempElement;
    for (let i = 0; i < idsForChange.length; i++) {
        tempElement = node.querySelector(idsForChange[i]).style.display = 'none';
    }
};

function clearInputValue(node) {
    node.querySelector('#TechRegParagraphs0Paragraphs').value = '';
    let selectElement = node.querySelector('#TechRegParagraphs0TechRegId');
    selectElement.value = '';
    selectElement.options[0].value = '';
    selectElement.options[0].innerHTML = '';
};

function changeNodeIds(node) {
    let idsForChange = [
        '#TechRegParagraphs0TechRegId',
        '#TechRegParagraphs0TechRegIdEdit',
        '#TechRegParagraphs0TechRegIdDetails',
        '#TechRegParagraphs0TechRegIdDelete',
        '#TechRegParagraphs0TechRegIdParagraphs',
        '#TechRegParagraphs0Paragraphs'
    ];

    let tempElement;
    for (let i = 0; i < idsForChange.length; i++) {
        tempElement = node.querySelector(idsForChange[i]);
        tempElement.id = tempElement.id.replace(0, techRegIdCounter);
    }
};

function addDeleteButton(node) {
    let child = document.createElement('div');
    child.setAttribute('class', 'btn btn-close btn-danger col-md-1');
    child.setAttribute('onmouseover', '');
    child.setAttribute('style', 'cursor: pointer;');
    child.setAttribute('onclick', 'deleteElement(this)');
    node.children[0].children[0].prepend(child);
};

function deleteElement(elem) {
    document.querySelector('#tableTemplateTechReg').removeChild(elem.parentElement.parentElement.parentElement);
    renameIds();
    reInitializationSelect2();
};

function renameIds() {
    let nodes = document.querySelectorAll("div[id^='rowTemplateTechReg']");
    for (let i = 1; i < nodes.length; i++) {
        let oldNumber = nodes[i].id.replace(nodes[0].id, '');
        nodes[i].id = nodes[i].id.replace(oldNumber, i);

        let ids = nodes[i].querySelectorAll("[id^='TechRegParagraphs']");
        for (let j = 0; j < ids.length; j++) {
            ids[j].id = ids[j].id.replace(oldNumber, i);
        }

        let names = nodes[i].querySelectorAll("[name^='TechRegParagraphs']");
        for (let j = 0; j < names.length; j++) {
            names[j].name = names[j].name.replace(oldNumber, i);
        }
    }
    techRegIdCounter = nodes.length - 1;
};

function addGovStandard() {
    ++govStandardIdCounter;

    let node = document.getElementById('rowTemplateGovStandard');
    $('#GovStandardParagraphs0GovStandardId').select2('destroy');
    let clonedNode = node.cloneNode(true);
    prepareGovStandardNode(clonedNode);

    let table = document.getElementById('tableTemplateGovStandard');
    table.append(clonedNode);

    reInitializationSelect2();
    InitializeBtnAnimation();
};

function prepareGovStandardNode(node) {
    node.id += govStandardIdCounter;
    clearGovStandardInputValue(node);
    changeGovStandardNodeNames(node);
    setGovStandardAttributesHiddenTrue(node);
    changeGovStandardNodeIds(node);
    addGovStandardDeleteButton(node);
};

function changeGovStandardNodeNames(node) {
    let idsForChange = [
        '#GovStandardParagraphs0GovStandardId',
        '#GovStandardParagraphs0Paragraphs'
    ];

    let tempElement;
    for (let i = 0; i < idsForChange.length; i++) {
        tempElement = node.querySelector(idsForChange[i]);
        tempElement.name = tempElement.name.replace(0, govStandardIdCounter);
    }
};

function setGovStandardAttributesHiddenTrue(node) {
    let idsForChange = [
        '#GovStandardParagraphs0GovStandardIdEdit',
        '#GovStandardParagraphs0GovStandardIdDetails',
        '#GovStandardParagraphs0GovStandardIdDelete',
        '#GovStandardParagraphs0GovStandardIdParagraphs'
    ];

    let tempElement;
    for (let i = 0; i < idsForChange.length; i++) {
        tempElement = node.querySelector(idsForChange[i]).style.display = 'none';
    }
};

function clearGovStandardInputValue(node) {
    node.querySelector('#GovStandardParagraphs0Paragraphs').value = '';
    let selectElement = node.querySelector('#GovStandardParagraphs0GovStandardId');
    selectElement.value = '';
    selectElement.options[0].value = '';
    selectElement.options[0].innerHTML = '';
};

function changeGovStandardNodeIds(node) {
    let idsForChange = [
        '#GovStandardParagraphs0GovStandardId',
        '#GovStandardParagraphs0GovStandardIdEdit',
        '#GovStandardParagraphs0GovStandardIdDetails',
        '#GovStandardParagraphs0GovStandardIdDelete',
        '#GovStandardParagraphs0GovStandardIdParagraphs',
        '#GovStandardParagraphs0Paragraphs'
    ];

    let tempElement;
    for (let i = 0; i < idsForChange.length; i++) {
        tempElement = node.querySelector(idsForChange[i]);
        tempElement.id = tempElement.id.replace(0, govStandardIdCounter);
    }
};

function addGovStandardDeleteButton(node) {
    let child = document.createElement('div');
    child.setAttribute('class', 'btn btn-close btn-danger col-md-1');
    child.setAttribute('onmouseover', '');
    child.setAttribute('style', 'cursor: pointer;');
    child.setAttribute('onclick', 'deleteGovStandardElement(this)');
    node.children[0].children[0].prepend(child);
};

function deleteGovStandardElement(elem) {
    document.querySelector('#tableTemplateGovStandard').removeChild(elem.parentElement.parentElement.parentElement);
    renameGovStandardIds();
    reInitializationSelect2();
};

function renameGovStandardIds() {
    let nodes = document.querySelectorAll("div[id^='rowTemplateGovStandard']");
    for (let i = 1; i < nodes.length; i++) {
        let oldNumber = nodes[i].id.replace(nodes[0].id, '');
        nodes[i].id = nodes[i].id.replace(oldNumber, i);

        let ids = nodes[i].querySelectorAll("[id^='GovStandardParagraphs']");
        for (let j = 0; j < ids.length; j++) {
            ids[j].id = ids[j].id.replace(oldNumber, i);
        }

        let names = nodes[i].querySelectorAll("[name^='GovStandardParagraphs']");
        for (let j = 0; j < names.length; j++) {
            names[j].name = names[j].name.replace(oldNumber, i);
        }
    }
    govStandardIdCounter = nodes.length - 1;
};

function reInitializationSelect2() {
    let selectElements = [];

    pushTechRegToElements(selectElements, 0);
    pushTechRegToElements(selectElements, techRegIdCounter);
    pushGovStandardToElements(selectElements, 0);
    pushGovStandardToElements(selectElements, govStandardIdCounter);

    establishSelect2Algorithm(selectElements);
};

function pushTechRegToElements(selectElements, elementIndex) {
    selectElements.push({
        id: '#TechRegParagraphs' + elementIndex + 'TechRegId',
        url: '/TechReg/GetTechRegs/',
        placeholder: 'Выберите тех. регламент'
    });
};

function pushGovStandardToElements(selectElements, elementIndex) {
    selectElements.push({
        id: '#GovStandardParagraphs' + elementIndex + 'GovStandardId',
        url: '/GovStandard/GetGovStandards/',
        placeholder: 'Выберите ГОСТ'
    });
};