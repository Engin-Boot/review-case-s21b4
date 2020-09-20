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

        
        public string GetAssociatedDatesForAWord(IEnumerable<IEnumerable<string>> data, string word)
        {
            List<List<string>> dataList = (List<List<string>>)data;
            string dates = "";
            for(int i=0;i<dataList.Count;i++)
            {
                var wordsInARow = (List<string>)GetSeparatedWordsBySpaceFromARow(dataList[i]);
                if (wordsInARow.Contains(word))
                    dates += dataList[i][0] + " ";
            }
            
            return dates;
        }

        public IEnumerable<IEnumerable<string>> CountWordFrequency(IEnumerable<IEnumerable<string>> data)
        {
            IDictionary<string, int> wordFrequency = new Dictionary<string, int>();

            var dataList = (List<List<string>>) data;
            var originalData = dataList.Select(row => row.ToList()).ToList();

            for (int i=0;i<dataList.Count;i++)
            {
                dataList[i].RemoveAt(0);
                var wordsInARow = GetSeparatedWordsBySpaceFromARow(dataList[i]);
                wordFrequency = AddWordCountInDictionary(wordFrequency, wordsInARow);
            }

            var wordCountList = wordFrequency.Select(item => new List<string> { item.Key, item.Value.ToString() }).ToList();

            for (int i = 0; i < wordCountList.Count; i++)
            {
                wordCountList[i].Add(GetAssociatedDatesForAWord(originalData, wordCountList[i][0]));
            }

            for (int i = 0; i < wordCountList.Count; i++)
            {
                for (int j = 0; j < wordCountList[i].Count; j++)
                {
                    Console.Write(wordCountList[i][j] + " ");
                }
                Console.WriteLine();
            }

            return wordCountList;

        }

    }

}
