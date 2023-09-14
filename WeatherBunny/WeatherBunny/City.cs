using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherBunny
{
    internal class City
    {
        public string CityName { get; }
        public string Temperature { get; }

        public City(string cityName, string temperature)
        {
            CityName = cityName;
            Temperature = temperature;
        }

        public override string ToString()
        {
            return CityName + " (" + Temperature + ")";
        }

        public string ToString(int width)
        {
            string outputString = "";
            int space = width - WidthMinimum();
            if(space > 0)
            {
                //YES
                outputString = CityName + Spacing(space) + " (" + Temperature + ")";
            }
            else
            {
                //NO
                outputString = ToString();
            }
            return outputString;
        }

        public int WidthMinimum()
        {
            return CityName.Length + Temperature.Length;
        }
        private string Spacing(int width)
        {
            string outputString = "";
            for(int i = 0; i < width; i++)
            {
                outputString += " ";
            }
            return outputString;
        }
    }
}
