using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDay1
{
    public class TransactionDemo
    {
        private static decimal _balance = 10000;

        //static async Task Main(string[] args)
        //{
        //    await Task.WhenAll(ShowBalanceAsync(), DepositAsync(3000), WithdrawAsync(2500), WithdrawAsync(15000), ShowBalanceAsync());

        //    Console.WriteLine("Transactions completed.");
        //    Console.ReadLine();
        //}

        public static async Task RunAsync()
        {
            Console.WriteLine("Bank Transactions: ");
            await Task.WhenAll(ShowBalanceAsync(), DepositAsync(3000), WithdrawAsync(2500), WithdrawAsync(15000), ShowBalanceAsync());
            Console.WriteLine("Transactions Completed");
        }

        static async Task ShowBalanceAsync()
        {
            await Task.Delay(500);
            Console.WriteLine($"Current Balance: {_balance}");
        }

        static async Task DepositAsync(decimal amount)
        {
            await Task.Delay(500);

            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be greater than zero");
                return;
            }

            _balance += amount;
            Console.WriteLine($"Deposited: {amount} | Balance: {_balance}");
        }

        static async Task WithdrawAsync(decimal amount)
        {
            await Task.Delay(500);

            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero");
                return;
            }

            if (amount > _balance)
            {
                Console.WriteLine($"Withdrawal Failed: Insufficient balance ({_balance})");
                return;
            }

            _balance -= amount;
            Console.WriteLine($"Withdrawn: {amount} | Balance: {_balance}");
        }
    }
}
