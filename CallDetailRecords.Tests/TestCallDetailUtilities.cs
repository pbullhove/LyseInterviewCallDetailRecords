using Xunit;
using Xunit.Abstractions;

namespace CallDetailRecords.Tests;

public class TestCallDetailUtilities(ITestOutputHelper output)
{
    private readonly ITestOutputHelper _output = output;
    private IEnumerable<CallDetailRecord> _records = new List<CallDetailRecord>
    {
        new() { Caller = "1", Receiver = "2", Duration = 1 },
        new() { Caller = "1", Receiver = "3", Duration = 2 },
        new() { Caller = "2", Receiver = "1", Duration = 3 },
        new() { Caller = "3", Receiver = "1", Duration = 4 },
        new() { Caller = "1", Receiver = "4", Duration = 5 },
    };

    [Fact]
    public void TestTotalDurationToCaller__ValidCaller__ValidDuration()
    {
        var result = CallDetailUtilities.TotalDurationToCaller(_records, "1");
        // Result should be 7 as caller '1' has been called 3 minutes by '2' and 4 minutes by '3'.
        Assert.Equal(7, result); 
    }
    
    [Fact]
    public void TestTotalDurationToCaller__CallerDoesNotExist__ReturnsZero()
    {
        var result = CallDetailUtilities.TotalDurationToCaller(_records, "x");
        Assert.Equal(0, result);
    }
    [Fact]
    public void TestTotalDurationToCaller__NoRecords__ReturnsZero()
    {
        var result = CallDetailUtilities.TotalDurationToCaller([], "x");
        Assert.Equal(0, result);
    }
}