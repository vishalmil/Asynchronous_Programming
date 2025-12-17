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
        await TPLParallel.RunAsync();
        await TPLParallel2.RunAsync();
        await TPLParallelSortingPLINQ.RunAsync();
        await TPLReadFileOperations.RunAsync();
        await TPLReadURLFileOperations.RunAsync();
    }
}