using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDay1
{
    internal class TPLParallelSortingPLINQ
    {
        public static async Task RunAsync()
        {
            int[] numbers = Enumerable.Range(1, 100).ToArray();

            //1. Sorted order
            Console.WriteLine("Sorted numbers are..");
            var sortedNumbers = numbers.AsParallel().OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join(",", sortedNumbers.Take(20)) + "..");

            //2. Prime numbers
            Console.WriteLine($"All prime numbers are..");
            var primes = numbers.AsParallel().Reverse().Where(IsPrime).ToArray();
            Console.WriteLine(string.Join(",", primes.Take(50)) + ".." + primes.Length);

            //3. Searching of any number in given data source wanted to see the number us present or not
            //if it is present so what is the index where it is present
            //Parallel for search
            Console.WriteLine("Enter any number from 1-100");
            int mySearchNumber = int.Parse(Console.ReadLine());

            bool found = false;
            Parallel.For(0, numbers.Length, (x, i) =>
            {
                if (numbers[x] == mySearchNumber)
                {
                    found = true;
                    Console.WriteLine($"Number found at index {x + 1}");
                    i.Stop();
                }
            });
            if (!found)
            {
                Console.WriteLine("Not exist in the given list");
            }


            //Highst and Lowest number in number array 1-100
            Console.WriteLine("Highest and Lowest numbers are..");

            int highest = 0;
            int lowest = numbers.AsParallel().Min();

            Parallel.For(0, numbers.Length, (x, i) =>
            {
                if (numbers[x] > highest)
                {
                    highest = numbers[x];
                }
            });


            Console.WriteLine($"Lowest:{lowest} Highest: {highest}");

        }
        static bool IsPrime(int number)
        {
            //if (number < 2)
            //{
            //    return false;
            //}
            //if (number == 2) { return true; }
            //for (int i = 2; i <= number; i++)
            //{
            //    if (number % 2 == 0) return false;
            //}
            //return true;

            if (number <= 1)
            {
                return false;
            }
            if (number == 2)
            {
                return true;
            }
            if (number % 2 == 0) return false;
            return true;
        }
    }
}
