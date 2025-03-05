using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Firstgame
{
    internal class player
    {
        public string name { get; set; }
        public int balance { get; set; }
        public List<Card> hand { get; private set; }
        public bool currentlyPlaying { get; set; }

        public player(string name, int initialbalance = 777)
        {
            name = name;
            balance = initialbalance;
            hand = new List<Card>();
            currentlyPlaying = false;
        }
        public void StopPlaying()
        {
            currentlyPlaying = false;
        }


        public void ReceiveCard(Card card)
        {
            hand.Add(card);
        }
        public void Resethand()
        {
            hand.Clear();
        }
        public void Showhand()
        {
            Console.WriteLine($"{name}'s hand:");
            foreach (var card in hand)
            {
                Console.WriteLine(card);
            }
        }
        public int CalculatehandValueBlackjack()
        {
            int totalValue = 0;
            int aceCount = 0;

            foreach (var card in hand)
            {
                totalValue += card.cardValue;
                if (card.cardRank == "A") aceCount++;
            }
            while (totalValue > 21 && aceCount > 0)
            {
                totalValue -= 10;
                aceCount--;
            }

            return totalValue;
        }
        public bool PlaceBet(int betAmount)
        {
            if (betAmount <= balance)
            {
                balance -= betAmount;
                return true;
            }
            else
            {
                Console.WriteLine("You don't have enough money to place that bet.");
                return false;
            }
        }
        public void gettingMoneyAfterAWin(int moneyWon)
        {
            balance += moneyWon;
        }
        public bool HasReachedWinCon()
        {
            return balance >= 21777;
        }
        public bool Lost()
        {
            return balance <= 0;
        }
        public void Showbalance()
        {
            Console.WriteLine($"{name}'s balance: {balance}");
        }


    }
}
