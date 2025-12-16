using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDay1
{
    internal class TPLParallel
    {
        public static async Task RunAsync()
        {
            var task = new List<Task<string>>
            {
                FetchMyData("a1", 500),
                FetchMyData("a2", 1000),
                FetchMyData("a3", 2000),
                FetchMyData("a4", 1000),
                FetchMyData("a5", 500),

                Task.FromResult("All sub task is combined now")
            };

            Console.WriteLine("Task is in progress.");
            
            var completdTask = await Task.WhenAny(task);
            Console.WriteLine($"{await completdTask}");

            var pendingTask = task.ToList();
            Console.WriteLine($"{pendingTask.Count} is in pending situation.");

            while (pendingTask.Any())
            {
                var completed = await Task.WhenAny(pendingTask);
                pendingTask.Remove(completed);
                Console.WriteLine($"{await completed}");
            }
            Console.WriteLine($"All tasks are completed now.");

        }
        public static async Task<string> FetchMyData(string source, int delay)
        {
            await Task.Delay(delay).ConfigureAwait(false);
            return $"{source} with {delay}";
        }
    }
}
