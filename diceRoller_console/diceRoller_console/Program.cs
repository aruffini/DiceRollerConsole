/*      Program Name: Dice Roller
 *      Created: 10/28/2018
 *      Author: Ashley Ruffini
 *      Purpose: Roll any number of the same sided dice and view their results
 *      
 *      Last Update: 10/28/2018 - Ashley Ruffini
 * */

using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows;
using System.Reflection;
using System.Diagnostics;


namespace diceRoller_console
{
    class Program
    {
        private static int numOfDice; //Number of dice being rolled 
        private static int diceSides;  //Type of di being rolled ie: d4, d8, d12...
        private static int startNum = 1; // This is the starting point for a di
        private static List<int> rollResults = new List<int>(); //List for roll results
        private readonly String sResponse = String.Empty;
        private static Regex regex = new Regex("[0-9\b]+");

        static void Main(string[] args)
        {
            PrintMessage("\nWelcome to Dice Roller!");
            PrintMessage("\nLet's get started.");
            PrintMessage("");
            PrintMessage("");
            PrintMessage("");
            GetNumOfDice();
            GetDiceSides();
            RandomRoller(numOfDice, diceSides);
            ShowResults();
            //ResetResults();
            RollAgain();
        }

        //Get the number for how many dice
        private static void GetNumOfDice()
        {
            PrintMessage("How many dice would you like to roll?");
            string number = Console.ReadLine();

            if (regex.IsMatch(number))
            {
                numOfDice = Convert.ToInt32(number);
                if(numOfDice < 0)
                {
                    PrintMessage("Please enter number greater then 0.");
                    GetNumOfDice();
                }
                else
                {
                    PrintMessage("");
                }
            }
            else
            {
                PrintMessage("Please enter number greater then 0.");
                GetNumOfDice();
            }

        }

        //Get the number inputed for the number of sides
        private static void GetDiceSides()
        {
            PrintMessage("How How many sides does your di have?");
            string number = Console.ReadLine();

            if (regex.IsMatch(number))
            {
                diceSides = Convert.ToInt32(number);
                if (diceSides < 0)
                {
                    PrintMessage("Please enter number greater then 0.");
                    GetDiceSides();
                }
                else
                {
                    PrintMessage("");
                }
            }
            else
            {
                PrintMessage("Please enter number greater then 0.");
                GetDiceSides();
            }

        }

        //Roll the dice
        private static void RandomRoller(int num, int sides)
        {

            int n = startNum; // set n = starting number on the di

            while (n <= num)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode()); // Seed the random number

                int result = rand.Next(startNum, sides + 1); // Use n incase the starting number needs to be increased for some reason. Add one to allow the max number to be included
                rollResults.Add(result); // Add result to the list 
                n++;
            }

        }

        //Show the roll results
        private static void ShowResults()
        {
            PrintMessage("\nYour Results for " + numOfDice + "d" + diceSides + ":\n\t");

            foreach (int result in rollResults)
            {
                Console.Write("[" + result + "]  ");
            }

            PrintMessage("");
        }

        private static void RollAgain()
        {
            PrintMessage("\n\nWould you like to roll again? (Y/N)");
            var info = Console.ReadKey();

            //if (info.ToString().ToUpper().Substring(0) == "Y")
            switch (info.Key)
            {
                case ConsoleKey.Y:
                    RestartProgram();
                    break;
                case ConsoleKey.N:
                    Environment.Exit(0);
                    break;
            }
        }

        //quickly print a message
        static void PrintMessage(string str)
        {
            Console.WriteLine(str);
        }

        // Reset the result list
        private static void ResetResults()
        {
            rollResults.Clear();
        }

        //Restart the Appication over
        private static void RestartProgram()
        {
            string[] args = new string[] {""};
            Console.Clear();
            Main(args);
        }

    }
}
