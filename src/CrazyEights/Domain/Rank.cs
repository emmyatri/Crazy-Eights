namespace CrazyEights.Domain;

public enum Rank
{
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}

public static class RankExtensions
{
    public static bool IsEight(this Rank rank)
    {
        return rank == Rank.Eight;
    }
}