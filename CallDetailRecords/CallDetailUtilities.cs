using System.Collections;
using System.Collections.Specialized;
using System.Reflection.PortableExecutable;

namespace CallDetailRecords;

public static class CallDetailUtilities
{
    public static IEnumerable<(string Caller, int NumberOfCalls)> MostActiveCallersByNumberOfCalls(
        IEnumerable<CallDetailRecord> records, int pickNFirst = 3
    )
    {
        var callerGroups = records.GroupBy(record => record.Caller, record => record.Caller); 
        callerGroups = callerGroups.OrderByDescending(callerGroup => callerGroup.Count());
        callerGroups = callerGroups.Take(pickNFirst);
        var callerTuples = callerGroups.Select(callerGroup => (callerGroup.Key, callerGroup.Count()));
        return callerTuples;
    }

    public static int TotalDurationToCaller(IEnumerable<CallDetailRecord> records, string receiver)
    {
        return records.Aggregate(0, (sum, next) => next.Receiver == receiver ? sum + next.Duration : sum);
    }
    
    public static int TotalDistinctPhoneNumbers(IEnumerable<CallDetailRecord> records)
    {
        var numbers = new HashSet<string>();
        foreach (var callDetailRecord in records)
        {
            numbers.Add(callDetailRecord.Receiver);
            numbers.Add(callDetailRecord.Caller);
        }
        return numbers.Count; 
    }
}
