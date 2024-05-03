// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;

namespace LogRun
{
    class Dialog
    {
        const string menu = "1. Add Exercise.\n2. View Graphs.\n3. View Data.\n4. Save and Exit.";

        public void TextWrapper(string str = menu)
        {
            string [] substrings= str.Split('\n');
            int maxLength = substrings.Max(s => s.Length);
            int numSubstrings = substrings.Length;

            // Print top border
            Console.Write("+");
            for (int i = 0; i < maxLength + 2; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");

            // Print each line of the menu, wrapped in borders
            foreach (string s in substrings)
            {
                Console.WriteLine($"| {s.PadRight(maxLength)} |");
            }

            Console.Write("+");
            for (int i = 0; i < maxLength + 2; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("+");
            Console.WriteLine();

            // Console.WriteLine($"Number of lines (substrings): {numSubstrings}");
        }
    }


    class Log
    {
        public static void Main(String[] args)
        {
            int selection = -1;
            Dialog dialog = new Dialog();

            dialog.TextWrapper("Welcome to LogRun! Enter 0 for menu.");
            Console.Write("Please select your choice: ");
            while (selection == -1)
            {
                if (int.TryParse(Console.ReadLine(), out selection))
                {
                    if (selection == 0)
                        dialog.TextWrapper();
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Please Try Again. Please select your choice: ");
                    selection = -1;
                }
            }
        }

        public static void Helper(int selection)
        {
        }


    }

}
