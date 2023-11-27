using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetSDK.Utils;

internal static class MultiUserParser
{
    private static readonly JsonSnakeCaseNamingPolicy Converter = new();
    internal static string ParseUsers(SplitwiseUser[] users)
    {
        return ParseMultiElementAdd("users", new string[] { "Id", "FirstName", "LastName", "Email" }, users);
    }

    internal static string ParseFriends(SplitwiseUser[] friends)
    {
        return ParseMultiElementAdd("friends", new string[] { "Id", "FirstName", "LastName", "Email" }, friends);

    }

    private static string ParseMultiElementAdd(string prefix, string[] validProps, SplitwiseUser[] elements)
    {
        if (elements.Length == 0)
        {
            throw new ArgumentException("No elements to Parse");
        }
        StringBuilder sb = new();
        sb.Append('{');
        int i = 0;
        foreach (SplitwiseUser user in elements)
        {
            if (user.Email == null && user.Id == null)
            {
                throw new ArgumentException("All Users require an id or an email.");
            }
            string indexedPrefix = $"{prefix}__{i}__";
            foreach (PropertyInfo prop in user.GetType().GetProperties())
            {
                var jsonValue = prop.GetValue(user, null);
                if (jsonValue == null) continue;
                if (jsonValue.GetType() != typeof(int)) jsonValue = $"\"{jsonValue}\"";
                if (!validProps.Contains(prop.Name)) continue;
                var jsonName = String.Concat(indexedPrefix, NameToSnake(prop.Name));
                var finalString = $"\"{jsonName}\": {jsonValue}, ";
                sb.Append(finalString);
            }
            i++;
        }
        sb.Remove(sb.Length - 2, 2); // Remove trailing comma + space
        sb.Append('}');
        var final = sb.ToString();
        return final;
    }

    private static string NameToSnake(string name)
    {
        return Converter.ConvertName(name);
    }
}


