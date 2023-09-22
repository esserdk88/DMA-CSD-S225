using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLotto
{
    internal class LottoRow
    {
        public List<int> _Row = new List<int>();
        public int _RowLength = 7;
        public int _LowestNumber = 1;
        public int _HighestNumber = 36;

        public LottoRow(int rowLength)
        {
            _RowLength = rowLength;
            _Row = GetRandomRow();
        }
        public LottoRow(int rowLength, int lowestNumber, int highestNumber) 
        {
            _RowLength = rowLength;
            _LowestNumber = lowestNumber;
            _HighestNumber = highestNumber;
            _Row = GetRandomRow();
        }

        private List<int> GetRandomRow()
        {
            List<int> row = new List<int>();
            List<int> posibleNumbers = GetPosibleNumbers();
            Random random = new Random();
            for (int i = 0; i < _RowLength; i++)
            {
                int randomIndex = random.Next(posibleNumbers.Count);
                row.Add(posibleNumbers[randomIndex]);
                posibleNumbers.RemoveAt(randomIndex);
            }
            row.Sort((x, y) => x.CompareTo(y));
            return row;
        }

        private List<int> GetPosibleNumbers()
        {
            List<int> outputList = new List<int>();
            for(int i = _LowestNumber; i <= _HighestNumber; i++)
            {
                outputList.Add(i);
            }
            return outputList;
        }

        public bool IsNumberInRow(int input)
        {
            return _Row.Contains(input);
        }

        public override string? ToString()
        {
            string outputString = "";
            if (_RowLength > 0) 
            { 
                foreach (int row in _Row)
                {
                    if(row < 10)
                    {
                        outputString += row.ToString().PadLeft(2,'0') + "-";
                    }
                    else
                    {
                        outputString += row.ToString() + "-";
                    }
                    
                }
                outputString = outputString.Substring(0,outputString.Length-1);
            }
            else
            {
                outputString = "Empty";
            }
            return outputString;
        }
    }
}
