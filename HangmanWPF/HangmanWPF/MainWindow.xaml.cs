﻿using System.Diagnostics.Tracing;
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
        List<char> letters = new List<char>();
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
        string word;
        int mistakes;

        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private string HiddenGuessedWord(string word)
        {
            string guessedWord = "";
            foreach (char c in word)
            {
                if (letters.Contains(c)) { guessedWord += c; }
                else if (c == ' ') { guessedWord += " "; }
                else { guessedWord += "_"; }
            }
            guessedWordTextBlock.Text = guessedWord;
            return guessedWord;
        }

        private void inputLetterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            { 
                string inputText = inputLetterTextBox.Text;
                if (!string.IsNullOrEmpty(inputText) && inputText.Length == 1)
                {
                    char letter = inputText[0];
                    CheckInputLetter(letter, word);
                    string hiddenWord = HiddenGuessedWord(word);
                    guessedWordTextBlock.Text = hiddenWord;
                    bool gameStatus = CheckGameStatus(hiddenWord);
                    if (gameStatus) { EndGame(); };
                    gallowsTextBlock.Text = gallows[mistakes];
                    inputLetterTextBox.Clear();
                }
            }
        }

        private void CheckInputLetter(char letter, string guessedWord)
        {
            if (letters.Contains(letter)) { mistakes++; }
            else if (!letters.Contains(letter) && !guessedWord.Contains(letter)) { letters.Add(letter); mistakes++; }
            else { letters.Add(letter); }
        }

        private bool CheckGameStatus(string guessedWord)
        {
            if (!guessedWord.Contains("_") || mistakes >= 14) { return true; }
            return false;
        }

        private void SetUpGame()
        {
            word = words[rng.Next(0, words.Count())].ToLower();
            words.Remove(word);
            letters.Clear();
            mistakes = 0;
        }

        private void EndGame()
        {
            inputLetterTextBox.IsEnabled = false;
            inputLetterTextBox.Visibility = Visibility.Hidden;
            if (mistakes >= 14 ) { typeLetterTextBlock.FontSize = 24; typeLetterTextBlock.Text = "You loose, guessed word was: " + "'" + word.ToUpper() + "'"; }
            else { typeLetterTextBlock.Text = "You win! "; }
        }

    }
}