using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class BankAccount
    {
        public int accountNumber;
        public double balance;
        public string currency;
        public string holderName;

        public BankAccount( string holderName, string currency)
        {
            this.holderName = holderName;
            this.currency = currency;
            balance = 0;
            Random rng  = new Random();
            accountNumber = rng.Next(100000000, 999999999);
        }
        public void Deposit(double amount)
        {
            
            if (amount > 0)
            {
                balance += balance;
                Console.WriteLine("new balance equals:" + balance);
            }
            else { Console.WriteLine("invalid amount"); }
        }
        public double Withdraw(double amount)
        {
            {
                if (balance >= amount)
                {
                    
                    balance -= amount;
                    Console.WriteLine("new balance equals:" + balance);
                    return amount;
                    
  
                }
                else { Console.WriteLine("not enough funds");
                    return 0;
                }
            }
           
        }
        public static bool Transfer(double amount, BankAccount accountFrom, BankAccount accountTo)
        {
            
            if(accountFrom.balance > amount)
            {
                accountFrom.Withdraw(amount);
                accountTo.Deposit(amount);
                
                return true;
            }  
            else
            {
                return false;
            }
            
        }
    }
}
