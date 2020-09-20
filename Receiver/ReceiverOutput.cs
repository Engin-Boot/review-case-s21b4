using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

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
            for(int i=0;i<wordFrequencyList.Count();i++)
            {
                //var newLine = string.Join("," , row);
                for(int j=0;j<wordFrequencyList[i].Count();j++){
                    file.WriteLine(wordFrequencyList[i][j]+",");
                    FileOutput.Add(wordFrequencyList[i][j]+",");
                    Console.WriteLine(wordFrequencyList[i][j]+",");
               }
                
            }
            file.Close();
            
            OutputStatus = true;
        }
    }
}
