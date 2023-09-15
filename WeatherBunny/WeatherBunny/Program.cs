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
        private List<City> _cityList;

        public Program()
        {
            _cityList = GetCityList();
        }

        public void StartAlt()
        {
            Console.WriteLine("Hi, I will be your weatherbunny today");
            foreach (City city in _cityList)
            {
                Console.WriteLine(city.ToString(16));
            }
            Console.ReadLine();
        }

        private List<City> GetCityList()
        {
            List<City> cityList = new List<City>();

            
            string url = "https://www.timeanddate.no/vaer/?continent=europe&low=c";
            HtmlNodeCollection cities = GetHtmlNodes(url, "//td");
            for (int index = 0; index < cities.Count; index += 4)
            {
                string temperature = cities[index + 3].InnerText;
                int posAmbersand = temperature.IndexOf('&');
                cityList.Add(new City(StringCleaner(cities[index].InnerText), cities[index + 3].InnerText.Remove(posAmbersand, 6)));
            }

            return cityList;

        }

        private HtmlNodeCollection GetHtmlNodes(string url,string xpath)
        {
            var web = new HtmlWeb();
            var dom = web.Load(url);
            var nodes = dom.DocumentNode.SelectNodes(xpath);
            return nodes;
        }

        private string StringCleaner(string text)
        {
            return text.Split(" ")[0];
        }
    }
}
