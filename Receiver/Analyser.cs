using System;
using System.Collections.Generic;
using System.Linq;

namespace Receiver
{
    public class Analyzer
    {

        public static IEnumerable<string> GetSeparatedWordsBySpaceFromARow(IEnumerable<string> row)
        {
            var separatedRow = new List<string>();
            foreach (var item in row)
            {
                var words = item.Split(' ');
                separatedRow.AddRange(words);
            }
            return separatedRow;
        }

        public static IDictionary<string, int> AddWordCountInDictionary(IDictionary<string, int> wordFrequency, IEnumerable<string> wordsInRow)
        {
            foreach (var word in wordsInRow)
            {
                if (!wordFrequency.ContainsKey(word))
                {
                    wordFrequency.Add(word, 1);
                }
                else
                {
                    wordFrequency[word]++;
                }
            }
            return wordFrequency;
        }

        
        private string GetAssociatedDatesForAWord(IEnumerable<IEnumerable<string>> data, string word)
        {
            List<List<string>> dataList = (List<List<string>>)data;
            string dates = "";
            foreach (var t in dataList)
            {
                var wordsInARow = (List<string>)GetSeparatedWordsBySpaceFromARow(t);
                if (wordsInARow.Contains(word))
                    dates += t[0] + " ";
            }
            
            return dates;
        }

        public IEnumerable<IEnumerable<string>> CountWordFrequency(IEnumerable<IEnumerable<string>> data)
        {
            IDictionary<string, int> wordFrequency = new Dictionary<string, int>();

            var dataList = (List<List<string>>) data;
            var originalData = dataList.Select(row => row.ToList()).ToList();

            foreach (var row in dataList)
            {
                row.RemoveAt(0);
                var wordsInARow = GetSeparatedWordsBySpaceFromARow(row);
                wordFrequency = AddWordCountInDictionary(wordFrequency, wordsInARow);
            }

            var wordCountList = wordFrequency.Select(item => new List<string> { item.Key, item.Value.ToString() }).ToList();

            foreach (var wordCountRow in wordCountList)
            {
                wordCountRow.Add(GetAssociatedDatesForAWord(originalData, wordCountRow[0]));
            }

            return wordCountList;

        }

    }

}
