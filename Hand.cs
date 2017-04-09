using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Hand
    {
        int playerCardtotal = 0;
        int dealerCardTotal;
        int firstCardTotal;
        int player = 1;
        int dealer = 2;
        Card downCard;

        public Hand()
        {

        }

        public void Player(List<Card> cards)
        {
            int index = 0;
            int column = 1;

            foreach(Card c in cards)
            {
                playerCardtotal += (int)Enum.Parse(typeof(Card.Rank), Enum.GetName(typeof(Card.Rank), c.CardRank));
                DrawCard.Draw(column == 1 ? 2 : column, 4, cards[index], false);

                index++;
                column *= 14;
            }

            string dealer = string.Format("PLAYER's HAND ({0}):", playerCardtotal);
            DrawCard.WriteAt(dealer, 2, 2);

            //Check if player had a blackjack.
            //Evaluations.BlackJack(playerCardtotal, dealerCardTotal);
            //if (playerCardtotal == 21)
            //    RevealDownCard();

            //Check if player bust.
            Evaluations.PlayerBust(playerCardtotal, dealerCardTotal);
        }

        public void Dealer(List<Card> cards)
        {
           
            int index = 0;
            int column = 1;
            
            foreach (Card c in cards)
            {
                //Check if second card.
                if (index == 1)
                    DrawCard.Draw(column, 16, cards[index], true);
                else
                {
                    //Get first card total only.
                    firstCardTotal += (int)Enum.Parse(typeof(Card.Rank), Enum.GetName(typeof(Card.Rank), c.CardRank));

                    //Ternary operator align column to 0 because initial value must be 1 in order to multiply by 12.
                    DrawCard.Draw(column == 1 ? 2: column, 16, cards[index], false);
                }

                //Dealer's down card.
                downCard = cards[1];
                index++;
                column *= 14;
            }

            string dealer = string.Format("DEALER's HAND ({0}):", firstCardTotal);
            DrawCard.WriteAt(dealer, 2, 14);

            //Check if dealer bust.
            Evaluations.DealerBust(playerCardtotal, dealerCardTotal);
        }

        public void Hit(Card card, int newColumn, int row)
        {
            AddCard(card, newColumn, row, player);

            string playerTotal = string.Format("PLAYER's HAND ({0}):", playerCardtotal);
            DrawCard.WriteAt(playerTotal, 2, 2);

            //Check if player bust.
            Evaluations.PlayerBust(playerCardtotal, dealerCardTotal);
            //Check if blackjack.
            Evaluations.BlackJack(playerCardtotal, dealerCardTotal);
        }

        public int Draw(Card card, int newColumn, int row)
        { 
            if (dealerCardTotal <= 16)
            {
                AddCard(card, newColumn, row, dealer);

                string dealerTotal = string.Format("DEALER's HAND ({0}):", dealerCardTotal);
                DrawCard.WriteAt(dealerTotal, 2, 14);

                //Check if dealer bust.
                Evaluations.DealerBust(playerCardtotal, dealerCardTotal);
                //Check if blackjack.
                Evaluations.BlackJack(playerCardtotal, dealerCardTotal);
            }
            else if (dealerCardTotal >= 17)
            {
                DrawCard.WriteAt("DEALER STAND's!", 80, 2);

                Evaluations.Result(playerCardtotal, dealerCardTotal);
                //Check if dealer bust.
                Evaluations.DealerBust(playerCardtotal, dealerCardTotal);
                //Check if blackjack.
                Evaluations.BlackJack(playerCardtotal, dealerCardTotal);
            }

            return dealerCardTotal;
        }

        public void DealerCardTotal(List<Card> cards)
        {
            int total = 0;
            foreach (Card c in cards)
            {
                total += (int)Enum.Parse(typeof(Card.Rank), Enum.GetName(typeof(Card.Rank), c.CardRank));
            }

            string dealer = string.Format("DEALER's HAND ({0}):", total);
            DrawCard.WriteAt(dealer, 2, 14);
        }

        public void RevealDownCard()
        {
            string suit = DrawCard.FormatCard(downCard.CardSuit);
            string cardValue = string.Format("{0} {1}", suit, downCard.CardRank);
            int downCardValue = (int)Enum.Parse(typeof(Card.Rank), Enum.GetName(typeof(Card.Rank), downCard.CardRank));

            dealerCardTotal = firstCardTotal + downCardValue;

            string dealer = string.Format("DEALER's HAND ({0}):", dealerCardTotal);
            DrawCard.WriteAt(dealer, 2, 14);
            DrawCard.WriteAt(cardValue, 16, 17);

            //Check if dealer had a blackjack.
            Evaluations.BlackJack(playerCardtotal, dealerCardTotal);
        }

        private void AddCard(Card card, int newColumn, int row, int actor)
        {
            int column = 26;
            if (actor == player)
            {
                playerCardtotal += (int)Enum.Parse(typeof(Card.Rank), Enum.GetName(typeof(Card.Rank), card.CardRank));
            }
            else if (actor == dealer)
            {
                dealerCardTotal += (int)Enum.Parse(typeof(Card.Rank), Enum.GetName(typeof(Card.Rank), card.CardRank));
            }
            DrawCard.Draw(column + newColumn, row, card, false);
        }


    }
}
