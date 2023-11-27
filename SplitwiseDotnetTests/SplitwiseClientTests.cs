namespace SplitwiseDotnetTests;
using SplitwiseDotnetSDK.Responses;
using SplitwiseDotnetSDK.Clients;

[TestFixture]
public class SplitwiseClientTests
{
    private Mock<SplitwiseClient> _sdkClientMock;
    private string mClientId = "";
    private string mClientSecret = "";
    [SetUp]
    public void Setup()
    {
        _sdkClientMock = new Mock<SplitwiseClient>();
    }

    [Test]
    public void Test1()
    {
        _sdkClientMock.Setup(c => c.GetCurrentUser().Result).Returns(new GetCurrentUserResponse());
    }
}