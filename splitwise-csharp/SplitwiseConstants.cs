using System.Diagnostics;

namespace SplitwiseCSharp;
public class SplitwiseConstants
{
    public static readonly string BASE_URL = "https://secure.splitwise.com";
    public static readonly string SPLITWISE_API_VERSION = "v3.0";
    public static readonly string BASE_API_URL = BASE_URL + $"/api/{SPLITWISE_API_VERSION}";

    // Constants for Authentication
    public static readonly string TOKEN_URL = "/oauth/token";
    public static readonly string AUTHORIZATION_URL = "/oauth/authorize";
    public static readonly string GRANT_TYPE = "client_credentials";

    // URLS for Users API
    public static readonly string GET_CURRENT_USER_URL = BASE_API_URL + "/get_current_user";
}
