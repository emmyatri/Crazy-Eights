using CrazyEights.Domain;
namespace CrazyEights.Cards;

/// <summary>
/// Standard playing card with suit and rank
/// </summary>

public class StandardCard : ICard
{
    
    public Rank Rank { get; set; }

    public Suit Suit {  get; set; }
    
    

    /// <summary>
    /// Create new card with specified rank and suit
    /// </summary>
    /// <param name="rank">Card rank</param>
    /// <param name="suit">Card suit</param>
    
    public StandardCard(Rank rank, Suit suit)
    {
        
        Rank = rank;
        
        Suit = suit;
        
    }
    
}