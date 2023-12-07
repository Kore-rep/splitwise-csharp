using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseDotnetSDK.Models;

abstract public class SplitwiseMoneyMovement
{
    public int From { get; set; }
    public int To { get; set; }
    public string Amount { get; set; }
}
