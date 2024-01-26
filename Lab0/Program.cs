using System;
using System.Collections.Generic;
using System.IO;

namespace Lab0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input a low number:");
            //int low = Convert.ToInt32(Console.ReadLine());
            double low = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please input a high number:");
            //int high = Convert.ToInt32(Console.ReadLine());
            double high = Convert.ToDouble(Console.ReadLine());


            //Console.WriteLine($"Difference between low and high is: {high - low}");
            //Console.ReadKey();

            while (low <= 0) 
            {
                Console.WriteLine("Please input a positive low number:");
                low = Convert.ToInt32(Console.ReadLine());
            }

            while (high <= low)
            {
                Console.WriteLine($"Please input a high number that is greater than the low number ({low})");
                high = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine($"Difference between low and high is: {high - low}");
            Console.ReadKey();

            // ARRAY
            /*int[] numberArray = new int[high - low - 1];

            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = low + i + 1;
            }

            Array.Reverse( numberArray );*/

            // LIST
            List<Double> numberList = new List<Double>();
            for (Double i = high - low - 2; i >= 0; i--)
            {
                numberList.Add(low + i + 1);
            }

            string fileName = "numbers.txt";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Double number in numberList)//numberArray) // Using List<> instead of array[]
                {
                    writer.WriteLine(number);
                }
            }

            Console.WriteLine($"Numbers between {low} and {high} written to {fileName} in highest to lowest order.");
            Console.ReadKey();

            Double sum = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {

                while (!reader.EndOfStream)
                {
                    if (Double.TryParse(reader.ReadLine(), out Double number))
                    {
                        sum += number;
                    }
                }
            }
            Console.WriteLine($"Sum of numbers from {fileName}: {sum}");
            Console.ReadKey();

        }
    }
}
