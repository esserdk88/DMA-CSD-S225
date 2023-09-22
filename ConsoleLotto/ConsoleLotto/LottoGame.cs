using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleLotto
{
    internal class LottoGame
    {
        public LottoRow _WinningRow = null;
        public List<LottoRow> _GeneratedRows = new List<LottoRow>();

        int[] rowMatches = null;
        int[] rowWinnings = null;

        public int _lowestNumber = 0;
        public int _highestNumber = 0;
        public int _rowLength = 0;
        public int _rowPrice = 0;
        public int _profitPercent = 0;

        public LottoGame(int lowestNumber, int highestNumber, int rowLength, int numberOfRowsInGame, int rowPrice, int profitPercent) 
        {
            _profitPercent = profitPercent;
            _rowPrice = rowPrice;
            _lowestNumber = lowestNumber;
            _highestNumber = highestNumber;
            _rowLength = rowLength;

            rowMatches = new int[_rowLength + 1];
            rowWinnings = new int[_rowLength + 1];

            _WinningRow = new LottoRow(rowLength, lowestNumber, highestNumber);
            _GeneratedRows = GeneratedRows(numberOfRowsInGame);
            UpdateWinners();
        }

        private List<LottoRow> GeneratedRows(int numberOfRowsInGame)
        {
            List<LottoRow> lottoRows = new List<LottoRow>();
            for (int i = 0; i < numberOfRowsInGame; i++)
            {
                lottoRows.Add(new LottoRow(_rowLength, _lowestNumber, _highestNumber));
            }
            
            return lottoRows;
        }

        private void UpdateWinners()
        {
            foreach (LottoRow row in _GeneratedRows)
            {
                rowMatches[CheckRow(row)]++;
            }
            int winners = WinnerCount();
            int share = TotalWinnings() / Shares();
            for (int i = LowestWinningRow(); i <= _rowLength; i++)
            {
                if(rowMatches[i] != 0)
                {
                    rowWinnings[i] = share / rowMatches[i];
                }
                
            }
        }

        public int CheckRow(LottoRow row)
        {
            int successCount = 0;
            foreach (int number in _WinningRow._Row)
            {
                if(row.IsNumberInRow(number))
                {
                    successCount++;
                }
            }
            return successCount;
        }
        public int TotalTurnover()
        {
            return _rowPrice * _GeneratedRows.Count();
        }
        public int TotalProfit()
        {
            return (int)((double)TotalTurnover() * ((double)_profitPercent / 100));
        }
        public int TotalWinnings()
        {
            return TotalTurnover() - TotalProfit();
        }
        public int LowestWinningRow()
        {
            return (int)(Math.Floor((double)_rowLength / 2));
        }
        public int WinnerCount()
        {
            int winners = 0;
            for(int i = LowestWinningRow();i<_rowLength;i++)
            {
                winners += rowMatches[i];
            }
            return winners;
        }

        private int Shares()
        {
            int count = 0;
            for (int i = LowestWinningRow(); i <= _rowLength; i++)
            {
                if (rowMatches[i] > 0)
                {
                    count++;
                }
            }
            
            return count;

        }

        public void printStatistics()
        {
            
            for (int i = 0; i < rowMatches.Length; i++)
            {
                Console.WriteLine(i + ": " + rowMatches[i] + " : Each: " + rowWinnings[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Turnover: " + TotalTurnover());
            Console.WriteLine("Profit: " + TotalProfit());
            Console.WriteLine("Winnings: " + TotalWinnings());
            Console.WriteLine("Lowest winning row: " + LowestWinningRow());
            Console.WriteLine("Winners: " + WinnerCount());
            Console.WriteLine("Share: " + Shares());

        }
    }
}
