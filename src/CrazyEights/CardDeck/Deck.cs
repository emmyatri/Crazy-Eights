using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.CardDeck;

public class Deck
{
    private readonly Stack<ICard> _cards;


    private Deck(IEnumerable<ICard> cards)
    {
        _cards = new Stack<ICard>(cards);
    }


    public bool IsEmpty => _cards.Count == 0;


    public int Count => _cards.Count;


    public static Deck ShuffleDeck()
    {
        var cards = CreateDeck();
        Shuffle(cards);
        return new Deck(cards);
    }


    private static List<ICard> CreateDeck()
    {
        var cards = new List<ICard>();

        foreach (var suit in Enum.GetValues<Suit>())
        foreach (var rank in Enum.GetValues<Rank>())
            cards.Add(new StandardCard(rank, suit));

        return cards;
    }


    /// <remarks>
    ///     Used Fisher-Yates Modern Method found at
    ///     https://exceptionnotfound.net/understanding-the-fisher-yates-card-shuffling-algorithm/
    /// </remarks>
    private static void Shuffle(List<ICard> cards)
    {
        var random = new Random();

        for (var n = cards.Count - 1; n > 0; n--)
        {
            var k = random.Next(n + 1);
            (cards[n], cards[k]) = (cards[k], cards[n]);
        }
    }


    public ICard? Draw()
    {
        return _cards.Count > 0 ? _cards.Pop() : null;
    }
}