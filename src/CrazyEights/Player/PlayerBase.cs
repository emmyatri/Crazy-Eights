using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Game;

namespace CrazyEights.Player;

public abstract class PlayerBase(string name) : IPlayer
{
    private readonly List<ICard> _hand = [];

    protected IReadOnlyList<ICard> Hand => _hand;

    public string Name { get; } = name;

    public int HandSize => _hand.Count;

    public bool HasEmptyHand => _hand.Count == 0;

    public void ReceiveCard(ICard card)
    {
        _hand.Add(card);
    }

    public abstract TurnResult TakeTurn(TurnContext context);

    protected List<ICard> GetPlayableCards(ICard topCard, Suit currentSuit)
    {
        List<ICard> playable = [];
        foreach (var card in _hand)
            if (card.Matches(topCard, currentSuit))
                playable.Add(card);

        return playable;
    }

    protected ICard RemoveCard(ICard card)
    {
        _hand.Remove(card);
        return card;
    }
}