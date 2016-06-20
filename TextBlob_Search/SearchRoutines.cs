using System;
using System.Collections.Generic;
using System.Linq;

namespace TextBlob_Search
{
    class SearchRoutines
    {
        // Lists for the string we are searching for within the document
        private static readonly List<string> SubSearchWordList = new List<string>();
        private static readonly List<string> SubCompareWordList = new List<string>();

        // Dictionary so that we can store the index of the section checked and the percentage value that it resembles the search string
        public Dictionary<int, float> ResultDictionary = new Dictionary<int, float>();

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="stringToSearchFor">String input we will be searching the document for</param>
        /// <param name="documentToSearch">String document that will be searched over</param>
        public SearchRoutines(string stringToSearchFor, string documentToSearch)
        {
            var documentParts = ParseDocument(documentToSearch);

            foreach (var section in documentParts)
            {
                // first find the difference in word count between the section of the document and string to search for
                var DifferenceInWordCount = SplitStrings(stringToSearchFor, section);

                // determine the match percentage
                var PercentageMatch = CompareStringsForMatch();

                // finally add the result to our ResultDictionary
                ResultDictionary.Add(DifferenceInWordCount, PercentageMatch);
            }
        }

        /// <summary>
        /// Method that will pick up the document that we are searching through and split them into
        /// paragraphs so that we can locate the section we are searching for.
        /// </summary>
        /// <param name="documentToSearch">Document we are searching to find a given section of text</param>
        private static IEnumerable<string> ParseDocument(string documentToSearch)
        {
            // TODO: split the document into paragraphs that can be broken down and compared to our section that we are searching for
            var partsArray = documentToSearch.Split(' ');
            return partsArray.ToList();
        }

        /// <summary>
        /// Method that will take both strings and split them into 4 word clusters so that we can compare the
        /// placement and similarity of both
        /// </summary>
        /// <param name="input">User input string that we will be searching the document for</param>
        /// <param name="documentSection">Section of the Document to compare against the inputString</param>
        /// <returns>Word count difference between the two strings</returns>
        private static int SplitStrings(string input, string documentSection)
        {
            var subStringCompare = input.Split(' ');
            var subStringSearch = documentSection.Split(new [] {' ', '.'});

            for(var i=0; i<subStringCompare.Length; i++)
            {
                SubSearchWordList.Add(String.Format("{0} {1} {2} {3}", subStringCompare[i], subStringCompare[i+1], subStringCompare[i+2], subStringCompare[i+3]));
                SubCompareWordList.Add(String.Format("{0} {1} {2} {3}", subStringSearch[i], subStringSearch[i+1], subStringSearch[i+2], subStringSearch[i+3]));
            }
            
            var lengthDifference = (subStringSearch.Length - subStringCompare.Length);
            return lengthDifference;
        }

        /// <summary>
        /// Using each section of the Document
        /// </summary>
        /// <returns>Percentage of how close the match between document section and the searched for string</returns>
        private static float CompareStringsForMatch()
        {
            // TODO: create algorithm to compare the sections of the document
            // not only does it need to be able to find typos, but also account for differing lengths of the search string and document
            return 0;
        }
    }
}
