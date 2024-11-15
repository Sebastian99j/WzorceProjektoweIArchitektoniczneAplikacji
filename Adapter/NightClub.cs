namespace Adapter
{
    public class NightClub
    {
        public bool AllowEntry(Adult person)
        {
            return person.IsAdult();
        }
    }
}
