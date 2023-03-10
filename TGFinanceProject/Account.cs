using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGFinanceProject
{
    internal class Account
    {
        public string accountName { get; set; }
        public double Balance { get; set; }

        public void Deposit(double value)
        {
            if (value <= 0)
            {
                throw new Exception("Invalid deposit amount");
            }
            else { Balance += value; }         
        }

        public void Withdraw(double value)
        {
            if (value <= 0)
            {
                throw new Exception("Invalid withdrawal amount");
            } else if(Balance < value)
                {
                    throw new Exception("Insufficient funds");
            }
            else{ Balance -= value; }
        }
    }
}
