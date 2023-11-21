using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseDotnetSDK.Models;

public class SplitwiseGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string GroupType { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool SimplifyByDefault { get; set; }
    public SplitwiseGroupMember[] Members { get; set; }
    public SplitwiseDebt[] OriginalDebts { get; set; }
    public SplitwiseDebt[] SimplifiedDebts { get; set; }
    public SplitwiseAvatar Avatar { get; set; }
    public bool CustomAvatar { get; set; }
    public SplitwiseCoverPhoto CoverPhoto { get; set; }
    public string InviteLink { get; set; }
}

