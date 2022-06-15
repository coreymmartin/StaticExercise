using System;
using System.Collections.Generic;
using System.Text;

namespace StaticExercise
{
    internal class Program
    {
        public static double AskForDouble(string msg = "please enter a number")
        {
            bool gotDouble = false;
            double userDouble;
            do {
                Console.Clear();
                Console.Write(msg);
                gotDouble = double.TryParse(Console.ReadLine(), out userDouble); 
            } while (!gotDouble);
            return userDouble;
        }

        public static double PercentError(double actual, double expected)
        {
            return Math.Round(Math.Abs((actual - expected) / expected) * 100, 2);
        }
        
        public static void GuessTempConversion()
        {
            int numOptions = (TempConverter.bEnableKelvin) ? 3 : 2;
            Random rand = new Random();
            int option = rand.Next(1, numOptions);
            double temp;
            double guess;
            double answer;
            double goodjob;
            string symbol;
            string response;
            switch(option){
                case 1:
                    temp = TempConverter.RandomCelcius();
                    symbol = "C";
                    response = (TempConverter.bEnableKelvin) ? "Kelvin" : "Fahrenheit";
                    guess = AskForDouble($"convert {temp} {symbol} to {response}.\ninput your answer and press enter...\n");
                    answer = (TempConverter.bEnableKelvin) ? TempConverter.CelciusToKelvin(temp) : TempConverter.CelciusToFahrenheit(temp);
                    goodjob = PercentError(guess, answer);
                    Console.WriteLine($"\ncorrect answer: {answer}, your guess:{guess}, percent error: {goodjob}%");
                    TempConverter.updateStats(goodjob); 
                    break;
                case 2:
                    temp = TempConverter.RandomFahrenheit();
                    symbol = "F";
                    response = (TempConverter.bEnableKelvin) ? "Kelvin" : "Celcius";
                    guess = AskForDouble($"convert {temp} {symbol} to {response}.\ninput your answer and press enter...\n");
                    answer = (TempConverter.bEnableKelvin) ? TempConverter.FahrenheitToKelvin(temp) : TempConverter.FahrenheitToCelcius(temp);
                    goodjob = PercentError(guess, answer);
                    Console.WriteLine($"\ncorrect answer: {answer}, your guess:{guess}, percent error: {goodjob}%");
                    TempConverter.updateStats(goodjob); 
                    break;
                case3:
                    temp = TempConverter.RandomKelvin();
                    symbol = "K";
                    response = "Fahrenheit";
                    guess = AskForDouble($"convert {temp} {symbol} to {response}.\ninput your answer and press enter...\n");
                    answer = TempConverter.KelvinToFahrenheit(temp);
                    goodjob = PercentError(guess, answer);
                    Console.WriteLine($"\ncorrect answer: {answer}, your guess:{guess}, percent error: {goodjob}%");
                    TempConverter.updateStats(goodjob); 
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("studies have shown its easier to just become familar with the temperature difference rather than doing the math" +
                "\nuse this tool to increase your familiararity with Celcius and Fahrenheit");
            bool userHasInterest = true;
            while (userHasInterest) {
                Console.WriteLine("\nSelect an option\n1. Train\n2. Enable/Disable Kelvin\n3. Exit");
                bool inputOK = false;
                int userInput;
                do { inputOK = int.TryParse(Console.ReadLine(), out userInput); }
                while (!inputOK);
                switch (userInput)
                {
                    case 1:
                        GuessTempConversion();
                        break;
                    case 2:
                        TempConverter.bEnableKelvin = !TempConverter.bEnableKelvin;
                        Console.WriteLine($"enable kelvin temp conversions: {TempConverter.bEnableKelvin}");
                        break;
                    case 3:
                        userHasInterest = false;
                        Console.WriteLine("goodbye my friend, good luck with your future temperature conversion!\n");
                        TempConverter.PrintStats();
                        Console.WriteLine("\npress enter to quit...\n");
                        break;
                    default:
                        Console.WriteLine("whoops. try again");
                        break;
                }
            }
        }
    }
}
