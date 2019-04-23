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
            Console.WriteLine("Welcome to Word Construction. \n");
            wordConstruction.StartConstructions();
            Console.WriteLine("Would you like to continue? Y or N");
            if (Console.ReadLine().Equals("Y"))
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
            Console.Write("Please submit a list of valid words as follows: { a, bb, ab, bbb, bab, bbbb } \n");
            string input = Console.ReadLine();
            if(input.Trim().StartsWith("{") && input.Trim().EndsWith("}"))
            {
                bool containsInt = input.Any(char.IsDigit);
                if(!containsInt)
                {
                    string validWords = input.TrimStart('{').TrimEnd('}').Replace(" ", "");
                    if (string.IsNullOrEmpty(validWords))
                    {
                        Console.WriteLine("Input cannot be empty.");
                        StartConstructions();
                    }
                    else
                    {
                        validWordsSuperSet = validWords.Split(',').ToList();
                        if (validWordsSuperSet.Count == 1)
                        {
                            Console.Write("{ ");
                            validWordsSuperSet.ForEach(Console.Write);
                            Console.Write(" } This subset passes.");
                            Console.ReadLine();
                        }
                        else
                        {
                            differentLetters = validWords.Replace(",", "").Distinct().ToList();
                            longestWord = validWordsSuperSet.OrderByDescending(s => s.Length).FirstOrDefault();
                            string stepOneLetter = InputCheck();
                            subsetOfValidWords.Add(stepOneLetter.ToString());
                            AddSecondLetter(stepOneLetter.ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Valid words must only be letters a-z");
                    StartConstructions();
                }
            }
            else
            {
                Console.WriteLine("Input must start and end with braces ( { and } )");
                StartConstructions();
            }
        }

        /// <summary>
        /// Checks if the letter inputted is only one letter and not a number
        /// </summary>
        /// <returns>The letter we received</returns>
        private string InputCheck()
        {
            Console.WriteLine("Submit any letter (a-z).");
            string input = Console.ReadLine();
            if (input.Length != 1 || input.Any(char.IsDigit))
            {
                Console.WriteLine("Please submit only one letter.");
                InputCheck();
            }
            return input;
        }

        /// <summary>
        /// First, we check if the length of the longestWord in the superset is still longer than the longest word in the subsetOfValidWords
        /// We ask the user to submit a second letter to manipulate the last word in the subssetOfValidWords
        /// We choose a "random" number to decide whether we are inserting at the beginning, middle, or end of the word we are manipulating
        /// We check if this new word is already in the subsetOfValidWords and if it isn't we add it to the subsetofValidWords
        /// We repeat this process until the length of the longest subsetword matches the length of the longest word in the superset
        /// </summary>
        /// <param name="stepOneLetter">The starting letter that kicks off the process</param>
        private void AddSecondLetter(string validWord)
        {
            string stepTwoLetter = "";
            string possibleValidWord = "";
            Random randomInsert = new Random();
            int whichInsert;
            string wordToManipulate = "";
            
            while(longestWord.Length > subsetOfValidWords.OrderByDescending(s => s.Length).FirstOrDefault().Length)
            {
                stepTwoLetter = InputCheck();
                wordToManipulate = subsetOfValidWords.Last();
                whichInsert = randomInsert.Next(1, 4);
                switch (whichInsert)
                {
                    case 1:
                        //beginning
                        possibleValidWord = wordToManipulate.Insert(0, stepTwoLetter);
                        break;
                    case 2:
                        //end
                        possibleValidWord = wordToManipulate.Insert(wordToManipulate.Length, stepTwoLetter);
                        break;
                    case 3:
                        //middle
                        possibleValidWord = wordToManipulate.Insert((wordToManipulate.Length / 2), stepTwoLetter);
                        break;
                    default:
                        break;
                }
                if (!subsetOfValidWords.Contains(possibleValidWord))
                {
                    subsetOfValidWords.Add(possibleValidWord);
                }
            }
            IsTheSubSetValid();
        }

        /// <summary>
        /// This method compares all the values in the subsetOfValidWords to find out if they are all in the validWordsSuperSet
        /// If so, we pass, if not, we fail
        /// </summary>
        public void IsTheSubSetValid()
        {
            bool pass = true;
            string subSet = "{";
            foreach (string s in subsetOfValidWords)
            {
                if (!validWordsSuperSet.Contains(s))
                    pass = false;
                subSet += (s + " ");
            }
            subSet += "}";
            Console.WriteLine(subSet);
            Console.WriteLine("This subSet " + (pass ? "passes" : "fails") + "\n\n");
        }
    }
}
