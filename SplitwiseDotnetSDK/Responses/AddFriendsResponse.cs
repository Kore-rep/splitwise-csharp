using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetSDK.Responses
{
    public class AddFriendsResponse
    {
        public SplitwiseFriend[] Users { get; set; }
        public string[] Errors { get; set; }
    }
}
