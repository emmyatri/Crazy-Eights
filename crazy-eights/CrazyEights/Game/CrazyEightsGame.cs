using CrazyEights.CardDeck;
using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Player;

namespace CrazyEights.Game;

public class CrazyEightsGame
{
    private readonly GameContext _context;
    private int _turnCount = 0;
    
    
    public CrazyEightsGame(string humanName)
    {
        _context = CrazyEightsInit.CreateGame(humanName);
    }
    
    public void Start()
    {
        
        UserInterface.DealDiscard(_context.Discard.TopCard!);
        _context.ActiveSuit = _context.Discard.TopCard!.Suit;

        if (_context.Discard.TopCard!.Rank == Rank.Eight)
        {
            _context.ActiveSuit = UserInterface.ChooseSuit();
        }

        while (!IsGameOver())
        {

            foreach (var player in _context.Players)
            {
                if (IsGameOver()) break;

                _turnCount++;
                
                UserInterface.TurnCount(_turnCount, _context.Deck, _context.Players);

                var turnContext = new TurnContext(
                    _context.Discard.TopCard!,
                    _context.ActiveSuit,
                    _context.Deck);

                var action = player.TakeTurn(turnContext);

                if (action.Type == ActionType.PlayCard && action.Card != null)
                {
                    _context.Discard.Add(action.Card);
                    _context.ActiveSuit = action.ActiveSuit;
                }
            }
        }

        AnnounceWinner();
    }

    private bool IsGameOver()
    {
        foreach (var player in _context.Players)
        {
            if (player.EmptyHand) return true;
        }

        return _context.Deck.Count == 0;
    }

    private void AnnounceWinner()
    {

        var emptyHandPlayer = _context.Players.FirstOrDefault(p => p.EmptyHand);
        if (emptyHandPlayer != null)
        {
            UserInterface.ShowWinner(emptyHandPlayer.Name);
            return;
        }

        var minCard = _context.Players.Min(p => p.Hand.Count);
        var winner = _context.Players.Where(p => p.Hand.Count == minCard).ToList();
        if (winner.Count > 1)
        {
            UserInterface.ShowTie();
        }
        else
        {
            UserInterface.ShowWinner(winner[0].Name);
        }
    }
    


}