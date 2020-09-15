using System;
using System.Collections.Generic;

namespace InputToSender
{
    public class Controller
    {
        public ISenderInput inputInterface;
        public ISenderOutput outputInterface;
        public Controller(ISenderInput inputInterface, ISenderOutput outputInterface)
        {
            this.inputInterface = inputInterface;
            this.outputInterface = outputInterface;
        }
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            return inputInterface.ReadInput();
        }

        public void WriteOutput(IEnumerable<IEnumerable<string>> parsedData)
        {
            outputInterface.WriteOutput(parsedData);
        }
        static void _Main(string[] args)
        {
            //string filepath = Console.ReadLine();
               string filepath = "https://github.com/Engin-Boot/review-case-s21b4/blob/master/InputToSender/Comments.csv";
            //string filter = args[0];
            //Console.WriteLine(filter);
            CSVInput csvInput = new CSVInput(filepath);
            ConsoleOutput consoleOutput = new ConsoleOutput();
            Controller controller = new Controller(csvInput, consoleOutput);
            List<List<string>> parsedinput = (List<List<string>>)controller.ReadInput();
            controller.WriteOutput(parsedinput);
        }
    }
}
