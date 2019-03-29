class game
{
  level: 1;
  constructor(){
    let blockArray = [];
    setup(blockArray); //initial call sends 1 param, second param defaults to 1
    //a next level button can be coded in html to call a next level function that calls
    //setup with corresponding level
  }
}

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

//each level will literally be a pattern of block and their corresponding x,y positions
levelPattern1(blockArray)
{
  
}

//create the game object.
let gameplay = new game();
gameplay.blockArray = [];
