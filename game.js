
///////////////TESTING




/////////////////////////








let CollisionDirection = {TOP: false, RIGHT: false, BOTTOM: false, LEFT: false};
const CollisionType = {
    TOP: 0,
    RIGHT: 1,
    BOTTOM: 2,
    LEFT: 3
}

class game
{
  //level: 1;
  constructor(){
    //this.blockArray = [];
    //setup(blockArray); //initial call sends 1 param, second param defaults to 1
    //a next level button can be coded in html to call a next level function that calls
    //setup with corresponding level
  }

  hasCollision(blockToCheck){

    CollisionDirection.RIGHT = false;
    CollisionDirection.LEFT = false;
    CollisionDirection.BOTTOM = false;
    CollisionDirection.TOP = false;

    let exception_i = undefined;
for(let i = 0; i < this.blockArray.length; i++)
{
  if(blockToCheck.unique_id == this.blockArray[i].unique_id)
  {
    exception_i = i;
  }
}
console.log("Type of check:", typeof blockToCheck);
    for(let i = 0; i < this.blockArray.length; i++)
    {
      if(i == exception_i) continue;

      if(!(blockToCheck.Right_Wall <= this.blockArray[i].Left_Wall ||
           blockToCheck.Left_Wall >= this.blockArray[i].Right_Wall ||
           blockToCheck.Bottom_Wall <= this.blockArray[i].Top_Wall ||
           blockToCheck.Top_Wall >= this.blockArray[i].Bottom_Wall)){
            // console.log("Collision Details ---------------");
             console.log("block to check:", blockToCheck);
             console.log("collided block:", this.blockArray[i]);
            //now must get direction of collision.

            if(blockToCheck.class == "blockHorizontal")
            {
              if((blockToCheck.Right_Wall > this.blockArray[i].Left_Wall) && (blockToCheck.Left_Wall <= this.blockArray[i].Left_Wall))
              {
                console.log(blockToCheck.Right_Wall, this.blockArray[i].Left_Wall);

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

}
*/
//create the game object.
let gameplay = new game();
gameplay.blockArray = [];
