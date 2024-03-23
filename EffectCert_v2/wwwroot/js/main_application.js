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
    addElement('TechReg', techRegIdCounter);
};

function addGovStandard() {
    ++govStandardIdCounter;
    addElement('GovStandard', govStandardIdCounter);
};

function addElement(elemStr, counter) {
    let node = document.getElementById('rowTemplate' + elemStr);
    $(`#${elemStr}Paragraphs0${elemStr}Id`).select2('destroy');
    let clonedNode = node.cloneNode(true);
    prepareNode(clonedNode, elemStr, counter);

    let table = document.getElementById('tableTemplate' + elemStr);
    table.append(clonedNode);

    reInitializationSelect2();
    InitializeBtnAnimation();
};

function prepareNode(node, elemStr, counter) {
    node.id += counter;
    clearInputValue(node, elemStr);
    changeNodeNames(node, elemStr, counter);
    setAttributesHiddenTrue(node, elemStr, counter);
    changeNodeIds(node, elemStr, counter);
    addDeleteButton(node, elemStr, counter);
};

function clearInputValue(node, elemStr) {
    node.querySelector(`#${elemStr}Paragraphs0Paragraphs`).value = '';
    let selectElement = node.querySelector(`#${elemStr}Paragraphs0${elemStr}Id`);
    selectElement.value = '';
    selectElement.options[0].value = '';
    selectElement.options[0].innerHTML = '';
};

function changeNodeNames(node, elemStr, counter) {
    let idsForChange = [
        `#${elemStr}Paragraphs0${elemStr}Id`,
        `#${elemStr}Paragraphs0Paragraphs`
    ];

    let tempElement;
    for (let i = 0; i < idsForChange.length; i++) {
        tempElement = node.querySelector(idsForChange[i]);
        tempElement.name = tempElement.name.replace(0, counter);
    }
};

function setAttributesHiddenTrue(node, elemStr) {
    let fullElemStr = `#${elemStr}Paragraphs0${elemStr}Id`;
    let idsForChange = [
        `${fullElemStr}Edit`,
        `${fullElemStr}Details`,
        `${fullElemStr}Delete`,
        `${fullElemStr}Paragraphs`
    ];

    let tempElement;
    for (let i = 0; i < idsForChange.length; i++) {
        tempElement = node.querySelector(idsForChange[i]).style.display = 'none';
    }
};

function changeNodeIds(node, elemStr, counter) {
    let fullElemStr = `#${elemStr}Paragraphs0${elemStr}Id`;
    let idsForChange = [
        `${fullElemStr}`,
        `${fullElemStr}Edit`,
        `${fullElemStr}Details`,
        `${fullElemStr}Delete`,
        `${fullElemStr}Paragraphs`,
        `#${elemStr}Paragraphs0Paragraphs`
    ];

    let tempElement;
    for (let i = 0; i < idsForChange.length; i++) {
        tempElement = node.querySelector(idsForChange[i]);
        tempElement.id = tempElement.id.replace(0, counter);
    }
};

function addDeleteButton(node, elemStr, counter) {
    let child = document.createElement('div');
    child.setAttribute('class', 'btn btn-close btn-danger col-md-1');
    child.setAttribute('deletebtnptr', `${elemStr}DeleteBtn`)
    child.setAttribute('onmouseover', '');
    child.setAttribute('style', 'cursor: pointer;');
    child.setAttribute('onclick', 'deleteElement(this)');
    node.children[0].children[0].prepend(child);
};

function deleteElement(elem) {
    let elemStr = elem.getAttribute('deletebtnptr').replace('DeleteBtn', '');
    while (true) {
        if (elem.id.includes('rowTemplate')) {
            break;
        }
        elem = elem.parentElement;
    }
    document.querySelector(`#tableTemplate${elemStr}`).removeChild(elem);
    renameIds(elemStr);
    reInitializationSelect2();
};

function renameIds(elemStr) {
    let nodes = document.querySelectorAll(`div[id^='rowTemplate${elemStr}']`);
    for (let i = 1; i < nodes.length; i++) {
        let oldNumber = nodes[i].id.replace(nodes[0].id, '');
        nodes[i].id = nodes[i].id.replace(oldNumber, i);

        let ids = nodes[i].querySelectorAll(`[id^='${elemStr}Paragraphs']`);
        for (let j = 0; j < ids.length; j++) {
            ids[j].id = ids[j].id.replace(oldNumber, i);
        }

        let names = nodes[i].querySelectorAll(`[name^='${elemStr}Paragraphs']`);
        for (let j = 0; j < names.length; j++) {
            names[j].name = names[j].name.replace(oldNumber, i);
        }
    }

    switch (elemStr) {
        case 'TechReg':
            techRegIdCounter = nodes.length - 1;
            break;
        case 'GovStandard':
            govStandardIdCounter = nodes.length - 1;
            break;
        default:
            break;
    }
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