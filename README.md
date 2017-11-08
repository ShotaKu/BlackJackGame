# BlackJackGame
This game is made for term project of Hybrid application development.

__This application is demo version yet.__

#### Scope of this project:
 - To make playable Black jack game in Windows and Android device.
 - The game have following functions
    - Can play Black Jack with computer
    - Can play Black Jack with friends by online mode (2 people)
    - Can play party mode Black Jack with friends by online mode ( more than 3 people)
    - Have ranking
 - User have to login facebook for personal authentication.
 
#### Features
 - **Demo:**         Can play computer mode
 - **Next release**  Can play PvP mode
 - **Next release**  Can play Party mode

#### Detail of each folder:
 - **Font:**        Folder that collect all fonts which used in this game.
 - **Images:**      Folder that collect all images which used in this game.
 - **Resources:**   Folder taht collect all prefab and gameobject which used in this game.
 - **_Creepy_Cat:** Downloaded asset. Detail is here " https://www.assetstore.unity3d.com/en/#!/content/40041 ".
 
 
 This Black Jack game application is created by using Unity 3D.
 If you want recompile this game, please ask .unitypackage file of this project to creator.
 **You can complie the game from pulled project file too. but import .unitypackage is more easyer.**
 
 #### How to build
 Open your directory that you want to save this project in cmd first <Enter>
 `git cd "Your directory"`<Enter>
 Then, clone the project.<Enter>
 `git clone https://github.com/ShotaKu/BlackJackGame/`<Enter>
 Open Unity3D and Make Empty 2D project<Enter>
 `Create new project > 2D project`<Enter>
 Import package from<Enter>
 `Assets > Import package > Custom package...`<Enter>
 And select BlackJack.unitypackage<Enter>
 
 #### Detail of main code file:
 .meta file of each .cs file is data that set in inspector window of unity3D.
  - **BlackJack.cs:** Main logic of Black Jack game.
  - **Player.cs:** Player class of the game.
  - **Card.cs:** card class that used in Black Jack game.
  
**Those 3 class can provide Black jack game that made by console application.**
  - **VsComputer.cs:**    Main code of vs computer mode.
  - **DealerRole.cs:**    Dealer action when choosing PvP mode (e.g. create new game, pass card to player)
  - **PlayerRole.cs:**    Player action when choosing PvP mode (e.g. Hit card request, get card)
  
#### Issue & Bugs:
 - Somewhere are Incompleated.
