using System.Collections.Generic;
using Sender;
using Xunit;

namespace SenderTests
{
    public class ControllerTests
    {
        const string Filepath = @"D:\a\review-case-s21b4\review-case-s21b4\SenderTests\TestSample.csv";
        readonly CsvInput _csvInput = new CsvInput(Filepath);
        readonly ConsoleOutput _consoleOutput = new ConsoleOutput();
        Controller _controller;


        [Fact]
        public void TestExpectingAnObjectOfCsvInputTypeToBeAssignedToControllersInputInterface()
        {
            _controller = new Controller(_csvInput, _consoleOutput);
            Assert.Equal(_csvInput, _controller.InputInterface);
            Assert.Equal(_consoleOutput, _controller.OutputInterface);
        }


        [Fact]
        public void TestExpectingAppropriateWriteOutputMethodToBeCalledWhenCalledWithTwoDimensionalIEnumerable()
        {

            _controller = new Controller(_csvInput, _consoleOutput);
            List<List<string>> parsedInput = (List<List<string>>)_controller.ReadInput();
            _controller.WriteOutput(parsedInput);
            Assert.Equal("sampledata", _consoleOutput.OutputData[0]);

        }
        [Fact]
        public void TestExpectingAppropriateReadInputMethodToBeCalledWhenCalled()
        {
            _controller = new Controller(_csvInput, _consoleOutput);
            List<List<string>> parsedInput = (List<List<string>>)_controller.ReadInput();
            Assert.Equal("sampledata", parsedInput[0][0]);
        }
    }
}
