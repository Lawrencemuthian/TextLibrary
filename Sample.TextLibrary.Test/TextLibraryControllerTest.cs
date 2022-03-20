using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sample.TextLibrary.Business;
using Sample.TextLibrary.Controllers;
using Sample.TextLibrary.Shared;
using System;
using System.Collections.Generic;

namespace Sample.TextLibrary.Test
{
    /// <summary>
    /// Test class for Text Library Controller
    /// </summary>
    public class TextLibraryControllerTest
    {
        private readonly ITextLibraryBusiness _textLibraryBusiness;
        private readonly TextLibraryController _textLibraryController;
        public TextLibraryControllerTest()
        {
            _textLibraryBusiness = Substitute.For<ITextLibraryBusiness>();
            _textLibraryController = new TextLibraryController(_textLibraryBusiness);
        }

        [Test]
        public void GetHighestFrequencyCount_ValidInput_ShouldMatchTheResult()
        {
            //Arrange
            string text = "The sun shines over the lake";
            _textLibraryBusiness.GetHighestFrequencyCount(text).Returns(2);

            //Act
            var response = _textLibraryController.GetHighestFrequencyCount(text);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<OkObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(2, okResult.Value);
        }

        [Test]
        public void GetHighestFrequencyCount_ValidInputWithMultipleLines_ShouldMatchTheResult()
        {
            //Arrange
            string text = "The sun shines over the lake The sun shines over the lake The sun shines over the lake " +
                "The sun shines over the lake The sun shines over the lake The sun shines over the lake";
            _textLibraryBusiness.GetHighestFrequencyCount(text).Returns(12);

            //Act
            var response = _textLibraryController.GetHighestFrequencyCount(text);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<OkObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(12, okResult.Value);
        }

        [Test]
        public void GetHighestFrequencyCount_NullInputText_ShouldReturnInvalidRequest()
        {
            //Arrange
            string text = null;
            _textLibraryBusiness.GetHighestFrequencyCount(text).Returns(12);

            //Act
            var response = _textLibraryController.GetHighestFrequencyCount(text);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<ObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(400, okResult.StatusCode);
            Assert.AreEqual("Please give the valid input", okResult.Value);
        }

        [Test]
        public void GetHighestFrequencyCount_EmptyInputText_ShouldReturnInvalidRequest()
        {
            //Arrange
            string text = "";
            _textLibraryBusiness.GetHighestFrequencyCount(text).Returns(12);

            //Act
            var response = _textLibraryController.GetHighestFrequencyCount(text);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<ObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(400, okResult.StatusCode);
            Assert.AreEqual("Please give the valid input", okResult.Value);
        }

        [Test]
        public void GetHighestFrequencyCount_WhiteSpaceInputText_ShouldReturnInvalidRequest()
        {
            //Arrange
            string text = "          ";
            _textLibraryBusiness.GetHighestFrequencyCount(text).Returns(12);

            //Act
            var response = _textLibraryController.GetHighestFrequencyCount(text);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<ObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(400, okResult.StatusCode);
            Assert.AreEqual("Please give the valid input", okResult.Value);
        }

        [Test]
        public void GetFrequencyForWord_ValidInput_ShouldMatchTheResult()
        {
            //Arrange
            string text = "The sun shines over the lake";
            string word = "the";
            _textLibraryBusiness.GetFrequencyForWord(text, word).Returns(2);

            //Act
            var response = _textLibraryController.GetFrequencyForWord(text,word);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<OkObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(2, okResult.Value);
        }

        [Test]
        public void GetFrequencyForWord_ValidInputWithMultipleLines_ShouldMatchTheResult()
        {
            //Arrange
            string text = "The sun shines over the lake The sun shines over the lake The sun shines over the lake " +
                "The sun shines over the lake The sun shines over the lake The sun shines over the lake";
            string word = "the";
            _textLibraryBusiness.GetFrequencyForWord(text, word).Returns(12);

            //Act
            var response = _textLibraryController.GetFrequencyForWord(text, word);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<OkObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(12, okResult.Value);
        }

