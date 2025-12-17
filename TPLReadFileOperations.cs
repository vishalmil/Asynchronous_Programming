using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDay1
{
    internal class TPLReadFileOperations
    {
        public static async Task RunAsync()
        {
            string path = "E:\\Test File.txt";
            //Console.WriteLine("Enter character");
            //string content = Console.ReadLine();
            //await WriteAsync(path, content);
            //string content = await ReadAsync(path);
            //Console.WriteLine(content);

            if (path != null && !string.IsNullOrEmpty(path))
            {
                Console.WriteLine("File details not found");
            }

            string content = File.ReadAllText(path);
            string[] words = content.Split(
                    new char[] { ' ', '\n', '\r', ',', '.', ';', ':', '-', '!', '?' },
                    StringSplitOptions.RemoveEmptyEntries);

            Parallel.Invoke(
                () =>
                {
                    Console.WriteLine("Task 1: Finding most frequent word...");
                    GetMostFrequentWord(words);
                },
                () =>
                {
                    Console.WriteLine("Task 2: Counting uppercase character...");
                    CountUppercase(content);
                },
                () =>
                {
                    Console.WriteLine("Task 3: Counting lowercase character...");
                    CountLowercase(content);
                }
            );

            Console.WriteLine("\nAll tasks completed.");
            
        }

        static async Task WriteAsync(string path, string content)
        {
            byte[] writeBytes = Encoding.UTF8.GetBytes(content);
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 2000, useAsync: true))
            {
                await fs.WriteAsync(writeBytes, 0, writeBytes.Length);
                Console.WriteLine("Completed");
            }
        }
        static async Task<string> ReadAsync(string path)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(path);
            string d1 = string.Empty;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 2000, useAsync: true))
            {
                int bytesRead = 0;
                while ((bytesRead = await fs.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    d1 = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine(d1);
                }
                Console.WriteLine("Read Completed");
            }
            return d1;

        }

        //2. Most Common words
        static void GetMostFrequentWord(string[] words)
        {
            var mostFrequent = words
                .GroupBy(w => w.ToLower())
                .OrderByDescending(g => g.Count())
                .First();

            Console.WriteLine($"Most frequent word: {mostFrequent.Key}");
        }

        static void CountUppercase(string content)
        {
            int count = content.Count(char.IsUpper);
            Console.WriteLine($"Uppercase letters count: {count}");
        }

        static void CountLowercase(string content)
        {
            int count = content.Count(char.IsLower);
            Console.WriteLine($"Lowercase letters count: {count}");
        }
    }
}
