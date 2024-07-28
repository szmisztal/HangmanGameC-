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
        List<string> words = new List<string>() { 
            "Alohomora", 
            "Sectumsempra",
            "Expelliarmus",
            "Avada Kedavra",
            "Petrificus Totalus",
            "Expecto Patronum",
            "Wingardium Leviosa",
            "Riddikulus",
            "Imperius Curse",
            "Locomotor Wibbly" };
        int mistakes = 0;
        public Dictionary<int, string> gallows = new Dictionary<int, string>();

        public void AddGallowsDrawingsToDict()
        {
            gallows.Add(1, "/");
            gallows.Add(2, "/ \\");
            gallows.Add(3, " | \n/ \\");
            gallows.Add(4, " | \n | \n/ \\");
            gallows.Add(5, " | \n | \n | \n/ \\");
            gallows.Add(6, " _\n | \n | \n | \n/ \\");
            gallows.Add(7, " __\n | \n | \n | \n/ \\");
            gallows.Add(8, " ___\n | \n | \n | \n/ \\");
            gallows.Add(9, " ___\n | O\n | \n | \n/ \\");
            gallows.Add(10, " ___\n | O\n |/\n | \n/ \\");
            gallows.Add(11, " ___\n | O\n |/\\\n | \n/ \\");
            gallows.Add(12, " ___\n | O\n |/|\\\n | \n/ \\");
            gallows.Add(13, " ___\n | O\n |/|\\\n |/ \n/ \\");
            gallows.Add(14, " ___\n | O\n |/|\\\n |/ \\ \n/ \\");
        }

        public string WordDraw()
        {
            return words[rng.Next(0, 10)];
        }

        public string GuessedWord(List<char> letters, string word, char letter)
        {
            letters.Add(letter);
            string guessedWord = "";
            foreach (char c in word)
            {
                if (letters.Contains(c)) { guessedWord += c; }
                else if (c == ' ') {  guessedWord += " "; }
                else { guessedWord += "_"; }
            }
            return guessedWord;
        }
    }
}
