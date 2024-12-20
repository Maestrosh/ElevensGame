# Elevens Card Game

## Overview
Elevens is a card game where players aim to remove cards from the board by finding pairs that add up to 11 or forming a set of Jack, Queen, and King. The goal is to clear the board and achieve the highest score.

This implementation is written in C# and provides a simple console-based gameplay experience.

## Features
- **Deck of Cards**: A complete standard deck with ranks, suits, and values.
- **Dynamic Board**: The board can hold up to 9 cards at a time.
- **Valid Moves**:
  - Remove pairs of cards whose values add up to 11.
  - Remove a trio of Jack, Queen, and King.
- **Scoring System**: Earn 1 point for each valid pair and 3 points for each valid trio.
- **Shuffling**: The deck is shuffled at the start of the game.
- **Game Over**: The game ends when there are no valid moves or the deck is empty.

## How to Play
1. **Run the Game**: Execute the program to start the game.
2. **View the Board**: The board will display the cards available for selection.
3. **Select Cards**:
   - Enter the indices of the cards you want to select (e.g., `1 2` or `1 2 3`).
4. **Remove Cards**:
   - A pair is removed if their values sum to 11.
   - A trio is removed if it contains a Jack, Queen, and King.
5. **Game Progress**:
   - The board refills with cards from the deck until the deck is empty.
   - The game ends when no more valid moves are possible.
6. **Winning**:
   - Clear the board to achieve the highest score.

## Project Structure
- **Card.cs**: Represents a single card with rank, suit, and value.
- **Deck.cs**: Handles the deck of cards, including shuffling and dealing.
- **Board.cs**: Manages the cards on the board and validates player moves.
- **Game.cs**: Implements the game logic, including scoring and gameplay loop.
- **Main.cs**: Entry point to start the game.

## How to Run


### Installation
```bash
# Clone the repository
git clone https://github.com/Maestrosh/ElevensGame.git
cd elevens-card-game

# Compile and run
dotnet run
```

## Gameplay Example
```
Welcome to Elevens!

Current Board:
1: 5 of Hearts
2: 6 of Diamonds
3: Jack of Spades
4: Queen of Hearts
5: King of Clubs
6: 3 of Diamonds
7: 8 of Spades
8: 2 of Hearts
9: 9 of Clubs

Enter the indices of the cards to select (e.g., 1 2 or 1 2 3): 1 2
Pair removed!
Current Board: ...
```

## Contributing
Contributions are welcome! Feel free to submit issues or pull requests to improve the game!

## License
This project is licensed under the MIT License. See `LICENSE` for details.

## Acknowledgments
This project was inspired by the classic card game and implemented as a learning exercise in C#.
