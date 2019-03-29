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

let rect = activeObject.getBoundingClientRect();

//Problems with initialX and Y, need to work that out.
activeObject.initialX = e.clientX - rect.left;
activeObject.initialY = e.clientY + rect.top/2;

//Create a new block object.

console.log(rect.top, rect.right, rect.bottom, rect.left);
for(let i = 0; i < gameplay.blockArray.length; i++)
{
  if(gameplay.blockArray[i].unique_id == activeObject.id)
  {
    gameplay.blockArray.splice(i,1);
    break;
  }
}
activeBlock = new block(rect, activeObject.id);
gameplay.blockArray.push(activeBlock);

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

  //thanks to https://stackoverflow.com/questions/442404/retrieve-the-position-x-y-of-an-html-element
let collidedBool = false;
  if (activeHorizontal) {

    e.preventDefault();

    if (e.type === "touchmove") {
      activeObject.currentX = e.pageX - activeObject.initialX;
      if(gameplay.hasCollision(activeBlock))
      {


      //  console.log("Collision!");
        return;
      }

    } else {
      activeObject.currentX = e.clientX - activeObject.initialX;
      if(gameplay.hasCollision(activeBlock))
      {
        console.log("Direction:",CollisionDirection);

        if(CollisionDirection.RIGHT){
          activeObject.xOffset = activeObject.currentX;
          setTranslate(activeObject.currentX - 5, 0, activeObject);
        }
        else if(CollisionDirection.LEFT){
          activeObject.xOffset = activeObject.currentX;
          setTranslate(activeObject.currentX + 5, 0, activeObject);
        }

        dragEnd(activeObject);
        //return;
      }
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
  gameplay.pair(activeBlock, activeObject);
}

function dragEnd(e) {
  activeObject.initialX = activeObject.currentX;
  activeObject.initialY = activeObject.currentY;



  activeHorizontal = false;
  activeVertical = false;

  activeObject = undefined;
}
