using CrazyEights.CardDeck;
using CrazyEights.Domain;
using CrazyEights.Player;

namespace CrazyEights.Game;

public class GameContext
{
    public Deck Deck { get;  }
    public DiscardPile Discard { get;  }
    public IReadOnlyList<IPlayer> Players { get;  }
    public Suit? ActiveSuit { get; set; }
    public int TurnCount { get; set; } = 0;


    public GameContext(Deck deck, DiscardPile discard, IReadOnlyList<IPlayer> players, Suit? activeSuit)
    {
        Deck = deck;
        Discard = discard;
        Players = players;
        ActiveSuit = activeSuit;
    }
}