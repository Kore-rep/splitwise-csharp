using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseDotnetSDK.Utils
{

    internal static class JsonTools
    {
        /// <summary>
        /// Merges two json strings with NO VALIDATION
        /// </summary>
        /// <param name="json1"></param>
        /// <param name="json2"></param>
        /// <returns>Combined JSON string</returns>
        internal static string MergeFlatJson(string json1, string json2)
        {
            var sb = new StringBuilder();
            sb.Append(json1);
            sb.Remove(sb.Length - 1, 1);
            sb.Append(", ");
            sb.Append(json2, 1, json2.Length - 1);
            var res = sb.ToString();
            return res;
        }
    }
}
