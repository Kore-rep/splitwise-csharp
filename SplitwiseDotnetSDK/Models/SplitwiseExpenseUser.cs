using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseDotnetSDK.Models
{
    public class SplitwiseExpenseUser
    {
        public SplitwiseUser User { get; set; }
        public int UserId { get; set; }
        public string PaidShare { get; set; }
        public string OwedShare { get; set; }
        public string NetBalance { get; set; }
    }
}
