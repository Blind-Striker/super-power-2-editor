using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class UnitGroupsMap : EntityMap<UnitGroups>
    {
        public UnitGroupsMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.GroupId).ToColumn("GROUP_ID");
            Map(p => p.CountryId).ToColumn("COUNTRY_ID");
            Map(p => p.Longitude).ToColumn("LONGITUDE");
            Map(p => p.Latitude).ToColumn("LATITUDE");
            Map(p => p.Status).ToColumn("STATUS");
        }
    }
}