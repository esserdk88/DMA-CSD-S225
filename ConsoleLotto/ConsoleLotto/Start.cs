using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLotto
{
    internal class Start
    {
        public static void Main(string[] args)
        {
            LottoGame lg = new LottoGame(1, 36, 7, 5000000,10,16);
            List<LottoRow> list = new List<LottoRow>();

            lg.printStatistics();

            //for(int i = 0; i < 100; i++)
            //{
            //    list.Add(new LottoRow(7));
            //}
            //Console.WriteLine(lg._WinningRow);
            //Console.WriteLine();
            //foreach(LottoRow row in list)
            //{
            //    Console.WriteLine(row.ToString() + " : " + lg.CheckRow(row));

            //}
        }
    }
}
