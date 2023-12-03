# Final report

##### Post-processing
The post processing is divided into two volumes, one which is applied during the pause screen to the *MenuCamera*  to highlight the user interface and clearly convey to the player that the game is paused.  The other volume is applied to the *GameplayCamera*  to create a more vibrant atmosphere by increasing the color saturation which is a common characteristic of "cartoony" games. 

#####  User-interface logic
The logic surrounding theuser interface is simple and based around the two classes *LevelManager* and *Levelswitcher* where the intention is that if a object is supposed to change the level it will simply incorporate the *LevelSwitcher* script. This way maintains a loose coupling between the manager and the objects that incorporate this feautre. This approach is inspired by the Scene management from the [2D-platformer ](https://www.coursera.org/learn/game-design-and-development-2/home/week/1) game from the course[^1]. 

##### User interface layout:
The user interface layout attempts to appeal to the familiarity to the player. The layout itself consists of a sidemenu and such. As the game is now the amount of information that needs to be displayed is minimal giving a lot of freedom when it comes to design. Given this we opted for a basic sidemenu to see the character and game in pause and menu and a centered controls and settings page. 
##### Animations:
The animation system simply consists of 4 animations, Running which serves as the Initial state between actions. From the running animation we have the two actions Jumping and Rolling which are the two actions the player can take.  These two animations can therefore not be interrupted but all others can. Meaning in order to be able to jump right after landing it has to be able to be interrupted . The conditions for the transitions are based on the physics properties of the player which are updated during the *FixedUpdate* which is dialed up to 100 calculations per second as a rough estimate meaning all framerates equal to or below this will not be affected.

*Animation logic and 1st iteration of animations*
<p align="center">
  <img src="/docs/imgs/Animations_logic.png"/>
  <img src="/docs/imgs/animations_1st.mp4" alt="animated" />
</p>

##### Level design
For the level itself  the Forest level  is composed of primarily 4 handmade sub-environments which also are sampled from the [Synthy Studios Student pack]( https://assetstore.unity.com/student-plan-pack1)[^2]. This is done to create a dynamic background which can be extended as far as needed, which can be practical when creating a runner game because it allows us to create a level length however long that's needed while still having a semi-dynamic background. The level itself is created in such a manner where each template forms a basis for that area which is then filled which obstacles. The obstacles too are segmented into batches and are placed in areas. This segmentation gives the level design process a modular approach which makes changes based on playtesting easy.

The obstacles is what engages the player in this genre of games and is therefore important as it is what forces the player to make choices. With that in mind this level challenges the players reaction time and control by establishing and breaking patterns that occur in a fast manner forcing the player to adapt. Additionally the increase in speed makes it so the player can be challenged in precision and timing by constructing obstacles that has to be maneuvered in a certain way to survive.


<p align="center">
  <img src="/docs/imgs/Obstacles_1.png"/>
  <img src="/docs/imgs/Obstacles_1_2.png" />
</p>
*This sequence of obstacles plays on this aspect by forcing the player to Roll to dodge a series of pick-ups to then break the pattern by encountering positive pickups which if dodged leads to taking damage. 

<p align="center">
  <img src="/docs/imgs/Obstacles_seg_2.png" />
</p>
*In this segment the player is challenged on his/hers precision and timing to be able to jump at the right time to stay on top of the rocks avoiding negative pick-ups and staying in frame. 

### Playercontroller

In terms of the gameplay the player is comprised of a *Collider* and a *RigidBody* provided by the Unity Engine. The *Collider* serves the role of detecting collisions between the player and his surroundings while the *Rigidbody* is used for manipulating the players position by using the Physics API provided by Unity. The implementation of these are present in the *PlayerController* where the logic of the mechanics and the interactions the player faces resides. 

As mentioned *PlayerController* manipulates the player based on given parameters, these parameters can be tweaked meaning changes can be made from player feedback  in order to create the desired movement. 

<p align="center">
  <img src="/docs/imgs/PlayerController.png" />
</p>

The script itself can be divided into two main components that is derived from the *MonoBehaviour* class and utilizes primarily the *Update* and *FixedUpdate* methods provided. *Update* registers the player input  and immediate feedback to the player such as audio. The *FixedUpdate* operates based on the registered input from the player and interacts with the *Collider* and the *Rigidbody*.

For simplicity the player's *Collider* consists of a single *BoxCollider* to detect collision. As the gameplay consists of only linear movement across a single plane, any form of collider would suffice for the purposes of this game. As for the mechanics associated with the collider it is responsible for the Roll mechanic. The Roll mechanic simply explained is just dividing the collider in half and moving it to the initial position, and vice versa for the reversal of this process. This makes it so that the level can be designed with this in mind to give the player the possibility of shrinking its size to evade obstacles.  

The *RigidBody* as previously mentioned deals with the player's position and the change in that position.  The only moving part of the scenes is the environment, this decision was made as it simplifies both the camera and player movement as they will both have one-dimensional movement. To accomplish this the *RigidBody* API method *AddForce* is used which is a method that abstracts away the physics and gives the ability to specify only the change in velocity desired.

*Equation for the AddForce method.*
<p align="center">
  <img src="/docs/imgs/momentum_eq.png" />
</p>

*Here is a comparison of the trajectories*
<p align="center">
  <img src="/docs/imgs/Jump_gravity.gif" alt="animated" />
  <img src="/docs/imgs/Jump_custom_grav.gif" alt="animated" />
</p>


To achieve a jumping mechanic that fits the "cartoony" style of this game I changed the gravity of the player upon descent making the jump two-part. This makes it so the player falls faster and allows for faster response as the player will have less air-time and makes the jump less "floaty". The implementation is a modified version of the "Super-Mario-jump"[^3].

In the end this approach was sufficient for our purposes, but in retrospect it might have been better not using physics at all for this type of game. The thought process was that if we intend to add any special features like changing perspective, movement, interactions or any similar features the usage of the built-in API would save time and resources. Given the timeframe a short-term approach without physics only using transforms might've been better as the utilization of physics posed problems throughout the development process.


The first problem was a relative simple one which was linked to the fact that the API calculates friction meaning when the player collider was in contact with obstacles it would stop the player from moving. The solution to this was to create *Physics Material* for the obstacles and player reducing the friction allowing the player to jump while in contact. 

<p align="center">
  <img src="/docs/imgs/stuck_20fps.gif" alt="animated" />
</p>


Another problem encountered came in the form of the so called "Airlaunch-bug" which was triggered in scenarios where the player jumps in oblique direction making the player trigger the jumping mechanic twice launching the player towards the air. Meaning the collision detection using the "*CompareTag*" approach would not suffice. One solution to this wouldve been to remove the depth the ground have and make it concave, but this would for lack of a better word remove the "rugged" feel of the game.

<p align="center">
  <img src="/docs/imgs/Airlaunch_gif.gif" alt="animated" />
</p>


To solve this  I took use of the built-in *Raycasting* and  directed it below the player to prevent registering collisions with other surfaces than the bottom. As a final note on this subject, it would be wise to implement a layer mask to this *Raycasting* to filter what should be considered a collision making the player grounded, which is not implemented as of now.


<p align="center">
  <img src="/docs/imgs/momentun_bug_gif.gif" alt="animated" />
</p>

With the solution of using *Raycasting* to another problem occurred with the player jumping shorter based on its current momentum as since the *Raycasting* makes it so the collider does not actually collide the momentum is carried on to the next jump, meaning if the player has negative velocity upon pressing jump it will jump shorter than intended. To solve this problem I considered multiple different approaches such as implemented a jumping delay.  A delay would solve the problem but is not optimal as the game is based around fast-paced gameplay and this would limit this. And compromising on the sole mechanic of the game is not ideal. Ultimately the solution I went for was nullifying the momentum in order to make the jump height constant as the initial conditions will then be the same for every jump.


<p align="center">
  <img src="/docs/imgs/Jump_code.png" />
</p>

##### My Contribution
###### **Petter Edvardsen**
During this project I created the gameplay logic surrounding the player movement and mechanics  , Animations, 1st iteration of User interface and logic, the Forest level as a whole and Post-processing for visuals on cameras. 

#####  References
[^1]:  https://www.coursera.org/learn/game-design-and-development-2/home/week/1
[^2]:  https://assetstore.unity.com/student-plan-pack1
[^3]: https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/#jump_unity