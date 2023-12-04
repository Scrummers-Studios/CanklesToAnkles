# Final report

## Overview
“Weight Escape” is an engaging 2.5D runner game developed using the Unity engine, blended elements of action, adventure, comedy and platforming genres. The game is designed to offer a balance of entertaining story and escalating challenge, appealing to a broad spectrum of players ranging from children to young adults.
Weight Escape has a captivating and humorous backstory. Players take on the role of an overweight character who embarks on a journey for a better life. On this journey the player must dodge a variety of obstacles in order to succeed. 
Aesthetically, the game environment is crafted in a polygon style, contrasting the main character's whimsical cartoon style. 

## Methodology
Our team’s collective objective was the development of our game, for which we adopted scrum as our project management methodology. For transparency, we collaborated through both physical meetings and virtual via Discord. This approach ensured that all team members were continually informed of each other’s challenges and progress, creating a supportive and collaborative environment.

Bi-weekly sprint meetings were a cornerstone of our project management. During these sessions, we produced sprint reports and each team member presented their recent accomplishments, current status and their task for the forthcoming two weeks. This way it also served as our milestones. 
In addition to structured sprint meetings, we held more informal meetings in time periods convenient for everyone. These sessions allowed for open dialogue, enabling us to discuss new ideas, additions to the project, and to ensure alignment in our team’s vision and approach. 
To organize task management and avoid duplication of efforts, we utilized a shared task folder. Team members could self-assign tasks, ensuring efficient distribution of work and minimizing task overlap. 
The pre-production phase consisted of in-person brainstorming sessions. Meeting physically was preferred to enhance team cohesion and ensure consensus on the game’s concept and storyline. This phase’s efficiency was pivotal in laying a strong foundation for the game’s development and made it possible to start developing our game early. 
The technical development of our game was executed using the Unity engine, with GitHub as our collaboration platform. Initially, we focused on using branches to manage code contributions. However, we encountered significant merge conflicts due to Unity’s auto-generated files and text-formatted scenes, which proved complex to merge. To address this, we shifted to a simpler workflow, with team members working directly in the main branch. Frequent commits and clear communication regarding who was working on specific scenes were key practices in this approach. Despite some challenges with Git, including loss of changes or asset modifications, this method proved to be more productive for our team.

## Story
The story starts with a man who lives a unhealthy life style. One night when he is sitting on his couch eating chips, he gets a sudden pain in his chest and right after he passes out. When he wakes up in the hospital he is surrounded by his family who all have worried looks on their face. That is when the doctor tells him that he just had a heart attack and that he is lucky to be alive. The doctor then tells him that if he does not change his life style, he will die in the near future. With his family around him sobbing, he decides to change. He must change the things he eats and start running, so that he can grow old with his wife and see his children grow up.
  
## Aesthetics
In “Weight Escape”, each level’s environment is rendered in a low poly style, encompassing the background, obstacles and skybox to maintain a cohesive aesthetic. This stylistic choice was driven by several strategic considerations. Primarily, the low poly style allows for the game to look good while also ensuring optimal game performance, with reduced load times and smoother gameplay. 
Another factor influencing our decision was the availability of Synty Studios’ Polygon educational pack, which offered high-quality low poly assets at no cost. This resource was invaluable in achieving a visually appealing and consistent look of our game without exceeding our  budget. 
The vibrant and colorful nature of the low poly style significantly enhances the game’s overall appeal. It imparts a playful and whimsical vibe, aligning perfectly with the game’s humorous theme. This aesthetic choice not only contributes to the game’s visual attractiveness but also complements its fun and engaging narrative. 
The runner game genre, traditionally aligns with the 2D genre. However, we opted to develop it in 2.5D to add an extra dimension of depth. This decision was made to enrich the visual experience and provide a sense of immersion that a purely 2D perspective may not fully capture. The 2.5D approach creates a unique feel to the game, enhancing the overall player experience. 

#### Visuals

##### Post-processing
The post processing is divided into two volumes, one which is applied during the pause screen to the *MenuCamera*  to highlight the user interface and clearly convey to the player that the game is paused.  The other volume is applied to the *GameplayCamera*  to create a more vibrant atmosphere by increasing the color saturation which is a common characteristic of "cartoony" games. 


## Level design and Enviroment

In “Weight Escape”, players traverse through four distinct levels, each with unique obstacles and thematic environments. The settings vary from villages and mystical forests to modern cityscapes. As the game progresses, the levels increase in difficulty, presenting a more challenging experience to the player. This escalation is achieved through a combination of faster gameplay speed, increased frequency of obstacles, and more difficult jumps and dodges.

