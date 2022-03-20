using Sample.TextLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sample.TextLibrary.Test
{
    /// <summary>
    /// Test calss for Word Frequency Analyzer
    /// </summary>
    public class WordFrequencyAnalyzerTest
    {
        private readonly IWordFrequencyAnalyzer _wordFrequencyAnalyzer;
        public WordFrequencyAnalyzerTest()
        {
            _wordFrequencyAnalyzer = new WordFrequencyAnalyzer();
        }

        [Test]
        public void CalculateHighestFrequency_ValidInput_ShouldMatchResponse()
        {
            //Arrange
            string text = "The sun shines over the lake";

            //Act
            var response = _wordFrequencyAnalyzer.CalculateHighestFrequency(text);

            //Arrange
            Assert.IsNotNull(response);
            Assert.AreEqual(2, response);
        }

        [Test]
        public void CalculateHighestFrequency_ValidInputWithMultipleLines_ShouldMatchTheResult()
        {
            //Arrange
            string text = "The sun shines over the lake The sun shines over the lake The sun shines over the lake " +
                "The sun shines over the lake The sun shines over the lake The sun shines over the lake";

            //Act
            var response = _wordFrequencyAnalyzer.CalculateHighestFrequency(text);

            //Arrange
            Assert.IsNotNull(response);
            Assert.AreEqual(12, response);
        }

        [Test]
        public void CalculateHighestFrequency_CaseInsensitive_ShouldMatchTheResult()
        {
            //Arrange
            string text = "THE sun shines Over the lake THe sun shines over tHe lake The sun shines over the lake " +
                "THE SUN SHINES OVER THE LAKE THE SUN SHINES OVER THE LAKE THE SUN SHINES OVER THE LAKE";

            //Act
            var response = _wordFrequencyAnalyzer.CalculateHighestFrequency(text);

            //Arrange
            Assert.IsNotNull(response);
            Assert.AreEqual(12, response);
        }

        [Datapoints]
        public string[] invalidStringValues = new string[] { null, "", "   ", "       " };

        [Test]
        [Theory]
        public void CalculateHighestFrequency_NullAndInvalidInput_ShouldReturnZero(string invalidStringValues)
        {
            //Arrange
            //mutiple input

            //Act
            var response = _wordFrequencyAnalyzer.CalculateHighestFrequency(invalidStringValues);

            //Arrange
            Assert.IsNotNull(response);
            Assert.AreEqual(0, response);
        }

        [Test]
        public void CalculateFrequencyForWord_ValidInput_ShouldMatchTheResult()
        {
            //Arrange
            string text = "The sun shines over the lake";
            string word = "the";

            //Act
            var response = _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, word);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(2, response);
        }

        [Test]
        public void CalculateFrequencyForWord_ValidInputWithMultipleLines_ShouldMatchTheResult()
        {
            //Arrange
            string text = "The sun shines over the lake The sun shines over the lake The sun shines over the lake " +
               "The sun shines over the lake The sun shines over the lake The sun shines over the lake";
            string word = "over";

            //Act
            var response = _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, word);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(6, response);
        }

        [Test]
        [Theory]
        public void CalculateFrequencyForWord_InvalidInputsBoth_ShouldReturnZero(string invalidStringValues)
        {
            //Arrange


            //Act
            var response = _wordFrequencyAnalyzer.CalculateFrequencyForWord(invalidStringValues, invalidStringValues);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(0, response);
        }

        [Test]
        [Theory]
        public void CalculateFrequencyForWord_InvalidInputTextAndValidWord_ShouldReturnZero(string invalidStringValues)
        {
            //Arrange
            string word = "the";

            //Act
            var response = _wordFrequencyAnalyzer.CalculateFrequencyForWord(invalidStringValues, word);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(0, response);
        }

        [Test]
        [Theory]
        public void CalculateFrequencyForWord_InvalidInputWordAndValidText_ShouldReturnZero(string invalidStringValues)
        {
            //Arrange
            string text = "The sun shines over the lake";

            //Act
            var response = _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, invalidStringValues);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(0, response);
        }

        [Test]
        public void CalculateMostFrequentNWords_ValidInput_ShouldReturnSuccessfullResponse()
        {
            //Arrange
            string text = "The sun shines over the lake";
            int frequency = 3;

            //Act
            var response = _wordFrequencyAnalyzer.CalculateMostFrequentNWords(text, frequency);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(3, response.Count);
            Assert.AreEqual(2, response[0].Frequency);
            Assert.AreEqual("the", response[0].Word);
            Assert.AreEqual(1, response[1].Frequency);
            Assert.AreEqual("lake", response[1].Word);
            Assert.AreEqual(1, response[2].Frequency);
            Assert.AreEqual("over", response[2].Word);
        }

        [Test]
        public void CalculateMostFrequentNWords_ValidInputForAscendingOrder_ShouldReturnSuccessfullResponse()
        {
            //Arrange
            string text = "over lake The sun shines  tHE over lake The";
            int frequency = 5;

            //Act
            var response = _wordFrequencyAnalyzer.CalculateMostFrequentNWords(text, frequency);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(5, response.Count);
            Assert.AreEqual(3, response[0].Frequency);
            Assert.AreEqual("the", response[0].Word);
            Assert.AreEqual(2, response[1].Frequency);
            Assert.AreEqual("lake", response[1].Word);
            Assert.AreEqual(2, response[2].Frequency);
            Assert.AreEqual("over", response[2].Word);
            Assert.AreEqual(1, response[3].Frequency);
            Assert.AreEqual("shines", response[3].Word);
            Assert.AreEqual(1, response[4].Frequency);
            Assert.AreEqual("sun", response[4].Word);
        }

        [Test]
        [Theory]
        public void CalculateMostFrequentNWords_InvalidTextInput_ShouldReturnZeroCount(string invalidStringValues)
        {
            //Arrange
            int frequency = 2;

            //Act
            var response = _wordFrequencyAnalyzer.CalculateMostFrequentNWords(invalidStringValues, frequency);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(0, response.Count);
        }

        [Test]
        public void CalculateMostFrequentNWords_ValidTextInvalidFrequency_ShouldReturnZeroCount()
        {
            //Arrange
            string text = "The sun shines over the lake";
            int frequency = -3;

            //Act
            var response = _wordFrequencyAnalyzer.CalculateMostFrequentNWords(text, frequency);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(0, response.Count);
        }
    }
}
