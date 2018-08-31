namespace SuperPowerEditor.Base.DataAccess.Entities
{
    public class TreatyMember
    {
        public int? Id { get; set; }
        public int? TreatyId { get; set; }
        public int? CountryId { get; set; }
        public int? Side { get; set; }
        public string Activated { get; set; }
        public string Original { get; set; }
        public string Suspended { get; set; }
    }
}