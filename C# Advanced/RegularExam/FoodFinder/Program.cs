using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zad1SecondAttempt
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine()
                .Split(" ").Select(x => char.Parse(x)));
            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(" ").Select(x => char.Parse(x)));

            List<char> pearWord = "pear".ToCharArray().ToList();
            List<char> flourWord = "flour".ToCharArray().ToList();
            List<char> porkWord = "pork".ToCharArray().ToList();
            List<char> oliveWord = "olive".ToCharArray().ToList();

            while (consonants.Count > 0)
            {
                char currConsonantChar = consonants.Pop();
                char currVowelChar = vowels.Dequeue();
                vowels.Enqueue(currVowelChar);

                foundAndRemove(pearWord, currVowelChar);
                foundAndRemove(flourWord, currVowelChar);
                foundAndRemove(porkWord, currVowelChar);
                foundAndRemove(oliveWord, currVowelChar); 
                
                foundAndRemove(pearWord, currConsonantChar);
                foundAndRemove(flourWord, currConsonantChar);
                foundAndRemove(porkWord, currConsonantChar);
                foundAndRemove(oliveWord, currConsonantChar);

            }
            int numberOfWordsFound = 0;
            var strB = new StringBuilder();
            if (pearWord.Count==0)
            {
                numberOfWordsFound++;
                strB.AppendLine("pear");
            }
            if (flourWord.Count == 0)
            {
                numberOfWordsFound++;
                strB.AppendLine("flour");
            }
            if (porkWord.Count == 0)
            {
                numberOfWordsFound++;
                strB.AppendLine("pork");
            }
            if (oliveWord.Count == 0)
            {
                numberOfWordsFound++;
                strB.AppendLine("olive");
            }
            Console.WriteLine($"Words found: {numberOfWordsFound}");
            if (numberOfWordsFound>0)
            {                
                Console.WriteLine(strB.ToString()); ;
            }
        }
        public static void foundAndRemove(List<char> listOfChars, char curChar)
        {
            for (int i = 0; i < listOfChars.Count; i++)
            {
                if (listOfChars[i] == curChar)
                {
                    listOfChars.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
