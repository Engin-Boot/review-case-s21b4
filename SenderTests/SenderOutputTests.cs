using System;
using System.Collections.Generic;
using Xunit;
using InputToSender;
namespace InputToSender.SenderTests
{
    class MockConsoleOuput : ISenderOutput
    {
        internal List<List<String>> OutputOnConsole = new List<List<string>>();

        public void WriteOutput(IEnumerable<IEnumerable<String>> data)
        {
            List<String> newRow;
            foreach (IEnumerable<String> row in data)
            {
                newRow = new List<string>();
                foreach (String value in row)
                {
                    newRow.Add(value);
                }
                OutputOnConsole.Add(newRow);
            }
        }
    }

    public class SenderOutputTest
    {
        [Fact]
        public void WhenCalledWithTwoDimensionalDataThenAccessValuesRowWiseFromData()
        {
            List<List<String>> testinput = new List<List<string>>
            {
                new List<string> { "Date", "Comment" },
                new List<string> { "12/12/2012", "All good" },
                new List<string> { "11/11/2011", "Remove duplication" },
                new List<string> { "30/11/2015", "Edge Cases not handled" }
            };

            MockConsoleOuput mockConsoleOuput = new MockConsoleOuput();
            mockConsoleOuput.WriteOutput(testinput);

            List<List<String>> testoutput = mockConsoleOuput.OutputOnConsole;
            Assert.Equal(testinput, testoutput);
        }

        [Fact]
        public void WhenCalledWithTwoDimensionalDataThenReturnNumberofColumnsinData()
        {
            List<List<String>> testinput = new List<List<string>>
            {
                new List<string> { "Date", "Comment" },
                new List<string> { "12/12/2012", "All good" },
                new List<string> { "11/11/2011", "Remove duplication" },
                new List<string> { "30/11/2015", "Edge Cases not handled" }
            };

            int noofColumns = ConsoleOutput.GetNumberofColumns(testinput);
            Assert.True(noofColumns == 2);
        }

    }
}
