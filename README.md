# Legendary-Palm-Tree
## Cornell College CSC 357


## CubeScape (Work in Progress)
- CubeScape is a multiplayer puzzle/exploration game

- The player(s) will start the game inside of a large cube with puzzles on all six sides of the cube.

- There are 5 objective items on every side of the cube, and the player(s) must collect all 30 of them. 
- Payers will be able to adjust their gravity to add more depth to the gameplay experience however it will not allow them to just traverse to the next zone, though it may allow for crafty ways of reaching objectives.

- On each side of the cube there is a gravity controller that will flip the player(s) gravity depending on which side the Gravity controller is located allowing them to travel to a new area.

### Install:
##### Open master branch, Clone repository, save anywhere on your computer, find the save folder, open Legendary-Palm-Tree-9-30, continue opening this folder until you find the Multiplayer Game Folder, open this then open Builds folder, finally click on playable to start game. Also recommend dragging executable to Home Screen for quick access.

### Controls(since there isn't a help menu atm)
- Use mouse to navigate network lobby. can create LAN or unity matchmaking lobbies. If alone and you press ready, matchmaking will begin as long as everyone else in lobby has pressed ready
<<<<<<< Updated upstream
![Lobby](https://github.com/chimkennumget/Legendary-Palm-Tree/blob/master/lobby.png)

=======
>>>>>>> Stashed changes
- Game is currently playable(testable) solo
- esc brings up exit menu however it is currently not working so external closing and restarting is required to begin a new game
- WASD or arrow keys for movement
- JKLI to rotate camera view, press O to reset to starting orientation
- F to change gravity to left of local orientation
- H to change gravity to right of local orientation
- G to change gravity to upsidedown current orientation
- V or B to change gravity to forward of current orientation
- T to change gravity to backwards of current orientation
- E to grab and release movable objects
- Space to jump
- Shift + A for left sidestepping
- Sift + D for right sidestepping
<<<<<<< Updated upstream
![Current InGame](https://github.com/chimkennumget/Legendary-Palm-Tree/blob/master/mazegamekaduki.png)

=======
>>>>>>> Stashed changes


### Link to Unity API for those interested in learning about the development platform

[Unity API](https://docs.unity3d.com/ScriptReference/)

#### Script link for adjusting player gravity

[player gravity script](https://github.com/chimkennumget/Legendary-Palm-Tree/blob/master/Legendary-Palm-Tree-9-30/Legendary-Palm-Tree-9-30/Multiplayer%20Game/Assets/FirstScene/relativegravitycontrol.cs)

### Script link for character movement

 [movement script](https://github.com/chimkennumget/Legendary-Palm-Tree/blob/master/Legendary-Palm-Tree-9-30/Legendary-Palm-Tree-9-30/Multiplayer%20Game/Assets/FirstScene/CharacterMovement.cs)
 
 ### Script link for attaching character to certain object surfaces
 
 [attachplayer script](https://github.com/chimkennumget/Legendary-Palm-Tree/blob/master/Legendary-Palm-Tree-9-30/Legendary-Palm-Tree-9-30/Multiplayer%20Game/Assets/FirstScene/attachplayer.cs)
 
 ### Script link for camera control(innaccurately labeled as FPS camera though it can technically be used as one
 
 [Camera Controls Script](https://github.com/chimkennumget/Legendary-Palm-Tree/blob/master/Legendary-Palm-Tree-9-30/Legendary-Palm-Tree-9-30/Multiplayer%20Game/Assets/FirstScene/FPSCameraController.cs)
 
### Script Link for grabbing certain objects with rigidbodies
[grabobject](https://github.com/chimkennumget/Legendary-Palm-Tree/blob/master/Legendary-Palm-Tree-9-30/Legendary-Palm-Tree-9-30/Multiplayer%20Game/Assets/FirstScene/grabrigidbodies.cs)

### Script to be used as basis for gravity panel gravity changes(currently just the prototype player gravity change script)

[prototype gravity script (to be repurposed)](https://github.com/chimkennumget/Legendary-Palm-Tree/blob/master/Legendary-Palm-Tree-9-30/Legendary-Palm-Tree-9-30/Multiplayer%20Game/Assets/FirstScene/playergravitycontrol.cs)

### Main networking script for ensuring players are controlling proper character and viewing their own player through their own camera.. Also contains player name(chat) feature
[player network setup script](https://github.com/chimkennumget/Legendary-Palm-Tree/blob/master/Legendary-Palm-Tree-9-30/Legendary-Palm-Tree-9-30/Multiplayer%20Game/Assets/FirstScene/setuplocalplayer.cs)

### Script for moving cubes(kinda bad in a lot of ways)
[cube mover](https://github.com/chimkennumget/Legendary-Palm-Tree/blob/master/Legendary-Palm-Tree-9-30/Legendary-Palm-Tree-9-30/Multiplayer%20Game/Assets/FirstScene/updatecubeposition.cs)
 
### Authors:
Amber Frazier, 
Brody Lamb, 
Corey Duncan, 
Cullen Yuska, 
Daniel Heinsch

### Thanks to Shiina Tenyo for their free voxel girl pack unity asset
[Link to creators site](http://fire-emotion.com/)


