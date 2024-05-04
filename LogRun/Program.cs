// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using Exercise;
using Dialog;

namespace LogRun
{
    class Log
    {
        public static void Main(String[] args)
        {
            int selection = -1;
            DialogHelper dialogHandler = new DialogHelper();
            dialogHandler.TextWrapper("Welcome to LogRun! Enter 0 for menu.\nRemember to load your data before adding new content!");

            while (true)
            {
                if (dialogHandler.GetSelection(out selection))
                {
                    if (selection == 0)
                        dialogHandler.TextWrapper();
                    else if (selection == -1)
                        Console.WriteLine("Invalid Argument.");
                    else
                        Helper(selection);
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
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
                    ExerciseHandler();
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
                    DataHandler(0);
                    Console.WriteLine("Waiting to return...");
                    Console.ReadLine();
                    break;
                }
                // Save and Exit
                case 5:
                {
                    DataHandler(1);
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

        private static void ExerciseHandler()
        {
            Exercise.Workout workout = new Workout();
            workout.AddWorkout();
        }

        private static void DataHandler(int method)
        {

        }

    }

}
