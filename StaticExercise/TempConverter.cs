using System;
using System.Collections.Generic;
using System.Text;


namespace StaticExercise
{
    public static class TempConverter
    {
        public static bool bEnableKelvin = false;
        public static int numConversions = 0;
        public static int numCorrectGuesses = 0;
        public static double avgError = 0;

        public static double FahrenheitToCelcius(double heat)
        {
            return (heat - 32.15) * (5.0/9.0);
        }

        public static double FahrenheitToKelvin(double heat)
        {
            return ((heat - 32.15) * (5.0 / 9.0) + 273.15);
        }

        public static double CelciusToFahrenheit(double heat)
        {
            return (heat * (9.0/5.0)) + 32.15;
        }

        public static double CelciusToKelvin(double heat)
        {
            return (heat + 273.15);
        }

        public static double KelvinToFahrenheit(double heat)
        {
            return (((heat - 273.15) * (9.0 / 5.0)) + 32.15);
        }

        public static double KelvinToCelcius(double heat)
        {
            return (heat - 273.15);
        }

        public static double RandomFahrenheit()
        {
            Random rand = new Random();
            double temp = rand.Next(-20000, 20000) / 100;
            return temp;
        }

        public static double RandomCelcius()
        {
            Random rand = new Random();
            double temp = rand.Next(-20000, 20000) / 100;
            return temp;
}

        public static double RandomKelvin()
        {
            Random rand = new Random();
            double temp = rand.Next(-50000, 50000) / 100;
            return temp;
        }

        public static void updateStats(double error)
        {
            numConversions++;
            avgError = avgError + ((error - avgError)/numConversions);
            numCorrectGuesses += (error < 2.5) ? 1 : 0;
        }

        public static void PrintStats()
        {
            Console.WriteLine($"total conversions:{numConversions}\ncorrect guesses:{numCorrectGuesses}\naverage error: {avgError}");
        }
    }
}
