using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public String dateTimeValue_;
        public String DateTimeValue 
        {
            get { return dateTimeValue_; }
            set { dateTimeValue_ = value; }
        }

        public override string ToString()
        {
            return String.Format($"Title: {Title} \n" +
                $"Amount: {Amount} \n" +
                $"Date: {DateTimeValue}\n");
        }
    }
}


//DateTime date1 = DateTime.Now - Get the current time. Variable = date1
//var dateString = 20/1/2008 08:30"
