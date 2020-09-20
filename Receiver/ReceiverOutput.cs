using System.Collections.Generic;
using System.IO;
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
            //var csv = new StringBuilder();
            var file = new StreamWriter(_filepath, false);
            var wordFrequencyList = (List<List<string>>)wordFrequency;
            foreach(var row in wordFrequencyList)
            {
                var newLine = "";
                for(int j=0;j<row.Count;j++)
                {
                    newLine +=  row[j]+ ",";
                }
                newLine = newLine.Remove(newLine.Length - 1);
                file.WriteLine(newLine);
                FileOutput.Add(newLine);
                Console.WriteLine(newLine);
            }
            file.Close();
            
            OutputStatus = true;
        }
    }
}
