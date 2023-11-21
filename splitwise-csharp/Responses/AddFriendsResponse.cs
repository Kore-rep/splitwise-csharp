using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitwiseCSharp.Models;

namespace SplitwiseCSharp.Responses
{
    public class AddFriendsResponse
    {
        public SplitwiseFriend[] Users { get; set; }
        public string[] Errors { get; set; }
    }
}
