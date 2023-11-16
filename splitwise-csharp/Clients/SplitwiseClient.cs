using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SplitwiseCSharp.Interfaces;
using SplitwiseCSharp.Models;
using SplitwiseCSharp.Requests;
using SplitwiseCSharp.Responses;
using SplitwiseCSharp.Utils;

namespace SplitwiseCSharp.Clients;

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
        var response = await Client.GetAsync(SplitwiseConstants.GET_CURRENT_USER_GROUPS);
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
    /// <param name="users">A list of users to add to the group. (Group creator is added by default)</param>
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
        var content = await responseJson.ReadAsStringAsync();
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


}
