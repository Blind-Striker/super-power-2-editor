using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class DesignFormatMap : EntityMap<DesignFormat>
    {
        public DesignFormatMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.UnitType).ToColumn("UNIT_TYPE");
            Map(p => p.CountryId).ToColumn("COUNTRY_ID");
            Map(p => p.NextId).ToColumn("NEXT_ID");
            Map(p => p.Name).ToColumn("NAME");
        }
    }
}