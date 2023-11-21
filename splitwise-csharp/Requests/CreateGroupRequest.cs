﻿namespace SplitwiseCSharp.Requests;

public class CreateGroupRequest
{
    private string _GroupType;
    public required string Name { get; set; }
    public required string GroupType
    {
        get
        {
            return _GroupType;
        }
        set
        {
            if (Enum.IsDefined(typeof (SplitwiseConstants.GROUP_TYPE), value))
            {
                _GroupType = value;
            } else
            {
                throw new InvalidDataException("Value must be one of apartment, house, trip, other");
            }
        }
    }

    public required bool SimplifyByDefault { get; set; }
}

