using Sample.TextLibrary.Shared;
using System;
using System.Collections.Generic;

namespace Sample.TextLibrary.Business
{
    /// <summary>
    /// This Class helps to implement the Text Library Business implementations
    /// </summary>
    public class TextLibraryBusiness : ITextLibraryBusiness
    {
        /// <summary>
        /// Word Frequency Analyzer interface
        /// </summary>
        private readonly IWordFrequencyAnalyzer _wordFrequencyAnalyzer;

        /// <summary>
        /// Text Library Business constructer
        /// </summary>
        /// <param name="wordFrequencyAnalyzer"></param>
        public TextLibraryBusiness(IWordFrequencyAnalyzer wordFrequencyAnalyzer)
        {
            _wordFrequencyAnalyzer = wordFrequencyAnalyzer;
        }

        /// <summary>
        /// To get the highest frequency count from text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int GetHighestFrequencyCount(string text)
        {
            return _wordFrequencyAnalyzer.CalculateHighestFrequency(text);
        }

        /// <summary>
        /// To get the frquency count for the word from the given text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public int GetFrequencyForWord(string text, string word)
        {
            return _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, word);
        }

        /// <summary>
        /// To get the most frequency N words from text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IWordFrequency> GetMostFrequentNWords(string text, int n)
        {
            return _wordFrequencyAnalyzer.CalculateMostFrequentNWords(text,n);
        }

    }
}
