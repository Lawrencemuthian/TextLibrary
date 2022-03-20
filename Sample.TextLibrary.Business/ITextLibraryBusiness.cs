using Sample.TextLibrary.Shared;
using System.Collections.Generic;

namespace Sample.TextLibrary.Business
{
    /// <summary>
    /// Interface to implement the Text Library Business
    /// </summary>
    public interface ITextLibraryBusiness
    {
        /// <summary>
        /// To get the highest frequency count from text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        int GetHighestFrequencyCount(string text);

        /// <summary>
        /// To get the frquency count for the word from the given text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        int GetFrequencyForWord(string text, string word);

        /// <summary>
        /// To get the most frequency N words from text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        IList<IWordFrequency> GetMostFrequentNWords(string text, int n);
    }
}
