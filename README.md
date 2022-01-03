# Monster Chase 2D
 2D sidescroller w/ data persistence, singletons, delegates & events, coroutines, simple physics, and enemy spawn & collector points.
v1.0 Dec 30, 2021 - Jan 02, 2022

Created in Unity3D, with C# scripting in Visual Studio Community 2019.

Monster Chaser is a 2D side scroller where players attempt to stay alive as long as possible by avoiding randomly spawned monsters. Players avoid the monsters by utilizing timed jumps.

# Features / Principles :

# OOP features - 

Data persistence between scenes -  players choose one of two characters from a main menu load scene.The selected character is loaded onto the map in a new scene. After dying, players may start the map over, with the same character, by clicking a UI restart button perpetually visible in the upper righthand corner.

Singleton pattern - A singleton pattern is used via a GameManager object to ensure data persistence and avoid duplicates. GameManager instantiates Player.

Delegates & events - subscribe & unsubscribe used to instantiate the chosen character when loading scene.

Coroutines - used to spawn enemies, pausing execution for a randomly determined number of seconds.

# Player features -
Left & right movement via keyboard using Unity’s Input class to capture raw axis values (whole numbers).

Hard map boundaries reinforced via Player’s x axis value.

Jump via space bar input using simple physics applied to the rigidbody component. Jump can only be activated if Player is in contact with the ground, achieved by using Collision2D CompareTag method to evaluate the tag of the object player is in contact with.

Ground-based Enemy contact is determined using the same method.

Floating Enemy contact is determined similarly, but with an applied trigger on Enemy.

Animations via simple state machine - idle/walk determined by bool condition on transitions, and flipping position based on comparison of raw axis value.

Animations created via sliced sprite sheet.

# Enemy features -
Enemies spawned have a number of random attributes : random enemy type from an array of all possible enemies; velocity based on a random “speed” factor variable; randomly determined starting position from two possible spawn points; random spawned time from a range of seconds.

Enemy direction animation flipped based on side of spawn point, using -1 scale transformation.

# Map features -
Left and right spawn points, outside of camera view, randomly determined.

Collector points to destroy Enemy game objects, on left and right side of board (also serves as a backup to destroy Player in the case of bypassing boundary based on x axis).

# Camera features - 
Follows Player, using Player’s x coordinate. 

Uses LateUpdate method to ensure camera is moved after calculations made for Player movement.

Hard boundary for camera movement, to hide map edges, and spawn points.

# UI features - 
MainMenu scene with character selection via buttons assigned representational sprites.

During gameplay, persistent “Home” and “Reload’ buttons to return to Main Menu, and restart map.

# To be implemented :
Score system - collect points when jumping over Enemies. 
High Score system - data persistence between game sessions.
Increased difficulty mechanics - ex: using a timer, as game enters last 15 seconds, speed &/or number of Enemies increases.
Sound Effects &/or music.
Additional maps & Enemies.

Based on Awesome Tuts project & assets.
