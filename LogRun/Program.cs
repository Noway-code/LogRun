// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;

namespace LogRun
{
    class Dialog
    {
        const string Menu = "1. Add Exercise.\n2. View Graphs.\n3. View Logs.\n4. Load Data\n5. Save and Exit.";

        public void TextWrapper(string str = Menu)
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

            dialog.TextWrapper("Welcome to LogRun! Enter 0 for menu.\nRemember to load your data before adding new content!");

            while (true)
            {
                Console.Write("Select your choice: ");
                if (int.TryParse(Console.ReadLine(), out selection))
                {

                    if (selection == 0)
                        dialog.TextWrapper();
                    else
                    {
                        Helper(selection);
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Invalid Arguement. ");
                    selection = -1;
                }
            }
        }

        public static void Helper(int selection)
        {
            Console.WriteLine($"Selection {selection}");
            switch (selection)
            {
                // Add Exercise
                case 1:
                {
                    // ExerciseHandler();
                    Console.WriteLine("Waiting to return...");
                    Console.ReadLine();
                    break;
                }
                // View Graphs
                case 2:
                {
                    Console.WriteLine("Waiting to return...");
                    Console.ReadLine();
                    break;
                }
                // View Logs
                case 3:
                {
                    Console.WriteLine("Waiting to return...");
                    Console.ReadLine();
                    break;
                }
                // Load Data
                case 4:
                {
                    Console.WriteLine("Waiting to return...");
                    Console.ReadLine();
                    break;
                }
                // Save and Exit
                case 5:
                {
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                }
                default:
                {
                    Console.WriteLine("No option found.");
                    return;
                }

            }
        }


    }

}
