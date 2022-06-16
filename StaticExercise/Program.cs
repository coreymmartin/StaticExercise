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
        
        public static void Conversions()
        {
            bool gotInt = false;
            bool intGood = false;
            double temp;
            int userSelect;
            int numOptions = (TempConverter.bEnableKelvin) ? 6 : 2;
            do
            {
                Console.Clear();
                Console.WriteLine("Temperature Conversion:\nselect which conversion to apply:\n1. Celcius    -> Fahrenheit\n2. Fahrenheit -> Celcius");
                if (TempConverter.bEnableKelvin)
                    Console.WriteLine("3. Celcius    -> Kelvin\n4. Fahrenheit -> Kelvin\n5. Kelvin     -> Celcius\n6. Kelvin     -> Fahrenheit");
                gotInt = int.TryParse(Console.ReadLine(), out userSelect);
                intGood = (gotInt && userSelect <= numOptions + 1) ? true : false;
            } while (!intGood);
            temp = AskForDouble("please enter temperature value to convert...");
            switch (userSelect)
            {
                case 1:
                    Console.WriteLine($"{temp} Celcius = {Math.Round(TempConverter.CelciusToFahrenheit(temp), 2)} Fahrenheit");
                    break;
                case 2:
                    Console.WriteLine($"{temp} Fahrenheit = {Math.Round(TempConverter.FahrenheitToCelcius(temp), 2)} Celcius");
                    break;
                case 3:
                    Console.WriteLine($"{temp} Celcius = {Math.Round(TempConverter.CelciusToKelvin(temp), 2)} Kelvin");
                    break;
                case 4:
                    Console.WriteLine($"{temp} Fahrenheit = {Math.Round(TempConverter.FahrenheitToKelvin(temp), 2)} Kelvin");
                    break;
                case 5:
                    Console.WriteLine($"{temp} Kelvin = {Math.Round(TempConverter.KelvinToCelcius(temp), 2)} Celcius");
                    break;
                case 6:
                    Console.WriteLine($"{temp} Kelvin = {Math.Round(TempConverter.KelvinToFahrenheit(temp), 2)} Fahrenheit");
                    break;
                default:
                    Console.WriteLine("sorry, we have made a mistake");
                    break;
            }
            Console.WriteLine("press enter to continue...\n");
            Console.ReadLine();
            Console.Clear();
        }

        public static void GuessTempConversion()
        {
            Console.WriteLine("studies have shown its easier to just become familar with the temperature difference rather than doing the math" +
                "\nuse this tool to increase your familiararity with Celcius and Fahrenheit");
            Random rand = new Random();
            int option = (TempConverter.bEnableKelvin) ? rand.Next(1, 4) : rand.Next(1, 3);
            double temp;
            double guess;
            double answer;
            double goodjob;
            string symbol;
            string response;
            switch(option){
                case 1:
                    temp = TempConverter.RandomCelcius();
                    symbol = "Celcius";
                    response = (TempConverter.bEnableKelvin) ? "Kelvin" : "Fahrenheit";
                    guess = AskForDouble($"convert {temp} {symbol} to {response}.\ninput your answer and press enter...\n");
                    answer = (TempConverter.bEnableKelvin) ? TempConverter.CelciusToKelvin(temp) : TempConverter.CelciusToFahrenheit(temp);
                    goodjob = PercentError(guess, answer);
                    Console.WriteLine($"\ncorrect answer: {Math.Round(answer, 2)}, your guess:{guess}, percent error: {goodjob}%");
                    TempConverter.updateStats(goodjob); 
                    break;
                case 2:
                    temp = TempConverter.RandomFahrenheit();
                    symbol = "Fahrenheit";
                    response = (TempConverter.bEnableKelvin) ? "Kelvin" : "Celcius";
                    guess = AskForDouble($"convert {temp} {symbol} to {response}.\ninput your answer and press enter...\n");
                    answer = (TempConverter.bEnableKelvin) ? TempConverter.FahrenheitToKelvin(temp) : TempConverter.FahrenheitToCelcius(temp);
                    goodjob = PercentError(guess, answer);
                    Console.WriteLine($"\ncorrect answer: {Math.Round(answer, 2)}, your guess:{guess}, percent error: {goodjob}%");
                    TempConverter.updateStats(goodjob); 
                    break;
                case 3:
                    temp = TempConverter.RandomKelvin();
                    symbol = "Kelvin";
                    response = "Fahrenheit";
                    guess = AskForDouble($"convert {temp} {symbol} to {response}.\ninput your answer and press enter...\n");
                    answer = TempConverter.KelvinToFahrenheit(temp);
                    goodjob = PercentError(guess, answer);
                    Console.WriteLine($"\ncorrect answer: {Math.Round(answer, 2)}, your guess:{guess}, percent error: {goodjob}%");
                    TempConverter.updateStats(goodjob); 
                    break;
            }
            Console.WriteLine("\npress enter to continue...\n");
            Console.ReadLine();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            bool userHasInterest = true;
            while (userHasInterest) {
                Console.WriteLine("Temperature is Cool!\n\nSelect an option\n1. Conversion\n2. Train\n3. Enable/Disable Kelvin\n4. Exit\n");
                bool inputOK = false;
                int userInput;
                do { inputOK = int.TryParse(Console.ReadLine(), out userInput); }
                while (!inputOK);
                switch (userInput)
                {
                    case 1:
                        Conversions();
                        break;
                    case 2:
                        GuessTempConversion();
                        break;
                    case 3:
                        Console.Clear();
                        TempConverter.bEnableKelvin = !TempConverter.bEnableKelvin;
                        Console.WriteLine($"enable kelvin temp conversions: {TempConverter.bEnableKelvin}.\npress enter to continue...\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        userHasInterest = false;
                        Console.Clear();
                        Console.WriteLine("\ngoodbye my friend, good luck with your future temperature conversions!\n");
                        if (TempConverter.numConversions > 0)
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
