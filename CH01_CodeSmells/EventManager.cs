namespace CodeSmells
{
    internal class EventManager
    {
        public void RegisterEvent(EventDetails eventDetails)
        {
            Console.WriteLine($"Event: {eventDetails.EventName}, Date: {eventDetails.EventDate}, Location: {eventDetails.Location}");
        }
    }
}
