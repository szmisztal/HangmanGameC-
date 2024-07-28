using System.Diagnostics.Tracing;

namespace HangmanConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> letters = new List<char>();

            Console.WriteLine("Welcome to Hangman game !");
            HangmanGame game = new HangmanGame();
            game.AddGallowsDrawingsToDict();
            string word = game.WordDraw();
            Console.WriteLine("Type a letter: ");
            string letterString = Console.ReadLine();
            char letter = letterString[0];
            string hiddenWord = game.CheckLetterInWord(letters, word, letter);
            Console.WriteLine(game.gallows[3]);
        }
    }
}