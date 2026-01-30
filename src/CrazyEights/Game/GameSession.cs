using CrazyEights.Player;

namespace CrazyEights.Game;

public class GameSession
{
    private readonly string _playerName;

    private GameSession(string playerName) => _playerName = playerName;


    public static GameSession Initialize()
    {
        DisplayWelcome();
        var playerName = PromptForName();
        return new GameSession(playerName);
    }

    public void Run()
    {
        var playAgain = true;

        while (playAgain)
        {
            var game = CreateGame();
            Console.WriteLine();
            game.Run();
            
            var humanWon = game.Winner?.Name == _playerName;
            playAgain = PromptPlayAgain(humanWon);
        }
    }

    private CrazyEightsGame CreateGame()
    {
        var human = new HumanPlayer(_playerName);
        var cpu = new CpuPlayer("Qwerty");
        return new CrazyEightsGame(human, cpu);
    }

    private static void DisplayWelcome()
    {
        Console.WriteLine("========================");
        Console.WriteLine("WELCOME TO CRAZY EIGHTS");
        Console.WriteLine("========================");
        Console.WriteLine();
    }

    private static string PromptForName()
    {
        Console.Write("Enter your name (or press enter for 'Player'): ");
        var input = Console.ReadLine();
        return string.IsNullOrEmpty(input) ? "Player" : input;
    }
    
    
    private static bool PromptPlayAgain(bool humanWon)
    {
        while (true)
        {
            Console.Write("\nPlay again? (Y/N): ");
            var input = Console.ReadLine()?.ToUpper();

            if (input == "Y") return true;
            if (input == "N")
            {
                if (!humanWon)
                    Console.WriteLine("\nSore loser...");
                return false;
            }

            Console.WriteLine("\nInvalid input. Enter Y or N\n");
        }
    }

    private static void DisplayGoodbye()
    {
        Console.WriteLine();
        Console.WriteLine("\nThanks for playing!");
        Console.WriteLine();
    }
    
}