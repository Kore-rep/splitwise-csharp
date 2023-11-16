using System.Diagnostics;

namespace SplitwiseCSharp;
public class SplitwiseConstants
{
    public static readonly string BASE_URL = "https://secure.splitwise.com";
    public static readonly string SPLITWISE_API_VERSION = "v3.0";
    public static readonly string BASE_API_URL = BASE_URL + $"/api/{SPLITWISE_API_VERSION}";
    public enum GROUP_TYPE
    {
        apartment,
        house,
        trip,
        other
    }
    
    // All URLS from dev.splitwise.com
    // Constants for Authentication
    public static readonly string TOKEN_URL = "/oauth/token";
    public static readonly string AUTHORIZATION_URL = "/oauth/authorize";
    public static readonly string GRANT_TYPE = "client_credentials";

    // URLS for Users API
    public static readonly string GET_CURRENT_USER_URL = BASE_API_URL + "/get_current_user";
    public static readonly string GET_USER_URL = BASE_API_URL + "/get_user";
    public static readonly string UPDATE_USER_URL = BASE_API_URL + "/update_user";

    // URLS for Groups API
    public static readonly string GET_CURRENT_USER_GROUPS = BASE_API_URL + "/get_groups";
    public static readonly string GET_GROUP_URL = BASE_API_URL + "/get_group";
    public static readonly string CREATE_GROUP_URL = BASE_API_URL + "/create_group";
    public static readonly string DELETE_GROUP_URL = BASE_API_URL + "/delete_group";


}
