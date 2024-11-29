using System.Collections;

namespace CallDetailRecords;

class CallDetailUtilities
{
    public IEnumerable<string> MostActiveCallersByNumberOfCalls(
        IEnumerable<CallDetailRecord> records
    )
    {
        // LINQ Group By?
        // Og deretter LINQ Sort?
        // Returner en sortert liste
        // Optional param som er maks antall som skal returneres
        // Problem når det er mange som har
        return [];
    }

    public int TotalDurationByCaller(IEnumerable<CallDetailRecord> records, string Caller)
    {
        return 0; 
    }
    
    public int TotalDistinctPhoneNumbers(IEnumerable<CallDetailRecord> records)
    {
        // Husk både callers og receivers her
        
        return 0; 
    }
}
