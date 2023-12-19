function StartAnimation(element) {
    let imgElement = element.children[0];
    imgElement.src = imgElement.src.replace('.png', '.gif');
};

function StopAnimation(element) {
    let imgElement = element.children[0];
    imgElement.src = imgElement.src.replace('.gif', '.png');
};

let elems = $('.btn-icons-animation');
for (let i = 0; i < elems.length; i++) {
    elems[i].onmouseover = function (event) {
        StartAnimation(this);
    };
    elems[i].onmouseout = function (event) {
        StopAnimation(this);
    }
}