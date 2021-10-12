using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyAdditiveRatioAssessment
{
    public class ConsoleInput
    {




        public static int ReadInt()
        {
            int result;
            bool success;
            do
            {
                Console.WriteLine("Please enter an integer:");
                Console.Write(">");
                string input = Console.ReadLine();
                success = ValidateInt(input, out result);
                if (!success)
                    Console.WriteLine("Invalid number!");
            } while (!success);
            return result;
        }

        public static int ReadIntAboveOrEquals(int compared)
        {
            int result;
            bool success;
            do
            {
                result = ReadInt();
                success = ValidateIntAboveOrEquals(result, compared);
                if (!success)
                    Console.WriteLine("Invalid number!");
            } while (!success);
            return result;
        }



        public static bool ValidateInt(string value, out int result) => int.TryParse(value, out result);


        public static bool ValidatePositiveInt(int value) => value > 0;

        public static bool ValidateIntAboveOrEquals(int value, int compared)
        {
            if (value >= compared)
                return true;
            Console.WriteLine($"Incorrect number = {value}. Number must be >= {compared}.");
            return false;
        }

        public static string ChooseFrom(string[] variants)
        {
            string result;
            bool success = false;
            do
            {
                Console.WriteLine("Please choose from variants: { " + String.Join(" ", variants) + " }.");
                Console.Write(">");
                result = Console.ReadLine();
                foreach (string temp in variants)
                    if (result == temp)
                    {
                        success = true;
                        break;
                    }
                if (!success)
                    Console.WriteLine("Invalid variant!");
            } while (!success);
            return result;
        }
    }
}
