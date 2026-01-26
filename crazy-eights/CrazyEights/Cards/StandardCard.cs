using CrazyEights.Domain;
namespace CrazyEights.Cards;

/// <summary>
/// Standard playing card with suit and rank
/// </summary>

public class StandardCard : ICard
{
    public Suit Suit { get; }
    
    public Rank Rank { get; }

    public StandardCard(Rank rank, Suit suit)
    {

        Rank = rank;
        
        Suit = suit;

    }

    public override string ToString()
    {
        
        return $"{Rank} of {Suit}{Suit.SuitSymbol()}";
        
    }
}