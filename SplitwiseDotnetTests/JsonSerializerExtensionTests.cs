using Newtonsoft.Json.Linq;
using SplitwiseDotnetSDK.Requests;
using SplitwiseDotnetSDK.Responses;
using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetTests;

[TestFixture]
internal class JsonSerializerExtensionTests
{
    [Test]
    public void Serialize_ShouldSerialize_WhenDataIsValid()
    {

        var testData = new UpdateUserRequest { Email = "test@test.com", DefaultCurrency = "ZAR", FirstName = "Joe", LastName = "Bloggs", Locale = "en-US", Password = "123456" };
        var expectedResponse = @"{""email"": ""test@test.com"", ""default_currency"": ""ZAR"", ""first_name"": ""Joe"", ""last_name"": ""Bloggs"", ""locale"": ""en-US"", ""password"": ""123456""}";
        var actualResponse = JsonSerializerExtensions.SerializeWithSnakeCase(testData);
        
        var expectedJson = JToken.Parse(expectedResponse);
        var actualJson = JToken.Parse(actualResponse);

        actualJson.Should().BeEquivalentTo(expectedJson);
    }

    [Test]
    public void Serialize_ShouldSerialize_WhenEmptyStringSupplied()
    {
        var response = JsonSerializerExtensions.SerializeWithSnakeCase("");
        response.Should().Match("\"\"");
    }

    [Test]
    public void Serialize_ShouldIgnoreNullFields_ByDefault()
    {

        var testData = new UpdateUserRequest { Email = "test@test.com", FirstName = null, LastName = null, DefaultCurrency = "ZAR" };
        var expectedResponse = @"{""email"": ""test@test.com"", ""default_currency"": ""ZAR""}";

        var actualResponse = JsonSerializerExtensions.SerializeWithSnakeCase(testData);
        var expectedJson = JToken.Parse(expectedResponse);
        var actualJson = JToken.Parse(actualResponse);

        actualJson.Should().BeEquivalentTo(expectedJson);
    }

    [Test]
    public void Serialize_ShouldWriteNullFields_WhenSpecified()
    {

        var testData = new UpdateUserRequest { Email = "test@test.com", FirstName = null, DefaultCurrency = "ZAR" };
        var expectedResponse = @"{""email"": ""test@test.com"", ""default_currency"": ""ZAR"", ""first_name"": null, ""last_name"": null, ""locale"": null, ""password"": null}";

        var actualResponse = JsonSerializerExtensions.SerializeWithSnakeCase(testData, false);
        var expectedJson = JToken.Parse(expectedResponse);
        var actualJson = JToken.Parse(actualResponse);

        actualJson.Should().BeEquivalentTo(expectedJson);
    }

    [Test]
    public void Deserialize_ShouldDeserialize_WhenDataIsValid()
    {
        var testData = @"{""groups"": [{""id"": 12345, ""name"": ""Test Group"", ""group_type"": ""house"", ""simplify_by_default"": true, ""members"": [{""first_name"": ""test"", ""last_name"": ""man""}, {""first_name"": ""Test"", ""last_name"": ""Man""}]}, {""id"": 54321, ""name"": ""Another Group"", ""group_type"": ""trip"", ""simplify_by_default"": false, ""members"": [{""first_name"": ""Joe"", ""last_name"": ""Bloggs""}, {""first_name"": ""Jane"", ""last_name"": ""Doe""}]}]}";
        var expectedResponse = new GetCurrentUserGroupsResponse() { 
            Groups = new SplitwiseGroup[] {
                new SplitwiseGroup() { 
                    Id = 12345,
                    Name = "Test Group",
                    GroupType = "house",
                    SimplifyByDefault = true,
                    Members = new SplitwiseGroupMember[] { 
                        new SplitwiseGroupMember() { 
                            FirstName = "test", LastName = "man" 
                        }, 
                        new SplitwiseGroupMember() { 
                            FirstName = "Test", LastName = "Man" 
                        }
                    } 
                },
                new SplitwiseGroup() {
                    Id = 54321,
                    Name = "Another Group",
                    GroupType = "trip",
                    SimplifyByDefault = false,
                    Members = new SplitwiseGroupMember[] {
                        new SplitwiseGroupMember() {
                            FirstName = "Joe", LastName = "Bloggs"
                        },
                        new SplitwiseGroupMember() {
                            FirstName = "Jane", LastName = "Doe"
                        }
                    }
                }
            } 
        };
        var actualResponse = JsonSerializerExtensions.DeserializeFromSnakeCase<GetCurrentUserGroupsResponse>(testData);
        actualResponse.Should().BeEquivalentTo(expectedResponse);
    }

    /// <summary>
    /// Ensure Serializer and Deserializer proeduce results that can be understood by the other.
    /// </summary>
    [Test]
    public void Deserialize_ShouldDeserialize_WhenStringIsFromSerializer()
    {
        var setupObject = new GetCurrentUserGroupsResponse()
        {
            Groups = new SplitwiseGroup[] {
                new SplitwiseGroup() {
                    Id = 12345,
                    Name = "Test Group",
                    GroupType = "house",
                    SimplifyByDefault = true,
                    Members = new SplitwiseGroupMember[] {
                        new SplitwiseGroupMember() {
                            FirstName = "test", LastName = "man"
                        },
                        new SplitwiseGroupMember() {
                            FirstName = "Test", LastName = "Man"
                        }
                    }
                },
                new SplitwiseGroup() {
                    Id = 54321,
                    Name = "Another Group",
                    GroupType = "trip",
                    SimplifyByDefault = false,
                    Members = new SplitwiseGroupMember[] {
                        new SplitwiseGroupMember() {
                            FirstName = "Joe", LastName = "Bloggs"
                        },
                        new SplitwiseGroupMember() {
                            FirstName = "Jane", LastName = "Doe"
                        }
                    }
                }
            }
        };
        var serialized = JsonSerializerExtensions.SerializeWithSnakeCase(setupObject);
        var deserialized = JsonSerializerExtensions.DeserializeFromSnakeCase<GetCurrentUserGroupsResponse>(serialized);
        deserialized.Should().BeEquivalentTo(setupObject);
    }

    /// <summary>
    /// Ensure Serializer and Deserializer proeduce results that can be understood by the other.
    /// </summary>
    [Test]
    public void Serialize_ShouldSerialize_WhenStringIsFromDeserializer()
    {
        var testData = @"{""groups"":[{""id"":12345,""name"":""Test Group"",""group_type"":""house"",""updated_at"":""0001-01-01T00:00:00"",""simplify_by_default"":true,""members"":[{""first_name"":""test"",""last_name"":""man"",""custom_picture"":false},{""first_name"":""Test"",""last_name"":""Man"",""custom_picture"":false}],""custom_avatar"":false},{""id"":54321,""name"":""Another Group"",""group_type"":""trip"",""updated_at"":""0001-01-01T00:00:00"",""simplify_by_default"":false,""members"":[{""first_name"":""Joe"",""last_name"":""Bloggs"",""custom_picture"":false},{""first_name"":""Jane"",""last_name"":""Doe"",""custom_picture"":false}],""custom_avatar"":false}]}";
        var deserialized = JsonSerializerExtensions.DeserializeFromSnakeCase<GetCurrentUserGroupsResponse>(testData);
        var serialized = JsonSerializerExtensions.SerializeWithSnakeCase(deserialized);
        serialized.Should().Match(testData);
    }
}
