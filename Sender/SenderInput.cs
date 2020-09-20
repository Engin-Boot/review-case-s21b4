using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Sender
{

    public interface ISenderInput
    {
        IEnumerable<IEnumerable<string>> ReadInput();
        bool InputExceptionHandler();
    }

    public class CsvInput : ISenderInput
    {
        public readonly string Filepath;
        private readonly List<List<string>> _csvData = new List<List<string>>();
        public CsvInput(string filepath)
        {
            this.Filepath = filepath;
        }
        private void CheckIfFileExists()
        {
            if (!File.Exists(Filepath))
            {
                throw new FileNotFoundException();
            }
        }
        
        public bool InputExceptionHandler()
        {
            CheckIfFileExists();
            return true;

        }
        
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            using var reader = new StreamReader(Filepath);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                
                if (string.IsNullOrEmpty(line)) 
                    continue;
                var values = line.Split(',');
                //Note: The first row in this list contains headers from CSV file
                _csvData.Add(values.ToList());
            }

            return _csvData;
        }

    }
}
