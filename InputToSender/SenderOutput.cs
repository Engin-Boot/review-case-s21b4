using System.Collections.Generic;
using System.Linq;
using Xunit;
using InputToSender;

namespace SenderTests
{
    internal class MockConsoleOutput : ISenderOutput
    {
        internal List<List<string>> OutputOnConsole = new List<List<string>>();

        public void WriteOutput(IEnumerable<IEnumerable<string>> data)
        {
            foreach (var row in data)
            {
                var newRow = row.ToList();
                OutputOnConsole.Add(newRow);
            }
        }
    }

    public class SenderOutputTests
    {
        [Fact]
        public void WhenCalledWithTwoDimensionalDataThenAccessValuesRowWiseFromData()
        {
            var testInput = new List<List<string>>
            {
                new List<string> { "Date", "Comment" },
                new List<string> { "12/12/2012", "All good" },
                new List<string> { "11/11/2011", "Remove duplication" },
                new List<string> { "30/11/2015", "Edge Cases not handled" }
            };

            var mockConsoleOutput = new MockConsoleOutput();
            mockConsoleOutput.WriteOutput(testInput);

            var testOutput = mockConsoleOutput.OutputOnConsole;
            Assert.Equal(testInput, testOutput);
        }

        [Fact]
        public void WhenCalledWithTwoDimensionalDataThenReturnNumberOfColumnsInData()
        {
            var testInput = new List<List<string>>
            {
                new List<string> { "Date", "Comment" },
                new List<string> { "12/12/2012", "All good" },
                new List<string> { "11/11/2011", "Remove duplication" },
                new List<string> { "30/11/2015", "Edge Cases not handled" }
            };

            var noOfColumns = ConsoleOutput.GetNumberOfColumns(testInput);
            Assert.True(noOfColumns == 2);
        }

    }
}
