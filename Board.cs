//Board.cs

using System;
using System.Collections.Generic;
using System.Linq;


// Board Class: Manages the cards on the board
public class Board
{
    private List<Card> cardsOnBoard;
    private const int MaxCardsOnBoard = 9;

    public Board()
    {
        cardsOnBoard = new List<Card>();
    }

    public void FillBoard(Deck deck)
    {
        while (cardsOnBoard.Count < MaxCardsOnBoard && deck.CardsRemaining() > 0)
        {
            cardsOnBoard.Add(deck.Deal());
        }
    }

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

    public bool ValidateTrio(int[] cardIndices)
    {
        if (cardIndices.Length != 3) return false;

        string[] requiredRanks = { "Jack", "Queen", "King" };
        var selectedCards = cardIndices.Select(index => cardsOnBoard[index]).ToList();
        return requiredRanks.All(rank => selectedCards.Any(card => card.Rank == rank));
    }

    public void RemoveCards(int[] cardIndices)
    {
        foreach (var index in cardIndices.OrderByDescending(i => i))
        {
            cardsOnBoard.RemoveAt(index);
        }
    }

    public List<Card> GetCardsOnBoard()
    {
        return new List<Card>(cardsOnBoard);
    }
}
