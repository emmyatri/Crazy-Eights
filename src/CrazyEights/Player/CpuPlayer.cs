using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Game;

namespace CrazyEights.Player;


// Note: Console output is handled directly in player classes for simplicity.
// A more flexible design would inject an IGameDisplay interface (at the cost of complexity)
public class CpuPlayer(string name) : PlayerBase(name)
{
    public override TurnResult TakeTurn(TurnContext context)
    {
        var playable = GetPlayableCards(context.TopCard, context.CurrentSuit);
        if (playable.Count > 0)
            return PlayCard(SelectCard(playable));

        return TryDrawAndPlay(context);
    }


    private TurnResult PlayCard(ICard card)
    {
        RemoveCard(card);
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"{Name} played {card.GetDisplayName()}");
        Console.WriteLine("----------------------------------------");

        if (!card.Rank.IsEight()) return TurnResult.PlayCard(card);

        var chosenSuit = SelectSuit();
        Console.WriteLine($"{Name} chose {chosenSuit}{chosenSuit.GetSymbol()}");
        Console.WriteLine("----------------------------------------");
        return TurnResult.PlayWildcard(card, chosenSuit);
    }


    private TurnResult TryDrawAndPlay(TurnContext context)
    {
        var drawn = context.DrawFromDeck();
        if (drawn == null)
            return TurnResult.CannotPlay();

        ReceiveCard(drawn);
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"{Name} drew {drawn.GetDisplayName()}");
        Console.WriteLine("----------------------------------------");

        return drawn.Matches(context.TopCard, context.CurrentSuit)
            ? PlayDrawnCard(drawn)
            : TurnResult.DrewOnly();
    }


    private TurnResult PlayDrawnCard(ICard card)
    {
        RemoveCard(card);
        Console.WriteLine($"{Name} played {card.GetDisplayName()}");
        Console.WriteLine("----------------------------------------");

        return card.Rank.IsEight()
            ? TurnResult.DrewAndPlayWildCard(card, SelectSuit())
            : TurnResult.DrewAndPlayedCard(card);
    }


    private ICard SelectCard(List<ICard> playable)
    {
        return playable[0];
    }


    private Suit SelectSuit()
    {
        if (Hand.Count == 0)
            return Suit.Hearts;

        return Hand
            .GroupBy(card => card.Suit)
            .OrderByDescending(group => group.Count())
            .First()
            .Key;
    }
}