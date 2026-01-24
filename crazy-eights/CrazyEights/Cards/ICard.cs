using CrazyEights.Domain;
namespace CrazyEights.Cards;

/// <summary>
/// Contract: Card must have both suit and rank
/// </summary>


public interface ICard
{
    Suit Suit { get; set; }
    
    Rank Rank { get; set; }
    
}