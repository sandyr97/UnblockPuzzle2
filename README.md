# UnblockPuzzle
## About the Project
The project began as a web game made with HTML/JS/CSS.
After recognizing the difficulty inherit in creating our own
2D rigid bodies with JavaScript, we decided to migrate the game
to be a Unity C# Project. 
## About Each GitHub Directory
### Documentation
1. GantChart.png  - an image of the project Gantt Chart.
2. HTML_DOCUMENTATION - all of the automatically generated C# documentation is here.
### OldHTMLJS
Here lies all of the old HTML/JS remnants from our game's youth.
Much of our current C# code was adapted from drag.js and game.js.
Also, much of the current style found in the Unity project was
adapted from the style used here on our index.html and start.html pages.
### PLAY
This folder contains a compiled copy of the game adjacent all the necessary files for it to run.
To play the game, simply clone the directory and click BlockBloque.exe.
### UNITY/BlockBloque
This folder contains all of the C# scripts and Unity files used to create the game.
C# scripts are found at UNITY/BlockBloque/Assets/Scripts
### Loose files
These are assets such as mp3's and images not yet implemented in the game.
There is also a .php file which we will be using to query a database to update high scores in the future.
## CITATIONS
### Planck.js
While we did not use this in the final release of the game, Planck.js is a free 2D physics engine
that we had hoped to use to overcome our 2D rigidbody woes. We decided to cite them regardless as 
somewhere in OldHTMLJS lives some remnant of Planck.js.
### Bootstrap
We used Bootstrap to style our original html pages. While we decided not to use this in the final product,
we decided to cite them anyway as somewhere in OldHTMLJS lives some remnant of Bootstrap.
### Unity
A free 2D/3D game engine. We decided to use this engine to overcome our rigidbody woes. Unity made
solving that problem remarkably simple, and should have been used from the start. Luckily, these
issues are now resolved, and we can dedicate more time to realizing Unity's true potential.
### https://www.kirupa.com/html5/drag.htm
Our original drag algorithm was adapted from this tutorial. While the one we actually use looks drastically different from this,
this was the original starting point and deserves to be cited.
### https://stackoverflow.com/questions/442404/retrieve-the-position-x-y-of-an-html-element
.getBoundingClientRect(). What a fun and useful method! Thanks!
