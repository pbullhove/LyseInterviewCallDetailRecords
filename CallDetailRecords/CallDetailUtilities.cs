using System.Collections;
using System.Reflection.PortableExecutable;

namespace CallDetailRecords;

public static class CallDetailUtilities
{
    public static IEnumerable<string> MostActiveCallersByNumberOfCalls(
        IEnumerable<CallDetailRecord> records
    )
    {
        // LINQ Group By?
        // Og deretter LINQ Sort?
        // Returner en sortert liste
        // aha denne må også være i begge ender.  
        // Optional param som er maks antall som skal returneres
        // Problem når det er mange som har
        return [];
    }

    public static int TotalDurationToCaller(IEnumerable<CallDetailRecord> records, string receiver)
    {
        
        // LINQ FindAll på Receiver == receiver og så sum?
        // Hva hvis den ikke finnes
        // Eller LINQ Aggregate?
        
        return records.Aggregate(0, (sum, next) => next.Receiver == receiver ? sum + next.Duration : sum);
    }
    
    public static int TotalDistinctPhoneNumbers(IEnumerable<CallDetailRecord> records)
    {
        // Husk både callers og receivers her
        // lage et nytt HashSet basert på LINQ map? 
        
        return 0; 
    }
}
