using System.Collections.Generic;
using Xunit;
using Sender;

namespace SenderTests
{

    /*public class MockConsoleOutput : ISenderOutput
    {
        public List<List<string>> OutputOnConsole = new List<List<string>>();
        public int NRows, NColumns;
        public void WriteOutput(IEnumerable<IEnumerable<string>> data)
        {
            var dataList = data.ToList();
            NRows = ConsoleOutput.GetNumberOfRows(dataList);
            NColumns = ConsoleOutput.GetNumberOfColumns(dataList);
            foreach (var newRow in dataList.Select(row => row.ToList()))
            {
                OutputOnConsole.Add(newRow);
            }
        }
    }*/

    public class SenderOutputTests
    {
        private readonly List<List<string>> _testInput = new List<List<string>>
            {
                new List<string> { "Date", "Comment" },
                new List<string> { "12/12/2012", "All good" },
                new List<string> { "11/11/2011", "Remove duplication" },
                new List<string> { "30/11/2015", "Edge Cases not handled" }
            };

        [Fact]
        public void WhenCalledWithTwoDimensionalIEnumerableThenGiveProperRowAndColumnCountAndAccessValuesRowWiseFromData()
        {

            var consoleOutput = new ConsoleOutput();
            consoleOutput.WriteOutput(_testInput);

            var testOutput = consoleOutput.OutputData;
            Assert.Equal(4, consoleOutput.NRows);
            Assert.Equal(2, consoleOutput.NColumns);
            Assert.Equal("Date", testOutput[0]);
            Assert.Equal("12/12/2012", testOutput[2]);
            Assert.Equal("Edge Cases not handled", testOutput[7]);

        }

        [Fact]
        public void WhenCalledWithTwoDimensionalDataThenReturnNumberOfColumnsInData()
        {
            var nColumns = ConsoleOutput.GetNumberOfColumns(_testInput);
            Assert.True(nColumns == 2);
        }

        [Fact]
        public void WhenCalledWithTwoDimensionalDataThenReturnNumberOfRowsInData()
        {
            var nRows = ConsoleOutput.GetNumberOfRows(_testInput);
            Assert.True(nRows == 4);
        }

    }
}
