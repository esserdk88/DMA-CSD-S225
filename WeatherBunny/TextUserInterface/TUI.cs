using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherBunny;

namespace TextUserInterface
{
    internal class TUI
    {
        public static void Main(string[] args)
        {
            //Start of the TUI
            State _currentState = State.MAINMENU;

            while(_currentState != State.EXIT)
            {
                State nextState = State.MAINMENU; //MainMenu
                switch (_currentState)
                {
                    case State.MAINMENU:
                        nextState = MainMenu();
                        break;

                    case State.TECHNOLOGY:
                        nextState = TechnologyMenu();
                        break;

                    case State.WEATHERBUNNY:
                        nextState = State.TECHNOLOGY;
                        //Run Weather Bunny
                        Console.Clear();
                        //WeatherBunny.Program.Start();
                        WeatherBunny.Program WBprogram = new WeatherBunny.Program();
                        WBprogram.StartAlt();

                        break;

                    //More cases can be added here

                    default: 
                        nextState = State.MAINMENU; 
                        break;

                        
                }
                _currentState = nextState;
            }
            Console.Clear();
            Console.WriteLine("The program will now exit. press enter to close");
        }

        private static State TechnologyMenu()
        {
            Console.Clear();
            State outputState = State.MAINMENU;
            Console.WriteLine("---------- Technology ----------");
            Console.WriteLine("");
            Console.WriteLine("(W) - WeatherBunny");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("(enter) - Main Menu");
            Console.WriteLine("(0) - Exit");
            Console.WriteLine("");
            Console.Write("Choose: ");
            char key = Console.ReadKey().KeyChar;

            switch (key)
            {
                case 'w':
                    outputState = State.WEATHERBUNNY;
                    break;
                case '0':
                    outputState = State.EXIT;
                    break;
            }

            return outputState;
        }

        private static State MainMenu()
        {
            Console.Clear();
            State outputState = State.MAINMENU;
            Console.WriteLine("---------- Main Menu ----------");
            Console.WriteLine("");
            Console.WriteLine("(T) - Technology");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("(0) - Exit");
            Console.WriteLine("");
            Console.Write("Choose: ");
            char key = Console.ReadKey().KeyChar;

            switch (key)
            {
                case 't':
                    outputState = State.TECHNOLOGY;
                    break;
                case '0':
                    outputState = State.EXIT;
                    break;
            }

            return outputState;
        }
    }
}
