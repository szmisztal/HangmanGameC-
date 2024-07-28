namespace HangmanConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HangmanGame game = new HangmanGame();
            game.AddGallowsDrawingsToDict();
            game.DictPrint();
        }
    }
}