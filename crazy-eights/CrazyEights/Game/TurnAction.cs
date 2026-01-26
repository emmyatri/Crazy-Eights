using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.Game;

public class TurnAction(ActionType type, Suit? activeSuit = null, ICard? card = null)

{
        
        public ActionType Type { get; } = type;
        public ICard? Card { get;  } = card;
        public Suit? ActiveSuit { get; } = activeSuit;
        
}


        