using CrazyEights.CardDeck;
using CrazyEights.Cards;
using CrazyEights.Player;

namespace CrazyEights.Game;

internal static class CrazyEightsInit
{

    private const int StartingHand = 5;
    
    
    internal static GameContext CreateGame(string humanName)
    {
        
        var deck = new Deck();
        deck.Shuffle();
        
        
        var discard = new DiscardPile();
        
        
        var human = new HumanPlayer(humanName);
        var cpu = new CpuPlayer("Qwerty");
        
        var players = new List<IPlayer> {human, cpu};
        

        for (int i = 0; i < StartingHand; i++)
        {
            
            human.Draw(deck.Draw()!);
            cpu.Draw(deck.Draw()!);
            
        }
        

        discard.Add(deck.Draw()!);

        return new GameContext(deck, discard, players, null);
    }

}