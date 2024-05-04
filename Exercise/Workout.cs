using System;
using System.Text.RegularExpressions;

namespace Exercise
{
    public class Workout
    {
        public string Duration { get; set; }
        public string Distance { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }

        public bool AddWorkout()
        {
            Dialog.DialogHelper dialog = new Dialog.DialogHelper();
            dialog.TextWrapper("Select an exercise:\n1. Run\n2. Weight Training");
            if (dialog.GetSelection(out int selection))
            {
                if (selection == 1)
                {
                    Console.WriteLine("Adding Running Workout:");
                    CollectWorkoutDetails();
                    return EditAndConfirmDetails();
                }
                else if (selection == 2)
                {
                    Console.WriteLine("Adding Weight Training (Details not implemented)");
                    return false;  // Or implement similarly
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                    return false;
                }
            }
            return false;
        }

        private void CollectWorkoutDetails()
        {
            this.Duration = DurationHelper();
            this.Distance = DistanceHelper();
            this.Date = DayHelper();
            this.Type = TypeHelper();
        }

        private bool EditAndConfirmDetails()
        {
            int editChoice;
            Dialog.DialogHelper dialog = new Dialog.DialogHelper();

            while (true)
            {
                Console.WriteLine("\nCurrent Workout Details:");
                Console.WriteLine($"1. Duration: {Duration}");
                Console.WriteLine($"2. Distance: {Distance} miles");
                Console.WriteLine($"3. Date: {Date}");
                Console.WriteLine($"4. Type: {Type}");
                Console.WriteLine("5. Confirm and Save");
                Console.WriteLine("6. Cancel");
                Console.WriteLine("Select the number to edit, or confirm/save:");

                if (!dialog.GetSelection(out editChoice))
                {
                    Console.WriteLine("Invalid input, please enter a number.");
                    continue;
                }

                switch (editChoice)
                {
                    case 1:
                        Duration = DurationHelper();
                        break;
                    case 2:
                        Distance = DistanceHelper();
                        break;
                    case 3:
                        Date = DayHelper();
                        break;
                    case 4:
                        Type = TypeHelper();
                        break;
                    case 5:
                        Console.WriteLine("Workout details saved successfully.");
                        return true;
                    case 6:
                        Console.WriteLine("Workout not saved.");
                        return false;
                    default:
                        Console.WriteLine("Invalid selection. Please select a valid option.");
                        continue;
                }
            }
        }

        private string DurationHelper()
        {
            Console.Write("Enter your duration (HH:MM:SS): ");
            string input = Console.ReadLine();
            string pattern = @"^(0?[0-9]|[1-9][0-9]):([0-5][0-9]):([0-5][0-9])$";
            if (Regex.IsMatch(input, pattern))
                return input;
            else
            {
                Console.WriteLine("Invalid duration format. Please enter in HH:MM:SS format.");
                return Duration;  // Return the previous value if input is invalid
            }
        }

        private string DistanceHelper()
        {
            Console.Write("Enter the distance (in miles, e.g., '5.3'): ");
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out decimal _))
                return input;
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                return Distance;  // Return the previous value if input is invalid
            }
        }

        private string DayHelper()
        {
            Console.Write("Enter the date (MM/DD/YYYY): ");
            string input = Console.ReadLine();
            string pattern = @"^(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])/\d{4}$";
            if (Regex.IsMatch(input, pattern))
                return input;
            else
            {
                Console.WriteLine("Invalid date format.");
                return Date;  // Return the previous value if input is invalid
            }
        }

        private string TypeHelper()
        {
            Console.Write("Enter the type of run (e.g., 'Interval', 'Long Run'): ");
            string input = Console.ReadLine();
            return input;  // Assuming no validation needed here
        }
    }
}
