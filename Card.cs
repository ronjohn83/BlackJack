using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        public enum Suit
        {
            Hearts = 1,
            Diamonds,
            Spades,
            Clubs
        }

        public enum Rank
        {
            Two = 2, Three = 3, Four = 4, Five = 5,
            Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10,
            Jack = 10, Queen = 10, King = 10, Ace = 11
        }

        public Suit CardSuit { get; set; }
        public Rank CardRank { get; set; }

    }
}
