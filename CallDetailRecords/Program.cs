
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CallDetailRecords;

public abstract class Program
{
    private static List<CallDetailRecord> ReadCallDataRecords(string fileName)
    {
        using var r = new StreamReader(fileName);
        var rawString = r.ReadToEnd();
        var records = JsonConvert.DeserializeObject<List<CallDetailRecord>>(rawString);
        return records;
    }
    public static void Main(string[] args)
    {
        var cdrs = ReadCallDataRecords("cdrs.json");
        var mostActive = CallDetailUtilities.MostActiveCallersByNumberOfCalls(cdrs, 3);
        Console.WriteLine($"Top 3 most active callers:");
        foreach (var superCaller in mostActive)
        {
            Console.WriteLine($"{superCaller.Caller}: {superCaller.NumberOfCalls} calls");
        }
        Console.WriteLine($"Total Duration of Calls to 12345678: {CallDetailUtilities.TotalDurationToCaller(cdrs, "12345678")} seconds");
        Console.WriteLine($"Total Unique Phone Numbers: {CallDetailUtilities.TotalDistinctPhoneNumbers(cdrs)}");
    }
}