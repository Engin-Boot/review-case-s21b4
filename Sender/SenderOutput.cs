using System;
using System.Collections.Generic;
using System.Linq;

namespace Sender
{
    public interface ISenderOutput
    {
        void WriteOutput(IEnumerable<IEnumerable<string>> data);
    }


    public class ConsoleOutput : ISenderOutput
    {
        public readonly List<string> OutputData = new List<string>();
        public int NRows, NColumns;
        public void WriteOutput(IEnumerable<IEnumerable<string>> data)
        {
            var dataList = data.ToList();
            NRows = GetNumberOfRows(dataList);
            NColumns = GetNumberOfColumns(dataList);
            Console.WriteLine(NRows);
            Console.WriteLine(NColumns);
            foreach (var value in dataList.SelectMany(row => row))
            {
                Console.WriteLine(value);
                OutputData.Add(value);
            }
        }

        public static int GetNumberOfColumns(IEnumerable<IEnumerable<string>> data)
        {
            var colCount = 0;
            foreach (var row in data)
            {
                colCount += row.Count();
                break;
            }
            return colCount;
        }

        public static int GetNumberOfRows(IEnumerable<IEnumerable<string>> data)
        {
            return data.Count();
        }
    }
}
