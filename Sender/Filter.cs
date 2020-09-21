using System.Collections.Generic;
using System.Linq;
using System;

namespace Sender
{
    public class Filter
    {
        private static IEnumerable<string> GetFilteredRowByColumnNos(IEnumerable<string> row, IEnumerable<int> columnNos)
        {
            var rowList = (List<string>) row;
            var columnNosList = columnNos.ToList();

            return rowList.Where((value, i) => columnNosList.Contains(i)).ToList();
        }
        private static void CheckIndexInRange(int expected,int actual)
        {
            if (actual >= expected)
            {
                throw new IndexOutOfRangeException();
            }
        }
        public static IEnumerable<IEnumerable<string>> GetDataFilteredByColumns
            (IEnumerable<IEnumerable<string>> data, IEnumerable<int> columnNos)
        {
            int nColumns = ConsoleOutput.GetNumberOfColumns(data);
            CheckIndexInRange(nColumns, columnNos.Max());
            var outputData = new List<List<string>>();

            var columnNosList = columnNos.ToList();

            foreach (var row in data)
            {
                var temp = GetFilteredRowByColumnNos(row, columnNosList).ToList();
                outputData.Add(temp);
            }

            return outputData;
        }

        public static IEnumerable<IEnumerable<string>> GetDataFilteredByColumns
            (IEnumerable<IEnumerable<string>> data, int startCol, int endCol)
        {
            int nColumns = ConsoleOutput.GetNumberOfColumns(data);
            CheckIndexInRange(nColumns, endCol);
            var inputData = (List<List<string>>)data;
            var outputData = new List<List<string>>();
            foreach (var row in inputData)
            {
                var temp = new List<string>();
                for (var j = startCol; j <= endCol; j++) temp.Add(row[j]);
                outputData.Add(temp);
            }

            return outputData;
        }
    }
}
