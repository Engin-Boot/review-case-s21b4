using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
            var filepath = @"D:\a\review-case-s21b4\review-case-s21b4\Receiver\output.csv";
            var csvOutput = new CsvOutput(filepath);
            var controller = new Controller(consoleInput, csvOutput);

            var output = (List<List<string>>)controller.ReadInput();
            var commentAnalyzer = new Analyzer();
            var wordCount = commentAnalyzer.CountWordFrequency(output);
            controller.WriteOutput(wordCount);
        }
    }
}
