using Xunit;
using Receiver;
using System.Collections.Generic;

namespace ReceiverTests
{
    public class ControllerTests
    {

        [Fact]
        public void TestExpectingCorrectAssignmentToControllersDataMembersWhenCalledWithValidObjects()
        {
            MockConsoleInput mockConsoleInput = new MockConsoleInput("3", "3");
            string filepath =  @"D:\a\review-case-s21b4\review-case-s21b4\ReceiverTests\output.csv";
            CsvOutput csvOutput = new CsvOutput(filepath);
            Controller controller = new Controller(mockConsoleInput, csvOutput);
            Assert.Equal(mockConsoleInput, controller.InputInterface);
            Assert.Equal(csvOutput, controller.OutputInterface);
        }

        [Fact]
        public void TestExpectingAppropriateReadInputMethodToBeCalled()
        {
            MockConsoleInput mockConsoleInput = new MockConsoleInput("3", "3");
            string filepath = "same_random_path";
            CsvOutput output = new CsvOutput(filepath);
            Controller controller = new Controller(mockConsoleInput, output);
            var outputRead = (List<List<string>>)controller.ReadInput();
            Assert.Equal("sample00", outputRead[0][0]);
        }

        [Fact]
        public void TestExpectingAppropriateWriteOutputMethodToBeCalledWhenCalledWithValidIDictionary()
        {
            MockConsoleInput mockInput = new MockConsoleInput("3", "3");
            string filepath = "same_random_path";
            CsvOutput output = new CsvOutput(filepath);
            Controller controller = new Controller(mockInput, output);
            List<List<string>> testInput = new List<List<string>>
            {
                new List<string> {"sample1", "2"}, new List<string> {"sample2", "5"}
            };
            controller.WriteOutput(testInput);
            Assert.True(output.OutputStatus);
            Assert.Equal("sample1,2", output.FileOutput[0]);
        }
    }
}
