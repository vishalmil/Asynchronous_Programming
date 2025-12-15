using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDay1
{
    internal class EmployeeSalary
    {
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }
        }
        //public static async Task Main(string[] args)
        //{
        //    try
        //    {
        //        List<Employee> emp = new List<Employee>
        //    {
        //            new Employee { Id = 1, Name = "Vishal", Salary = 10000 },
        //            new Employee { Id = 1, Name = "Vishal2", Salary = 100000 },
        //            new Employee { Id = 1, Name = "Vishal3", Salary = 100000 },
        //            new Employee { Id = 1, Name = "Vishal4", Salary = 100000 }
        //    };

        //        Console.WriteLine("Calculate employee salary");

        //        var MaxSal = GetHighestSal(emp);
        //        var MinSal = GetMinimumSal(emp);
        //        var AvgSal = GetAvgSal(emp);

        //        await Task.WhenAll(MaxSal, MinSal, AvgSal);

        //        Console.WriteLine($"Max Salary: {MaxSal.Result}");
        //        Console.WriteLine($"Min Salary: {MinSal.Result}");
        //        Console.WriteLine($"Avg Salary:  {MinSal.Result}");
        //        Console.ReadLine();
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }

        //}

        public static async Task RunAsync()
        {
            try
            {
                List<Employee> emp = new List<Employee>
            {
                    new Employee { Id = 1, Name = "Vishal", Salary = 10000 },
                    new Employee { Id = 1, Name = "Vishal2", Salary = 40000 },
                    new Employee { Id = 1, Name = "Vishal3", Salary = 50000 },
                    new Employee { Id = 1, Name = "Vishal4", Salary = 70000 }
            };

                Console.WriteLine("\nCalculate employee salary");

                var MaxSal = GetHighestSal(emp);
                var MinSal = GetMinimumSal(emp);
                var AvgSal = GetAvgSal(emp);
                var SecondHigh = GetSecondHighestSal(emp);
                var ThirdHigh = GetThirdHighestSal(emp);

                await Task.WhenAll(MaxSal, MinSal, AvgSal, SecondHigh, ThirdHigh);

                //Console.WriteLine($"Max Salary: {MaxSal.Result}");
                //Console.WriteLine($"Min Salary: {MinSal.Result}");
                //Console.WriteLine($"Avg Salary:  {MinSal.Result}");
                Console.WriteLine($"2nd High Salary:  {SecondHigh.Result}");
                Console.WriteLine($"3rd High Salary:  {ThirdHigh.Result}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static async Task<int> GetHighestSal(List<Employee> employee)
        {
            return await Task.Run(() => employee.Max(e => e.Salary));
        }

        public static async Task<int> GetMinimumSal(List<Employee> employee)
        {
            return await Task.Run(() => employee.Min(e => e.Salary));
        }

        public static async Task<double> GetAvgSal(List<Employee> employee)
        {
            return await Task.Run(() => employee.Average(e => e.Salary));
        }

        public static async Task<int> GetSecondHighestSal(List<Employee> employee)
        {
            return await Task.Run(() => employee.Select(e => e.Salary).Distinct().OrderByDescending(s => s).Skip(1).FirstOrDefault());
        }

        public static async Task<int> GetThirdHighestSal(List<Employee> employee)
        {
            return await Task.Run(() => employee.Select(e => e.Salary).Distinct().OrderByDescending(s => s).Skip(2).FirstOrDefault());
        }
    }
}
