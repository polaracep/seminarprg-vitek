using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firstgame
{
    internal class Deck
    {
        public List<Card> deckOfCards = new List<Card>();
        public static rng = new Random();

        public Deck()
        {
            deckOfCards = new List<Card>();
            InitializeDeck();
        }
        private void InitializeDeck()


        {
            string[] cardSuits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] cardRanks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            Dictionary<string, int> rankValues = new Dictionary<string, int>
        {
            { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 }, { "7", 7 },
            { "8", 8 }, { "9", 9 }, { "10", 10 }, { "J", 10 }, { "Q", 10 }, { "K", 10 }, { "A", 11 }
        };

            foreach (int suit in suits)
            {
                foreach (int rank in ranks)
                {
                    deckOfCards.Add(new Card(suit, rank, rankValues[rank]));
                }
            }
        }
        public void Shuffle()
        {
            int n = deckOfCards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = deckOfCards[k];
                deckOfCards[k] = deckOfCards[n];
                deckOfCards[n] = value;
            }
        }
        public Card Draw()
        {
            
            if (deckOfCards.Count == 0)
            {
                Console.WriteLine("deck is empty");
                break;
            }

            Card card = deckOfCards[0];
            deckOfCards.RemoveAt(0);
            return card;
        }
        public void ResetDeck()
        {
            deckOfCards.Clear();
            InitializeDeck();
            Shuffle();
        }
        public override string ToString()
        {
            return string.Join(", ", deckOfCards);
        }
    }
}
