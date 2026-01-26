namespace CrazyEights.Domain;

public static class SuitExtensions
{
    public static string SuitSymbol(this Suit suit)
    {
        return suit switch
        {
            Suit.Hearts => "\u2665",
            Suit.Diamonds => "\u2666",
            Suit.Spades => "\u2660",
            Suit.Clubs => "\u2663",
            _ => ""
        };
    }
}