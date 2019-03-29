class game
{
  constructor(){
    this.blockArray = undefined;
  }

  hasCollision(blockToCheck){
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


//create the game object.
let gameplay = new game();
gameplay.blockArray = [];
