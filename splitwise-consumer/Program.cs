// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using SplitwiseDotnetSDK.Clients;
using SplitwiseDotnetSDK.Requests;

var sdk = new SplitwiseClient("ImFJbPwPIxagiEYaz3NVoPLfN18q4XHYF4YDZwhv", "lqUw41Zq1BiQm1ZNKH5WwOQ2Qqjkt8SNYO8k98G9");

/*var currUser = await sdk.GetCurrentUser();

var otherUser = await sdk.GetUser(currUser.User.Id);

var updateResp = await sdk.UpdateUser(currUser.User.Id, new UpdateUserRequest
{
    DefaultCurrency = "ZAR"
});


var groups = await sdk.GetCurrentUserGroups();

var group = await sdk.GetGroup(groups.Groups[1].Id);*/

var createGroupResp = await sdk.CreateGroup(new CreateGroupRequest { Name = "test group", GroupType="other", SimplifyByDefault = true }, new SplitwiseDotnetSDK.Models.SplitwiseUser[] { new SplitwiseDotnetSDK.Models.SplitwiseUser { Email="jessfmclachlan@gmail.com" } });
var groups = await sdk.GetCurrentUserGroups();
var deletegroupResp = await sdk.DeleteGroup(createGroupResp.Group.Id);
Console.WriteLine(createGroupResp);
