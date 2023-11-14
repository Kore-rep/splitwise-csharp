using System.Text.Json;

namespace SplitwiseCSharp.Utils;

public static class JsonSerializerExtensions
{
    public static string SerializeWithSnakeCase<T>(this T data, bool excludeNulls=true)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy()
        };
        if (excludeNulls)
        {
            options.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        }
        return JsonSerializer.Serialize(data, options);
    }
    public static T DeserializeFromSnakeCase<T>(this string json)
    {
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
        {
            PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy()
        });
    }

}
