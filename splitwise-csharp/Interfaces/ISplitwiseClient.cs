using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitwiseCSharp.Models;
namespace SplitwiseCSharp.Interfaces;

internal interface ISplitwiseClient
{
    Task<SplitwiseUser> GetCurrentUser();
}
