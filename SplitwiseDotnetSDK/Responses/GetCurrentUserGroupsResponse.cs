﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetSDK.Responses
{
    public class GetCurrentUserGroupsResponse
    {
        public SplitwiseGroup[] Groups { get; set; }
    }
}
