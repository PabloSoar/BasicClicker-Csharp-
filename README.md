# BasicClicker-C#-
I've created this clicker in a C# mini-course

# Game and techs used
To play, simply run`~dotnet run~`;

The controls are simple:
- Holding the spacebar generates 10 points per second.
- [U] purchase/upgrade the generator. (Each level of the generator generates one passive point per second.)
- Press Esc to exit the program.

The technologies used were:
- Async/Await: To run the game without needing to use threads or timers and to run the point generator in parallel with the main loop.
- HashSet<T> was used to store pressed keys without duplicating them (when you release the spacebar, you stop earning points immediately).
- Basics of object-oriented programming, key detection and console WriteLine.
