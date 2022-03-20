using System.Collections.Generic;

namespace Sample.TextLibrary.Shared
{
    /// <summary>
    /// Word Frequency Analyzer interface helps to define the frequency calculation methods
    /// </summary>
    public interface IWordFrequencyAnalyzer
    {
        /// <summary>
        /// This method helps to calculate the highest frequency count from the given text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        int CalculateHighestFrequency(string text);

        /// <summary>
        /// This method helps to calculate the highest frequency count for the specific word from the given text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        int CalculateFrequencyForWord(string text, string word);

        /// <summary>
        /// This method helps to calculate the most frequent N words from the text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n);
    }
}
