using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGFinanceProject
{
    internal class Transactions
    {
        //Get and set the title chosen for the transaction.
        public string title_;
        public string Title
        {
            get { return title_; }
            set { title_ = value; }
        }

        //Get and set the amount deposited or withdrawn.
        public double amount_;
        public double Amount 
        {
            get { return amount_; }
            set { amount_ = value; }
        }

        //Get and set the date and time the transaction happened.
        public DateTime dateTimeValue_;
        public DateTime DateTimeValue 
        {
            get { return dateTimeValue_; }
            set { dateTimeValue_ = value; }
        }
    }
}


//DateTime date1 = DateTime.Now - Get the current time. Variable = date1
//var dateString = 20/1/2008 08:30"
