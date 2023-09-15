using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextUserInterface
{
    internal class MenuDesigner
    {
        public void MainMenu(List<string> items)
        {
            Console.WriteLine("---------- Main Menu ----------");
            Console.WriteLine("");
            PrintMenuItems(items);
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("(0) - Exit");
            Console.WriteLine("");
            Console.Write("Choose: ");
        }
        public void TechnologyMenu()
        {
            Console.WriteLine("---------- Technology ----------");
            Console.WriteLine("");
            Console.WriteLine("(W) - WeatherBunny");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("(enter) - Main Menu");
            Console.WriteLine("(0) - Exit");
            Console.WriteLine("");
            Console.Write("Choose: ");
        }

        private void PrintMenuItems(List<string> items)
        {
            foreach(string item in items)
            {
                Console.WriteLine(MenuItemCreator(item));
            }
            
        }
        private string MenuItemCreator(string name)
        {
            return "(" + name[0] + ") - " + name;
        }
    }
}
