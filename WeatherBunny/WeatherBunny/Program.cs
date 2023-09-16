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
        private HashSet<string> _links;
        private Stack<string> _linksStack;

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

        public void StartTest()
        {
            string startURL = "https://www.timeanddate.no";
            string startExt = "/vaer/?continent=europe&low=c";

            _links = new HashSet<string>();
            _linksStack = new Stack<string>();

            _links.Add(startURL+startExt);
            _linksStack.Push(startURL + startExt);
            while(_linksStack.Count > 0)
            {
                List<string> list = new List<string>();
                string nextURL = _linksStack.Pop();
                list = GetLinkList(nextURL, startExt);
                
                foreach(string link in list)
                {
                    if (_links.Add(link))
                    {
                        _linksStack.Push(link);
                    }
                }
            }
            
            foreach(string str in GetLinkList("https://www.timeanddate.no", "/vaer/?continent=europe&low=c"))
            {
                Console.WriteLine(str);
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

        private List<string> GetLinkList(string baseURL, string extension)
        {
            List<string> linkLink = new List<string>();

            HtmlNodeCollection links = GetHtmlNodes(baseURL+extension, "//a");

            foreach(HtmlNode item in links)
            {
                string temp = "";
                if (item.OuterHtml.StartsWith("<a href"))
                {
                    temp = item.OuterHtml.Split("\"")[1];
                    if (temp.StartsWith("/") && temp.Length > 1)
                    {
                        linkLink.Add(baseURL+temp);
                    }
                }
            }

            return linkLink;

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
