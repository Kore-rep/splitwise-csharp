using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCSharp.Models
{
    public class SplitwiseFriend : SplitwiseUser
    {
        public SplitwiseGroupFriend[] Groups { get; set; }
        public SplitwiseUserBalance[] Balances { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
