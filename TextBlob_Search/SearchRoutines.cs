using System;
using System.Collections.Generic;

namespace TextBlob_Search
{
    class SearchRoutines
    {
        // Lists for the string we are searching for within the document
        private static readonly List<string> SubSearchCharList = new List<string>();
        private static readonly List<string> SubSearchWordList = new List<string>();
        // Lists for the document so that we can compare with the string to search
        private static readonly List<string> SubCompareCharList = new List<string>(); 
        private static readonly List<string> SubCompareWordList = new List<string>();
        // List containing sections (paragraphs) of our original document to be 
        private static List<string> _documentParts = new List<string>();
        // Values for char/word difference after String.Split
        public int DifferenceInCharCount;
        public int DifferenceInWordCount;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="stringToSearchFor">String input we will be searching the document for</param>
        /// <param name="documentToSearch">String document that will be searched over</param>
        public SearchRoutines(string stringToSearchFor, string documentToSearch)
        {
            _documentParts = ParseDocument(documentToSearch);

            foreach (var section in _documentParts)
            {
                DifferenceInCharCount = SplitStrings_Char(stringToSearchFor, section);
                DifferenceInWordCount = SplitStrings_Word(stringToSearchFor, section);
            }
            
        }

        /// <summary>
        /// Method that will pick up the document that we are searching through and split them into
        /// paragraphs so that we can locate the section we are searching for.
        /// </summary>
        /// <param name="documentToSearch">Document we are searching to find a given section of text</param>
        private static List<string> ParseDocument(string documentToSearch)
        {
            var documentPartsList = new List<string>();
            var partsArray = documentToSearch.Split(' ');
            documentPartsList.Add(partsArray[0]);
            //TODO: split the document into paragraphs that can be broken down and compared to our section that we are searching for
            return documentPartsList;
        }

        /// <summary>
        /// Method that will divide each string into 4 char length clusters to be more easily compared
        /// to each other, taking into account typos in random locations.
        /// </summary>
        /// <param name="input">User input string that we will be searching the document for</param>
        /// <param name="documentSection">Section of our Document to compare against the inputString</param>
        /// <returns>Int value indicating the difference in string lengths</returns>
        private static int SplitStrings_Char(string input, string documentSection)
        {
            var lengthDifference = (documentSection.Length - input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                var subStringCompare = input.Substring(i, 4);
                var subStringSearch = _documentParts[0].Substring(i, 4);
                SubCompareCharList.Add(subStringCompare);
                SubSearchCharList.Add(subStringSearch);
            }
            
            return lengthDifference;
        }

        /// <summary>
        /// Method that will take both strings and split them into 4 word clusters so that we can compare the
        /// placement and similarity of both
        /// </summary>
        /// <param name="input">User input string that we will be searching the document for</param>
        /// <param name="documentSection">Section of the Document to compare against the inputString</param>
        /// <returns>Word count difference between the two strings</returns>
        private static int SplitStrings_Word(string input, string documentSection)
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
    }
}
