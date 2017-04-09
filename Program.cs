using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static DeckOfCards deck = new DeckOfCards();
        static Hand hand = new Hand();

        static void Main(string[] args)
        {
            //PlaceBet();
            ShowCursor(false);
            DealCards();
            PlayerMove();
            DealerMove();
            Console.ReadLine();
        }

        private static void PlaceBet()
        {
            int bet;
            Console.Write("Place your bet ($1, $5, $25, $100): ");
            bet = Convert.ToInt32(Console.ReadLine());

            while (bet != 5 && bet != 10 && bet != 25 && bet != 100)
            {
                Console.Write("Invalid Entry! Place a valid bet ($1, $5, $25, $100): ");
                bet = Convert.ToInt32(Console.ReadLine());
            }
        }

        private static void DealCards()
        {
            List<Card> playerCards = new List<Card>();
            List<Card> dealerCards = new List<Card>();
      
            for (int i = 0; i < 2; i++)
            {
                dealerCards.Add(deck.Deal());
                playerCards.Add(deck.Deal());
            }

            hand.Player(playerCards);
            hand.Dealer(dealerCards);
        }

        private static void PlayerMove()
        {
            int column = 0;

            DrawCard.WriteAt("HIT (Spacebar), STAND (Enter)", 2, 26);

            ConsoleKeyInfo info = Console.ReadKey();
            while (info.Key == ConsoleKey.Spacebar)
            {
                hand.Hit(deck.Deal(), column, 4);
                info = Console.ReadKey();

                column += 12;
            }
            if (info.Key == ConsoleKey.Enter)
            {
                DrawCard.WriteAt("PLAYER STAND!", 80, 2);
                hand.RevealDownCard();
            }

        }

        private static void DealerMove()
        {
            int column = 0;
            int dealCardTotal = hand.Draw(deck.Deal(), 0, 16);

            while (dealCardTotal < 17)
            {
                hand.Draw(deck.Deal(), 0, 16);
                column += 12;
            }

        }

        private static void ShowCursor(bool show)
        {
            Console.CursorVisible = show;
        }
   
    }
}
