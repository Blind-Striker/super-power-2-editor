namespace SuperPowerEditor.Base.DataAccess.Entities
{
    public class Design
    {
        public int? Id { get; set; }
        public int? DesignId { get; set; }
        public int? CountryDesigner { get; set; }
        public int? TypeId { get; set; }
        public int? Name { get; set; }
        public int? Speed { get; set; }
        public int? Sensors { get; set; }
        public int? GunRange { get; set; }
        public int? GunPrecision { get; set; }
        public int? GunDamage { get; set; }
        public int? MissilePayload { get; set; }
        public int? MissileRange { get; set; }
        public int? MissilePrecision { get; set; }
        public int? MissileDamage { get; set; }
        public int? Stealth { get; set; }
        public int? Countermeasures { get; set; }
        public int? Armor { get; set; }
        public short? Piece1 { get; set; }
        public short? Piece2 { get; set; }
        public short? Piece3 { get; set; }
        public short? Texture { get; set; }
    }
}