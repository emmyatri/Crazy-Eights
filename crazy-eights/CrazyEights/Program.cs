
using System.Text;
using CrazyEights.Game;
using CrazyEights.Player;

Console.OutputEncoding = Encoding.UTF8;


Console.WriteLine($"========================");
Console.WriteLine($"WELCOOME TO CRAZY EIGHTS");
Console.WriteLine($"========================");

Console.WriteLine();
Console.Write($"Enter your name (of press enter for 'Player'): ");



var input = Console.ReadLine();
string playerName = string.IsNullOrEmpty(input) ? "Player" : input;

bool playAgain = true;

while (playAgain)

{
    var human = new HumanPlayer(playerName);
    var cpu = new CpuPlayer("Qwerty");
    var game = new CrazyEightsGame(human, cpu);

    Console.WriteLine();
    game.Run();


    bool humanWon = game.Winner?.Name == playerName;
    playAgain = PromptPlayAgain(humanWon);
}

Console.WriteLine("\nThanks for playing!");

static bool PromptPlayAgain(bool humanWon)
{
    while (true)
    {
        Console.Write("\nPlay again? (Y/N): ");
        var input = Console.ReadLine()?.ToUpper();

        if (input == "Y") return true;
        if (input == "N") return false;
        {
            if (!humanWon)
                Console.WriteLine("Sore loser...");
        }
        
        Console.WriteLine("Invalid input. Enter Y or N");
    }
}


