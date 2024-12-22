using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        public static Random rng = new Random();
        public static bool cont = true;

        public static List<string> activities = new List<string>()
        {
            "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing",
            "Wine Tasting"
        };

        public static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            var userChoice = Console.ReadLine().ToLower();
            while (userChoice != "yes" && userChoice != "no")
            {
                Console.Write("Invalid Response!!! Please enter yes/no: ");
                userChoice = Console.ReadLine().ToLower();
            }

            if (userChoice == "no")
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            int userAge;
            Console.Write("What is your age? ");
            while (!int.TryParse(Console.ReadLine(), out userAge))
            {
                Console.Write("Invalid Age! Please enter a valid age: ");
            }

            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            userChoice = Console.ReadLine().ToLower();
            while (userChoice != "sure" && userChoice != "no thanks")
            {
                Console.Write("Invalid Response!!! Please enter Sure/No Thanks: ");
                userChoice = Console.ReadLine().ToLower();
            }

            if (userChoice == "sure")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();

                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                userChoice = Console.ReadLine().ToLower();
                while (userChoice != "yes" && userChoice != "no")
                {
                    Console.Write("Invalid Response! Please enter yes/no: ");
                    userChoice = Console.ReadLine().ToLower();
                }

                bool addToList = userChoice == "yes";
                Console.WriteLine();

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Would you like to add more? yes/no: ");
                    userChoice = Console.ReadLine().ToLower();
                    while (userChoice != "yes" && userChoice != "no")
                    {
                        Console.Write("Invalid Response! Please enter yes/no: ");
                        userChoice = Console.ReadLine().ToLower();
                    }
                    addToList = userChoice == "yes";
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}.");
                    Console.WriteLine("Picking something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                userChoice = Console.ReadLine().ToLower();

                while (userChoice != "keep" && userChoice != "redo")
                {
                    Console.Write("That was not a valid option. Please try again: Keep/Redo: ");
                    userChoice = Console.ReadLine().ToLower();
                }

                if (userChoice == "keep")
                {
                    cont = false;
                }
            }
        }
    }
}
