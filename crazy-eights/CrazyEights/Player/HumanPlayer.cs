using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Game;

namespace CrazyEights.Player;

public class HumanPlayer(string name) : PlayerBase(name)
{
    
    public override TurnAction TakeTurn(TurnContext context)
    {
    
        UserInterface.ShowTurn(Name, context.TopCard, context.ActiveSuit);
        UserInterface.ShowHand(Hand, Name);
        
        var playableCards = PlayableCards(context.TopCard, context.ActiveSuit);
        if (playableCards.Count > 0){
            
            UserInterface.ShowPlayableCards(playableCards);
            var choice = UserInterface.GetCardChoice(playableCards.Count);
            
            var cardToPlay = playableCards[choice];
            var playedCard = Play(cardToPlay);
            
            UserInterface.ShowCardPlayed(Name, playedCard);

            Suit? newSuit = null;
            if (playedCard.Rank == Rank.Eight)
            {
                newSuit = UserInterface.ChooseSuit();
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
            UserInterface.ShowCardDrawn(Name, drawnCard, true);

            return new TurnAction(ActionType.DrawCard);
        }
        
    }
    
}