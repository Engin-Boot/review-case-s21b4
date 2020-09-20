using System.Collections.Generic;
using Receiver;
using Xunit;

namespace ReceiverTests
{
    public class AnalyzerTests
    {
        [Fact]
        public void TestExpectingIEnumerableContainingWordsSeparatedBySpaceWhenCalledWithValidIEnumerable()
        {
            var testInput = new List<string> {"this is sample test string"};
            var output = (List<string>)Analyzer.GetSeparatedWordsBySpaceFromARow(testInput);
            Assert.Equal("this", output[0]);
            Assert.Equal("is", output[1]);
        }

        [Fact]
        public void TestExpectingAnUpdatedDictionaryOfWordFrequencyWhenCalledWithDictionaryToUpdateAndIEnumerable()
        {
            var testInput = new List<string> {"this", "sample"};
            IDictionary<string, int> dictToUpdate = new Dictionary<string, int>
            {
                { "dummy", 1 },
                { "sample", 1 }
            };
            var updatedDict = Analyzer.AddWordCountInDictionary(dictToUpdate, testInput);
            Assert.True(updatedDict["this"] == 1);
            Assert.True(updatedDict["sample"] == 2);
        }

        [Fact]
        public void TestExpectingWordFrequencyOfAllWordsWhenCalledWithATwoDimensionalIEnumerable()
        {
            var testAnalyzer = new Analyzer();
            var testInput = new List<List<string>>();
            var tempList1 = new List<string>
            {
                "sample string1"
            };
            var tempList2 = new List<string>
            {
                "sample string2"
            };
            testInput.Add(tempList1);
            testInput.Add(tempList2);
            var testOutput = (List<List<string>>)testAnalyzer.CountWordFrequency(testInput);
            Assert.Equal("sample",testOutput[0][0]);
            Assert.Equal("2",testOutput[0][1]);
        }
    }
}
