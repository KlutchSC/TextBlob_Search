using System;
using System.Collections.Generic;
using System.IO;

namespace TextBlob_Search
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter the file path to the document we are searching through.");
            var documentFilePath = Console.ReadLine();
            Console.WriteLine("Please enter the string to search the document for.");
            var inputTextBlob = Console.ReadLine();

            var documentToSearch = ReadDocumentFromFile(documentFilePath);

            var searchRoutine = new SearchRoutines(inputTextBlob, documentToSearch);

            DisplayResults(searchRoutine.ResultDictionary);
        }

        /// <summary>
        /// Method that will read in all text from a document that we will be searching over
        /// </summary>
        /// <param name="filePath">Path to the document file</param>
        /// <returns></returns>
        private static string ReadDocumentFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        /// <summary>
        /// Method to display the results of the section comparison
        /// </summary>
        /// <param name="results">actual result values from the comparison</param>
        private static void DisplayResults(Dictionary<int, float> results)
        {
            foreach (var result in results)
            {
                Console.WriteLine("Section had word count difference of {0} with {1} percentage match.", result.Key, result.Value);
            }
        }
    }
}
