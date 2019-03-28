/*
* Thanks largely in part to the tutorial located at https://www.kirupa.com/html5/drag.htm
*/



let dragHorizontal = document.querySelectorAll("#blockHorizontal");
let dragVertical = document.querySelectorAll("#blockVertical");
let container = document.querySelector("#box");

let activeHorizontal = false;
let activeVertical = false;
let currentX;
let currentY;
let initialX;
let initialY;
let xOffset = 0;
let yOffset = 0;

let activeObject;

//For mobile
container.addEventListener("touchstart", dragStart, false);
container.addEventListener("touchend", dragEnd, false);
container.addEventListener("touchmove", drag, false);

//For desktop
container.addEventListener("mousedown", dragStart, false);
container.addEventListener("mouseup", dragEnd, false);
container.addEventListener("mousemove", drag, false);

function dragStart(e) {

    initialX = e.clientX - xOffset;
    initialY = e.clientY - yOffset;



  activeObject = document.getElementById(e.srcElement.id);
  console.log(activeObject.className);
  if(activeObject.className == "blockHorizontal")
  {
    activeHorizontal = true;
  }
  else if(activeObject.className == "blockVertical")
  {
    activeVertical = true;
  }
  console.log(activeObject);
  //console.log(dragVertical[0]);
  //console.log(dragHorizontal);
}

function drag(e) {

console.log("activeHorizontal",activeHorizontal);
console.log("activeVertical",activeVertical);

  if (activeHorizontal) {

    e.preventDefault();

    if (e.type === "touchmove") {
      currentX = e.pageX - initialX;

    } else {
      currentX = e.clientX - initialX;
    }

    xOffset = currentX;

    setTranslate(currentX, 0, activeObject);
  }
  else if(activeVertical)
  {
    e.preventDefault();

    if (e.type === "touchmove") {

      currentY = e.touches[0].clientY - initialY;
    } else {

      currentY = e.clientY - initialY;
    }


    yOffset = currentY;
    console.log(activeObject);
    setTranslate(0, currentY, activeObject);
  }
}

function setTranslate(xPos, yPos, el) {
  el.style.transform = "translate3d(" + xPos + "px, " + yPos + "px, 0)";
}

function dragEnd(e) {
  initialX = currentX;
  initialY = currentY;

  activeHorizontal = false;
  activeVertical = false;

  activeObject = undefined;
}
