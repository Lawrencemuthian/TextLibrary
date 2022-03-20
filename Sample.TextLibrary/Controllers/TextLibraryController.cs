using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Sample.TextLibrary.Business;
using Sample.TextLibrary.Shared;

namespace Sample.TextLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextLibraryController : ControllerBase
    {
        /// <summary>
        /// Text Library Business Interface 
        /// </summary>
        private readonly ITextLibraryBusiness _textLibraryBusiness;

        /// <summary>
        /// Text Library Controller Constructer
        /// </summary>
        /// <param name="textLibraryBusiness"></param>
        public TextLibraryController(ITextLibraryBusiness textLibraryBusiness)
        {
            _textLibraryBusiness = textLibraryBusiness;
        }

        /// <summary>
        /// To get the highest frequency count from text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpGet("/HighestFrequencyCount")]
        public IActionResult GetHighestFrequencyCount(string text)
        {
            int highestFrequncyCount;
            try
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Please give the valid input");
                }
                highestFrequncyCount = _textLibraryBusiness.GetHighestFrequencyCount(text);
            }
            catch (Exception ex)
            {
                //TODO:Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok(highestFrequncyCount);
        }

        /// <summary>
        /// To get the frquency count for the word from the given text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpGet("/FrequencyForWord")]
        public IActionResult GetFrequencyForWord(string text, string word)
        {
            int frequncyCount;
            try
            {
                //Validation
                if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(word))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Please give the valid input");
                }
                frequncyCount = _textLibraryBusiness.GetFrequencyForWord(text, word);
            }
            catch (Exception ex)
            {
                //TODO:Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok(frequncyCount);
        }

        /// <summary>
        /// To get the most frequency N words from text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        [HttpGet("/MostFrequentNWords")]
        public IActionResult GetMostFrequentNWords(string text, int n)
        {
            IList<IWordFrequency> mostFrequentNWords;
            try
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Please give the valid input");
                }
                mostFrequentNWords = _textLibraryBusiness.GetMostFrequentNWords(text, n);
            }
            catch (Exception ex)
            {
                //TODO:Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok(mostFrequentNWords);
        }
    }
}
