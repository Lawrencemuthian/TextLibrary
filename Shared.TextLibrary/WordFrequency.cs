using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.TextLibrary.Shared
{
    /// <summary>
    /// Word Frequency class helps to pass the frequency analyzer fields
    /// </summary>
    public class WordFrequency : IWordFrequency
    {
        /// <summary>
        /// This Word property holds word to calculate the frequency
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// This Frequency hold the count of the text frequency
        /// </summary>
        public int Frequency { get; set; }
    }
}
