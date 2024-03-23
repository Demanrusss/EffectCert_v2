function changeVisibility(fieldId, checkElement) {
    let field = document.getElementById(fieldId);
    field.disabled = checkElement.checked;
    field.required = !checkElement.checked;
    document.getElementById(fieldId + 'Warning').innerHTML = '';
};

function changeVisibilityDiv(groupDivId, checkElement) {
    document.getElementById(groupDivId).hidden = checkElement.checked;
};

function setVisibilityButtons(element) {
    let status = element.selectedIndex == 0 && element.options[0].value == '';
    document.getElementById(element.id + 'Edit').style.display = status ? 'none' : 'inline';
    document.getElementById(element.id + 'Details').style.display = status ? 'none' : 'inline';
    document.getElementById(element.id + 'Delete').style.display = status ? 'none' : 'inline';
};

function setRequired(fieldId, checkElement) {
    let field = document.getElementById(fieldId);
    field.required = !checkElement.checked;
    document.getElementById(fieldId + 'Warning').innerHTML = '';
};