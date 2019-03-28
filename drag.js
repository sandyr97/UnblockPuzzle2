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
let activeBlock;


//For mobile
container.addEventListener("touchstart", dragStart, false);
container.addEventListener("touchend", dragEnd, false);
container.addEventListener("touchmove", drag, false);

//For desktop
container.addEventListener("mousedown", dragStart, false);
container.addEventListener("mouseup", dragEnd, false);
container.addEventListener("mousemove", drag, false);

function dragStart(e) {
    //activeBlock = new block(e.clientX - xOffset, e.clientY - yOffset );
    initialX = e.clientX - xOffset;
    initialY = e.clientY - yOffset;

activeObject = document.getElementById(e.srcElement.id);
activeObject.initialX = 60;
activeObject.initialY = 60;

    console.log("initialX",activeObject.initialX);
    console.log("initialY",activeObject.initialY);

  if(activeObject.className == "blockHorizontal")
  {
    activeHorizontal = true;
  }
  else if(activeObject.className == "blockVertical")
  {
    activeVertical = true;
  }

}

function drag(e) {


  if (activeHorizontal) {

    e.preventDefault();

    if (e.type === "touchmove") {
      activeObject.currentX = e.pageX - activeObject.initialX;


    } else {
      activeObject.currentX = e.clientX - activeObject.initialX;

    }

    activeObject.xOffset = activeObject.currentX;

    setTranslate(activeObject.currentX, 0, activeObject);
  }
  else if(activeVertical)
  {
    e.preventDefault();

    if (e.type === "touchmove") {

      activeObject.currentY = e.clientY - activeObject.initialY;

    } else {

      activeObject.currentY = e.clientY - activeObject.initialY;

    }


    activeObject.yOffset = activeObject.currentY;
    setTranslate(0, activeObject.currentY, activeObject);
  }
}

function setTranslate(xPos, yPos, el) {
  el.style.transform = "translate3d(" + xPos + "px, " + yPos + "px, 0)";
}

function dragEnd(e) {
  activeObject.initialX = activeObject.currentX;
  activeObject.initialY = activeObject.currentY;

  activeHorizontal = false;
  activeVertical = false;

  activeObject = undefined;
}
