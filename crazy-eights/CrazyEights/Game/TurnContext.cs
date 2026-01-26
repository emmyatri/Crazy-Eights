using CrazyEights.CardDeck;
using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.Game;

public class TurnContext(ICard topCard, Suit? activeSuit, Deck deck)

{

    public ICard TopCard { get; } = topCard;
    public Suit? ActiveSuit { get; } = activeSuit;
    public Deck Deck { get; } = deck;

}
    
    
