using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Game;

namespace CrazyEights.Player;

public class CpuPlayer(string name) : PlayerBase(name)
{
    public override TurnAction TakeTurn(TurnContext context)
    {

        UserInterface.ShowTurn(Name, context.TopCard!, context.ActiveSuit);

        var playableCards = PlayableCards(context.TopCard!, context.ActiveSuit);
        var cardToPlay = playableCards.Count > 0 ? playableCards[0] : null;

        if (cardToPlay != null)
        {

            var playedCard = Play(cardToPlay);
            UserInterface.ShowCardPlayed(Name, playedCard);

            Suit? newSuit = null;
            if (playedCard.Rank == Rank.Eight)
            {
                var suits = Enum.GetValues<Suit>();
                newSuit = suits[new Random().Next(suits.Length)];
                UserInterface.ShowSuitChange(Name, newSuit.Value);

            }

            return new TurnAction(ActionType.PlayCard, newSuit ?? playedCard.Suit, playedCard);

        }
        else
        {
            var drawnCard = context.Deck.Draw();
            if (drawnCard != null)
            {
                Draw(drawnCard);
            }

            UserInterface.ShowCardDrawn(Name, drawnCard, false);
            
            return new TurnAction(ActionType.DrawCard);
        }
    }
}

