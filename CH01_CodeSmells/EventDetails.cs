namespace CodeSmells
{
    internal class EventDetails
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }

        public EventDetails(string eventName, DateTime eventDate, string location)
        {
            EventName = eventName;
            EventDate = eventDate;
            Location = location;
        }
    }
}
