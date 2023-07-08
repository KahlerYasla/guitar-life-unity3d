# Guitar-Life
![0](Media/0.jpeg)
![1](Media/1.jpeg)
![2](Media/2.jpeg)
![3](Media/3.jpeg)
![4](Media/4.jpeg)
![5](Media/5.jpeg)
![6](Media/6.jpeg)

## Description
The system is a collection of scripts that work together to create a small game with multiple
scenes and functionalities such as inventory management, NPC interaction and scene transitions.
The scripts are written in C# and use UnityEngine, a game engine developed by Unity
Technologies.
First, the "SO_CharacterBody" script creates a ScriptableObject that stores an array of body parts
for a character. Each body part is an instance of the "BodyPart" class, which contains a name and
a reference to a ScriptableObject for that specific body part. This allows for easy management
and customization of character body parts in the Unity editor.
The "BuySellManager" script manages the buying and selling of items in the game's market
scene. It keeps track of the player's money and inventory, and allows the player to purchase
items from the market and sell items from their inventory. It uses a LinkedList to store all the
items in the game, and accesses them through a series of indexes to perform the buying and
selling actions.
The "CameraFollow" script controls the movement of the camera in the game, following the
player character's movement on the x-axis. It also uses an offset value to keep the player within a
certain range of the camera's view. The "CarManager" script controls the spawning, movement
and destruction of cars in the game. It uses a LinkedList to store the instantiated cars, and uses a
Coroutine to spawn new cars at random intervals. It also sorts the order of the cars based on the
player's y-position, using sorting layer to make sure the cars are rendered behind or in front of
the player. The "DiscoMaker" script randomly changes
the color of a sprite renderer over time, creating a "disco" effect. It uses the InvokeRepeating
function to call the "ColorChanger" function every 0.5 seconds, and the ColorChanger function
uses the Random.value function to generate random color values for the red, green, and blue
channels of the sprite renderer's color.
The "InventoryToggle" script controls the opening and closing of the inventory menu in the
game. It listens for input from the player's horizontal and vertical axes, and if detected, it sets the
inventory menu game object to inactive. It also has a function, "OpenInventory", that is called by
a button on the game's UI. When this function is called, it checks if the inventory menu game
object is already active, and if it is, it sets it to inactive, otherwise, it sets it to active.
The "MarketSpeech" script controls the interaction between the player and NPCs in the game's
market scene. It checks for the player's collision with an NPC and sets a speech bubble and
buttons to active or inactive based on that collision. It also controls the state of the market
inventory and trading mode.
Overall, I believe that I did well during the interview in understanding and explaining the
functionality of each script and how they work together to create a cohesive game system. I also
explained my thought process behind the design choices and data structures used in each script. I
think that my understanding of UnityEngine, C# and data structures helped me to do well in this
task.
