using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class ReligionsMap : EntityMap<Religions>
    {
        public ReligionsMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.RegionId).ToColumn("REGION_ID");
            Map(p => p.ReligionId).ToColumn("RELIGION_ID");
            Map(p => p.Population).ToColumn("POPULATION");
        }
    }
}