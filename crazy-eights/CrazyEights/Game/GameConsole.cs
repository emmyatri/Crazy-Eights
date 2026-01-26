namespace CrazyEights.Game;




public static class GameConsole
{
    
    public static void WriteLine (string message = "") => Console.WriteLine(message);
    
    public static void Write (string message) => Console.Write(message);
    
    public static string? ReadLine () => Console.ReadLine();
    
    public static void WriteSeparator (string message = "") => Console.WriteLine("----------------------------------");
    
    public static void WriteBoldSeparator (string message = "") => Console.WriteLine("====================================");
    
    public static void WriteSquigSeparator (string message = "") => Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    
    
}