using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Receiver
{
    public interface IReceiverInput
    {
        IEnumerable<IEnumerable<string>> ReadInput();
    }

    [ExcludeFromCodeCoverage]
    public class ConsoleInput : IReceiverInput
    {
        public IEnumerable<IEnumerable<string>> ReadInput()
        {
            int nRows = ReadNumberOfRows();
            int nColumns = ReadNumberOfColumns();

            var inputFromSender = new List<List<string>>();
            for (int i = 0; i < nRows; i++)
            {
                var newRow = new List<string>();
                for (int j = 0; j < nColumns; j++)
                {
                    newRow.Add(Console.ReadLine());
                }
                inputFromSender.Add(newRow);
            }
            return inputFromSender;
        }

        private int ReadNumberOfRows()
        {
            int nRows = 0;
            string temp = Console.ReadLine();
            if (!string.IsNullOrEmpty(temp))
            {
                nRows = int.Parse(temp);
            }
            return nRows;
        }

        private int ReadNumberOfColumns()
        {
            int nColumns = 0;
            string temp = Console.ReadLine();
            if (!string.IsNullOrEmpty(temp))
            {
                nColumns = int.Parse(temp);
            }
            return nColumns;
        }

    }
}
