using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.TextLibrary.Shared
{
    /// <summary>
    /// Word Frequency Analyzer class helps to define the frequency calculation methods
    /// </summary>
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {

        /// <summary>
        /// This method helps to calculate the highest frequency count from the given text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int CalculateHighestFrequency(string text)
        {
            var response = CalculateFrequency(text);
            return response.Select(x => x.Frequency).FirstOrDefault();
        }

        /// <summary>
        /// This method helps to calculate the highest frequency count for the specific word from the given text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public int CalculateFrequencyForWord(string text, string word)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                var response = CalculateFrequency(text);
                return response.Where(x => x.Word == word.ToLower().Trim()).Select(x => x.Frequency).FirstOrDefault();
            }
            return 0;
        }


        /// <summary>
        /// This method helps to calculate the most frequent N words from the text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {
            var response = CalculateFrequency(text);
            return response.Take(n).ToList();
        }

        /// <summary>
        /// This method helps to calculate the frquency from the text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private IList<IWordFrequency> CalculateFrequency(string text)
        {
            var wordFrequencyList = new List<IWordFrequency>();

            if (!string.IsNullOrWhiteSpace(text))
            {
                var linqResponseList = text.ToLower().Trim().Split()
                .GroupBy(g => g)
                .Where(w=>!string.IsNullOrEmpty(w.Key))
                .Select(s => new WordFrequency { Word = s.Key, Frequency = s.Count() })
                .OrderByDescending(o => o.Frequency).ThenBy(o => o.Word).ToList();

                wordFrequencyList.AddRange(linqResponseList);
            }
            return wordFrequencyList;
        }

    }
}
