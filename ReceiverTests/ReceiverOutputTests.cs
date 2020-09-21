using System;
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
            CsvOutput csvOutput = new CsvOutput("Random_file_path");
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
            CsvOutput mockOutput = new CsvOutput("Random_file_path");
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
            CsvOutput mockOutput = new CsvOutput("Random_file_path");
            mockOutput.WriteOutput(new List<List<string>>());
            Assert.True(mockOutput.FileOutput.Count == 0);
        }

        [Fact]
        public void TestExpectingArgumentExceptionWhenFileFormatIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => new CsvOutput("output.doc"));
        }

        [Fact]
        public void TestExpectingNoExceptionWhenFileFormatIsValid()
        {
            CsvOutput object1 = new CsvOutput("output.csv");
            Assert.False(object1.OutputStatus);
            object1 = new CsvOutput("output.xlsx");
            Assert.False(object1.OutputStatus);
        }
    }
}
