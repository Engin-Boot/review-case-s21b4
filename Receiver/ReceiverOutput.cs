using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
namespace Receiver
{
    public interface IReceiverOutput
    {
        void WriteOutput(IEnumerable<IEnumerable<string>> data);
    }

    public class CsvOutput : IReceiverOutput
    {
        public bool OutputStatus;
        readonly string _filepath;
        public readonly List<string> FileOutput = new List<string>();

        public CsvOutput(string filepath)
        {
            this._filepath = filepath;
            OutputStatus = false;
        }

        public void WriteOutput(IEnumerable<IEnumerable<string>> wordFrequency)
        {
            var csv = new StringBuilder();
            foreach (var row in wordFrequency)
            {
                var newLine = "";
                foreach (var value in row)
                {
                    newLine += value + ",";
                }

                newLine = newLine.Remove(newLine.Length - 1);
                csv.AppendLine(newLine);
                FileOutput.Add(newLine);
            }

            File.WriteAllText(_filepath, csv.ToString());
            Console.WriteLine(csv.ToString());
            OutputStatus = true;
        }
    }
}
