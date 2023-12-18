function getFullName() {
    let country = document.getElementById('country').value;
    let index = document.getElementById('index').value;
    let address_str = document.getElementById('address_str').value;

    let full_address = new Array();
    if (country)
        full_address.push(country);
    if (index)
        full_address.push(index);
    if (address_str)
        full_address.push(address_str);

    document.getElementById('full_address_name').value = full_address.join(", ");
};