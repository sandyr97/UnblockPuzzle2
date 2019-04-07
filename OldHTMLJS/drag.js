/*
* Thanks largely in part to the tutorial located at https://www.kirupa.com/html5/drag.htm
*/
let container = document.querySelector("#box");

let activeHorizontal = false;
let activeVertical = false;


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


/*
*@function: dragStart
*@param: e: the event.
*@desc: this function starts a drag event.
* it assigns elements to activeObject and activeBlock.
* It also determines if the axis of motion will be
* horizontal or vertical.
*@return: none.
*/
function dragStart(e) {

//The object (div) being moved by the user.
activeObject = document.getElementById(e.srcElement.id);
//The user is not allowed to move the container.
if(activeObject.className == "box"){return;}
//The coordinates of the user controlled object.
let rect = activeObject.getBoundingClientRect();
//Problems with initialX and Y, need to work that out.
//Problems with initialX and Y, need to work that out.
console.log(e.clientX, e.clientY);
if(activeObject.initialX == undefined)
{
  activeObject.initialX = e.clientX;
}
if(activeObject.initialY == undefined)
{
    activeObject.initialY = e.clientY;
}
//activeObject.initialX = e.clientX - rect.left;
//activeObject.initialY = e.clientY - rect.top/2;
//Create a new block object.
//NO duplicates. This could be optimized.
for(let i = 0; i < gameplay.blockArray.length; i++)
{
  if(gameplay.blockArray[i].unique_id == activeObject.id)
  {
    gameplay.blockArray.splice(i,1);
    break;
  }
}
activeBlock = new block(rect, activeObject.id, activeObject.className);
gameplay.blockArray.push(activeBlock);

  //horizontal or vertical block type?
  if(activeObject.className == "blockHorizontal")
  {
    activeHorizontal = true;
  }
  else if(activeObject.className == "blockVertical")
  {
    activeVertical = true;
  }

}
/*
*@function:
*@param: e: the event.
*@desc: this function IS the drag event.
* It moves the player controlled object,
* meanwhile detecting collisions and acting
* accordingly.
*@return: none.
*/
function drag(e) {

  //thanks to https://stackoverflow.com/questions/442404/retrieve-the-position-x-y-of-an-html-element

gameplay.winCondition(activeBlock);

  if (activeHorizontal) {

    e.preventDefault();

    if (e.type === "touchmove") {
      activeObject.currentX = e.pageX - activeObject.initialX;
      if(gameplay.hasCollision(activeBlock, container))
      {
        return;
      }

    } else {
      activeObject.currentX = e.clientX - activeObject.initialX;
      if(gameplay.hasCollision(activeBlock, container))
      {
        console.log("Direction:",CollisionDirection);

        if(CollisionDirection.RIGHT){
            activeObject.xOffset = activeObject.currentX;
            setTranslate(activeObject.currentX - 15,0 , activeObject);
        }
        else if(CollisionDirection.LEFT){
          activeObject.xOffset = activeObject.currentX;
          setTranslate(activeObject.currentX + 15, 0, activeObject);
        }

        dragEnd(e);
        return;
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
//console.log("here");
      activeObject.currentY = e.clientY - activeObject.initialY;
      if(gameplay.hasCollision(activeBlock))
      {
        console.log("Direction:",CollisionDirection);

        if(CollisionDirection.TOP){
          activeObject.xOffset = activeObject.currentX;
          setTranslate(0, activeObject.currentY + 5, activeObject);
        }
        else if(CollisionDirection.BOTTOM){
          activeObject.xOffset = activeObject.currentX;
          setTranslate(0, activeObject.currentY - 5, activeObject);
        }
        
        dragEnd(e);
        return;
      }
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



  activeObject.initialX = e.clientX - activeObject.currentX;
  activeObject.initialY = e.clientY - activeObject.currentY;



  activeHorizontal = false;
  activeVertical = false;

  activeObject = undefined;
}
