using System.Collections.Generic;

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

        public static IDictionary<string, int> AddWordCountInDictionary(IDictionary<string, int> wordfrequency, IEnumerable<string> wordsInRow)
        {
            foreach (var word in wordsInRow)
            {
                if (!wordfrequency.ContainsKey(word))
                {
                    wordfrequency.Add(word, 1);
                }
                else
                {
                    wordfrequency[word]++;
                }
            }
            return wordfrequency;
        }

        public IDictionary<string, int> CountWordFrequency(IEnumerable<IEnumerable<string>> data)
        {
            IDictionary<string, int> wordFrequency = new Dictionary<string, int>();

            foreach (var row in data)
            {
                var wordsInARow = GetSeparatedWordsBySpaceFromARow(row);
                wordFrequency = AddWordCountInDictionary(wordFrequency, wordsInARow);
            }
            return wordFrequency;

        }
    }

}
