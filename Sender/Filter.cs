using System.Collections.Generic;
using System.Linq;

namespace Sender
{
    public class Filter
    {
        private IEnumerable<string> GetFilteredRowByColumnNos(IEnumerable<string> row, IEnumerable<int> columnNos)
        {
            var rowList = (List<string>) row;
            var columnNosList = columnNos.ToList();

            return rowList.Where((value, i) => columnNosList.Contains(i)).ToList();
        }

        public IEnumerable<IEnumerable<string>> GetDataFilteredByColumnNos
            (IEnumerable<IEnumerable<string>> data, IEnumerable<int> columnNos)
        {
            var outputData = new List<List<string>>();

            var columnNosList = columnNos.ToList();

            foreach (var row in data)
            {
                var temp = GetFilteredRowByColumnNos(row, columnNosList).ToList();
                outputData.Add(temp);
            }

            return outputData;
        }

        public IEnumerable<IEnumerable<string>> GetDataFilteredByColumnRange
            (IEnumerable<IEnumerable<string>> data, int startCol, int endCol)
        {
            var inputData = (List<List<string>>) data;
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
