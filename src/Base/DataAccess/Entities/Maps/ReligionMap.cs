using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class ReligionMap : EntityMap<Religion>
    {
        public ReligionMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.ReligionName).ToColumn("RELIGION_NAME");
        }
    }
}