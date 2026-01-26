using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.CardDeck;


public class Deck
{
    private Stack<ICard> _cards = new Stack<ICard>();


    public Deck()
    {

        foreach (var suit in Enum.GetValues<Suit>())
        {
            foreach (var rank in Enum.GetValues<Rank>())
            {
               var card = new StandardCard(rank, suit);
               _cards.Push(card);
            }
        }
    }


    public void Shuffle()
    {
        List<ICard> list = _cards.ToList();
        
        var random =  new Random();

        for (int n = list.Count - 1; n > 0; n--)
        {
            var k =  random.Next(n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }
        _cards = new Stack<ICard>(list);
    }
    
    
    public int Count => _cards.Count;
    
    
    public ICard? Draw() => Count > 0 ?  _cards.Pop() : null;

}