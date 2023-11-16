using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCSharp.Models
{
    public class SplitwiseDebt 
    {
        public int From { get; set; }
        public int To { get; set; }
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
        
    }
}
