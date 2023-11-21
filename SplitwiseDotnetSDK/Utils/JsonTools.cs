using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseDotnetSDK.Utils
{
    internal class JsonTools
    {
        internal static string MergeFlatJson(string json1, string json2)
        {
            var sb = new StringBuilder();
            sb.Append(json1);
            sb.Remove(sb.Length - 1, 1);
            sb.Append(',');
            sb.Append(json2, 1, json2.Length-1);
            var res = sb.ToString();
            return res;
        }
    }
}
