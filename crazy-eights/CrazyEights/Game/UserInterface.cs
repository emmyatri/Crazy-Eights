using CrazyEights.CardDeck;
using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Player;

namespace CrazyEights.Game;

public class UserInterface
{
    public static void Welcome()
    {
        GameConsole.WriteLine("""
                              ====================================
                              Welcome to Crazy Eights (Simplified)
                              ====================================
                              """);
        GameConsole.WriteLine();
    }

    public static string GetPlayerName()
    {
        GameConsole.Write("Enter your name (or pressed Enter for 'Player'): ");
        var name = GameConsole.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            name = "Player";
        }

        GameConsole.WriteLine();
        return name;
    }


    public static void DealDiscard(ICard topCard)
    {
        GameConsole.WriteSeparator();
        GameConsole.WriteLine($"The dealer flips: {topCard}");
        GameConsole.WriteSeparator();
        GameConsole.WriteLine();
    }

    public static void TurnCount(int turnCount, Deck deck, IReadOnlyList<IPlayer> players)
    {
        GameConsole.WriteLine();
        GameConsole.WriteSquigSeparator();
        GameConsole.WriteLine($"Turn {turnCount}");
        GameConsole.WriteLine($"Deck remaining: {deck.Count} cards.");
        
        var playerStatus = new List<String>();
        foreach (var player in players)
        {
            playerStatus.Add($"{player.Name}: {player.Hand.Count}");
        }
        GameConsole.WriteLine(string.Join(" | ", playerStatus));
        GameConsole.WriteSquigSeparator();
    }



    public static void ShowHand(IReadOnlyList<ICard> hand, string playerName)
    {
        GameConsole.WriteSeparator();
        GameConsole.WriteLine();
        GameConsole.Write($"{playerName}'s hand: ");
        GameConsole.WriteLine();
        GameConsole.WriteLine();
        foreach (var card in hand)
        {
            GameConsole.WriteLine($"{card}");
        }

        GameConsole.WriteLine();
        GameConsole.WriteSeparator();
        GameConsole.WriteLine();
    }

    public static void ShowCardPlayed(string playerName, ICard card)
    {
        GameConsole.WriteLine();
        GameConsole.WriteSeparator();
        GameConsole.WriteLine($"{playerName} played {card}");
        GameConsole.WriteSeparator();
    }

    public static void ShowCardDrawn(string playerName, ICard? card, bool isHuman)
    {
        var message = isHuman
            ? $"No playable cards. {playerName} drew {card}"
            : $"No playable cards. {playerName} drew a card";

        GameConsole.WriteLine(message);
    }

    public static void ShowTurn(string playerName, ICard topCard, Suit? activeSuit = null)
    {

        GameConsole.WriteLine();
        GameConsole.WriteBoldSeparator();
        GameConsole.WriteLine($"**{playerName}'s turn!**");
        GameConsole.WriteBoldSeparator();
        GameConsole.WriteLine();
        GameConsole.WriteLine($"Top card: {topCard}");



        if (topCard.Rank == Rank.Eight && activeSuit.HasValue)
        {
            GameConsole.WriteLine($"Active suit: {activeSuit.Value}");
        }
    }

    public static void ShowPlayableCards(IReadOnlyList<ICard> playableCards)
    {

        GameConsole.WriteLine($"You can play: ");
        GameConsole.WriteLine();
        for (int i = 0; i < playableCards.Count; i++)
        {
            GameConsole.WriteLine($"[{i + 1}]  {playableCards[i]}");

        }

        GameConsole.WriteLine();
    }

    public static int GetCardChoice(int maxChoice)
    {
        while (true)
        {
            GameConsole.Write($"Enter card number: ");
            var input = GameConsole.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= maxChoice)
            {
                return choice - 1;
            }

            GameConsole.WriteLine($"Invalid choice. Enter a number between 1 and {maxChoice}");
        }
    }

    public static Suit ChooseSuit()
    {
        while (true)
        {
            GameConsole.Write($"Choose a suit: ");
            GameConsole.WriteLine($"""

                                   ===============
                                   [1] Hearts   
                                   [2] Diamonds 
                                   [3] Spades   
                                   [4] Clubs    
                                   ===============

                                   """);
            GameConsole.Write("Enter your choice of suit: ");
            var input = GameConsole.ReadLine();

            switch (input)
            {
                case "1": return Suit.Hearts;
                case "2": return Suit.Diamonds;
                case "3": return Suit.Spades;
                case "4": return Suit.Clubs;
                default:
                    GameConsole.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    public static void ShowSuitChange(string playerName, Suit suit)
    {
        GameConsole.WriteLine();
        GameConsole.WriteSeparator();
        GameConsole.WriteLine($"{playerName} changed suit to: {suit}");
        GameConsole.WriteSeparator();
    }

    public static void ShowTie()
    {
        GameConsole.WriteSeparator();
        GameConsole.WriteLine("It's a tie!");
    }

    public static void ShowWinner(string playerName)
    {
        GameConsole.WriteLine();
        GameConsole.WriteLine($"{playerName} wins!");
        GameConsole.WriteLine();
    }

    public static bool PlayAgain()
    {
        GameConsole.WriteLine();
        GameConsole.Write($"Play againt? (y/n): ");
        var input = GameConsole.ReadLine();

        return input?.ToLower() == "y";
    }

    public static void Goodbye()
    {
        GameConsole.WriteLine();
        GameConsole.WriteLine("Thanks for playing!");
    }
}