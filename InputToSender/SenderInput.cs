using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace InputToSender
{

    public interface ISenderInput
    {
        IEnumerable<IEnumerable<string>> ReadInput();
        void InputExceptionHandler();
    }

    public class CsvInput : ISenderInput
    {
        public string Filepath;
        public CsvInput(string filepath)
        {
            this.Filepath = filepath;
        }
        public void InputExceptionHandler()
        {
            if (!File.Exists(Filepath))
            {
                throw new FileNotFoundException();
            }
            if (new FileInfo(Filepath).Length == 1)
            {
                throw new ArgumentNullException();
            }

        }
        public static List<List<string>> CsvData = new List<List<string>>();
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            //InputExceptionHandler();
            using (var reader = new StreamReader(Filepath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;

                    var values = line.Split(',');
                    //Note: The first row in this list contains headers from CSV file
                    CsvData.Add(values.ToList());
                }
            }
            return CsvData;
        }

    }
}
