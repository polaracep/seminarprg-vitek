using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firstgame
{
    internal class blackjack
    {
        private Deck deckOfCards;
        private player player;
        private List<Card> dealerHand;

        public blackjack(player player1)
        {
            deckOfCards = new Deck();
            deckOfCards.Shuffle();
            player = player1;
            dealerHand = new List<Card>();
        }
        public void DealInitialCards()
        {
            player.ReceiveCard(deckOfCards.Draw());
            player.ReceiveCard(deckOfCards.Draw());
            dealerHand.Add(deckOfCards.Draw());
            dealerHand.Add(deckOfCards.Draw());
        }
        public void ShowCards()
        {
            player.Showhand();
            Console.WriteLine("Dealer's hand:");
            Console.WriteLine(dealerHand[0]);
            Console.WriteLine("[Hidden Card]");
        }
        public void PlayerHit()
        {
            player.ReceiveCard(deckOfCards.Draw());
            player.Showhand();
        }
        public void PlayerStand()
        {
            Console.WriteLine("Player stands.");
        }
        public void DealerTurn()
        {
            int dealerHandValue = CalculateHandValueBlackjack(dealerHand);
            while (dealerHandValue < 17)
            {
                dealerHand.Add(deckOfCards.Draw());
                dealerHandValue = CalculateHandValueBlackjack(dealerHand);
            }

            Console.WriteLine("Dealer's hand:");
            foreach (var card in dealerHand)
            {
                Console.WriteLine(card);
            }
        }
        private int CalculateHandValueBlackjack(List<Card> hand)
        {
            int totalValue = 0;
            int aceCount = 0;

            foreach (var card in hand)
            {
                totalValue += card.cardValue;
                if (card.cardSuit == "A") aceCount++;
            }
            while (totalValue > 21 && aceCount > 0)
            {
                totalValue -= 10;
                aceCount--;
            }

            return totalValue;
        }
        public void DeterminewhoWon()
        {
            int playerHandValue = 0;
            int dealerHandValue = 0;
            playerHandValue = player.CalculatehandValueBlackjack();
            dealerHandValue = CalculateHandValueBlackjack(dealerHand);

            Console.WriteLine($"Player hand value: {playerHandValue}");
            Console.WriteLine($"Dealer hand value: {dealerHandValue}");

            if (playerHandValue > 21)
            {
                Console.WriteLine("Player busts");
            }
            else if (dealerHandValue > 21)
            {
                Console.WriteLine("Dealer busts");
            }
            else if (playerHandValue > dealerHandValue)
            {
                Console.WriteLine("Player wins");
            }
            else if (playerHandValue < dealerHandValue)
            {
                Console.WriteLine("Dealer wins");
            }
            else
            {
                Console.WriteLine("draw");
            }
        }

        public bool PlaceBet(int amount)
        {
            return player.PlaceBet(amount);
        }
        public void GiveWinnings(int amount)
        {
            player.gettingMoneyAfterAWin(amount);
        }
    }
}
