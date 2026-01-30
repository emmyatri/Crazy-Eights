using CrazyEights.CardDeck;
using CrazyEights.Domain;
using CrazyEights.Player;

namespace CrazyEights.Game;

public class CrazyEightsGame
{
    private readonly Deck _deck;
    private readonly DiscardPile _discardPile;
    private readonly List<IPlayer> _players;


    public CrazyEightsGame(IPlayer player1, IPlayer player2)
    {
        _players = [player1, player2];
        _deck = Deck.ShuffleDeck();
        DealCards();
        _discardPile = new DiscardPile(_deck.Draw()!);
    }

    public IPlayer? Winner { get; private set; }

    private void DealCards()
    {
        foreach (var player in _players)
            for (var i = 0; i < 5; i++)
                player.ReceiveCard(_deck.Draw()!);
    }

    public void Run()
    {
        var currentPlayerIndex = 0;
        var turnNumber = 1;

        while (!IsGameOver())
        {
            var currentPlayer = _players[currentPlayerIndex];

            DisplayTurnHeader(turnNumber, currentPlayer);

            var context = new TurnContext(
                _discardPile.TopCard,
                _discardPile.CurrentSuit,
                _deck);

            var result = currentPlayer.TakeTurn(context);

            ApplyTurnResult(result);


            if (currentPlayer.HasEmptyHand)
            {
                AnnounceWinner(currentPlayer);
                return;
            }

            currentPlayerIndex = (currentPlayerIndex + 1) % _players.Count;
            turnNumber++;
        }

        DetermineWinnerByCardCount();
    }

    private bool IsGameOver()
    {
        return _players.Any(p => p.HasEmptyHand) || _deck.IsEmpty;
    }

    private void DisplayTurnHeader(int turn, IPlayer currentPlayer)
    {
        Console.WriteLine();
        Console.WriteLine("======================");
        Console.WriteLine($"    Turn {turn}     ");
        Console.WriteLine("======================");
        Console.WriteLine();
        Console.WriteLine($"Top card: {_discardPile.TopCard.GetDisplayName()}");
        Console.WriteLine($"Current Suit: {_discardPile.CurrentSuit}{_discardPile.CurrentSuit.GetSymbol()}");
        Console.WriteLine($"Deck: {_deck.Count} cards.");
        Console.WriteLine(string.Join(" | ",
            _players.Select(p => $"{p.Name}: {p.HandSize} {(p.HandSize == 1 ? "card" : "cards")}")));
        Console.WriteLine();
    }

    private void ApplyTurnResult(TurnResult result)
    {
        if (!result.WasCardPlayed)
            return;

        if (result.Action is TurnAction.PlayedWildCard or TurnAction.DrewAndPlayedWildCard)
            _discardPile.Push(result.PlayedCard!, result.PlayedSuit!.Value);
        else
            _discardPile.Push(result.PlayedCard!);
    }

    private void AnnounceWinner(IPlayer winner)
    {
        Winner = winner;
        Console.WriteLine();
        Console.WriteLine($"*****{Winner.Name.ToUpper()} WINS!*****");
        Console.WriteLine();
    }

    private void DetermineWinnerByCardCount()
    {
        var minCards = _players.Min(p => p.HandSize);
        var playersWithMinCards = _players.Where(p => p.HandSize == minCards).ToList();
        var cardWord = minCards == 1 ? "card" : "cards";
        
        Console.WriteLine();
        Console.WriteLine("Deck is empty!");

        if (playersWithMinCards.Count > 1)
        {
            var tiedName = string.Join(" and ", playersWithMinCards.Select(p => p.Name));
            Console.WriteLine($"It's a tie! {tiedName} each have {minCards} {cardWord}.");
        }
        else
        {
            Winner = playersWithMinCards[0];
            Console.WriteLine($"{Winner.Name} wins with {minCards} {cardWord} in their hand.");
        }
    }
}