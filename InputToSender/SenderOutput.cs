using System;
using System.Collections.Generic;

namespace InputToSender
{
    public interface ISenderOutput
    {
        void WriteOutput(IEnumerable<IEnumerable<String>> data);
    }

    public class ConsoleOutput : ISenderOutput
    {
        public void WriteOutput(IEnumerable<IEnumerable<String>> data)
        {
            int noofColumns = GetNumberofColumns(data);
            Console.WriteLine(noofColumns);
            foreach (IEnumerable<String> row in data)
            {
                foreach (String value in row)
                {
                    Console.WriteLine(value);
                }
            }
        }

        public static int GetNumberofColumns(IEnumerable<IEnumerable<String>> data)
        {
            int count = 0;
            foreach (IEnumerable<String> row in data)
            {
                foreach (String value in row)
                {
                    count++;
                }
                break;
            }
            return count;
        }
    }
}
