using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseDotnetSDK.Requests;

public class AddFriendRequest
{
    public string UserEmail { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
}
