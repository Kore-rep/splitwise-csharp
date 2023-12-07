using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetTests;

[TestFixture]
internal class MultiUserParserTests
{
    private Fixture _fixture;
    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture { RepeatCount = 20};
    }
    [Test]
    public void ParseUsers_ShouldParseUsers()
    {
        var users = new SplitwiseUser[] { new SplitwiseUser { Email = "test@test.com", FirstName = "First", RegistrationStatus = "active" }, new SplitwiseUser { Id = 12345 }  };

        var res = MultiUserParser.ParseUsers(users);
        res.Should().Match(@"{""users__0__first_name"": ""First"", ""users__0__email"": ""test@test.com"", ""users__1__id"": 12345}");
        Console.WriteLine(res);
    }
    [Test]
    public void ParseUsers_ShouldParseManyUsers()
    {
        var users = _fixture.Create<SplitwiseUser[]>();

        Action act = () => MultiUserParser.ParseUsers(users);

        act.Should().NotThrow();
    }
    [Test]
    public void ParseUsers_ShouldThrowArguementException_WhenNoUsers()
    {
        var users = Array.Empty<SplitwiseUser>();

        Action act = () => MultiUserParser.ParseUsers(users);

        act.Should().Throw<ArgumentException>()
            .WithMessage("No elements to Parse");
    }
    [Test]
    public void ParseFriends_ShouldParseFriends()
    {
        var users = new SplitwiseUser[] { new SplitwiseUser { Email = "test@test.com", FirstName = "First", RegistrationStatus = "active" }, new SplitwiseUser { Id = 12345 } };

        var res = MultiUserParser.ParseFriends(users);
        res.Should().Match(@"{""friends__0__first_name"": ""First"", ""friends__0__email"": ""test@test.com"", ""friends__1__id"": 12345}");
        Console.WriteLine(res);
    }
    [Test]
    public void ParseFriends_ShouldParseManyFriends()
    {
        var users = _fixture.Create<SplitwiseUser[]>();

        Action act = () => MultiUserParser.ParseFriends(users);

        act.Should().NotThrow();
    }
    [Test]
    public void ParseFriends_ShouldThrowArguementException_WhenNoFriends()
    {
        var users = Array.Empty<SplitwiseUser>();

        Action act = () => MultiUserParser.ParseFriends(users);

        act.Should().Throw<ArgumentException>()
            .WithMessage("No elements to Parse");
    }
}
