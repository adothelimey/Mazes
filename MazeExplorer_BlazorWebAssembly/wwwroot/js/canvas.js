let canvas;
let context;

function initCanvas(canvasId) {
    debugger;
    canvas = document.getElementById(canvasId);
    context = canvas.getContext("2d");
}

function drawRectangle(x, y, width, height, color) {
    debugger;
    context.fillStyle = color;
    context.fillRect(x, y, width, height);
}