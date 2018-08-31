using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class DesignMap : EntityMap<Design>
    {
        public DesignMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.DesignId).ToColumn("DESIGN_ID");
            Map(p => p.CountryDesigner).ToColumn("COUNTRY_DESIGNER");
            Map(p => p.TypeId).ToColumn("TYPE_ID");
            Map(p => p.Name).ToColumn("NAME");
            Map(p => p.Speed).ToColumn("SPEED");
            Map(p => p.Sensors).ToColumn("SENSORS");
            Map(p => p.GunRange).ToColumn("GUN_RANGE");
            Map(p => p.GunPrecision).ToColumn("GUN_PRECISION");
            Map(p => p.GunDamage).ToColumn("GUN_DAMAGE");
            Map(p => p.MissilePayload).ToColumn("MISSILE_PAYLOAD");
            Map(p => p.MissileRange).ToColumn("MISSILE_RANGE");
            Map(p => p.MissilePrecision).ToColumn("MISSILE_PRECISION");
            Map(p => p.MissileDamage).ToColumn("MISSILE_DAMAGE");
            Map(p => p.Stealth).ToColumn("STEALTH");
            Map(p => p.Countermeasures).ToColumn("COUNTERMEASURES");
            Map(p => p.Armor).ToColumn("ARMOR");
            Map(p => p.Piece1).ToColumn("PIECE1");
            Map(p => p.Piece2).ToColumn("PIECE2");
            Map(p => p.Piece3).ToColumn("PIECE3");
            Map(p => p.Texture).ToColumn("TEXTURE");
        }
    }
}