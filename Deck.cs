/// <summary>
/// Represents a deck of playing cards with functionalities to shuffle, deal, and manage the cards.
/// </summary>
using System;
using System.Collections.Generic;

public class Deck
{
    /// <summary>
    /// The list of cards in the deck.
    /// </summary>
    private List<Card> cards;

    /// <summary>
    /// The suits available in a standard deck of cards.
    /// </summary>
    private static readonly string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

    /// <summary>
    /// The ranks available in a standard deck of cards.
    /// </summary>
    private static readonly string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

    /// <summary>
    /// The corresponding values for each rank.
    /// </summary>
    private static readonly int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1 };

    /// <summary>
    /// Initializes a new instance of the <see cref="Deck"/> class and populates it with a standard set of 52 playing cards.
    /// </summary>
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

    /// <summary>
    /// Shuffles the deck using the Fisher-Yates algorithm.
    /// </summary>
    public void Shuffle()
    {
        Random rng = new Random();
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (cards[i], cards[j]) = (cards[j], cards[i]);
        }
    }

    /// <summary>
    /// Deals the top card from the deck.
    /// </summary>
    /// <returns>The top <see cref="Card"/> from the deck.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the deck is empty.</exception>
    public Card Deal()
    {
        if (cards.Count == 0) throw new InvalidOperationException("The deck is empty.");
        Card dealtCard = cards[^1];
        cards.RemoveAt(cards.Count - 1);
        return dealtCard;
    }

    /// <summary>
    /// Gets the number of cards remaining in the deck.
    /// </summary>
    /// <returns>The number of cards remaining.</returns>
    public int CardsRemaining()
    {
        return cards.Count;
    }
}
