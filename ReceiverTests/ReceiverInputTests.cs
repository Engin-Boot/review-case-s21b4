using System.Collections.Generic;
using Receiver;
using Xunit;

namespace ReceiverTests
{

    public class MockConsoleInput : IReceiverInput
    {
        int _nRows;
        int _nColumns;
        readonly string _tempRows, _tempCols;

        public MockConsoleInput(string tempRows, string tempCols)
        {
            this._tempRows = tempRows;
            this._tempCols = tempCols;
        }

        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            _nRows = ReadNumberOfRows();
            _nColumns = ReadNumberOfColumns();
            var inputFromSender = new List<List<string>>();
            for (int i = 0; i < _nRows; i++)
            {
                var newRow = new List<string>();
                for (int j = 0; j < _nColumns; j++)
                {
                    newRow.Add("sample" + i.ToString() + j.ToString());

                }
                inputFromSender.Add(newRow);
            }
            return inputFromSender;
        }

        private int ReadNumberOfRows()
        {
            int numRows = 0;
            if (!string.IsNullOrEmpty(_tempRows))
            {
                numRows = int.Parse(_tempRows);
            }
            return numRows;
        }

        private int ReadNumberOfColumns()
        {
            int numCols = 0;
            if (!string.IsNullOrEmpty(_tempCols))
            {
                numCols = int.Parse(_tempCols);
            }
            return numCols;

        }
    }

    public class ReceiverInputTests
    {

        [Fact]
        public void TestExpectingAnIEnumerableToBeReturnedWhenCalledWithNumRowsAndNumColsAndData()
        {

            MockConsoleInput mockObject = new MockConsoleInput("3", "3");
            var actualTestOutput = (List<List<string>>)mockObject.ReadInput();
            Assert.Equal("sample00", actualTestOutput[0][0]);
        }
        [Fact]
        public void TestExpectingOutputToBeEmptyWhenNumRowsOrNumColsReadFromConsoleAreNullOrEmpty()
        {
            MockConsoleInput mockObject = new MockConsoleInput(string.Empty, string.Empty);
            var actualTestOutput = (List<List<string>>)mockObject.ReadInput();
            Assert.True(actualTestOutput.Count == 0);
        }

    }
}
