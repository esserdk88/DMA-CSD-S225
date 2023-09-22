using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCards
{
    internal class Start
    {
        public static void Main(string[] args)
        {
            Deck deck = new Deck();

            Console.WriteLine(deck);
            for(int i = 0; i < 55; i++)
            {
                try
                {
                    deck.drawCard();
                }
                catch (NullReferenceException e) 
                { 
                    Console.WriteLine(e.Message); 
                }
                
            }
            Console.WriteLine(deck.Drawpile.Count());
        }
    }
}
