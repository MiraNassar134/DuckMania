# DuckMania

In this Pac-Man inspired game, you control a duck who is trying to collect all of the coins in a maze while being chased by crocodiles. The crocodiles are constantly on the lookout for the duck and will try to catch it if it gets too close. However, the duck can turn the tables on the crocodiles by eating power-ups scattered throughout the maze. These power-ups give the duck temporary invincibility, allowing it to defeat the crocodiles and pass through them unharmed.

The duck must navigate through the maze, avoiding the crocodiles and collecting as many coins as possible. The coins are placed strategically throughout the maze and some may be hidden in harder-to-reach places. The duck must use its quick reflexes and strategic thinking to collect all of the coins and make it to the end of the level.

As the player progresses through the levels, the challenges will increase and the crocodiles will become more aggressive. With only three lives to work with, the player must be careful to avoid losing all of their lives before reaching the end of the game. Can you outsmart the crocodiles ?

Try it out [here!](https://mazen-ghaleb.github.io/DuckMania/Build/index.html "Project's Git Page Link")

## Rules

- The player controls a duck who must navigate through a maze and collect all of the coins while avoiding crocodiles.
- The duck has three lives at the start of the game, and it will lose a life if it is caught by a crocodile.
- The player can eat power-ups (Power Pellet) to temporarily defeat the crocodiles and pass through them unharmed.

## Gameplay

- The player uses the arrow keys to move the duck through the maze.
- The crocodiles will chase the duck and try to catch it.
- The player must collect all of the coins in the maze to complete the level.
- The player must use their quick reflexes and strategic thinking to avoid the crocodiles and collect the coins.

## Visuals

- The game features 2D graphics with a top-down view of the maze.
- The duck, crocodiles, and pellets are all represented by distinct sprites.

## Installation

To play the game, the player has multiple options:

1. Downloading and Opening the Unity project from the repository:

   - The player must have the Unity game engine (2021.3.16f1 or higher) installed on their computer.
   - The player must download the game files from the repository and open the project in Unity.
   - The player can then click the "Play" button in the Unity editor to start the game.

2. Downloading and Building the Unity project from the repository:

   - The player must have the Unity game engine (2021.3.16f1 or higher) installed on their computer.
   - The player must download the game files from the repository and open the project in Unity.
   - Once the project is open in Unity, the player can click on "File" in the top menu and then click on "Build Settings...".
   - In the "Build Settings" window, the player can choose the platform they want to build the project for WebGL
   - The player can then click on the "Build and Run" button and choose a location to save the build files.
   - Once the build is complete, the player will have a new tab on the browser open with the game.

3. Hosting the game using servers such as Live Server:

   - Download ‘Build’ directory from the repository.
   - The player can also use a tool like "Live Server" for Visual Studio Code to automatically open the "index.html" file in the directory in a web browser.

4. Opening the game on the hosted website on [GitPages](https://mazen-ghaleb.github.io/DuckMania/Build/index.html "Project's Git Page Link"):

   - The player can simply go to the hosted website on GitPages and the game will be loaded and run in the player's web browser.

In all cases, the player can then follow the on-screen instructions to navigate the duck through the maze and collect the coins while avoiding the crocodiles.

## Scripts

### AnimatedSprite.cs

This script is for an animated sprite in a Unity game. It requires a SpriteRenderer component to be attached to the same game object as the script.

The script has several public variables:

- sprites is an array of sprites that will be played in sequence to create an animation.
- animationTime is the time in seconds between switching to the next sprite in the animation.
- animationFrame is the current frame of the animation.
- loop is a boolean that determines whether the animation should loop or play once and stop.

The script has several methods:

- Awake() is a Unity event that is called when the script is first initialized. In this method, the script gets a reference to the attached SpriteRenderer component.
- Start() is a Unity event that is called when the script is enabled, just before the first frame update. In this method, the script starts a repeating timer that will call the Advance() method at regular intervals.
- Advance() is a method that advances the animation to the next frame. It increments the animationFrame variable and checks if it has reached the end of the sprites array. If loop is true, it will reset animationFrame to 0. If animationFrame is within the bounds of the sprites array, it will set the sprite of the attached SpriteRenderer component to the current frame of the animation.
- Restart() is a method that restarts the animation from the first frame. It sets animationFrame to -1 and calls Advance(), which will advance the animation to the first frame.

### GameManager.cs

This script is for a game manager in a Unity game. It controls the overall gameplay, including scoring, lives, and game states such as game over and round transitions.

The script has several public variables:

- crocodiles is an array of crocodile objects in the game.
- duck is the player-controlled duck object.
- pellets is a transform that holds all of the pellet objects in the game.
- gameOverText is a Text object that displays the ‘Game over’ to the player upon defeat.
- livesText is a Text object that displays the current remaining lives.
- scoreText is a Text object that displays the current score.
- roundText is a Text object that displays the current round number.
- crocodileMultiplier is a multiplier that increases each time the player defeats a crocodile.
- score is the current score of the player.
- lives is the number of lives the player has remaining.
- round is the current round number.

The script has several methods:

- Start() is a Unity event that is called when the script is enabled, just before the first frame update. In this method, the script checks if the "StartScreen" scene is still loaded and unloaded it if it is. It also starts a new game by calling NewGame().
- Update() is a Unity event that is called every frame. In this method, the script checks if the game is over and if the player has pressed any key (excluding the Escape key). If both of these conditions are true, it starts a new game by calling NewGame().
- NewGame() is a method that starts a new game. It sets the score, lives, and round to their starting values and starts a new round by calling NewRound().
  NewRound() is a method that starts a new round. It increments the round number, hides the game over text, and activates all of the pellet objects. It also calls ResetState() to reset the game objects to their starting states.
- ResetState() is a method that resets the game objects to their starting states. It resets the crocodile multiplier, calls the ResetState() method on each crocodile object, and calls the ResetState() method on the duck object.
- GameOver() is a method that is called when the player runs out of lives. It enables the game over text, disables all crocodile and duck objects, and ends the current round.
- SetScore(int score) is a method that sets the current score and updates the score text.
- SetRound(int round) is a method that sets the current round number and updates the round text.
- SetLives(int lives) is a method that sets the number of lives remaining and updates the lives text.
- CrocodileEaten(Crocodile crocodile) is a method that is called when the player defeats a crocodile. It increases the score by the number of points that the crocodile is worth, multiplied by the current crocodile multiplier. It also increases the crocodile multiplier.
- DuckEaten() is a method that is called when a crocodile catches the player's duck. It disables the duck object, decreases the number of lives remaining, and either restarts the round or ends the game depending on whether the player has any lives remaining.
- PelletEaten(Pellet pellet) is a method that is called when the player collects a pellet object. It disables the pellet object, increases the player's score by the number of points that the pellet is worth, and checks if there are any remaining pellet objects in the level. If there are no remaining pellets, it disables the duck object and starts a new round after a delay.
- PowerPelletEaten(PowerPellet pellet) is a method that is called when the player collects a power pellet object. It calls the Enable(float duration) method on the frightened component of each crocodile object, which will cause the crocodiles to behave differently for a certain duration. It also calls the PelletEaten(Pellet pellet) method to disable the pellet object and increase the player's score. It also cancels any invocations of the ResetCrocodileMultiplier() method that may be scheduled.
- ResetCrocodileMultiplier() is a method that resets the crocodile multiplier.

### Movement.cs

This script is for movement control in a Unity game. It requires a Rigidbody2D component to be attached to the same game object as the script.

The script has several public variables:

- speed is the base movement speed of the object.
- speedMultiplier is a multiplier that can be used to temporarily increase or decrease the movement speed.
- initialDirection is the initial direction that the object will move in when the game starts.
- obstacleLayer is a LayerMask that determines which layers the object will collide with when checking for obstacles.
- rigidbody is a reference to the attached Rigidbody2D component.
- direction is the current direction that the object is moving in.
- nextDirection is the next direction that the object will move in.
- startingPosition is the starting position of the object.

The script has several methods:

- Awake() is a Unity event that is called when the script is first initialized. In this method, the script gets a reference to the attached Rigidbody2D component and stores the starting position of the object.
- Start() is a Unity event that is called when the script is enabled, just before the first frame update. In this method, the script calls the ResetState() method to reset the object to its starting state.
- ResetState() is a method that resets the object to its starting state. It sets the speed multiplier to 1.0, the direction to the initial direction, the next direction to zero, the position to the starting position, and enables the Rigidbody2D component and script.
- Update() is a Unity event that is called every frame. In this method, the script checks if the next direction is not zero and, if it is not, calls the SetDirection() method with the next direction.
- FixedUpdate() is a Unity event that is called at a fixed interval. In this method, the script calculates the object's new position based on its current position, direction, speed, speed multiplier, and the fixedDeltaTime. It then moves the object to the new position using the Rigidbody2D component's MovePosition() method.
- SetDirection(Vector2 direction, bool forced = false) is a method that sets the object's direction. If the forced argument is false (the default), it will only set the direction if there are no obstacles in that direction. If the forced argument is true, it will set the direction regardless of obstacles. If the direction is not set, it sets the next direction to the intended direction.
- Occupied(Vector2 direction) is a method that returns a boolean indicating whether there is an obstacle in the given direction. It uses a Physics2D.BoxCast() method to check for collisions with objects in the obstacle layer within a certain distance. If a collision is detected, it returns true, otherwise it returns false.

### Node.cs

This script is for determining the available directions that an object can move in a Unity game. It has a public LayerMask variable obstacleLayer that determines which layers will be considered obstacles, and a public List of Vector2 availableDirections that will store the available directions.

The script has several methods:

- Start() is a Unity event that is called when the script is enabled, just before the first frame update. In this method, the script initializes the availableDirections list and calls the CheckAvailableDirection() method for each of the four cardinal directions (up, down, left, and right).
- CheckAvailableDirection(Vector2 direction) is a method that checks if there are any obstacles in the given direction. It uses a Physics2D.BoxCast() method to check for collisions with objects in the obstacle layer within a certain distance. If no collision is detected, it adds the direction to the availableDirections list.

### Pellet.cs

This script is for a pellet object in a Unity game. It has a public integer variable points that determines the number of points that the player will receive when collecting the pellet.

The script has several methods:

- Eat() is a protected virtual method that is called when the pellet is collected by the player. It finds the GameManager object in the scene and calls its PelletEaten() method with a reference to itself as an argument.
- OnTriggerEnter2D(Collider2D other) is a Unity event that is called when another collider enters the trigger collider attached to the same game object as this script. In this method, the script checks if the other collider is on the "Duck" layer (which is the layer assigned to the player object) and, if it is, calls the Eat() method.

### PowerPellet.cs

This script is for a power pellet object in a Unity game, which is a type of pellet that gives the player a temporary power-up. It has a public float variable duration that determines how long the power-up will last.

The script has a single method:

- Eat() is a protected override method that is called when the power pellet is collected by the player. It finds the GameManager object in the scene and calls its PowerPelletEaten() method with a reference to itself as an argument. This method overrides the Eat() method in the base Pellet class and calls a different method in the GameManager.

Note: This script is derived from the Pellet class, so it also has the functionality of the Pellet class, including the OnTriggerEnter2D() event that is called when the player collides with the power pellet.

### Passage.cs

This script is for a passage object in a Unity game, which allows an object to move from one location to another by passing through it. It has a public Transform variable connection that determines the location that the object will be teleported to when it enters the passage.

The script has a single method:

- OnTriggerEnter2D(Collider2D other) is a Unity event that is called when another collider enters the trigger collider attached to the same game object as this script. In this method, the script gets the position of the other collider's transform and sets its x and y values to the x and y values of the connection transform. It then sets the other collider's transform position to this modified position. This has the effect of teleporting the other collider to the location of the connection transform.

### Duck.cs

This script is for a duck object in a Unity game, which represents the player character.

The script has several public variables:

- movement is a movement script that controls the movement of the duck in the game world.
- spriteRenderer is a component that is responsible for rendering a sprite for the duck.
- collider is a component that is responsible for detecting collisions between the duck and other colliders in the game world.

The script has several methods:

- Awake() is a Unity method that is called when the script is first enabled. In this method, the script gets references to the Movement, SpriteRenderer, and Collider2D components attached to the same game object as this script.
- Update() is a Unity method that is called once per frame. In this method, the script checks for input from the player to change the direction of the duck's movement. It also rotates the duck to face the direction it is moving.
- ResetState() is a custom method that resets the duck's state, enabling its components and game object, and resetting its movement.

### Crocodile.cs

This script is attached to the Crocodile game object and it controls the behavior of the crocodile character in the game.

The script has several public variables:

- movement: a reference to the Movement component attached to the Crocodile game object. This is used to control the movement of the crocodile.
- home: a reference to the CrocodileHome component attached to the Crocodile game object. This is used to control the home behavior of the crocodile.
- chase: a reference to the CrocodileChase component attached to the Crocodile game object. This is used to control the chasing behavior of the crocodile.
- frightened: a reference to the CrocodileFrightened component attached to the Crocodile game - object. This is used to control the frightened behavior of the crocodile.
- scatter: a reference to the CrocodileScatter component attached to the Crocodile game object. This is used to control the scatter behavior of the crocodile.
- initialBehaviour: a reference to the initial behavior of the crocodile. This determines which behavior the crocodile will start with when the game begins.
- target: a reference to the Duck game object. This is used to determine the target of the crocodile's behaviors.
- points: the number of points the player will receive for eating this crocodile.

The script has several methods:

- Awake(): This method is called when the object is initialized. It gets references to the object's Movement, CrocodileChase, CrocodileHome, CrocodileFrightened, and CrocodileScatter components and stores them in the corresponding properties.
- Start(): This method is called when the object is spawned. It calls the ResetState() method to reset the crocodile's state.
- ResetState(): This method resets the crocodile's state. It sets the object's gameObject to active, calls the ResetState() method of the object's Movement component, disables the CrocodileFrightened and CrocodileChase components, and enables the CrocodileScatter component. If the object's initialBehaviour property is not null, it also disables the CrocodileHome component and enables the initialBehaviour component.
- OnCollisionEnter2D(Collision2D collision): This method is called when the object collides with another object. If the collided object's layer is "Duck", the method checks whether the CrocodileFrightened component is enabled. If it is, it calls the CrocodileEaten() method of the GameManager object, passing itself as an argument. If the CrocodileFrightened component is not enabled, the method calls the DuckEaten() method of the GameManager object.

### CrocodileBehaviour.cs

This script is an abstract class that defines a common set of behaviors for different types of crocodile behavior. It requires that the game object it is attached to has a Crocodile component.

The script has several public variables:

- duration: a float value representing the duration of the behavior.
- crocodile: a private variable that stores a reference to the Crocodile component attached to the game object.

The script has several methods:

- Awake(): this method is called when the script is first initialized. It stores a reference to the Crocodile component attached to the game object and disables the CrocodileBehaviour script.
- Enable(): this method enables the CrocodileBehaviour script and sets the duration of the behavior to the value of the duration variable.
- Enable(float duration): this method is similar to the Enable() method, but allows you to specify a custom duration for the behavior.
- Disable(): this method disables the CrocodileBehaviour script and cancels any pending invocations of the Disable() method.

The CrocodileBehaviour class is intended to be extended by other classes that define specific types of crocodile behavior.

### CrocodileChase.cs

CrocodileChase is a class that derives from the CrocodileBehaviour class and represents the behavior of a crocodile when chasing the duck.

The script has several methods:

- OnDisable(): this method is called when the CrocodileChase component is disabled. It enables the crocodile's scatter behavior.
- OnTriggerEnter2D(): this method is called when the crocodile collides with another collider with a 2D BoxCollider component. If the other collider has a Node component and the CrocodileChase component is enabled and the crocodile is not in a frightened state, the method sets the crocodile's direction towards the duck. It does this by finding the direction with the minimum distance to the duck among the available directions of the node.

### CrocodileFrightened.cs

CrocodileFrightened is a class that derives from the CrocodileBehaviour class and represents the behavior of a crocodile when frightened from the duck.

The script has several public variables:

- body: a SpriteRenderer component that is used to render the body of the crocodile
- eyes: a SpriteRenderer component that is used to render the eyes of the crocodile
- green: a SpriteRenderer component that is used to render the crocodile when it is in a "frightened" state
- white: a SpriteRenderer component that is used to render the crocodile when it is flashing in a "frightened" state
- eaten: a boolean value that indicates whether the crocodile has been eaten or not

The script has several methods:

- OnEnable(): this method is called when the script is enabled (e.g. when the crocodile enters the "frightened" state).
- Enable(float duration): this method is used to enable the "frightened" state of the crocodile and make it flash. The duration parameter specifies how long the "frightened" state should last.
- OnDisable(): this method is called when the script is disabled (e.g. when the crocodile exits the "frightened" state).
- Disable(): this method is used to disable the "frightened" state of the crocodile and return it to its normal state.
- Flash(): this method is used to make the crocodile flash while it is in the "frightened" state.
- Eaten(): this method is used to handle the case where the crocodile is eaten while it is in the "frightened" state.
- OnCollisionEnter2D(Collision2D collision): this method is called when the crocodile collides with another GameObject with a collider.
- OnTriggerEnter2D(Collider2D other): this method is called when the crocodile enters the trigger area of another GameObject with a collider.

### CrocodileHome.cs

CrocodileHome is a class that derives from the CrocodileBehaviour class and represents the behavior of a crocodile when it is in its home area

The script has several public variables:

- inside: a Transform that represents the position of the crocodile when it is inside its home.
- outside: a Transform that represents the position of the crocodile when it is outside its home.

The script has several methods:

- OnEnable(): this method is called when the script is enabled. It stops all coroutines that are running on the game object.
- OnDisable(): this method is called when the script is disabled. It starts a coroutine called ExitTransition.
- OnCollisionEnter2D(): this method is called when the game object collides with another game object. If the other game object has the "Obstacle" layer, the direction of the crocodile's movement is reversed.
- ExitTransition(): this method is a coroutine that moves the crocodile from its home area to the outside. The crocodile is made to move in the upward direction and its movement is made kinematic. Its position is then smoothly interpolated from its current position to the inside position, and then from the inside position to the outside position. The crocodile's direction is then set to a random horizontal direction and its movement is made dynamic again.

### CrocodileScatter.cs

CrocodileScatter is a class that derives from the CrocodileBehaviour class and represents the behavior of a crocodile where it scatters through the map.

The script has several methods:

- OnDisable(): a method that is called when the script is disabled. In this method, if the scatter field of the crocodile object is not null, the chase behavior is enabled.
- OnTriggerEnter2D(Collider2D other): a method that is called when the object this script is attached to enters a 2D trigger. In this method, if the other object has a Node component, and this script is enabled and the frightened behavior of the crocodile object is not enabled, a random direction is chosen from the available directions of the Node component and the direction of the crocodile object is set to this direction.

### CrocodileEyes.cs

CrocodileEyes is a script that manages the sprite renderer of the eyes of a crocodile game object.

The script has several public variables:

- spriteRenderer: a SpriteRenderer component used to display a sprite on the GameObject this script is attached to
- movement: a Movement component representing the movement behavior of the parent GameObject
  up: a Sprite representing the eye sprite to be displayed when the parent GameObject is moving upwards
- down: a Sprite representing the eye sprite to be displayed when the parent GameObject is moving downwards
- left: a Sprite representing the eye sprite to be displayed when the parent GameObject is moving left
- right: a Sprite representing the eye sprite to be displayed when the parent GameObject is moving right

The script has several methods:

- Awake(): a Unity method called when the script is first initialized. It is used to initialize the spriteRenderer and movement variables.
- Update(): a Unity method called every frame. It is used to update the spriteRenderer's sprite based on the movement direction of the parent GameObject.

### StartMenu.cs

The StartMenu script is a Unity script that handles the logic for a start menu in a game.

The script has single public variable:

- gameloaded: a static bool variable that determines whether the game has been loaded or not.

The script has several methods:

- Start(): this is a Unity method that is called when the script is first initialized. It sets the time scale to 1, sets the game to not be paused, and loads the DuckMania scene if the game has been loaded before.
- StartGame(): this method starts the game by setting the time scale to 1, setting the game to not be paused, and loading the DuckMania scene.
- ExitGame(): this method quits the game by calling the Application.Quit() method and the closeWindow() method (which is a method written in native code to close web application).

### PauseMenuScript.cs

The PauseMenuScript script is a script that handles the functionality of a pause menu in a game.

The script has single public variable:

- isPaused: static boolean representing the current paused state of the game.

The script has several methods:

- Start(): Initializes the script when it is first loaded. This method is called before the first frame update.
- Update(): Called once per frame, this method listens for the user to press the Escape key and responds by either pausing or resuming the game depending on the current state.
- PauseGame(): This method is called when the game needs to be paused. It loads the "pauseScene" scene, sets the Time.timeScale to 0 (which effectively pauses the game), and sets isPaused to true.
- ResumeGame(): This method is called when the game needs to be resumed. It unloads the "pauseScene" scene, sets the Time.timeScale back to 1 (which effectively resumes the game), and sets isPaused to false.
- ExitGame(): This method is called when the user wants to exit the game. It quits the application and closes the window (on a web platform).

### pausebuttons.cs

The script handles different actions for buttons when the game is paused.

The script has several methods:

- ResumeGame(): This method is called when the "Resume" button is pressed. It sets the time scale to 1, which means the game will resume its normal speed. It also sets the static boolean variable "isPaused" to false. It then checks if the "pauseScene" scene is currently loaded, and if it is, it unloads it.
- GotoMainMenu(): This method is called when the "Main Menu" button is pressed. It sets the time scale to 0, which means the game will pause. It also sets the static boolean variable "isPaused" to true. It then checks if the "pauseScene" scene is currently loaded, and if it is, it unloads it. It also unloads the "DuckMania" scene. It then finds all game objects in the scene and destroys them. Finally, it loads the "StartScreen" scene.
- ExitGame(): This method is called when the "Exit" button is pressed. It closes the application and calls the "closeWindow" function (which is defined in an external library).
