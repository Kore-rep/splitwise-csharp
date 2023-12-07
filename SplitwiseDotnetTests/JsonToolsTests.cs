namespace SplitwiseDotnetTests;

[TestFixture]
internal class JsonToolsTests
{
    [Test]
    public void MergeFlatJson_ShouldMergeJsonStrings()
    {
        var obj1 = @"{""prop1"": ""val1"", ""prop2"": 222}";
        var obj2 = @"{""prop3"": ""val3""}";
        var expected = @"{""prop1"": ""val1"", ""prop2"": 222, ""prop3"": ""val3""}";

        var res = JsonTools.MergeFlatJson(obj1, obj2);
        res.Should().Be(expected);
    }
}
