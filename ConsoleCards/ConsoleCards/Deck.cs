using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCards
{
    internal class Deck
    {
        public enum ShuffleOptions { ALL, DRAWPILE, DISCARDPILE}

        public List<Card> Drawpile = new List<Card>();
        public List<Card> Discardpile = new List<Card>();

        public Deck()
        {
            foreach (Card.Suit suit in Enum.GetValues<Card.Suit>())
            {
                foreach (Card.Value value in Enum.GetValues<Card.Value>())
                {
                    Drawpile.Add(new Card(suit, value));
                }
            }
            shuffle(ShuffleOptions.ALL);
        }

        public void shuffle(ShuffleOptions shuffleOptions)
        {
            List<Card> inputCards = new List<Card>();
            List<Card> outputCards = new List<Card>();
            Random random = new Random();

            //Add cards together
            if(ShuffleOptions.DRAWPILE == shuffleOptions || ShuffleOptions.ALL == shuffleOptions)
            {
                inputCards.AddRange(Drawpile);
            }
            if (ShuffleOptions.DISCARDPILE == shuffleOptions || ShuffleOptions.ALL == shuffleOptions)
            {
                inputCards.AddRange(Discardpile);
            }

            //Shuffle loop
            while(inputCards.Count > 0)
            {
                int randomIndex = random.Next(inputCards.Count);
                outputCards.Add(inputCards[randomIndex]);
                inputCards.RemoveAt(randomIndex);
            }

            Drawpile = new List<Card>(outputCards);
        }
        public Card drawCard()
        {
            Card outputCard = null;
            if(Drawpile.Count > 0)
            {
                //Mark card for output
                outputCard = Drawpile[0];
                //Add the card to discardpile
                Discardpile.Add(outputCard);
                //Remove the card from drawpile
                Drawpile.RemoveAt(0);
            }
            else
            {
                throw new NullReferenceException("No Cards in drawpile");
            }
            return outputCard;
        }

        public override string? ToString()
        {
            string output = "";
            foreach (Card card in Drawpile)
            {
                output += card.ToString() + "\n";
            }
            foreach (Card card in Discardpile)
            {
                output += card.ToString() + "\n";
            }
            return output;
        }
    }
}
