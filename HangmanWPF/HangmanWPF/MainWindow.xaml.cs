using System.Diagnostics.Tracing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HangmanWPF
{
    public partial class MainWindow : Window
    {
        static Random rng = new Random();
        static List<string> words = new List<string>()
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
        static List<char> letters = new List<char>();
        int mistakes = 0;
        Dictionary<int, string> gallows = new Dictionary<int, string>()
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

        public MainWindow()
        {
            InitializeComponent();
        }

        static string WordDraw()
        {
            return words[rng.Next(0, 10)];
        }

        static string HiddenGuessedWord(string word)
        {
            string guessedWord = "";
            foreach (char c in word)
            {
                if (letters.Contains(c)) { guessedWord += c; }
                else if (c == ' ') { guessedWord += " "; }
                else { guessedWord += "_"; }
            }
            return guessedWord;
        }

        static string word = WordDraw();
        string hiddenWord = HiddenGuessedWord(word);

        private void inputLetterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            string letterString;
            if (e.Key == Key.Enter)
            {
                letterString = e.Key.ToString();
                char letter = letterString[0];         
                CheckInputLetter(letter, hiddenWord);
                gallowsTextBlock.Text = gallows[mistakes];
                inputLetterTextBox.Clear();
            }
        }

        public void CheckInputLetter(char letter, string guessedWord)
        {
            if (letters.Contains(letter)) { mistakes++; }
            else if (!letters.Contains(letter) & !guessedWord.Contains(letter)) { letters.Add(letter); mistakes++; }
            else { letters.Add(letter); }
        }

        public bool CheckWordIsGuessed(string guessedWord)
        {
            if (guessedWord.Contains("_")) { return false; }
            return true;
        }
    }
}