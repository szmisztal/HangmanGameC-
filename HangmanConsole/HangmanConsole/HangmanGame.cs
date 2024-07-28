using System;
using System.Collections.Generic;
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
        Dictionary<int, string> gallows = new Dictionary<int, string>();

        public void AddGallowsDrawingsToDict()
        {
            gallows.Add(1, "/");
            gallows.Add(2, "/ \\");
        }

        public void DictPrint()
        {
            foreach (var entry in gallows)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
