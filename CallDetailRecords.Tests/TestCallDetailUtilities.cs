using Xunit;
using Xunit.Abstractions;

namespace CallDetailRecords.Tests;

public class TestCallDetailUtilities()
{
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
    
    [Fact]
    public void TestTotalDistinctPhoneNumbers__ValidRecords__ValidDistinctPhoneNumbers()
    {
        var result = CallDetailUtilities.TotalDistinctPhoneNumbers(_records);
        Assert.Equal(4, result); 
    }
    
    [Fact]
    public void TestTotalDurationToCaller__EmptyRecords__ReturnsZero()
    {
        var result = CallDetailUtilities.TotalDistinctPhoneNumbers([]);
        Assert.Equal(0, result);
    }


    [Fact]
    public void MostActiveCallerByNumberOfCalls__ValidCalls__ReturnsCorrect()
    {
        var callers =  CallDetailUtilities.MostActiveCallersByNumberOfCalls(_records, 3);
        
        Assert.Equal(3, callers.Count());
        Assert.Equal(("1", 3), callers.First());
        Assert.Equal(("2", 1), callers.Skip(1).First());
        Assert.Equal(("3", 1), callers.Skip(2).First());
    }
    
    [Fact]
    public void MostActiveCallerByNumberOfCalls__PickZero__ReturnsEmpty()
    {
        var callers =  CallDetailUtilities.MostActiveCallersByNumberOfCalls(_records, 0);
        Assert.Empty(callers);
    }
    
    [Fact]
    public void MostActiveCallerByNumberOfCalls__EmptyArray__ReturnsEmpty()
    {
        var callers =  CallDetailUtilities.MostActiveCallersByNumberOfCalls([]);
        Assert.Empty(callers);
    }
}