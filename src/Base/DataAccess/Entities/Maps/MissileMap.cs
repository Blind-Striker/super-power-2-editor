using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class MissileMap : EntityMap<Missile>
    {
        public MissileMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.MissileId).ToColumn("MISSILE_ID");
            Map(p => p.CountryId).ToColumn("COUNTRY_ID");
            Map(p => p.DesignId).ToColumn("DESIGN_ID");
            Map(p => p.Quantity).ToColumn("QUANTITY");
            Map(p => p.Longitude).ToColumn("LONGITUDE");
            Map(p => p.Latitude).ToColumn("LATITUDE");
            Map(p => p.FromSub).ToColumn("FROM_SUB");
            Map(p => p.SubId).ToColumn("SUB_ID");
        }
    }
}