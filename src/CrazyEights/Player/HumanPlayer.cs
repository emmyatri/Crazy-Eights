using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Game;

namespace CrazyEights.Player;


// Note: Console output is handled directly in player classes for simplicity.
// A more flexible design would inject an IGameDisplay interface (at the cost of complexity)
public class HumanPlayer(string name) : PlayerBase(name)
{
    public override TurnResult TakeTurn(TurnContext context)
    {
        DisplayHand();

        var playable = GetPlayableCards(context.TopCard, context.CurrentSuit);

        if (playable.Count > 0)
        {
            DisplayPlayableCards(playable);
            var selected = CardSelection(playable);
            return PlayCard(selected);
        }

        Console.WriteLine("No playable cards. Drawing from deck...");
        Console.WriteLine();
        return TryDrawAndPlay(context);
    }

    private void DisplayHand()
    {
        Console.WriteLine("==========================");
        Console.WriteLine($"{Name}'s hand: ");
        Console.WriteLine("==========================");
        foreach (var card in Hand) Console.WriteLine($"{card.GetDisplayName()} ");
        Console.WriteLine("==========================");
        Console.WriteLine();
    }

    private void DisplayPlayableCards(IList<ICard> playable)
    {
        Console.WriteLine($"{Name} can play: ");
        for (var i = 0; i < playable.Count; i++) Console.WriteLine($"[{i + 1}] {playable[i].GetDisplayName()} ");
    }

    private ICard CardSelection(List<ICard> playable)
    {
        while (true)
        {
            Console.Write("Choose a card to play: ");

            if (int.TryParse(Console.ReadLine(), out var choice)
                && choice >= 1
                && choice <= playable.Count)
                return playable[choice - 1];
            Console.WriteLine("\nInvalid choice\n");
        }
    }

    private Suit ChooseSuit()
    {
        Console.WriteLine("""

                          Choose new suit:

                          [1] Hearts
                          [2] Diamonds
                          [3] Spades
                          [4] Clubs

                          """);

        while (true)
        {
            Console.Write("Choose Suit: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1": return Suit.Hearts;
                case "2": return Suit.Diamonds;
                case "3": return Suit.Spades;
                case "4": return Suit.Clubs;
                default:
                    Console.WriteLine("\nInvalid option. Try again.\n");
                    break;
            }
        }
    }

    private TurnResult TryDrawAndPlay(TurnContext context)
    {
        var drawn = context.DrawFromDeck();

        if (drawn == null)
        {
            Console.WriteLine("\nDeck is empty. Cannot play.\n");
            return TurnResult.CannotPlay();
        }

        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"{Name} drew: {drawn.GetDisplayName()}");
        Console.WriteLine("----------------------------------------");
        ReceiveCard(drawn);

        if (drawn.Matches(context.TopCard, context.CurrentSuit))
        {
            Console.WriteLine();
            Console.WriteLine($"{drawn.GetDisplayName()} is playable!");
            return PlayDrawnCard(drawn);
        }

        Console.WriteLine();
        Console.WriteLine($"{drawn.GetDisplayName()} is not playable. Turn ends.");
        Console.WriteLine();
        return TurnResult.DrewOnly();
    }

    private TurnResult PlayCard(ICard card)
    {
        RemoveCard(card);
        Console.WriteLine();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"You played {card.GetDisplayName()}");
        Console.WriteLine("----------------------------------------");

        if (!card.Rank.IsEight()) return TurnResult.PlayCard(card);

        var chosenSuit = ChooseSuit();
        Console.WriteLine($"You chose {chosenSuit.GetSymbol()}");
        return TurnResult.PlayWildcard(card, chosenSuit);
    }

    private TurnResult PlayDrawnCard(ICard card)
    {
        RemoveCard(card);
        Console.WriteLine();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"You played {card.GetDisplayName()}");
        Console.WriteLine("----------------------------------------");

        if (!card.Rank.IsEight()) return TurnResult.DrewAndPlayedCard(card);

        var chosenSuit = ChooseSuit();
        Console.WriteLine($"You chose {chosenSuit.GetSymbol()}");
        return TurnResult.DrewAndPlayWildCard(card, chosenSuit);
    }
}