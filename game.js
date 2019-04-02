
/*
*@Desc: The collision direction object.
* Whenever there is a collision, this object signals which side
* of the active object (being drug by the user) has collided
* with something.
*/
let CollisionDirection = {TOP: false, RIGHT: false, BOTTOM: false, LEFT: false};

/*
*@Class: game
*@desc: The game class, contains a blockArray that contains
* one object for each block in the game.
*/
class game
{
  //level: 1;
  constructor(){
  this.blockArray = [];
    //setup(blockArray); //initial call sends 1 param, second param defaults to 1
    //a next level button can be coded in html to call a next level function that calls
    //setup with corresponding level
  }
  /*
  *@function: hasCollision
  *@param: blockToCheck: the block being controlled by the user.
  *@param: container: the gameplay area.
  *@return: true if there is a collision, false if not.
  */
winCondition(blockToCheck)
{


    if(!(blockToCheck.Right_Wall <= gameplay.finishline.Left_Wall ||
         blockToCheck.Left_Wall >= gameplay.finishline.Right_Wall))
         {
           console.log("you win!");
         }

}

  hasCollision(blockToCheck, container){
    //initialize all collisions to false.
    CollisionDirection.RIGHT, CollisionDirection.LEFT, CollisionDirection.BOTTOM, CollisionDirection.TOP = false;
    //We must store the iterator that is the object controlled by the user.
    //It is not necessary to check if the object is colliding with itself.
    let exception_i;
  //here we search for exception_i.
    for(let i = 0; i < this.blockArray.length; i++)
    {
      if(blockToCheck.unique_id == this.blockArray[i].unique_id)
      {
        exception_i = i;
      }
    }

    for(let i = 0; i < this.blockArray.length; i++)
    {
      //Not necessary to check self-collision.
      if(i == exception_i) continue;
      //The traditional recipe for "a collision"
      if(!(blockToCheck.Right_Wall <= this.blockArray[i].Left_Wall ||
           blockToCheck.Left_Wall >= this.blockArray[i].Right_Wall ||
           blockToCheck.Bottom_Wall <= this.blockArray[i].Top_Wall ||
           blockToCheck.Top_Wall >= this.blockArray[i].Bottom_Wall)){
            //Now we must get the direction of the collision.
            if(blockToCheck.class == "blockHorizontal")
            {
              if((blockToCheck.Right_Wall > this.blockArray[i].Left_Wall) && (blockToCheck.Left_Wall <= this.blockArray[i].Left_Wall))
              {
                CollisionDirection.RIGHT = true;
              }

              else if(!(blockToCheck.Left_Wall > this.blockArray[i].Right_Wall))
              {
                CollisionDirection.LEFT = true;
              }
            }
            else
            {
              if(!(blockToCheck.Top_Wall > this.blockArray[i].Bottom_Wall))
              {
                CollisionDirection.TOP = true;
              }
              else if((blockToCheck.Bottom_Wall > this.blockArray[i].Top_Wall) && (blockToCheck.Top_Wall >= this.blockArray[i].Top_Wall))
              {
                CollisionDirection.BOTTOM = true;
              }
            }
        return true;
      }
    }
    return false;
}

 /*
 *@function: pair
 *@param: activeBlock: the block corresponding to the user controlled object.
 *@param: activeObject: the user controlled object.
 *@desc: this function "pairs" the coordinates of both the user controlled object
 * and its corresponding block object.
 *@return: none.
 */
 pair(activeBlock, activeObject){
   let rect = activeObject.getBoundingClientRect();
   activeBlock.Top_Wall = rect.top;
   activeBlock.Bottom_Wall = rect.bottom;
   activeBlock.Left_Wall = rect.left;
   activeBlock.Right_Wall = rect.right;
 }

}
/*
setup(blockArray, level = 1)
{
    switch (level) {
      case 1:
      levelPattern1(blockArray);
        break;
      case 2:

        break;
      case 3:

        break;
      case 4:

        break;
      case 5:

        break;
      default:

    }
}
*/
//each level will literally be a pattern of block and their corresponding x,y positions
/*
levelPattern1(blockArray)
{
  for (let i = 0; i < 5; i++) {
    blockArray.push(document.createElement("Div"));
    blockArray[i].setAttribute("id", i);
  }
}
*/
//create the game object.
let gameplay = new game();
gameplay.finishline = document.getElementById("finishline");
gameplay.winnerblock = document.getElementById("winnerblock");
let rect = gameplay.finishline.getBoundingClientRect();
gameplay.finishline.Right_Wall = rect.right;
gameplay.finishline.Left_Wall = rect.left;
gameplay.finishline.Top_Wall = rect.top;
gameplay.finishline.Bottom_Wall = rect.bottom;
rect = gameplay.winnerblock.getBoundingClientRect();
gameplay.winnerblock.Right_Wall = rect.right;
gameplay.winnerblock.Left_Wall = rect.left;
gameplay.winnerblock.Top_Wall = rect.top;
gameplay.winnerblock.Bottom_Wall = rect.bottom;
