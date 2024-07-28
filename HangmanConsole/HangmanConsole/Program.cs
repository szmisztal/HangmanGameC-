using System.Diagnostics.Tracing;

namespace HangmanConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman game !");
            HangmanGame game = new HangmanGame();
            string word = game.WordDraw();
            while (game.mistakes < 14)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine(game.gallows[game.mistakes]);
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Type a letter: ");
                string letter = Console.ReadLine();
                bool checkInputLength = CheckInputLength(letter);
                if (!checkInputLength) { Console.WriteLine("Type a single letter !"); game.mistakes++; continue; }
                Console.WriteLine("---------------------------------");
                game.CheckInputLetter(letter[0], word.ToLower());
                Console.WriteLine("---------------------------------");
                string hiddenGuessedWord = game.HiddenGuessedWord(word.ToLower());
                Console.WriteLine(hiddenGuessedWord);
                bool checkWordIsGuessed = game.CheckWordIsGuessed(hiddenGuessedWord);
                if (checkWordIsGuessed) { break; }
            }
            if (game.mistakes == 14) { Console.WriteLine(game.gallows[14] + "\nYou're hanging ! Guessed word was : " + word); }
            else { Console.WriteLine("You`re winner ! Your mistakes counter is: " + game.mistakes); }
        }

        static private bool CheckInputLength(string input)
        {
            if (input.Length == 1) { return true; }
            else { return false; }
        }
    }
}