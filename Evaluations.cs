using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public static class Evaluations
    {
        public static void Result(int playerCardTotal, int dealerCardTotal)
        {
            int blackJack = 21;
            int player = blackJack - playerCardTotal;
            int dealer = blackJack - dealerCardTotal;

            if (player < dealer)
                DrawCard.WriteAt("PLAYER WINS!!", 80, 2);
            else if (dealer < player)
                DrawCard.WriteAt("DEALER WINS!!", 80, 2);
            else if (dealer == player)
                DrawCard.WriteAt("TIE GAME!!", 80, 2);
        }

        public static void BlackJack(int playerCardTotal, int dealerCardTotal)
        {
            if (dealerCardTotal == 21 && playerCardTotal != 21)
                DrawCard.WriteAt("BLACKJACK!! DEALER WINS!!!", 80, 2);
            else if (playerCardTotal == 21 && dealerCardTotal != 21)
                DrawCard.WriteAt("BLACKJACK!! PLAYER WINS!!!", 80, 2);
            else if (playerCardTotal == 21 && dealerCardTotal == 21)
                DrawCard.WriteAt("TIE GAME!! DRAW!!!", 80, 2);

        }

        public static void PlayerBust(int playerCardTotal, int dealerCardTotal)
        {
            if (playerCardTotal > 21)
                DrawCard.WriteAt("PLAYER BUST!! HOUSE WINS!!!", 80, 2);
            else if (playerCardTotal == dealerCardTotal)
                DrawCard.WriteAt("TIE GAME!! DRAW!!!", 80, 2);
        }

        public static void DealerBust(int playerCardTotal, int dealerCardTotal)
        {
            if (dealerCardTotal > 21)
                DrawCard.WriteAt("DEALER BUST!! PLAYER WINS!!!", 80, 2);
            else if (playerCardTotal == dealerCardTotal)
                DrawCard.WriteAt("TIE GAME!! DRAW!!!", 80, 2);
        }
    }
}
