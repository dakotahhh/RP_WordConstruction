using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_WordConstruction
{
    public class WordConstruction
    {

        private List<string> validWordsSuperSet;
        private List<char> differentLetters;
        private List<string> subsetOfValidWords;
        private string longestWord;

        public WordConstruction()
        {
            validWordsSuperSet = new List<string>();
            differentLetters = new List<char>();
            subsetOfValidWords = new List<string>();
            longestWord = "";
        }

        public static void Main(string[] args)
        {
            WordConstruction wordConstruction = new WordConstruction();
            Console.WriteLine("Welcome to Word Construction. \n" +
                "Please submit a list of valid words as follows: { a, bb, ab, bbb, bab, bbbb } \n");
            wordConstruction.StartConstructions();
        }

        /// <summary>
        /// This method takes the users list of valid words and stores it in a string
        /// We then split this string to create a superset list called validWordsSuperSet
        /// We then take all distinct characters (other than commas) and store them in a char list. We do this so we have a list off all the chars we can work with and are valid to use.
        /// We add the initial letter to the subset of valid words as this is what we will start working with.
        /// We then call the AddSecondLetter method.
        /// </summary>
        private void StartConstructions()
        {
            string validWords = Console.ReadLine().TrimStart('{').TrimEnd('}').Replace(" ", "");
            validWordsSuperSet = validWords.Split(',').ToList();
            differentLetters = validWords.Replace(",", "").Distinct().ToList();
            longestWord = validWordsSuperSet.OrderByDescending(s => s.Length).FirstOrDefault();
            Console.WriteLine("Submit any letter (a-z) to start with.");
            string stepOneLetter = Console.ReadLine();
            subsetOfValidWords.Add(stepOneLetter);
            AddSecondLetter(stepOneLetter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stepOneLetter">The valid word we are working with</param>
        private void AddSecondLetter(string validWord)
        {
            while(longestWord.Length > validWord.Length)
            {
                Console.WriteLine("Submit a second letter a-z");
                string stepTwoLetter = Console.ReadLine();
                string possibleValidWord = string.Empty;
                Random randomInsert = new Random();
                //string wordToManipulate = subsetOfValidWords.Last();
                string wordToManipulate = validWord;
                string whatIs = "";
                int whichInsert;
                if (!subsetOfValidWords.Contains(stepTwoLetter))
                {
                    whichInsert = randomInsert.Next(1, 3);
                    switch (whichInsert)
                    {
                        case 1:
                            //beginning
                            whatIs = wordToManipulate.Insert(0, stepTwoLetter);
                            break;
                        case 2:
                            //end
                            whatIs = wordToManipulate.Insert(wordToManipulate.Length, stepTwoLetter);
                            break;
                        case 3:
                            //middle
                            whatIs = wordToManipulate.Insert((wordToManipulate.Length / 2), stepTwoLetter);
                            break;
                        default:
                            break;
                    }
                }
                if (!subsetOfValidWords.Contains(stepTwoLetter))
                {
                    subsetOfValidWords.Add(possibleValidWord);
                }
                AddSecondLetter(subsetOfValidWords.Last());
            }
            //Console.WriteLine("Submit a second letter a-z");
            //stepTwoLetter = Console.ReadLine();
            //whichInsert = randomInsert.Next(1, 3);
            //switch (whichInsert)
            //{
            //    case 1:
            //        whatIs = wordToManipulate.Insert(0, stepTwoLetter);
            //        break;
            //    case 2:
            //        whatIs = wordToManipulate.Insert(wordToManipulate.Length, stepTwoLetter);
            //        break;
            //    case 3:
            //        //middle
            //        whatIs = wordToManipulate.Insert((wordToManipulate.Length / 2), stepTwoLetter);
            //        break;
            //    default:
            //        break;
            //}
            //if (!subsetOfValidWords.Contains(stepTwoLetter))
            //{
            //    subsetOfValidWords.Add(possibleOutcome);
            //}
            bool pass = true;
            string subSet = "{";
            if (subsetOfValidWords.Count == validWordsSuperSet.Count)
            {
                foreach (string s in subsetOfValidWords)
                {
                    if (!validWordsSuperSet.Contains(s))
                        pass = false;
                    subSet += s;
                }
            }
            subSet += "}";
            Console.WriteLine(subSet);
            Console.WriteLine("This subSet " + pass);
            Console.ReadLine();
        }
    }
}
