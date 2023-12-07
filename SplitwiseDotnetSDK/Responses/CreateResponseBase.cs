using System.Text.Json.Nodes;

namespace SplitwiseDotnetSDK.Responses
{
    abstract public class CreateResponseBase
    {
        public JsonObject[] Errors { get; set; }
    }
}
