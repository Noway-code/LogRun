// See https://aka.ms/new-console-template for more information

namespace LogRun
{

    class Log
    {
        public static void Main(String[] args)
        {
            int selection = -1;

            Console.Write("Welcome to LogRun! Enter 0 for menu.\nPlease select your choice: ");
            while (selection == -1)
            {
                if (int.TryParse(Console.ReadLine(), out selection))
                {
                    if (selection == 0)
                    {
                        Console.WriteLine("");
                    }
                    Helper(selection);
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
