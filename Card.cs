/// <summary>
/// Represents a playing card with a rank, suit, and value.
/// </summary>
using System;

public class Card
{
    /// <summary>
    /// Gets the rank of the card (e.g., "Ace", "2", "King").
    /// </summary>
    public string Rank { get; private set; }

    /// <summary>
    /// Gets the suit of the card (e.g., "Hearts", "Spades").
    /// </summary>
    public string Suit { get; private set; }

    /// <summary>
    /// Gets the numerical value of the card.
    /// </summary>
    public int Value { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Card"/> class.
    /// </summary>
    /// <param name="rank">The rank of the card.</param>
    /// <param name="suit">The suit of the card.</param>
    /// <param name="value">The numerical value of the card.</param>
    public Card(string rank, string suit, int value)
    {
        Rank = rank;
        Suit = suit;
        Value = value;
    }

    /// <summary>
    /// Returns a string representation of the card in the format "Rank of Suit".
    /// </summary>
    /// <returns>A string describing the card.</returns>
    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}
