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

    public class CSVInput : ISenderInput
    {
        public string filepath;
        public CSVInput(string filepath)
        {
            this.filepath = filepath;
        }
        public void InputExceptionHandler()
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException();
            }
            if (new FileInfo(filepath).Length == 0)
            {
                throw new ArgumentNullException();
            }

        }
        public static List<List<string>> csvData = new List<List<string>>();
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            InputExceptionHandler();
            using (var reader = new StreamReader(filepath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    //Note: The first row in this list contains headers from CSV file
                    csvData.Add(values.ToList<string>());
                }


            }
            return csvData;
        }

    }
}
