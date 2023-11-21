using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SplitwiseDotnetSDK.Interfaces;
using SplitwiseDotnetSDK.Models;
using SplitwiseDotnetSDK.Requests;
using SplitwiseDotnetSDK.Responses;
using SplitwiseDotnetSDK.Utils;

namespace SplitwiseDotnetSDK.Clients;

/// <summary>
/// Class SplitwiseClient provides methods to interact with the splitwise API https://dev.splitwise.com/#section/Introduction
/// It makes use of the OAuth 2.0 Client Credentials flow.
/// </summary>
public class SplitwiseClient : ISplitwiseClient
{

    private readonly HttpClient Client;

    /// <summary>
    /// The constructor for a Splitwise Client.
    /// </summary>
    /// <param name="clientId">Consumer Key from https://secure.splitwise.com</param>
    /// <param name="clientSecret">Consumber Secret from https://secure.splitwise.com</param>
    public SplitwiseClient(string clientId, string clientSecret)
    {
        Client = new HttpClient(new AuthenticatedHttpClientHandler(clientId, clientSecret));
    }

    /// <summary>
    /// Fetches the current user given the client ID and secret.
    /// </summary>
    /// <exception cref="HttpRequestException">
    /// Thrown when the Get Request fails.
    /// Can fail with:
    /// <list type="table">
    /// <item>
    /// <term>401</term>
    /// <description>Unauthorized (Invalid key or access token).</description>
    /// </item>
    /// </list>
    /// </exception>
    /// <returns>
    /// A <see cref="GetCurrentUserResponse"/> or <c>null</c>.
    /// </returns>
    public async Task<GetCurrentUserResponse> GetCurrentUser() 
    {
        var getUserReponse = await Client.GetAsync(SplitwiseConstants.GET_CURRENT_USER_URL);
        getUserReponse.EnsureSuccessStatusCode();
        var getUserResponseJson = getUserReponse.Content;
        if (getUserResponseJson != null) 
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<GetCurrentUserResponse>(await getUserResponseJson.ReadAsStringAsync());
        }
        return null;
    }

    /// <summary>
    /// Fetches information about a particular user.
    /// </summary>
    /// <param name="userId">Id of the user to fetch info about</param>
    /// <exception cref="HttpRequestException">
    /// Thrown when the Get Request fails.
    /// 
    /// </exception>
    /// <list type="table">
    /// <item>
    /// <term>401</term>
    /// <description>Unauthorized (Invalid key or access token).</description>
    /// </item>
    /// <item>
    /// <term>403</term>
    /// <description>Forbidden (Not allowed to access user).</description>
    /// </item>
    /// <item>
    /// <term>404</term>
    /// <description>Not Found (User does not exist).</description>
    /// </item>
    /// </list>
    /// <returns>A <see cref="GetUserByIdResponse"/> or <c>null</c></returns>
    public async Task<GetUserByIdResponse> GetUser(int userId)
    {
        var response = await Client.GetAsync(SplitwiseConstants.GET_USER_URL + $"/{userId}");
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<GetUserByIdResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }

    /// <summary>
    /// Update certain fields of a user
    /// </summary>
    /// <exception cref="HttpRequestException">
    /// Thrown when the Post Request fails.
    /// </exception>
    /// <list type="table">
    /// <item>
    /// <term>401</term>
    /// <description>Unauthorized (Invalid key or access token).</description>
    /// </item>
    /// <item>
    /// <term>403</term>
    /// <description>Forbidden (Not allowed to access user).</description>
    /// </item>
    /// <item>
    /// <term>404</term>
    /// <description>Not Found (User does not exist).</description>
    /// </item>
    /// </list>
    /// <param name="userId">Id of User</param>
    /// <param name="req">Details of user to update</param>
    /// <returns>A <see cref="UpdateUserResponse"/> or <c>null</c></returns>
    public async Task<UpdateUserResponse> UpdateUser(int userId, UpdateUserRequest req)
    { 

        var body = JsonSerializerExtensions.SerializeWithSnakeCase(req);
        var response = await Client.PostAsync(SplitwiseConstants.UPDATE_USER_URL + $"/{userId}", new StringContent(body));
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<UpdateUserResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }

    /// <summary>
    /// Gets all groups that the current user belongs to.
    /// </summary>
    /// <exception cref="HttpRequestException">
    /// Thrown when the Get Request fails.
    /// </exception>
    /// <list type="table">
    /// <item>
    /// <term>401</term>
    /// <description>Unauthorized (Invalid key or access token).</description>
    /// </item>
    /// </list>
    /// <returns>A <see cref="GetCurrentUserGroupsResponse"/> or <c>null</c></returns>
    public async Task<GetCurrentUserGroupsResponse> GetCurrentUserGroups()
    {
        var response = await Client.GetAsync(SplitwiseConstants.GET_CURRENT_USER_GROUPS_URL);
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<GetCurrentUserGroupsResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }

    /// <summary>
    /// Fetches information about a particular group
    /// </summary>
    /// <param name="groupId">Id of the group to fetch info about</param>
    /// <exception cref="HttpRequestException">
    /// Thrown when the Get Request fails.
    /// </exception>
    /// <list type="table">
    /// <item>
    /// <term>401</term>
    /// <description>Unauthorized (Invalid key or access token).</description>
    /// </item>
    /// <item>
    /// <term>403</term>
    /// <description>Forbidden (Not allowed to access user).</description>
    /// </item>
    /// <item>
    /// <term>404</term>
    /// <description>Not Found (Group does not exist).</description>
    /// </item>
    /// </list>
    /// <returns>A <see cref="GetGroupByIdResponse"/> or <c>null</c></returns>
    public async Task<GetGroupByIdResponse> GetGroup(int groupId)
    {
        var response = await Client.GetAsync(SplitwiseConstants.GET_GROUP_URL + $"/{groupId}");
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            var a = await responseJson.ReadAsStringAsync();
            return JsonSerializerExtensions.DeserializeFromSnakeCase<GetGroupByIdResponse>(a);
        }
        return null;
    }

    /// <summary>
    /// Creates a new group with the given information. 
    /// </summary>
    /// <param name="req">Basic details about the group</param>
    /// <param name="users">A list of users to add to the group. (Group creator is added by default) Each user only requires email, first_name and last_name</param>
    /// <exception cref="HttpRequestException">
    /// Thrown when the Get Request fails.
    /// </exception>
    /// <list type="table">
    /// <item>
    /// <term>400</term>
    /// <description>Bad Request.</description>
    /// </item>
    /// </list>
    /// <returns>A <see cref="CreateGroupResponse"/> or <c>null</c></returns>
    public async Task<CreateGroupResponse> CreateGroup(CreateGroupRequest req, SplitwiseUser[] users)
    {
        var body = JsonSerializerExtensions.SerializeWithSnakeCase(req);
        var usersJson = MultiUserParser.ParseUsers(users);
        var combinedJson = JsonTools.MergeFlatJson(body, usersJson);
        var response = await Client.PostAsync(SplitwiseConstants.CREATE_GROUP_URL, new StringContent(combinedJson, Encoding.UTF8, "application/json"));
        var responseJson = response.Content;
        response.EnsureSuccessStatusCode();
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<CreateGroupResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }

    /// <summary>
    /// Delete an existing group. Destroys all associated records (expenses, etc.).
    /// </summary>
    /// <param name="groupId">The id of the group to delete.</param>
    /// <exception cref="HttpRequestException">
    /// Thrown when the Post Request fails.
    /// </exception>
    /// <list type="table">
    /// <item>
    /// <term>401</term>
    /// <description>Unauthorized (Invalid key or access token).</description>
    /// </item>
    /// <item>
    /// <term>403</term>
    /// <description>Forbidden (Not allowed to access Group).</description>
    /// </item>
    /// <item>
    /// <term>404</term>
    /// <description>Not Found (Group does not exist).</description>
    /// </item>
    /// </list>
    /// <returns>A <see cref="DeleteGroupResponse"/> or <c>null</c></returns>
    public async Task<DeleteGroupResponse> DeleteGroup(int groupId)
    {
        var response = await Client.PostAsync(SplitwiseConstants.DELETE_GROUP_URL + $"/{groupId}", null);
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<DeleteGroupResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }

    /// <summary>
    /// Restores a deleted group.
    /// Note: 200 OK does not indicate a successful response.You must check the success value of the response.
    /// </summary>
    /// <param name="groupId">Id of deleted group</param>
    /// <returns></returns>
    public async Task<RestoreGroupResponse> RestoreGroup(int groupId)
    {
        var response = await Client.PostAsync(SplitwiseConstants.RESTORE_GROUP_URL + $"/{groupId}", null);
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<RestoreGroupResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }
    /// <summary>
    /// Adds a given user to a given group.
    /// Note: 200 OK does not indicate a successful response. You must check the success value of the response.
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    public async Task<AddUserToGroupResponse> AddUserToGroup(AddUserToGroupRequest req)
    {
        var response = await Client.PostAsync(SplitwiseConstants.RESTORE_GROUP_URL, new StringContent(JsonSerializerExtensions.SerializeWithSnakeCase(req)));
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<AddUserToGroupResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }

    /// <summary>
    /// Remove a user from a group. Does not succeed if the user has a non-zero balance.
    /// Note: 200 OK does not indicate a successful response.You must check the success value of the response.
    /// </summary>
    /// <param name="req">The group and user details.</param>
    /// <returns></returns>
    public async Task<RemoveUserFromGroupResponse> RemoveUserFromGroup(RemoveUserFromGroupRequest req)
    {
        var response = await Client.PostAsync(SplitwiseConstants.RESTORE_GROUP_URL, new StringContent(JsonSerializerExtensions.SerializeWithSnakeCase(req)));
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<RemoveUserFromGroupResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }

    public async Task<GetCurrentUserFriendsResponse> GetCurretUserFriends()
    {
        var response = await Client.GetAsync(SplitwiseConstants.GET_CURRENT_USER_FRIENDS_URL);
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<GetCurrentUserFriendsResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }

    public async Task<GetFriendResponse> GetFriend(int id)
    {
        var response = await Client.GetAsync(SplitwiseConstants.GET_FRIEND_URL);
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<GetFriendResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }

    public async Task<GetFriendResponse> AddFriend(AddFriendRequest req)
    {
        var response = await Client.PostAsync(SplitwiseConstants.ADD_FRIEND_URL, new StringContent(JsonSerializerExtensions.SerializeWithSnakeCase(req)));
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<GetFriendResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }

    public async Task<AddFriendsResponse> AddFriends(SplitwiseUser[] users)
    {
        var usersJson = MultiUserParser.ParseFriends(users);
        var response = await Client.PostAsync(SplitwiseConstants.ADD_FRIEND_URL, new StringContent(JsonSerializerExtensions.SerializeWithSnakeCase(usersJson)));
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<AddFriendsResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }

    public async Task<DeleteFriendResponse> AddFriends(int id)
    {
        var response = await Client.PostAsync(SplitwiseConstants.DELETE_FRIEND_URL + $"/{id}", null);
        response.EnsureSuccessStatusCode();
        var responseJson = response.Content;
        if (responseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<DeleteFriendResponse>(await responseJson.ReadAsStringAsync());
        }
        return null;
    }


}
