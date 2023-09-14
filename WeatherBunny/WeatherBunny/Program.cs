using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace WeatherBunny
{
    public class Program
    {
        List<City> _cityList;

        public Program()
        {
            _cityList = GetCityList();
        }
        public static void Start()
        {
            Console.WriteLine("Hi, I will be your weatherbunny today");
            var url = "https://www.timeanddate.no/vaer/?continent=europe&low=c";
            var web = new HtmlWeb();
            var dom = web.Load(url);
            var cities = dom.DocumentNode.SelectNodes("//td");
            Console.WriteLine("Hi, I will be your weatherbunny today");
            for (int index = 0; index < cities.Count; index += 4)
            {
                string temperature = cities[index + 3].InnerText;
                int posAmbersand = temperature.IndexOf('&');
                Console.WriteLine(cities[index].InnerText + "   " + cities[index + 3].InnerText.Remove(posAmbersand, 6));
            }
            Console.ReadLine();

        }

        public void StartAlt()
        {
            foreach(City city in _cityList)
            {
                Console.WriteLine(city.ToString(16));
            }
            Console.ReadLine();
        }

        private List<City> GetCityList()
        {
            var cityList = new List<City>();

            Console.WriteLine("Hi, I will be your weatherbunny today");
            var url = "https://www.timeanddate.no/vaer/?continent=europe&low=c";
            var web = new HtmlWeb();
            var dom = web.Load(url);
            var cities = dom.DocumentNode.SelectNodes("//td");
            for (int index = 0; index < cities.Count; index += 4)
            {
                string temperature = cities[index + 3].InnerText;
                int posAmbersand = temperature.IndexOf('&');
                cityList.Add(new City(StringCleaner(cities[index].InnerText), cities[index + 3].InnerText.Remove(posAmbersand, 6)));
            }

            return cityList;

        }

        private string StringCleaner(string text)
        {
            return text.Split(" ")[0];
        }
    }
}
