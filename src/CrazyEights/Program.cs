using System.Text;
using CrazyEights.Game;
using CrazyEights.Player;

Console.OutputEncoding = Encoding.UTF8;


var session = GameSession.Initialize();
session.Run();

