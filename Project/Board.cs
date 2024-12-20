/// <summary>
/// Represents the board in the card game, managing cards currently on display.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;

public class Board
{
    /// <summary>
    /// List of cards currently on the board.
    /// </summary>
    private List<Card> cardsOnBoard;

    /// <summary>
    /// Maximum number of cards allowed on the board at any time.
    /// </summary>
    private const int MaxCardsOnBoard = 9;

    /// <summary>
    /// Initializes a new instance of the <see cref="Board"/> class.
    /// </summary>
    public Board()
    {
        cardsOnBoard = new List<Card>();
    }

    /// <summary>
    /// Fills the board with cards from the deck until the maximum number of cards is reached
    /// or the deck is empty.
    /// </summary>
    /// <param name="deck">The deck to draw cards from.</param>
    public void FillBoard(Deck deck)
    {
        while (cardsOnBoard.Count < MaxCardsOnBoard && deck.CardsRemaining() > 0)
        {
            cardsOnBoard.Add(deck.Deal());
        }
    }

    /// <summary>
    /// Validates if two selected cards form a valid pair that adds up to 11.
    /// </summary>
    /// <param name="card1Index">The index of the first card.</param>
    /// <param name="card2Index">The index of the second card.</param>
    /// <returns>True if the pair is valid; otherwise, false.</returns>
    public bool ValidatePair(int card1Index, int card2Index)
    {
        if (card1Index < 0 || card1Index >= cardsOnBoard.Count ||
            card2Index < 0 || card2Index >= cardsOnBoard.Count ||
            card1Index == card2Index)
        {
            return false;
        }

        return cardsOnBoard[card1Index].Value + cardsOnBoard[card2Index].Value == 11;
    }

    /// <summary>
    /// Validates if three selected cards form a valid trio of "Jack", "Queen", and "King".
    /// </summary>
    /// <param name="cardIndices">The indices of the three cards.</param>
    /// <returns>True if the trio is valid; otherwise, false.</returns>
    public bool ValidateTrio(int[] cardIndices)
    {
        if (cardIndices.Length != 3) return false;

        string[] requiredRanks = { "Jack", "Queen", "King" };
        var selectedCards = cardIndices.Select(index => cardsOnBoard[index]).ToList();
        return requiredRanks.All(rank => selectedCards.Any(card => card.Rank == rank));
    }

    /// <summary>
    /// Removes specified cards from the board.
    /// </summary>
    /// <param name="cardIndices">The indices of the cards to remove.</param>
    public void RemoveCards(int[] cardIndices)
    {
        foreach (var index in cardIndices.OrderByDescending(i => i))
        {
            cardsOnBoard.RemoveAt(index);
        }
    }

    /// <summary>
    /// Gets a copy of the cards currently on the board.
    /// </summary>
    /// <returns>A list of cards on the board.</returns>
    public List<Card> GetCardsOnBoard()
    {
        return new List<Card>(cardsOnBoard);
    }
}
