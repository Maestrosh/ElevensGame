// Card.cs
using System;

    // Card Class: Represents a playing card
    public class Card
    {
        public string Rank { get; private set; }
        public string Suit { get; private set; }
        public int Value { get; private set; }

        public Card(string rank, string suit, int value)
        {
            Rank = rank;
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
