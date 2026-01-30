using CrazyEights.Domain;

namespace CrazyEights.Cards;

public interface ICard
{
    Suit Suit { get; }


    Rank Rank { get; }


    public bool Matches(ICard topCard, Suit currentSuit);


    public string GetDisplayName();
}