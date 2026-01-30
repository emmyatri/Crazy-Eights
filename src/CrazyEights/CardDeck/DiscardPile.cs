using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.CardDeck;

public class DiscardPile(ICard startingCard)
{
    private readonly Stack<ICard> _pile = new([startingCard]);

    public ICard TopCard => _pile.Peek();


    //currentSuit may differ from TopCard.Suit when wildcard {Eight} is played
    public Suit CurrentSuit { get; private set; } = startingCard.Suit;

    public void Push(ICard card)
    {
        _pile.Push(card);
        CurrentSuit = card.Suit;
    }

    public void Push(ICard card, Suit currentSuit)
    {
        _pile.Push(card);
        CurrentSuit = currentSuit;
    }
}