﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCSharp.Models;

public class SplitwiseGroupMember : SplitwiseUser
{
    public SplitwiseUserBalance[] Balance { get; set; }
}