        [Test]
        public void GetHighestFrequencyCount_NullTextAndValidWord_ShouldReturnInvalidRequest()
        {
            //Arrange
            string text = null;
            string word = "the";
            _textLibraryBusiness.GetFrequencyForWord(text, word).Returns(12);

            //Act
            var response = _textLibraryController.GetFrequencyForWord(text, word);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<ObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(400, okResult.StatusCode);
            Assert.AreEqual("Please give the valid input", okResult.Value);
        }

        [Test]
        public void GetHighestFrequencyCount_NullWordAndValidtext_ShouldReturnInvalidRequest()
        {
            //Arrange
            string text = "The sun shines over the lake"; 
            string word = null;
            _textLibraryBusiness.GetFrequencyForWord(text, word).Returns(12);

            //Act
            var response = _textLibraryController.GetFrequencyForWord(text, word);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<ObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(400, okResult.StatusCode);
            Assert.AreEqual("Please give the valid input", okResult.Value);
        }

        [Test]
        public void GetHighestFrequencyCount_NullInputs_ShouldReturnInvalidRequest()
        {
            //Arrange
            string text = null;
            string word = null;
            _textLibraryBusiness.GetFrequencyForWord(text, word).Returns(12);

            //Act
            var response = _textLibraryController.GetFrequencyForWord(text, word);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<ObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(400, okResult.StatusCode);
            Assert.AreEqual("Please give the valid input", okResult.Value);
        }

        [Test]
        public void GetHighestFrequencyCount_EmptyTextAndValidWord_ShouldReturnInvalidRequest()
        {
            //Arrange
            string text = " ";
            string word = "the";
            _textLibraryBusiness.GetFrequencyForWord(text, word).Returns(12);

            //Act
            var response = _textLibraryController.GetFrequencyForWord(text, word);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<ObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(400, okResult.StatusCode);
            Assert.AreEqual("Please give the valid input", okResult.Value);
        }

        [Test]
        public void GetHighestFrequencyCount_EmptyWordAndValidtext_ShouldReturnInvalidRequest()
        {
            //Arrange
            string text = "The sun shines over the lake";
            string word = " ";
            _textLibraryBusiness.GetFrequencyForWord(text, word).Returns(12);

            //Act
            var response = _textLibraryController.GetFrequencyForWord(text, word);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<ObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(400, okResult.StatusCode);
            Assert.AreEqual("Please give the valid input", okResult.Value);
        }

        [Test]
        public void GetHighestFrequencyCount_EmptyInputs_ShouldReturnInvalidRequest()
        {
            //Arrange
            string text = " ";
            string word = " ";
            _textLibraryBusiness.GetFrequencyForWord(text, word).Returns(12);

            //Act
            var response = _textLibraryController.GetFrequencyForWord(text, word);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<ObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(400, okResult.StatusCode);
            Assert.AreEqual("Please give the valid input", okResult.Value);
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
            _textLibraryBusiness.GetMostFrequentNWords(text,frequency).Returns(list);

            //Act
            var response = _textLibraryController.GetMostFrequentNWords(text,frequency);

            //Assert
            Assert.IsNotNull(response);
            Assert.That(response, Is.TypeOf<OkObjectResult>());
            var okResult = response as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.That(okResult.Value, Is.TypeOf<List<IWordFrequency>>());
            var wordFrequencyResult = okResult.Value as IList<IWordFrequency>;
            Assert.AreEqual(2, wordFrequencyResult[0].Frequency);
            Assert.AreEqual("the", wordFrequencyResult[0].Word);
            Assert.AreEqual(1, wordFrequencyResult[1].Frequency);
            Assert.AreEqual("lake", wordFrequencyResult[1].Word);
            Assert.AreEqual(1, wordFrequencyResult[2].Frequency);
            Assert.AreEqual("over", wordFrequencyResult[2].Word);
        }

    }
}