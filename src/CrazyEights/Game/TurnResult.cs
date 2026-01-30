using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.Game;

public class TurnResult(TurnAction action, ICard? playedCard = null, Suit? playedSuit = null)
{
    public TurnAction Action { get; } = action;


    public ICard? PlayedCard { get; } = playedCard;


    public Suit? PlayedSuit { get; } = playedSuit;


    public bool WasCardPlayed => Action is
        TurnAction.PlayedCard or
        TurnAction.PlayedWildCard or
        TurnAction.DrewAndPlayedCard or
        TurnAction.DrewAndPlayedWildCard;


    public static TurnResult PlayCard(ICard card)
    {
        return new TurnResult(TurnAction.PlayedCard, card, card.Suit);
    }


    public static TurnResult PlayWildcard(ICard card, Suit suit)
    {
        return new TurnResult(TurnAction.PlayedWildCard, card, suit);
    }


    public static TurnResult DrewAndPlayedCard(ICard card)
    {
        return new TurnResult(TurnAction.DrewAndPlayedCard, card, card.Suit);
    }


    public static TurnResult DrewAndPlayWildCard(ICard card, Suit playedSuit)
    {
        return new TurnResult(TurnAction.DrewAndPlayedWildCard, card, playedSuit);
    }


    public static TurnResult DrewOnly()
    {
        return new TurnResult(TurnAction.DrewOnly);
    }


    public static TurnResult CannotPlay()
    {
        return new TurnResult(TurnAction.CannotPlay);
    }
}