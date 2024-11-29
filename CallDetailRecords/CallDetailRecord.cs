public class CallDetailRecord
{
    public string Caller { get; set; } // Phone Number
    public string Receiver { get; set; } // Phone Number
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }

    public CallDetailRecord(string caller, string receiver, DateTime startTime, int duration)
    {
        Caller = caller; // Overrides the property initializer
        Receiver = receiver; // Overrides the property initializer
        StartTime = startTime; // Overrides the property initializer
        Duration = duration; // Overrides the property initializer
    }
}