The design of these levels was meticulously carried out within the Unity engine, utilizing assets from Synty Studios’ educational asset pack. These assets were strategically arranged to construct the levels’ backgrounds, grounds, and various obstacles. Key to our design process was the creation of prefabs for certain obstacles, allowing to reuse and place these throughout the levels. 

Our decision to employ a low poly art style was instrumental in shaping the level design. The style’s popularity made it easy to find available assets in the Unity store which afforded us the possibility to achieve a particular vision or design element. This was, we had a bigger possibility to design levels exactly how we planned.  

### Tutorial level

The tutorial level was created using assets from the [Synthy Studios Student pack]( https://assetstore.unity.com/student-plan-pack1)[^2]. This level was created from scratch placing roads, grass, trees and so on until we had a clean looking introduction level. We then needed to implement some tutorialmanager that tells the player the basics of the game. This was done through a script that goes through popUps one by one, and demands some kind of key to be pressed and/or time to pass to get the next pupUp. In the gif below we can see how these pop ups function. 

<p align="center">
  <img src="/docs/imgs/tutorial_showcase.gif" alt="animated" />
  <img src="/docs/imgs/tutorial.png" />
</p>

### Village level

This is the first full level created for "Weight Escape". This level was created entirely by drag and drop from the asset folder, and duplication of placed assets. It starts easy with a few obstacles and pickups, with some woods in the background. Later we enter a village and end up jumping across rooftops before we get out of the village again and approach goal. 

<p align="center">
  <img src="/docs/imgs/village_house.png"/>
  <img src="/docs/imgs/village.png"/>
</p>

### Forest level
For the level itself  the Forest level  is composed of primarily 4 handmade sub-environments which also are sampled from the [Synthy Studios Student pack]( https://assetstore.unity.com/student-plan-pack1)[^2]. This is done to create a dynamic background which can be extended as far as needed, which can be practical when creating a runner game because it allows us to create a level length however long that's needed while still having a semi-dynamic background. The level itself is created in such a manner where each template forms a basis for that area which is then filled which obstacles. The obstacles too are segmented into batches and are placed in areas. This segmentation gives the level design process a modular approach which makes changes based on playtesting easy.

The obstacles is what engages the player in this genre of games and is therefore important as it is what forces the player to make choices. With that in mind this level challenges the players reaction time and control by establishing and breaking patterns that occur in a fast manner forcing the player to adapt. Additionally the increase in speed makes it so the player can be challenged in precision and timing by constructing obstacles that has to be maneuvered in a certain way to survive.


*This is the sub-enviroments allowing for the modular apporach of the level*

<p align="center">
  <img src="/docs/imgs/Temp_Env1.png"/>
  <img src="/docs/imgs/Template_Env2.png" />
  <img src="/docs/imgs/Temp_env3.png" />
  <img src="/docs/imgs/Temp_Env4.png" />
</p>


*This sequence of obstacles plays on this aspect by forcing the player to Roll to dodge a series of pick-ups to then break the pattern by encountering positive pickups which if dodged leads to taking damage*

<p align="center">
  <img src="/docs/imgs/Obstacles_1.png"/>
  <img src="/docs/imgs/Obstacles_1_2.png" />
</p>

*In this segment the player is challenged on his/hers precision and timing to be able to jump at the right time to stay on top of the rocks avoiding negative pick-ups and staying in frame*

<p align="center">
  <img src="/docs/imgs/Obstacles_seg_2.png" />
</p>


*Up until this point in the level the player is conditoned to jump upon traversing and will be punished if him/her does not react to the changes.* 

<p align="center">
  <img src="/docs/imgs/Obstacles_seg_3.png" />
</p>

### City level

In the design of the final level, our objective was to create a city that felt full and alive. To achieve this dynamix cityscape while efficiently managing development time, we strategically used the demo scene included in the Synty Studios city pack. 

this pre-designed city scene provided an ideal foundation for our level. However, to edit it to our specific requirements, we made significant modifications. Initially, we scaled down the city by removing half, using the remaining portion as the level's background to create this sense of a bustling city. 

We then started creating the playable area of the level. This involved adding additional buildings and other obstacles and making various adjustments to ensure seamless integration with the game's aesthetic and gameplay needs.

<p align="center">
  <img src="/docs/imgs/city_roof.png" />
</p>

<p align="center">
  <img src="/docs/imgs/city.png" />
</p>

## Characters
“Cankles to Ankles” is a game which takes players on a journey of a man trying to transform his physique from a heavy build to a leaner build. The game consists of a total of four playable levels where one can see a gradual size decrease for each level. The process to start creating the characters, two pre-made characters were chosen. The skinny character remained the same, while for the heavier character, 3 versions were made. 

It started by importing the overweight character into Blender, where a red track suit was painted on. When the material was ready, the character, along with the track suit, was imported into Unity. Three duplicates of the character were then created. To adjust the size, the scaling tool was used to make the progression from a heavy to a lean build. 

When trying to use the different characters for animations, we discovered that the characters who were scaled didn’t look good when running, jumping etc. To fix this, the rigging of the characters where the animations didn’t work properly were removed. The characters were then imported into Mixamo where a new rig was fitted and added. When the character then was imported again into Unity the animations worked as they should.  

### Animations
The animation system simply consists of 4 animations, Running which serves as the Initial state between actions. From the running animation we have the two actions Jumping and Rolling which are the two actions the player can take. All animations can be interuppted with the exception of Incoming transistions to Jumping, Rolling and Landing. This is done to make the player repsonsive in fast paced scenarios. The way this is implemented is that both the incoming and outgoing transistions "Running" and the outgoing transistion of "Landing" have their "Interruption source: Next state" meaning they can be interrupted by either Rolling or Jumping. The conditions for the transitions are based on the different player states determined by the physics of the player. To make sure these are updated frequently enough the fixed intervals are calculated 100 times each second meaning any framerate equal to or below will be in sync with the player animatons. 

*Animation logic*
<p align="center">
  <img src="/docs/imgs/Animations_logic_updated.png"/>
</p>


*1st iteration of animations*
<p align="center">
  <img src="/docs/imgs/Animations_1st_iteration.gif" alt="animated" />
</p>

*3rd iteration of animations*
<p align="center">
  <img src="/docs/imgs/Animations_3rd_iteration.gif" alt="animated" />
</p>

## Gameplay and Gameplay Mecahnics
The gameplay for this game is fairly simple. In our game the goal is to reach the end of each level. The character moves constantly, and the player uses space to jump and ctrl to dodge obstacles. If the character gets caught by an obstacle and falls too far behind the camera, the level resets. In addition to obstacles there are both healthy and unhealthy foods that manipulate the “diabetes bar”. This is the character’s health, the bar fills up as the player gets closer to diabetes, and lowers if the player interacts with healthy foods. These foods and obstacles are spread through the different levels.

The game is designed to make the environment, pickups, goal and everything related to the level moves rather than the player. The character and the camera are somewhat static, the player can only be moved by the obstacles that are placed throughout the levels, and the camera moves to track the player with some delay. If the player gets caught by the terrain for too long, the character will move out of the view of the camera, this is one of our loose conditions. Allowing the player to be “still” or caught in the terrain, the diabetes wins and the character dies. This happens also if the character “eats” too much unhealthy food, this is our second loose condition. 

In order to traverse from one level to the other, the player has to reach the end of the level. The different length of the levels vary and depend both on the speed of the level as well as the difficulty of the level. At the end of each level, there is a goal. This goal activates the win screen, which gives the player positive feedback on clearing a level. From this windscreen the player can choose to move to the next level or return to the main menu.

### HealthScript
The health script is orchestrating the whole mechanics for the health. It is built up with some basic methods that can alter the health of the player, in terms of be *damaged* or *healed*. If the one of these methods alter the health to the maximum, the player will not achive any more healing. Otherwise if the players health is altered below the minimum requirement, the player will respawn at the start of the stage. When the player respawns all of the pickups, enemies and the enviroment will be sett back to the original position at level start.
<p align="center">
  <img src="/docs/imgs/healthScript.png"/>
</p>
As seen in the the picture above, the script needs the enviroment, player and the picture in the healthbar. The script allso allows some basic settings such as the default damage taken, the current health as well as the maximum health and the default health. The bar in the health script gets updated every time the health of the player is altered, this is done by setting the fill property of the image to the current health divided by the maximum health. Our healthbar is somewhat different than other health bars, it is inverted, representing *diabetes*. So the full equation for the bar is actully 1 - currentHealth/ maximumHealth. Respawn is a method that is public in the healthScript, this is because the camera needs the ability to both deal damage to the player and respawn the player.

Initially we thought it would be best to implement both health and lives, however after furthur discussion we decided to only use health. The first iteration of the health script consisted of both health and lives, with the ability to turn on or off the usage of the lives. We were planning on using lives as the health bar depleted, and after all the lives has been used, the player would need to restart the game at level 1.

### CameraScript
The camera needs to be able to detect if the player is slowing down and ends up outside of the view to the camera. This is done by using frustum planes. By creating many planes for the view angle of the camera and iterating trough them, the camera detects if the player's *boxCollider* is inside or outside these planes. This is a continuous check that goes every frame. If the player happens to be outside of these planes, the camera script will respawn the character.

At the first iteration this method used pixels and *transform.position* to detect the position of the player. This was not a good solution since we felt like the player should have some chance to come back to the center of the screen. The problem for this was solved by making a moving camera with some delay. The camera follows the player, with some delay that will allow the player to both get stuck in the terrain and to return to the center of the screen.

Second problem we encountered was that the player had the ability to respawn inside objects. By respawning the character in the center of the screen, the terrain might have gained some altitude or an obstacle might be in the way. This caused the player to respawn inside these objects and cant move. This was solved by resetting the position of the enviroment and all the components of the game. The one thing we did not set back to it's original position is the camera, this could have been implemented, but we decided not to do this cause the camera will *jump* back to it's place and it looked laggy.

### Pickups and enemies
The pickups use a script, handle all the logic for the pickups and the enemies. Originally this script was just a enemy script, that dealt some damage to the player, after some iterations we had implemented so that the enemies disapears when colliding with the player. Some iterations later, the script was altered to an pickupscript, this script allowed for changing from damage to healing of the player. With this we had the ability to implement healthy food which lowers the *diabetesbar*. In the last iteration some basic rotation was added to give a more intriguing impression of the pickups and the enemies.

With the script disabling the pickups after the collision the pickups will still be inactive after the player respawns, this allows the player to contiune trying to clear the level if they should die from too much unhealthy food.

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

*Here is a comparison of the two jump trajectories*
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


## User interface

####  User-interface logic
The logic surrounding theuser interface is simple and based around the two classes *LevelManager* and *Levelswitcher* where the intention is that if a object is supposed to change the level it will simply incorporate the *LevelSwitcher* script. This way maintains a loose coupling between the manager and the objects that incorporate this feautre. This approach is inspired by the Scene management from the [2D-platformer ](https://www.coursera.org/learn/game-design-and-development-2/home/week/1) game from the course[^1]. 

#### User interface layout:
The user interface layout attempts to appeal to the familiarity to the player. The layout itself consists of a sidemenu and such. As the game is now the amount of information that needs to be displayed is minimal giving a lot of freedom when it comes to design. Given this we opted for a basic sidemenu to see the character and game in pause and menu and a centered controls and settings page. 

## Sound

Having sounds in a game is a must. It gives the player a completely different experience, when it comes to the emotional impact that it has and adds an aesthetic value. Sounds can affect emotions and set the mood for the game, level or story being told. It makes the player more engaged and makes it an overall more enjoyable game. Not only can it affect a player's emotions, it also helps with complementing the level's visuals.

The game focuses on being a fun casual game, which aims to make the player have compassion with the character. When starting the game, we see a dancing character in the main menu with fitting music. This makes the game seem like a fun approachable game rather than a hardcore one. When starting the game, one gets to see the story of the character. Here the sound is supposed to make the player feel bad for the character and give him a desire to help. It gives the player the full story behind the reason he runs, and with the sounds, the seriousness of the situation is implied. Having the ambulance sound play along with the images add the extra layer of seriousness in the situation.

This can also be heard in the transition video from level 3 to level 4. After completing level 1-3 and seeing the player get smaller and faster for each level a video is played before level 4. Here we see him go through different stages, and to show this thru sound we can hear his breathing get calmer and calmer for each of the pictures shown.

Throughout the game the player will play through various levels, where the soundtrack for each level is fitted to the theme. An example of this is the city level. Here urban music is chosen to fit the aesthetic and give the player both a visual and auditory experience.

To add an extra layer of realism, the character has sounds that he makes. Both when he jumps and when he rolls sounds come from him. Adding life-like sounds to him makes him feel more “alive” to players. Giving him a struggle sound for each jump and rolle makes the player feel more compassion for the character.          

## Implementation
The implementation of “Cankles to Ankles” involved a lot of learning, but also came with challenges along the way. Here we worked with everything, from coding and level design to character animations and sound integration.
To develop the game, the Unity engine was used. To begin with we decided to use Git LFS(Large File Support) and branches for code management, but due to Unity’s auto-generated files, several merge conflicts had to be solved. To avoid this happening in the future, the team shifted over to the main branch. This way we avoided many conflicts, and ended up making the workflow more productive with everybody updated on the newest changes.
The game also includes four levels which all have their own themes. All these themes are familiar places where a low poly style was used in the design process. Using the Unity engine with the build assets made the levels look great, and gives more depth to the game. The assets were found on the Unity asset store, but the design of the levels were all made by the team. 
When creating the characters, multiple tools were used to get the desired characters. Pre-made characters were imported into Blender to get the wanted design, and after that scaled to the correct size in Unity. Due to some problems with the character rig, some characters were brought into Mixamo for rigging, to make the animations as good as possible. As mentioned, the team had some challenges along the way. This includes problems with the Git workflow and animations to mention some of them. However, we were able to change strategies and keep on developing the game.  


## Game development process

### Pre-production
Our pre-production phase consisted of brainstorming as a group and outlining what type of game we are creating. This meant defining our goals and the scope of the game. Given the short timeframe and limited budget we quickly landed on a "Runner" type game as a game which is simple in premise, but can easily be expanded upon should there be an oppertunity for it. As we have no experience with game development between us we had to create a plan for how to move forward aswell as who should research what. The details concerning planning, scope and goals are outlined in the High-level document.

### Production
During the production phase, our team adopted a structured approach, organizing our workflow into two-week sprints. Each team member was assigned specific tasks to be completed within these intervals. At the end of each sprint, we reviewed our progress, discuss any challenges encountered, and shared the solutions we implemented. We created sprint reports from these sessions, documenting our accomplishments and any issues faced. 

The development process mostly took place remotely, as most team members had access to superior hardware at their homes compared to their laptops, which were not optimally equipped for running our game on Unity. To manage tasks efficiently, we maintained a dynamic task list, enabling team members to pick up new tasks upon completing their current ones. Communication was facilitated through Discord, allowing for continuous collaboration, discussion of fixes, and other requests or questions, despite working from different locations. For version control and collaborative coding, we utilized GitHub. 

Once we were satisfied with the gameplay length and content, given our resource constraint, we transitioned into the post-production phase. This stage was focused on putting together all game components to complete the game loop, along with refining and polishing various elements. Additionally, it involved identifying and resolving bugs. 

The production phase was a tremendous learning experience. One key insight was the importance of having a well-structured workflow. It became evident that preemptively creating all game elements before expanding to more levels would be more efficient. Implementing this approach in future projects will save time and resources, as it would eliminate the need to change around assets to add new elements, allowing for them to be implemented from the first creation of the level. 

## Tools

For the development of “Weight Escape”, we selected the Unity engine as our primary game development platform. Unity’s popularity among indie game developers, coupled with its suitability for creating smaller-scale games, made it an ideal for our project. The development process with Unity was generally smooth, with the main challenges arising from our version control system rather than the engine itself. 

Due to the size of our team, which consisted of four members, we were too many for the free tier of Unity Teams. Consequently, we opted to use GitHub for our version control and collaboration, as we all had prior experience with the platform. Despite this, we encountered some technical issues with git, particularly with scene file management. The text rendering of scene files in Git introduced difficulties in merging changes, making the version control process somewhat challenging.  

Our team utilized Discord for communication. We established dedicated channels for file sharing, web links, and general discussions, as well as a voice channel for online meetings. This setup allowed for effective collaboration, allowing us to stream work sessions, plan meetings, and provide assistance during both collaborative and independent work phases. 

A pivotal aspect of “Weight Escape” is its story-driven humor. To effectively show this humorous narrative, we created an introductory video that plays at the game’s beginning. For video production, we used Clipchamp, a standard editing tool used for hangling images, video and sound editing. In the creation of visuals for these videos we used ChatGPT, an advanced AI tool. By inputting detailed prompts, ChatGPT generated the required images that we then used in our video

To create a unique design which would fit the character Blender was used. The player was given a red track suit, which sticks out in all the levels and gives the character a colorful presence. There was also a attempt to add some details to the face of the character, but due to the player only  being seen from the side, these features are not noticed. 

To give the character smooth animations, pre-made animations were picked from the animation library at Mixamo. Here we were able to pick out the animations that looked the best, and along with the animator in Unity, we were able to give the character clean animations. 

## Our experience

### Testing

As a developer one often becomes blind to the things being done. It’s easy to think that new implementations are easy for users to understand, but this is not always the case to new players. Throughout the project we have had people test our game at various stages to ensure that the player understands what the game is, how to play it and if they understand what they see in front of them. This includes everything from the UIs a player sees through the game, the levels and the controlling of the character.

By week 44 we had a level with a character which had working animations and an interactable main menu. The main menu got good response when it came to functionality and the layout of it, but didn’t feel like the design reflected what the game was really about, which is a fun game for everyone. When it came to the playable level there wasn’t really much to show, but we had basic running and jumping down. Which worked as they should, but we got told to add a jumping animation and a roll or slide animation, which would make it look more like natural movement.

By week 47 we had several improvements. The design of the UI was improved to make it fit the theme of the game. Pickups were added to let the character have something to interact with. Also a new level was completed. For the UI we got good feedback. It fit the theme more and was easy to understand. The level that was finished also got great feedback. It looked great and was hard, but manageable. Pickups was an intriguing implementation as the player got more objects to interact with, making the game overall more appealing.

Final product?   

### Reflections
As a whole our thoughts is that the final product is inline with our initial expectations. We are satisfied with mulitple aspects of the game which makes it a playable and challenging fun adventure. Looking back at our initial expectations and goals in the pre-production phase it is apparent that we have underestimated the amount of skill and work it takes to make games look good. Where the biggest challenge was animation and character modeling. In retrospect we should have invested more resources into animations as it is a crucial part of making the game feel fluent and responsive which might be the most important quality in a game like this. But given the limitations of our team not having any experience with artistry, we accept the final result. 

## My contribution

###### **Petter Edvardsen**
In the process of developing this game I worked on aspects such as the Player movement and mechanics relating to the physics and object interactions, *PlayerController* and its relations aswell as the bugfixing. I also worked on the 1st and final iteration of the Animations aswell as the underlying logic as it is directly related to the physics. For the level design I created the Forest level as a whole with the exception of one obstacle prefab. Additionally the 1st iteration of the user interface with the layout that remained and the implementation of the logic surrounding the scene management. For the visuals I worked on the cameras with the Post-processing. 

###### **Harald W Fredriksen**
In the development of our game, I primarily focused on two critical areas: level design and camera development. My responsibility encompassed the creation and design of various levels, specifically the first level (Tutorial), level two (Village), and level four (City). Additionally, I contributed to the design and creation of obstacles on the third level (Forest). 
To enhance the visual appeal and maintain consistency with the games polygonal style, I updated the skybox, ensuring that it aesthetically fit with the rest of the game.    
Another vital aspect of my role was developing the camera functionality. I created a Playertracker, which allows the player to move out of bounds along the x-axis while ensuring the camera follows along the y-axis. Furthermore, I integrated Cinemachine Virtual Camera to enable the player to catch up with the camera.  

###### **Sivert Ertshus**
During the development of this game I created the characters and set up character rigs along with parts of the animations and sounds. I also created the design for the different user interfaces. To tell a more detailed story of the game, I created the two story videos that get played in the game.   

###### **Jakob Finstad**
Under the development process i had focus on the camera, health and pickups. I created and altered the functions for the camera out of bounds detection, and all the functions in the pickup and health script. I've also did the implementation of the enemies, by finding the right assets to use, scale it to the right size, balance the damage/heal amount etc. At the end of each level there is a goal that I implemented, as well as an made event system that represent the confetti raining after a level is completed. Furthermore, I created the health bar, with some inspiration and some usage of some assets. I made an image to better fit our need for a progressbar, and made the scripts handling the progression of the bar.

## Manual
The game "The Weight Escape" is built for WebGL, Mac and Windows.
When starting the game, the player sees the main menu. Here the player has a total of four choices. Play game, which brings the player right into the story of the game. Settings, which lets the player change the volume in the game. Controls, which opens up a image where the player sees the controls. Quit game, which stops the game from running.
When playing the game the character runs on its own, but the player needs to jump and rolle to dodge obstacles. To make the character jump, the player presses space to jump and ctrl to make it rolle, and if the player ever needs to see the controls again, they can press the esc button on the keyboard, and one will be able to see the same settings as they did on the main menu. The differences are that instead of play game, it says resume game, and instead of quit game, it brings one back to the main menu. 
When finishing a level, a win menu pops up. Here the player is given the choice to either continue to the next level or go back to the main menu.



##  References
[^1]:  https://www.coursera.org/learn/game-design-and-development-2/home/week/1
[^2]:  https://assetstore.unity.com/student-plan-pack1
[^3]: https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/#jump_unity
