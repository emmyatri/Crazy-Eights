using CrazyEights.Cards;

namespace CrazyEights.CardDeck;

public class DiscardPile
{
    
    private readonly Stack<ICard> _discardStack = new Stack<ICard>();

    public void Add(ICard card)
    {
        _discardStack.Push(card);
    }

    public ICard? TopCard => (_discardStack.Count > 0) ? _discardStack.Peek() : null;

}