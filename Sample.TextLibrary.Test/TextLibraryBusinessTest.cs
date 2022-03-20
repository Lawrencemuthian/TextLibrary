using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Sample.TextLibrary.Business;
using Sample.TextLibrary.Shared;

namespace Sample.TextLibrary.Test
{
    /// <summary>
    /// Test class for Text Library Business
    /// </summary>
    public class TextLibraryBusinessTest
    {
        private readonly IWordFrequencyAnalyzer _wordFrequencyAnalyzer;
        private readonly ITextLibraryBusiness _textLibraryBusiness;
        public TextLibraryBusinessTest()
        {
            _wordFrequencyAnalyzer = Substitute.For<IWordFrequencyAnalyzer>();
            _textLibraryBusiness = new TextLibraryBusiness(_wordFrequencyAnalyzer);
        }

        [Test]
        public void GetHighestFrequencyCount_ValidInput_ShouldMatchResponse()
        {
            //Arrange
            string text = "The sun shines over the lake";
            _wordFrequencyAnalyzer.CalculateHighestFrequency(text).Returns(2);

            //Act
            var response = _textLibraryBusiness.GetHighestFrequencyCount(text);

            //Arrange
            Assert.IsNotNull(response);
            Assert.AreEqual(2, response);
        }

        [Test]
        public void GetHighestFrequencyCount_ValidInputWithMultipleLines_ShouldMatchTheResult()
        {
            //Arrange
            string text = "The sun shines over the lake The sun shines over the lake The sun shines over the lake " +
                "The sun shines over the lake The sun shines over the lake The sun shines over the lake";
            _wordFrequencyAnalyzer.CalculateHighestFrequency(text).Returns(12);

            //Act
            var response = _textLibraryBusiness.GetHighestFrequencyCount(text);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(12, response);
        }
        
        [Test]
        public void GetFrequencyForWord_ValidInput_ShouldMatchTheResult()
        {
            //Arrange
            string text = "The sun shines over the lake";
            string word = "the";
            _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, word).Returns(2);

            //Act
            var response = _textLibraryBusiness.GetFrequencyForWord(text, word);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(2, response);
        }

        [Test]
        public void GetFrequencyForWord_ValidInputWithMultipleLines_ShouldMatchTheResult()
        {
            //Arrange
            string text = "The sun shines over the lake The sun shines over the lake The sun shines over the lake " +
               "The sun shines over the lake The sun shines over the lake The sun shines over the lake";
            string word = "the";
            _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, word).Returns(12);

            //Act
            var response = _textLibraryBusiness.GetFrequencyForWord(text, word);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(12, response);
        }

        [Test]
        public void GetMostFrequentNWords_ValidInput_ShouldReturnSuccessfullResponse()
        {
            //Arrange
            string text = "The sun shines over the lake";
            int frequency = 3;
            IList<IWordFrequency> list = new List<IWordFrequency>();
            list.Add(new WordFrequency { Frequency = 2, Word = "the" });
            list.Add(new WordFrequency { Frequency = 1, Word = "lake" });
            list.Add(new WordFrequency { Frequency = 1, Word = "over" });
            _wordFrequencyAnalyzer.CalculateMostFrequentNWords(text, frequency).Returns(list);

            //Act
            var response = _textLibraryBusiness.GetMostFrequentNWords(text, frequency);

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
    }
}
