namespace SuperPowerEditor.Base.DataAccess.Entities
{
    public class Missile
    {
        public int? Id { get; set; }
        public int? MissileId { get; set; }
        public int? CountryId { get; set; }
        public int? DesignId { get; set; }
        public int? Quantity { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int? FromSub { get; set; }
        public int? SubId { get; set; }
    }
}