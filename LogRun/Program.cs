// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
using Newtonsoft.Json;
using Exercise;
using Dialog;

namespace LogRun
{
    class Log
    {
        static string _dataFilePath = "/home/noway/RiderProjects/LogRun/LogRun/workouts.json";
        static List<Exercise.Workout> workouts = new List<Exercise.Workout>();

        public static void Main(String[] args)
        {
            int selection = -1;

            DialogHelper dialogHandler = new DialogHelper();
            dialogHandler.TextWrapper("Welcome to LogRun! Enter 0 for menu.\nRemember to load your data before adding new content!");

            LoadData();

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
                    LoadData();
                    Console.WriteLine("Waiting to return...");
                    Console.ReadLine();
                    break;
                }
                // Save and Exit
                case 5:
                {
                    SaveData();
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

            if (workout.AddWorkout())
            {
                workouts.Add(workout);
            }
        }

        private static void LoadData()
        {
            if (File.Exists(_dataFilePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(_dataFilePath);
                    workouts = JsonConvert.DeserializeObject<List<Exercise.Workout>>(jsonData) ?? new List<Exercise.Workout>();
                    Console.WriteLine("Data loaded successfully.");
                    DisplayLoadedWorkouts();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to load data: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("No saved data found.");
            }
        }

        private static void DisplayLoadedWorkouts()
        {
            if (workouts.Count == 0)
            {
                Console.WriteLine("No workouts to display.");
                return;
            }
            Console.WriteLine("Displaying loaded workouts:");
            foreach (var workout in workouts)
            {
                Console.WriteLine($"Type: {workout.Type}, Date: {workout.Date}, Duration: {workout.Duration}, Distance: {workout.Distance} miles");
            }
        }

        private static void SaveData()
        {
            if (workouts.Count == 0)
            {
                workouts.Add(new Workout
                {
                    Duration = "00:30:00",
                    Distance = "5.0",
                    Date = "05/04/2024",
                    Type = "Interval"
                });
                workouts.Add(new Workout
                {
                    Duration = "01:00:00",
                    Distance = "10.0",
                    Date = "05/05/2024",
                    Type = "Long Run"
                });
            }

            string jsonData = JsonConvert.SerializeObject(workouts, Formatting.Indented);
            File.WriteAllText(_dataFilePath, jsonData);
            Console.WriteLine("Data saved successfully.");

        }
    }

}
