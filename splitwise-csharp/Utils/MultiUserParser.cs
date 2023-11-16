﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SplitwiseCSharp.Models;

namespace SplitwiseCSharp.Utils;

internal class MultiUserParser
{
    private static readonly JsonSnakeCaseNamingPolicy Converter = new();
    private static readonly string[] ValidProperties = { "Id", "FirstName", "LastName", "Email" };
    internal static string ParseUsers(SplitwiseUser[] users)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append('{');
        int i = 0;
        foreach (SplitwiseUser user in users)
        {
            if (user.Email == null && user.Id == null)
            {
                throw new ArgumentException("All Users require an id or an email.");
            }
            string prefix = $"users__{i}__";
            foreach (PropertyInfo prop in user.GetType().GetProperties())
            {
                var jsonValue = prop.GetValue(user, null);
                if (jsonValue == null) continue;
                if (jsonValue.GetType() != typeof(int)) jsonValue = $"\"{jsonValue}\"";
                if (!ValidProperties.Contains(prop.Name)) continue;
                var jsonName = String.Concat(prefix, NameToSnake(prop.Name));
                var finalString = $"\"{jsonName}\": {jsonValue},";
                sb.Append(finalString);
            }
        }
        sb.Remove(sb.Length-1, 1);
        sb.Append('}');
        var final = sb.ToString();
        return final;
    }

    private static string NameToSnake(string name)
    {
        return Converter.ConvertName(name);
    }
}

