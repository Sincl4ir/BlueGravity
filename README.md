# BlueGravityTechnicalTest
2D Top-down prototype

These are the main systems/modules that I've developed/added to the project in order to have a working MVP:
 
+ **Player controller system.**
  I've developed a player controller for this task to be able to quickly test player interactions in the project. It takes care of basic movement and it has some functionality added to it to interact with other systems. It   could be separated into small modules.
+ **Event Registry system ("Tapestry")**
  I've added a custom event registry system. It was not developed by me, I've used it in other projects and it's a nice way to handle static events.
+ **Dialogue system.**
  It was developed by me for previous projects and since we will have a player interacting with the NPC I thought it was a must. I did not have the time to re-implement/refactor the code to use the Tapestry Event System
+ **Inventory system.**
  It was also developed by me in the past but I've to put some hours on it to avoid the use of singleton and manual assignments by the inspector. After some rework I was able to implement the Tapestry Event System and handle     interaction with UI and other systems without hard references.
+ **Equipment system.**
  I've developed it for this project since in order to be able to equip an item you will need an equipment manager, not just an inventory system. It also uses the Tapestry Event System to interact with other modules.
+ **Shop system.**
  I've developed this system for this project since we need something to connect the Shopper NPC with the Inventory and UI modules. It also uses the Tapestry Event System to interact with other modules.
+ **UI System.**
  I've developed it for past projects and it also needed some re-work/re-factor to be more modular and avoid hard references. It also uses the Tapestry Event System to interact with other modules.

 Cheers,
**Leandro.**  
//EOF.
