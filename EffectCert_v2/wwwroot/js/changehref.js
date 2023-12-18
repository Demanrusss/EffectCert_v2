function changeref(element) {
    let elementEdit = document.getElementById(element.id + 'Edit');
    let elementDetails = document.getElementById(element.id + 'Details');
    let elementDelete = document.getElementById(element.id + 'Delete');

    if (elementEdit !== null)
        elementEdit.pathname = getCleanPath(elementEdit.pathname) + '/' + element.value;
    if (elementDetails !== null)
        elementDetails.pathname = getCleanPath(elementDetails.pathname) + '/' + element.value;
    if (elementDelete !== null)
        elementDelete.pathname = getCleanPath(elementDelete.pathname) + '/' + element.value;

    function getCleanPath(pathname) {
        const pathArray = pathname.split('/');
        return `/${pathArray[1]}/${pathArray[2]}`;
    }
};