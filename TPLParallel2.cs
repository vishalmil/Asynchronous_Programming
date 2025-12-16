using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDay1
{
    internal class TPLParallel2
    {
        public static async Task RunAsync()
        {
            int[] myArray1 = { 10, 20, 30, 40, 50, 60 };
            int[] myArray2 = { 70, 80, 90, 100, 110 };
            int[][] resultArray = new int[][] { myArray1, myArray2 };

            Parallel.For(0, resultArray.Length, i =>
            {
                Console.WriteLine($"sum of the array:{SumOfTheArray(resultArray[i])}");
            });

            Console.WriteLine("Started with parallel.foreach");

            Parallel.ForEach(resultArray, i =>
            {
                Console.WriteLine($"Sum of the Array: {SumOfTheArray(i)}");
            });

            static int SumOfTheArray(int[] array)
            {
                int sum = 0;
                foreach (int item in array)
                {
                    sum += item;
                    Console.WriteLine(item);
                }
                return sum;
            }
        }
    }
}
