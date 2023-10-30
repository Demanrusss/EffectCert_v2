function getFullName() {
    let country = document.getElementById('country').value;
    let index = document.getElementById('index').value;
    let addressStr = document.getElementById('address_str').value;
    
    document.getElementById('full_address_name').value = `${country}, ${index}, ${addressStr}`;
}