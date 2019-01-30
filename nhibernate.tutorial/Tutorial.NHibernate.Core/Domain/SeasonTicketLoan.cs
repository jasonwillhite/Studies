using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial.NHibernate.Core.Domain
{
    public class SeasonTicketLoan : Benefit
    {
        public int Amount { get; set; }
        public double MonthyInstallment { get; set; }
    }
}
