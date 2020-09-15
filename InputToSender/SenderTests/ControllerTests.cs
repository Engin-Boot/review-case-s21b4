using System.Diagnostics;
using Xunit;
namespace InputToSender.SenderTests
{
    public class ControllerTests
    {
        [Fact]
        public static void TestExpectingAnObjectOfCSVInputTypeToBeAssignedToControllersInputInterface()
        {

            CSVInput csvInput = new CSVInput("SampleTest.csv");
            ConsoleOutput output = new ConsoleOutput();
            Controller controller = new Controller(csvInput, output);
            var type = controller.inputInterface.GetType();
            Debug.Assert(type == csvInput.GetType());
        }
    }
}
