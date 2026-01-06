This script implements an AI patrol system in Unity.  
It allows an object to move between multiple predefined locations in sequence.  
This code was created by Mahyar from Maho Company.  
If your game is 2D, you need to change vector3 to vector2 in the code.  
This code was written without NavmeshAgent(In other versions, it is placed in the git, that version).  
////////////////Description/////////////  
A patrol system in Unity is used to make AI characters move automatically between multiplepoints in the game environment.   
These points, called waypoints, can be followed in order orin a loop.   
The system handles movement, obstacle avoidance, and sometimes random pauses to makethe AI behavior more natural.  
Animations are often added to make walking or running look realistic.  
Advanced patrol systems can react to the player, change paths, or switch between patrol and chase modes.   
This system can be implemented in 2D using simple movement scripts or in 3D using NavMeshAgent for pathfinding.  
Overall, patrol systems make enemies or NPCs behave dynamically and make the game world feel alive.  
