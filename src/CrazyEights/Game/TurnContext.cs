using CrazyEights.CardDeck;
using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.Game;


// Provides limited game state to players, hiding direct access to game internals
public class TurnContext(ICard topCard, Suit currentSuit, Deck deck)

{
    public ICard TopCard { get; } = topCard;


    public Suit CurrentSuit { get; } = currentSuit;


    public bool IsDeckEmpty => deck.IsEmpty;


    public ICard? DrawFromDeck()
    {
        return deck.Draw();
    }
}