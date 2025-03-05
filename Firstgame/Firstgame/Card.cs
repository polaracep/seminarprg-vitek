using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firstgame
{
    internal class Card
    {
        public string cardRank { get; set; }
        public int cardValue { get; set; }
        public string cardSuit { get; set; }

        public Card(string suit, string rank, int value)
        {
            cardSuit = suit;
            cardRank = rank;
            cardValue = value;
        }
        public override string ToString()
        {
            return $"{cardRank} of {cardSuit}";
        }


    }
}
