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
    document.getElementById(element.id + 'Paragraphs').hidden = element.value == '';
};

var techRegIdCounter = 0;

function addTechReg() {
    ++techRegIdCounter;

    let node = document.getElementById('rowTemplate');
    $('#TechRegParagraphs0TechRegId').select2('destroy');
    let clonedNode = node.cloneNode(true);
    prepareNode(clonedNode);

    let table = document.getElementById('tableTemplate');
    table.append(clonedNode);

    reInitializationSelect2();
    InitializeBtnAnimation();
};

function prepareNode(node) {
    node.id += techRegIdCounter;
    changeNodeNames(node);
    setAttributesHiddenTrue(node);
    clearInputValue(node);
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
        tempElement = node.querySelector(idsForChange[i]).hidden = true;
    }
};

function clearInputValue(node) {
    node.querySelector('#TechRegParagraphs0Paragraphs').value = '';
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
    child.setAttribute('onclick', 'deleteRow(this)');
    node.children[0].children[0].prepend(child);
};

function deleteRow(element) {
    document.querySelector('#tableTemplate').removeChild(element.parentElement.parentElement.parentElement);
    renameIds();
    reInitializationSelect2();
};

function renameIds() {
    let nodes = document.querySelectorAll("div[id^='rowTemplate']");
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

function reInitializationSelect2() {
    let selectElements = [];

    selectElements.push({
        id: '#TechRegParagraphs' + 0 + 'TechRegId',
        url: '/TechReg/GetTechRegs/',
        placeholder: 'Выберите тех. регламент'
    });

    selectElements.push({
        id: '#TechRegParagraphs' + techRegIdCounter + 'TechRegId',
        url: '/TechReg/GetTechRegs/',
        placeholder: 'Выберите тех. регламент'
    });

    establishSelect2Algorithm(selectElements);
};