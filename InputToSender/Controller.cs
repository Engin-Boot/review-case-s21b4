using System.Collections.Generic;

namespace InputToSender
{
    public class Controller
    {
        public ISenderInput InputInterface;
        public ISenderOutput OutputInterface;
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

        public void _Main()
        {
            //var filepath = Console.ReadLine();
            var filepath = @"D:\a\review-case-s21b4\review-case-s21b4\InputToSender\Comments.csv";
            var csvInput = new CsvInput(filepath);
            var consoleOutput = new ConsoleOutput();
            var controller = new Controller(csvInput, consoleOutput);
            var parsedInput = (List<List<string>>)controller.ReadInput();
            controller.WriteOutput(parsedInput);
        }
    }
}
