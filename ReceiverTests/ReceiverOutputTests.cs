using System.Collections.Generic;
using Xunit;
using Receiver;

namespace ReceiverTests
{

    /*public class MockCSVOutput : IReceiverOutput
    {
        string filepath;
        public List<string> MockFileOutput = new List<string>();
        public bool OutputStatus;
        public MockCSVOutput(string filepath)
        {
            this.filepath = filepath;
            this.OutputStatus = false;
        }
        public void WriteOutput(IDictionary<string, int> WordFrequency)
        {
            foreach (var line in WordFrequency)
            {
                var newLine = string.Format("{0},{1}", line.Key, line.Value);
                MockFileOutput.Add(newLine);
                
            }
            this.OutputStatus = true;
        }
    }*/

    public class ReceiverOutputTests
    {
        [Fact]
        public void TestExpectingStatusOfFileWrittenAsTrueWhenCalledWithDictionaryOfWordFrequency()
        {
            CsvOutput csvOutput = new CsvOutput(@"D:\a\review-case-s21b4\review-case-s21b4\ReceiverTests\StatusOutput.csv");
            List<List<string>> testInput = new List<List<string>>
            {
                new List<string> {"sample1", "1"}, new List<string> {"sample2", "1"}
            };

            csvOutput.WriteOutput(testInput);
            Assert.True(csvOutput.OutputStatus);
        }

        [Fact]
        public void TestExpectingValidMockFileOutputWhenCalledWithDictionaryOfWordFrequency()
        {
            CsvOutput mockOutput = new CsvOutput(@"D:\a\review-case-s21b4\review-case-s21b4\ReceiverTests\WordCountOutput.csv");
            List<List<string>> testInput = new List<List<string>>
            {
                new List<string> {"sample1", "1"}, new List<string> {"sample2", "2"}
            };
            mockOutput.WriteOutput(testInput);
            Assert.Equal("sample1,1", mockOutput.FileOutput[0]);
        }

        [Fact]
        public void TestExpectingFileOutputToBeEmptyWhenCalledWithEmptyIDictionary()
        {
            CsvOutput mockOutput = new CsvOutput(@"D:\a\review-case-s21b4\review-case-s21b4\ReceiverTests\EmptyOutput.csv");
            mockOutput.WriteOutput(new List<List<string>>());
            Assert.True(mockOutput.FileOutput.Count == 0);
        }
    }
}
