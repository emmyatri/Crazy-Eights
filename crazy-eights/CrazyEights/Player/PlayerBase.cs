using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Game;

namespace CrazyEights.Player;



public abstract class PlayerBase(string name) : IPlayer

{

    public string Name { get; } = name;
    
    private readonly List<ICard> _hand = new List<ICard>();
    
    public IReadOnlyList<ICard> Hand => _hand;
    

    public void Draw(ICard card)
    {
        _hand.Add(card);
    }
    
    
    public bool EmptyHand => Hand.Count == 0;

    
    public ICard Play(ICard card)
    {
        _hand.Remove(card);
        return card;
    }
    
    public IReadOnlyList<ICard> PlayableCards(ICard topCard, Suit? activeSuit = null)
    {

        var suitToMatch = activeSuit ?? topCard.Suit;
        
        var playableCard = new List<ICard>();
        
        foreach (var card in Hand)
        {
            if (card.Suit == suitToMatch ||
                card.Rank == topCard.Rank ||
                card.Rank == Rank.Eight)
            {
                playableCard.Add(card);
            }
        }
        return playableCard;
    }
    
    public abstract TurnAction TakeTurn(TurnContext context);
    
    
}