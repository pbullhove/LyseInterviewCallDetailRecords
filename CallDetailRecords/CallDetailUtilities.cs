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
        // LINQ Group By?
        // Og deretter Sort by count of group?
        // Returner en sortert liste av tuples.
        // Optional param som er maks antall som skal returneres
        // Problem når det er mange som har like mange calls? Da spiller det kanskje ingen rolle hvem av de som er 'like jeg tar'
        
        var callerGroups = records.GroupBy(record => record.Caller, record => record.Caller); 
        callerGroups = callerGroups.OrderByDescending(callerGroup => callerGroup.Count());
        callerGroups = callerGroups.Take(pickNFirst);
        var callerTuples = callerGroups.Select(callerGroup => (callerGroup.Key, callerGroup.Count()));
        return callerTuples;
    }

    public static int TotalDurationToCaller(IEnumerable<CallDetailRecord> records, string receiver)
    {
        // Tankeprosess:
        // LINQ FindAll på Receiver == receiver og så sum?
        // Eller LINQ Aggregate? Ja, jeg går for det. Det hånterer tilfeller også hvor den ikke finnes, eller records er tom. 
        
        return records.Aggregate(0, (sum, next) => next.Receiver == receiver ? sum + next.Duration : sum);
    }
    
    public static int TotalDistinctPhoneNumbers(IEnumerable<CallDetailRecord> records)
    {
        // Husk både callers og receivers her
        // lage et nytt HashSet basert på å iterere gjennom records og legge til? 
        // og så returnere set.count?
        // Finnes helt sikkert en LINQ metode som kan gjøre dette litt raskere. 
        
        var numbers = new HashSet<string>();
        foreach (var callDetailRecord in records)
        {
            numbers.Add(callDetailRecord.Receiver);
            numbers.Add(callDetailRecord.Caller);
        }
        return numbers.Count; 
    }
}
