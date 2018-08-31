namespace SuperPowerEditor.Base.DataAccess.Entities
{
    public class Treaty
    {
        public int? Id { get; set; }
        public int? TreatyId { get; set; }
        public int? Name { get; set; }
        public int? TypeTreaty { get; set; }
        public string Private { get; set; }
        public string Activated { get; set; }
    }
}