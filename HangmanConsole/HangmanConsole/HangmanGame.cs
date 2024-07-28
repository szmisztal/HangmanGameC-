using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanConsole
{
    internal class HangmanGame
    {
        Random rng = new Random();
        List<string> words = new List<string>() 
        { 
            "Alohomora", 
            "Sectumsempra",
            "Expelliarmus",
            "Avada Kedavra",
            "Petrificus Totalus",
            "Expecto Patronum",
            "Wingardium Leviosa",
            "Riddikulus",
            "Imperius Curse",
            "Locomotor Wibbly" 
        };
        public List<char> letters = new List<char>();
        public int mistakes = 0;
        public Dictionary<int, string> gallows = new Dictionary<int, string>()
        {
            { 0, " " },
            { 1, "/" },
            { 2, "/ \\" },
            { 3, " | \n/ \\" },
            { 4, " | \n | \n/ \\" },
            { 5, " | \n | \n | \n/ \\" },
            { 6, " _\n | \n | \n | \n/ \\" },
            { 7, " __\n | \n | \n | \n/ \\" },
            { 8, " ___\n | \n | \n | \n/ \\" },
            { 9, " ___\n | O\n | \n | \n/ \\" },
            { 10, " ___\n | O\n |/\n | \n/ \\" },
            { 11, " ___\n | O\n |/\\\n | \n/ \\" },
            { 12, " ___\n | O\n |/|\\\n | \n/ \\" },
            { 13, " ___\n | O\n |/|\\\n |/ \n/ \\" },
            { 14, " ___\n | O\n |/|\\\n |/ \\ \n/ \\" }
        };

        public string WordDraw()
        {
            return words[rng.Next(0, 10)];
        }

        public string HiddenGuessedWord(string word)
        {
            string guessedWord = "";
            foreach (char c in word)
            {
                if (letters.Contains(c)) { guessedWord += c; }
                else if (c == ' ') {  guessedWord += " "; }
                else { guessedWord += "_"; }
            }
            return guessedWord;
        }

        public void CheckInputLetter(char letter, string guessedWord)
        {
            if (letters.Contains(letter)) { Console.WriteLine("Your letter is already on the list !"); mistakes++; }
            else if (!letters.Contains(letter) & !guessedWord.Contains(letter)) { letters.Add(letter); Console.WriteLine("Your letter isn`t in guessed word !"); mistakes++; }
            else { letters.Add(letter); Console.WriteLine("Correct ! Your letter is in guessed word !"); }
        }
        
        public bool CheckWordIsGuessed(string guessedWord)
        {
            if (guessedWord.Contains("_")) { return false; }
            return true;
        }
    }
}
