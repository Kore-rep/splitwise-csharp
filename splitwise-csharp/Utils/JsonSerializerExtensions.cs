using System.Text.Json;

namespace SplitwiseCSharp.Utils;

public static class JsonSerializerExtensions
{
    public static T DeserializeFromSnakeCase<T>(this string json)
    {
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
        {
            PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy()
        });
    }

}
