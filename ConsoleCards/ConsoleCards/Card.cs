using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCards
{
    internal class Card
    {
        public enum Suit
        {
            CLUBS,DIAMONDS,HEARTS,SPADES
        }
        public enum Value
        {
            ACE,TWO,THREE,FOUR,FIVE,SIX,SEVEN,EIGHT,NINE,TEN,JACK,QUEEN,KING
        }

        public Suit suit { get; set; }
        public Value value { get; set; }
        public Card(Suit suit, Value value)
        {
            this.suit = suit;
            this.value = value;
        }

        public override string? ToString()
        {
            return value.ToString().ToLower() +" of " + suit.ToString().ToLower();
        }
    }
}
