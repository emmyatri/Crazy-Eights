using CrazyEights.Domain;

namespace CrazyEights.Cards;

public class StandardCard(Rank rank, Suit suit) : ICard
{
    public Suit Suit { get; } = suit;

    public Rank Rank { get; } = rank;


    public bool Matches(ICard topCard, Suit currentSuit)
    {
        return Rank == topCard.Rank ||
               Suit == currentSuit ||
               Rank.IsEight();
    }


    public string GetDisplayName()
    {
        return $"{Rank} of {Suit} {Suit.GetSymbol()}";
    }
}