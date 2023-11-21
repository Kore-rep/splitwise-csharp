using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCSharp.Models
{
    public class SplitwiseGroupFriend
    {
        public int GroupId { get; set; }
        public SplitwiseUserBalance[] Balances { get; set; }
    }
}
