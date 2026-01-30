namespace CrazyEights.Domain;

public enum Suit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}

public static class SuitExtensions
{
    public static string GetSymbol(this Suit suit)
    {
        return suit switch
        {
            Suit.Hearts => "♥",
            Suit.Diamonds => "♦",
            Suit.Spades => "♠",
            Suit.Clubs => "♣",
            _ => ""
        };
    }
}