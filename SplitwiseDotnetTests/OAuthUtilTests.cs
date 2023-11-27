using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace SplitwiseDotnetTests;

[TestFixture]
internal class OAuthUtilTests
{
    [Test]
    public async Task GetAccessTokenAsync_ShouldFetchAccessToken()
    {
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
            "SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(@"{""access_token"": ""4CR0DBxxxxxxxxxxxxxxxxxxxxxxxxxxxxxl44hA"", ""token_type"": ""bearer""}"),
            })
            .Verifiable();

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("http://test.com/"),
        };

        var resp = await OAuthUtil.GetAccessTokenAsync(httpClient, "someClient", "someSecret");

        resp.Should().NotBeNull();
        resp.AccessToken.Should().Match("4CR0DBxxxxxxxxxxxxxxxxxxxxxxxxxxxxxl44hA");
        resp.TokenType.Should().Match("bearer");

        handlerMock.Protected().Verify(
            "SendAsync",
            Times.Exactly(1), // we expected a single external request
            ItExpr.Is<HttpRequestMessage>(req =>
                req.Method == HttpMethod.Post  // we expected a GET request
            ),
            ItExpr.IsAny<CancellationToken>()
            );
    }

    [Test]
    public async Task GetAccessTokenAsync_ShouldThrowJsonError_WhenAccessTokenIsInvalid()
    {
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
            "SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(@"{""access_token"": 1234, ""token_type"": ""bearer""}"),
            })
            .Verifiable();

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("http://test.com/"),
        };

        var act = async () => await OAuthUtil.GetAccessTokenAsync(httpClient, "someClient", "someSecret");

        await act.Should().ThrowAsync<JsonException>();
    }

    [Test]
    public async Task GetAccessTokenAsync_ShouldHttpException_WhenAccessTokenRequestFails()
    {
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
            "SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
            })
            .Verifiable();

        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("http://test.com/"),
        };

        var act = async () => await OAuthUtil.GetAccessTokenAsync(httpClient, "someClient", "someSecret");

        await act.Should()
            .ThrowAsync<HttpRequestException>();
    }
}
