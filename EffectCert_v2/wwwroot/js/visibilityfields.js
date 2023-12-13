function changeVisibility(fieldId, checkElement) {
    let field = document.getElementById(fieldId);
    field.disabled = checkElement.checked;
    field.required = !checkElement.checked;
    document.getElementById(fieldId + 'Warning').innerHTML = '';
}
function changeVisibilityDiv(groupDivId, checkElement) {
    document.getElementById(groupDivId).hidden = checkElement.checked;
}
function setVisibilityButtons(element) {
    let status = element.selectedIndex == 0 && element.options[0].value == '';
    document.getElementById(element.id + 'Edit').hidden = status;
    document.getElementById(element.id + 'Details').hidden = status;
    document.getElementById(element.id + 'Delete').hidden = status;
}
function setRequired(fieldId, checkElement) {
    let field = document.getElementById(fieldId);
    field.required = !checkElement.checked;
    document.getElementById(fieldId + 'Warning').innerHTML = '';
}