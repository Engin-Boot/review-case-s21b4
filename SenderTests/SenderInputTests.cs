using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;
using Sender;

namespace SenderTests
{
    /*public class MockInputInterface: ISenderInput
    {
        public IEnumerable<IEnumerable<string>> ReadInput(string Filepath)
        {
            List < List<string> >  MockInput= new List<List<string>>();
            List<string> row = new List<string>();
            row.Add("sample string");
            MockInput.Add(row);
            return MockInput;
        }
    }*/
    public class SenderInputTests
    {
        [Fact]
        public void TestExpectingValidFilepathAssignmentToClassMemberWhenCalledWithValidFilepath()
        {
            string filepath = @"EmptySample.csv";
            CsvInput csvInput = new CsvInput(filepath);
            Assert.Equal("EmptySample.csv", csvInput.Filepath);
        }
        [Fact]
        public void TestExpectingCsvFileToBeReadWhenCalledWithFilePath()
        {
            string filepath =  @"D:\a\review-case-s21b4\review-case-s21b4\SenderTests\TestSample.csv";
            CsvInput csvInput = new CsvInput(filepath);
            List<List<string>> testOutput = (List<List<string>>)csvInput.ReadInput();
            Debug.Assert(testOutput[0][0] == "sampledata");
        }
        [Fact]
        public void TestExpectingOutputToBeEmptyWhenCalledWithFilePathWhereFileIsEmpty()
        {
            string filepath =  @"D:\a\review-case-s21b4\review-case-s21b4\SenderTests\EmptySample.csv";
            CsvInput csvInput = new CsvInput(filepath);
            List<List<string>> testOutput = (List<List<string>>)csvInput.ReadInput();
            Assert.True(testOutput.Count==0);
        }
        [Fact]
        public void TestExpectingExceptionWhenFileCouldNotBeFoundOrOpened()
        {
            string filepath =  @"D:\a\review-case-s21b4\review-case-s21b4\SenderTests\TestSample2.csv";
            CsvInput csvInput = new CsvInput(filepath);
            Assert.Throws<FileNotFoundException>(() => csvInput.InputExceptionHandler());
        }
        [Fact]
        public void TestExpectingNoExceptionWhenFileExists()
        {
            string filepath = @"D:\a\DummyReviews\DummyReviews\SenderTests\TestSample.csv";
            CsvInput csvInput = new CsvInput(filepath);
            Assert.True(csvInput.InputExceptionHandler());
        }
        [Fact]
        public void TestExpectingEmptyLineToBeIgnoredFromInputWhenCalled()
        {
            string filepath =  @"D:\a\review-case-s21b4\review-case-s21b4\SenderTests\EmptyLineSample.csv";
            CsvInput csvInput = new CsvInput(filepath);
            var output = csvInput.ReadInput();
            Assert.True(output.Count()==4);
        }
    }
}
