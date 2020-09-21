using System;
using System.Collections.Generic;
using Sender;
using Xunit;

namespace SenderTests
{
    public class FilterTest
    {
        readonly List<List<string>> testInput = new List<List<string>>(){
            new List<string> { "column1", "column2", "column3", "column4" },
            new List<string> { "c1data", "c2data", "c3data", "c4data" }
        };
        [Fact]
        public void TestExpectingDataFilteredByColumnNosWhenCalledWithTwoDimensionalDataAndColumnNos()
        {

            var testOutput = (List<List<string>>)Filter.GetDataFilteredByColumns(testInput, new List<int> { 1, 2 });
            Assert.Equal("column2", testOutput[0][0]);
            Assert.Equal("column3", testOutput[0][1]);
            Assert.Equal("c2data", testOutput[1][0]);
            Assert.Equal("c3data", testOutput[1][1]);
        }


        [Fact]
        public void TestExpectingDataFilteredByColumnRangeWhenCalledWithTwoDimensionalDataAndStartColAndEndCol()
        {
            

            var testOutput = (List<List<string>>)Filter.GetDataFilteredByColumns(testInput, 0, 2);
            Assert.Equal("column1", testOutput[0][0]);
            Assert.Equal("column3", testOutput[0][2]);
            Assert.Equal("c1data", testOutput[1][0]);
            Assert.Equal("c3data", testOutput[1][2]);
        }
        [Fact]
        public void TestExpectingIndexOutOfRangeExceptionWhenColumnNumberIsOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(() => Filter.GetDataFilteredByColumns(testInput, 0, 5));
            Assert.Throws<IndexOutOfRangeException>(() => Filter.GetDataFilteredByColumns(testInput, new List<int> { 0, 5}));

        }
    }
}
