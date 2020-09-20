using System.Collections.Generic;
using Sender;
using Xunit;

namespace SenderTests
{
    public class FilterTest
    {
        [Fact]
        public void TestExpectingDataFilteredByColumnNosWhenCalledWithTwoDimensionalDataAndColumnNos()
        {
            var testInput = new List<List<string>>();
            var temp1 = new List<string> {"column1", "column2", "column3"};
            testInput.Add(temp1);

            var temp2 = new List<string> {"c1data", "c2data", "c3data"};
            testInput.Add(temp2);
            
            Filter filter = new Filter();
            var testOutput = (List<List<string>>) filter.GetDataFilteredByColumnNos(testInput, new List<int> {1, 2});
            Assert.Equal("column2", testOutput[0][0]);
            Assert.Equal("column3", testOutput[0][1]);
            Assert.Equal("c2data", testOutput[1][0]);
            Assert.Equal("c3data", testOutput[1][1]);
        }


        [Fact]
        public void TestExpectingDataFilteredByColumnRangeWhenCalledWithTwoDimensionalDataAndStartColAndEndCol()
        {
            var testInput = new List<List<string>>();
            var temp1 = new List<string> {"column1", "column2", "column3", "column4"};
            testInput.Add(temp1);

            var temp2 = new List<string> {"c1data", "c2data", "c3data", "c4data"};
            testInput.Add(temp2);

            Filter filter = new Filter();
            var testOutput = (List<List<string>>) filter.GetDataFilteredByColumnRange(testInput, 0, 2);
            Assert.Equal("column1", testOutput[0][0]);
            Assert.Equal("column3", testOutput[0][2]);
            Assert.Equal("c1data", testOutput[1][0]);
            Assert.Equal("c3data", testOutput[1][2]);
        }
    }
}
