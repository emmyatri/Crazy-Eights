using CrazyEights.Cards;
using CrazyEights.Game;

namespace CrazyEights.Player;

public interface IPlayer
{
    string Name { get; }


    int HandSize { get; }


    bool HasEmptyHand { get; }


    TurnResult TakeTurn(TurnContext context);


    void ReceiveCard(ICard card);
}