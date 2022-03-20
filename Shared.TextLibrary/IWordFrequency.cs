namespace Sample.TextLibrary.Shared
{
    /// <summary>
    /// Word Frequency interface helps to pass the frequency analyzer fields
    /// </summary>
    public interface IWordFrequency
    {
        /// <summary>
        /// This Word property holds word to calculate the frequency
        /// </summary>
        string Word { get; }

        /// <summary>
        /// This Frequency hold the count of the text frequency
        /// </summary>
        int Frequency { get; }
    }
}
