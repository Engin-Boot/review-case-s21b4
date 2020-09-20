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

        public IEnumerable<IEnumerable<string>> CountWordFrequency(IEnumerable<IEnumerable<string>> data)
        {
            IDictionary<string, int> wordFrequency = new Dictionary<string, int>();

            foreach (var row in data)
            {
                var wordsInARow = GetSeparatedWordsBySpaceFromARow(row);
                wordFrequency = AddWordCountInDictionary(wordFrequency, wordsInARow);
            }

            var wordCountList = wordFrequency.Select(item => new List<string> { item.Key, item.Value.ToString() }).ToList();

            return wordCountList;

        }
    }


}
