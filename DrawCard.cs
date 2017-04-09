using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class DrawCard : Card
    {
        public DrawCard()
        {

        }

        public static void Draw(int x, int y, Card card, bool dealers2ndCard)
        {
            Console.SetCursorPosition(x, y-1);
            Console.Write(" ____________ \n");

            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(x, y + i);
                if (i == 1)
                {
                    Console.SetCursorPosition(x, y + i);
                    if (!dealers2ndCard)
                    {
                        string suit = FormatCard(card.CardSuit);
                        Console.WriteLine("| {0} {1}      |", suit, card.CardRank);
                    }
                    else
                    {
                        Console.WriteLine("| {0} {1}       |", "X", "XX");
                    }
                }
                Console.WriteLine("|            |");
            }
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("|____________|");
        }

        public static string FormatCard(Suit suit)
        {
            string encode = string.Empty;
            switch(suit)
            {
                case Suit.Hearts:
                    encode = "\u2665";
                    break;
                case Suit.Diamonds:
                    encode = "\u2666";
                    break;
                case Suit.Spades:
                    encode = "\u2660";
                    break;
                case Suit.Clubs:
                    encode = "\u2663";
                    break;

            }
            return encode;
        }

        public static void WriteAt(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(s);
        }
    }
}
