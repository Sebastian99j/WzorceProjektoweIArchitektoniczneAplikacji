namespace CodeSmells;

public class EventDetails
{
    public string EventName { get; set; }
    public DateTime EventDate { get; set; }
    public string Location { get; set; }

    public void RegisterEvent(EventDetails eventDetails)
    {
        Console.WriteLine($"EventName: {eventDetails.EventName}, EventDate: {eventDetails.EventDate}, Location: {eventDetails.Location}");
    }
}