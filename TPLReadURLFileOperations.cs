using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace AsyncDay1
{
    internal class TPLReadURLFileOperations
    {
        public static async Task RunAsync()
        {
            string[] word = CreatedWordArray(@"");
            Parallel.Invoke(() =>
            {
                Console.WriteLine("Begin First Task...");
                GetMostCommonWord(word);
            },
            () =>
            {
                Console.WriteLine("Begin second...");
                GetCountWord(word, "sleep");
            });
        }

        //1.Get Count Word
        static void GetCountWord(string[] word, string n1)
        {
            var findWord = from word1 in word where word1.ToUpper().Contains(n1.ToUpper()) select word1;

            Console.WriteLine($@"Word {n1} occurs {findWord}");
        }

        //2. Most Common words
        public static void GetMostCommonWord(string[] word)
        {
            var frequentWord = from word2 in word
                               where word.Length > 6
                               group word by word into g
                               orderby g.Count()
                               descending
                               select g.Key;
            var commonWords = frequentWord.Take(word.Length).ToArray();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Most common words are...");
            foreach (var i in commonWords)
            {
                sb.AppendLine(" " + i);
            }
            Console.WriteLine(sb.ToString());
        }


        public static string[] CreatedWordArray(string uri)
        {
            string a = new WebClient().DownloadString(uri);

            return a.Split(new char[] { ' ', '\u000A', ',', '.', ':', '-', '_', '/' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
