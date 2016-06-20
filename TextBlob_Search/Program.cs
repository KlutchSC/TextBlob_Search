using System;

namespace TextBlob_Search
{
    class Program
    {
        private const string DocumentToSearch = "";
        static void Main()
        {
            // Input string to compare with
            var inputTextBlob = Console.ReadLine();

            var searchRoutine = new SearchRoutines(inputTextBlob, DocumentToSearch);
            Console.WriteLine("The difference in character count is: {0}", searchRoutine.DifferenceInCharCount);
            Console.WriteLine("The difference in word count is: {0}", searchRoutine.DifferenceInWordCount);
        }
    }
}
