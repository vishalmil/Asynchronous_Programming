using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDay1
{
    internal class MathsOperations
    {
        public static async Task RunAsync()
        {
            Console.WriteLine($"\nPlease enter the number to check Fatorial, IsPrime, Square, Cube, Palindrom");

            int number = int.Parse(Console.ReadLine());

            var factorialTask = GetFactorial(number);
            var primeTask = IsPrime(number);
            Task<(int square, int cube)> powerTask = Task.Run(() => GetSquareAndCube(number));
            var palindromeTask =IsPalindrome(number);

            await Task.WhenAll(factorialTask, primeTask, powerTask, palindromeTask);

            Console.WriteLine($"Factorial      : {factorialTask.Result}");
            Console.WriteLine($"Is Prime       : {primeTask.Result}");
            Console.WriteLine($"Square         : {powerTask.Result.square}");
            Console.WriteLine($"Cube           : {powerTask.Result.cube}");
            Console.WriteLine($"Is Palindrome  : {palindromeTask.Result}");

            Console.WriteLine("\nAll operations completed.");
        }

        public static async Task<double> GetFactorial(int n)
        {
            double result = 1;
            await Task.Run(() =>
            {
                
                for (int i = 1; i <= n; i++)
                    result *= i;
            });
            return result;
        }

        public static async Task<bool> IsPrime(int n)
        {
            bool result = false;
            await Task.Run(() =>
            {
                if (n <= 1) return result = false;
                for (int i = 2; i <= Math.Sqrt(n); i++)
                    if (n % i == 0)
                        return result = false;
                return result = true;
            });
            return result;
        }

        static (int square, int cube) GetSquareAndCube(int n)
        {
            return (n * n, n * n * n);
        }

        public static async Task<bool> IsPalindrome(int n)
        {
            bool result = false;
            await Task.Run(() =>
            {
                int original = n, reverse = 0;

                while (n > 0)
                {
                    reverse = reverse * 10 + n % 10;
                    n /= 10;
                }

                return result = original == reverse;
            });
            return result;
        }
    }
}