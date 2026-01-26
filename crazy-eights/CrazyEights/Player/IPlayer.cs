using CrazyEights.Cards;
using CrazyEights.Game;

namespace CrazyEights.Player;



public interface IPlayer
{
    
    string Name { get;  }

    IReadOnlyList<ICard> Hand { get; }

    bool EmptyHand =>  Hand.Count == 0;
    
    TurnAction TakeTurn(TurnContext context);

}