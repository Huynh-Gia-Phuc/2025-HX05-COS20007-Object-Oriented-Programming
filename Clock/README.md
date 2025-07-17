# Clock Application

## Overview
This application demonstrates a simple object-oriented implementation of a digital clock using C#.

- The `Counter` class represents a simple counter with increment and reset functionality.
- The `Clock` class uses three `Counter` objects to represent hours, minutes, and seconds, and provides methods to tick the clock, set the time, and display the current time.
- The `Program` class contains the entry point and demonstrates usage of the counters.

## File Structure
- `Counter.cs`: Defines the `Counter` class.
- `Clock.cs`: Defines the `Clock` class, which uses three counters for hours, minutes, and seconds.
- `Program.cs`: Contains the `Main` method and demonstrates how to use the classes.

## Usage
1. **Compile the project** using your preferred C# IDE or the .NET CLI:
   ```sh
   dotnet build
   ```
2. **Run the application**:
   ```sh
   dotnet run
   ```
3. **Modify `Program.cs`** to experiment with the `Clock` and `Counter` classes as needed.

## Example
Here is an example of how to use the `Clock` class:
```csharp
Clock myClock = new Clock();
myClock.SetTime(23, 59, 55);
for (int i = 0; i < 10; i++)
{
    myClock.ClockTick();
    Console.WriteLine(myClock);
}
```

## Author
- Student ID: SWS01358

---
This project is for educational purposes and demonstrates basic OOP concepts in C#. 