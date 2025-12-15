// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using AsyncDay1;

public class Program
{
    public static async Task Main(string[] args)
    {
        await TransactionDemo.RunAsync();
        await EmployeeSalary.RunAsync();
        await MathsOperations.RunAsync();
    }
}