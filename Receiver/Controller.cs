using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Receiver
{
    public class Controller
    {
        public readonly IReceiverInput InputInterface;
        public readonly IReceiverOutput OutputInterface;

        public Controller(IReceiverInput inputInterface, IReceiverOutput outputInterface)
        {
            InputInterface = inputInterface;
            OutputInterface = outputInterface;
        }

        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            return InputInterface.ReadInput();
        }

        public void WriteOutput(IEnumerable<IEnumerable<string>> data)
        {
            OutputInterface.WriteOutput(data);
        }

        [ExcludeFromCodeCoverage]
        private static void Main()
        {
            var consoleInput = new ConsoleInput();
            var filepath = @"D:\a\DummyReviews\DummyReviews\Receiver\output.csv";
            var csvOutput = new CsvOutput(filepath);
            var controller = new Controller(consoleInput, csvOutput);

            Console.WriteLine("----------------------Reading Sender Data----------------------");

            var output = (List<List<string>>)controller.ReadInput();
            var commentAnalyzer = new Analyzer();
            var wordCount = commentAnalyzer.CountWordFrequency(output);

            var wordCountList = wordCount.Select(item => new List<string> { item.Key, item.Value.ToString() }).ToList();

            controller.WriteOutput(wordCountList);
        }
    }
}
