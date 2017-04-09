using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackJack
{
    class DeckOfCards : Card
    {
        const int NUM_Of_Cards = 52;
        private Card[] deck;
        List<int> randomNumList = new List<int>();

        public DeckOfCards()
        {
            deck = new Card[NUM_Of_Cards];
            CreateDeck();
        }

        public void CreateDeck()
        {
            int i = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                {
                    deck[i] = new Card { CardSuit = s, CardRank = r };
                    i++;
                }
            }
            DeckList();
        }

        public void Shuffle()
        {
            Random random = new Random();
            Card temp;

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < NUM_Of_Cards; j++)
                {
                    int secondCardIndex = random.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secondCardIndex];
                    deck[secondCardIndex] = temp;
                }
            }
        }

        private void DeckList()
        {
            //Select random card from deck then remove card
            //from deck to guarantee unique card with request.
            Random random = new Random();
            while (randomNumList.Count < 52)
            {
                int number = random.Next(1, 53);
                if (!randomNumList.Contains(number))
                    randomNumList.Add(number);
            }
        }

        public Card Deal()
        {
            int element = randomNumList.ElementAt(0);
            Card card = deck[element];
            randomNumList.Remove(element);

            return card;
        }
    }
}
