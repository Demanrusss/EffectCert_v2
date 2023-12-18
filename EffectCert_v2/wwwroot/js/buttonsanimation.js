function StartAnimation(element) {
    let imgElement = element.children[0];
    imgElement.src = imgElement.src.replace('.png', '.gif');
};

function StopAnimation(element) {
    let imgElement = element.children[0];
    imgElement.src = imgElement.src.replace('.gif', '.png');
};