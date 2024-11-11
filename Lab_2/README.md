# Coffee Shop Simulation - OOP Lab

This project is a Coffee Shop simulation developed as part of an OOP laboratory assignment in C#. The project demonstrates object-oriented principles such as **inheritance**, **encapsulation**, **polymorphism**, and **abstraction** within a layered application structure. The main components include various coffee types, a `Barista` class to manage coffee orders, and an interactive console application to simulate a coffee ordering system.

## Project Structure

The project is organized into multiple tasks:

1. **Task 1** - _Coffee & More Coffee_:

   - Implemented a series of classes for different coffee types (`Coffee`, `Cappuccino`, `Americano`, etc.) using inheritance.
   - Each derived class adds a unique property to represent its specific ingredients or preparation requirements.

2. **Task 2** - _Inheritance Behavior Part 1_:

   - Introduced `printDetails` methods to each coffee class to display preparation steps.
   - Demonstrated method overriding and the `super` keyword for shared behavior across classes.

3. **Task 3** - _Inheritance Behavior Part 2_:

   - Added specific class methods for creating each coffee type (e.g., `makeCappuccino`, `makeAmericano`).
   - Implemented `sealed` methods to prevent further method overrides in subclasses.

4. **Task 4** - _Barista, the Work Starts Now_:
   - Introduced the `Barista` class as the main interface for managing coffee orders.
   - Encapsulated coffee classes within the `Barista` class, hiding internal logic from the main application.
   - Implemented a layered structure to handle user input, order processing, and coffee preparation in an organized way.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or later)
- IDE like [Rider](https://www.jetbrains.com/rider/) or [Visual Studio](https://visualstudio.microsoft.com/)

### Running the Application

1. Clone this repository.
2. Navigate to the project directory and run the application:
   ```bash
   dotnet run
   ```
3. Follow the console prompts to place coffee orders.

## Testing

Unit tests are implemented using NUnit, covering:

- Individual coffee classes for correct output (`CoffeeTests`).
- The `Barista` class’s `TakeOrder` method for processing multiple coffee orders correctly (`BaristaTests`).

To run the tests, use:

```bash
dotnet test
```

## Key OOP Principles

- **Encapsulation**: Coffee classes are encapsulated within the `Barista` class, exposing only essential functionality.
- **Inheritance**: Various coffee types inherit from a base `Coffee` class, extending functionality as needed.
- **Polymorphism**: `MakeCoffee` method is overridden in each subclass to provide specific preparation steps.
- **Abstraction**: The `Barista` class abstracts complex operations and provides a simplified interface for the user.

## Sample Output

```plaintext
Welcome to the Coffee Shop!
1. Cappuccino
2. Pumpkin Spice Latte
3. Americano
4. Syrup Cappuccino
5. Finish and Place Order
Please select an option (1-5): 1

Making Cappuccino
Intensity set to NORMAL
Adding 50 mls of milk
...
```

## License

Feel free to use, modify, and distribute this project for any purpose.

---
