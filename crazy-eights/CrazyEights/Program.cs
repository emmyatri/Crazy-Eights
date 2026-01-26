using CrazyEights.Game;

Console.OutputEncoding = System.Text.Encoding.UTF8;


UserInterface.Welcome();
var name = UserInterface.GetPlayerName();

do
{
    var game = new CrazyEightsGame(name);
    game.Start();
} while (UserInterface.PlayAgain());

UserInterface.Goodbye();



