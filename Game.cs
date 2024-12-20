//Game.cs

using System;
using System.Collections.Generic;
using System.Linq;


// Game Class: Manages the overall game logic
public class Game
{
    private Deck deck;
    private Board board;
    private int score;
    public Game()
    {
        deck = new Deck();
        board = new Board();
        score = 0;
        deck.Shuffle();
        board.FillBoard(deck);
    }
    public void Play()
    {
        Console.WriteLine("Welcome to Elevens!");
        while (true)
        {
            if (!HasValidMoves())
            {
                Console.WriteLine("No more valid moves. Game over! Your score is: " + score); // Display the score
                break;
            }
            DisplayBoard();
            Console.WriteLine("Enter the indices of the cards to select (e.g., 1 2 or 1 2 3):");
            string[] input = Console.ReadLine()?.Split();
            if (input == null)
            {
                Console.WriteLine("Invalid input. Try again.");
                continue;
            }
            int[] cardIndices = new int[input.Length];
            bool isValidInput = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (!int.TryParse(input[i], out cardIndices[i]))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    isValidInput = false;
                    break;
                }
                cardIndices[i]--;
            }
            if (!isValidInput)
            {
                continue;
            }
            if (cardIndices.Length == 2)
            {
                if (board.ValidatePair(cardIndices[0], cardIndices[1]))
                {
                    board.RemoveCards(cardIndices);
                    Console.WriteLine("Pair removed!");
                    score++; // Increment score for a pair
                }
                else
                {
                    Console.WriteLine("Invalid pair. Try again.");
                }
            }
            else if (cardIndices.Length == 3)
            {
                if (board.ValidateTrio(cardIndices))
                {
                    board.RemoveCards(cardIndices);
                    Console.WriteLine("Trio removed!");
                    score += 3; // Increment score for a trio
                }
                else
                {
                    Console.WriteLine("Invalid trio. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
            if (board.GetCardsOnBoard().Count == 0 && deck.CardsRemaining() == 0)
            {
                Console.WriteLine("Congratulations! You've cleared the board. Your score is: " + score); // Display the score
                break;
            }
            board.FillBoard(deck);
        }
    }
    private void DisplayBoard()
    {
        Console.WriteLine("Current Board:");
        var cards = board.GetCardsOnBoard();
        for (int i = 0; i < cards.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {cards[i]}");
        }
    }
    private bool HasValidMoves()
    {
        var cards = board.GetCardsOnBoard();
        // Check for any valid pairs
        for (int i = 0; i < cards.Count; i++)
        {
            for (int j = i + 1; j < cards.Count; j++)
            {
                if (cards[i].Value + cards[j].Value == 11)
                {
                    return true;
                }
            }
        }
        // Check for any valid trios
        var ranksOnBoard = cards.Select(card => card.Rank).ToList();
        if (ranksOnBoard.Contains("Jack") && ranksOnBoard.Contains("Queen") && ranksOnBoard.Contains("King"))
        {
            return true;
        }
        return false;
    }
}
