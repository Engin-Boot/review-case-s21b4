using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Xunit;
using InputToSender;

namespace SenderTests
{
    /*public class MockInputInterface: ISenderInput
    {
        public IEnumerable<IEnumerable<string>> ReadInput(string filepath)
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
        public void TestExpectingNonEmptyCsvFileToBeReadWhenCalledWithFilePath()
        {
            const string filepath = @"D:\a\review-case-s21b4\review-case-s21b4\SenderTests\TestSample.csv";
            var csvInput = new CsvInput(filepath);
            var testOutput = (List<List<string>>)csvInput.ReadInput();
            Debug.Assert(testOutput[0][0] == "sampledata");
        }

        [Fact]
        public void TestExpectingExceptionWhenFileCouldNotBeFoundOrOpened()
        {
            const string filepath = "TestSample2.csv";
            var csvInput = new CsvInput(filepath);
            Assert.Throws<FileNotFoundException>(() => csvInput.InputExceptionHandler());
        }
        
        /*[Fact]
        public void TestExpectingNullArgumentExceptionWhenFileExistsButIsEmpty()
        {
            const string filepath = @"C:\Users\ALIRAZA\source\repos\InputtoSender\SenderTests\EmptySample.csv";
            var csvInput = new CsvInput(filepath);
            Assert.Throws<ArgumentNullException>(() => csvInput.InputExceptionHandler());
        }
        */
    }
}
