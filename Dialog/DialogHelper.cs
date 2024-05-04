namespace Dialog
{
    public class DialogHelper
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

        public bool GetSelection(out int selection)
        {
            Console.Write("Select your choice: ");
            return int.TryParse(Console.ReadLine(), out selection) && selection >= -1;
        }
    }
}

