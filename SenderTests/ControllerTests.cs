using System.Diagnostics;
using Xunit;
using InputToSender;

namespace InputToSender.SenderTests
{
    public class ControllerTests
    {
        [Fact]
        public static void TestExpectingAnObjectOfCsvInputTypeToBeAssignedToControllersInputInterface()
        {

            var csvInput = new CsvInput("TestSample.csv");
            var output = new ConsoleOutput();
            var controller = new Controller(csvInput, output);
            var type = controller.InputInterface.GetType();
            Debug.Assert(type == csvInput.GetType());
        }
    }
}
