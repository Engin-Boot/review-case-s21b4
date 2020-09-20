using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Sender
{
    public class Controller
    {
        public readonly ISenderInput InputInterface;
        public readonly ISenderOutput OutputInterface;
        public Controller(ISenderInput inputInterface, ISenderOutput outputInterface)
        {
            this.InputInterface = inputInterface;
            this.OutputInterface = outputInterface;
        }
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            InputInterface.InputExceptionHandler();
            return InputInterface.ReadInput();
        }

        public void WriteOutput(IEnumerable<IEnumerable<string>> parsedData)
        {
            OutputInterface.WriteOutput(parsedData);
        }
        [ExcludeFromCodeCoverage]
        static void Main()
        {
            string filepath = @"D:\a\review-case-s21b4\review-case-s21b4\Sender\Comments.csv";
            CsvInput csvInput = new CsvInput(filepath);
            ConsoleOutput consoleOutput = new ConsoleOutput();
            Filter filter = new Filter();
            StopWordsTool stopWordsTool = new StopWordsTool();
            Controller controller = new Controller(csvInput, consoleOutput);
            List<List<string>> parsedinput = (List<List<string>>)controller.ReadInput();
            var filteredInput = (List<List<string>>)filter.GetDataFilteredByColumnNos(parsedinput, new List<int> { 0, 1 });
            var parsedData = stopWordsTool.RemoveStopWords(filteredInput);
            controller.WriteOutput(parsedData);
        }
    }
}
