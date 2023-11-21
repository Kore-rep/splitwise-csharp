using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCSharp.Responses;

public class DeleteFriendResponse
{
    public bool Success { get; set; }
    public string[] Errors { get; set; }
}
