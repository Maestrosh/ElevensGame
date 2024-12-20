//Deck.cs

using System;
using System.Collections.Generic;

// Deck Class: Manages a deck of playing cards
public class Deck
{
    private List<Card> cards;
    private static readonly string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    private static readonly string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
    private static readonly int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1 };

    public Deck()
    {
        cards = new List<Card>();
        foreach (var suit in suits)
        {
            for (int i = 0; i < ranks.Length; i++)
            {
                cards.Add(new Card(ranks[i], suit, values[i]));
            }
        }
    }

    public void Shuffle()
    {
        Random rng = new Random();
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (cards[i], cards[j]) = (cards[j], cards[i]);
        }
    }

    public Card Deal()
    {
        if (cards.Count == 0) throw new InvalidOperationException("The deck is empty.");
        Card dealtCard = cards[^1];
        cards.RemoveAt(cards.Count - 1);
        return dealtCard;
    }

    public int CardsRemaining()
    {
        return cards.Count;
    }
}
