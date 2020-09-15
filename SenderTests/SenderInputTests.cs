using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Xunit;


namespace InputToSender.SenderTests
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
        public void TestExpectingProvidedCSVFileToBeReadWhenCalledWithFilePath()
        {
            string filepath = "..\SenderTests\TestSample.csv";
            CSVInput csvInput = new CSVInput(filepath);
            List<List<string>> testOutput = (List<List<string>>)csvInput.ReadInput();
            Debug.Assert(testOutput[0][0] == "sampledata");
            Console.WriteLine(testOutput[0][0]);
            Console.WriteLine("test");
        }

        [Fact]
        public void TestExpectingExceptionWhenFileCouldNotBeFoundOrOpened()
        {
            string filepath = "TestSample2.csv";
            CSVInput csvInput = new CSVInput(filepath);
            Assert.Throws<FileNotFoundException>(() => csvInput.InputExceptionHandler());
        }
        /*[Fact]
        public void TestExpectingNullArgumentExceptionWhenFileExistsButIsEmpty()
        {
            string filepath = @"E:\BootCamp\Sender\InputToSender\SenderTests\EmptySample.csv";
            CSVInput csvInput = new CSVInput(filepath);
            Assert.Throws<ArgumentNullException>(() => csvInput.InputExceptionHandler());
        }*/
    }
}
