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
            return InputInterface.ReadInput();
        }

        public void WriteOutput(IEnumerable<IEnumerable<string>> parsedData)
        {
            OutputInterface.WriteOutput(parsedData);
        }

        /*public static void Main(string[] args)
        {
            //var filepath = Console.ReadLine();
            var filepath = "https://github.com/Engin-Boot/review-case-s21b4/blob/master/InputToSender/Comments.csv";
            var csvInput = new CsvInput(filepath);
            var consoleOutput = new ConsoleOutput();
            var controller = new Controller(csvInput, consoleOutput);
            var parsedInput = (List<List<string>>)controller.ReadInput();
            controller.WriteOutput(parsedInput);
        }*/
    }
}
