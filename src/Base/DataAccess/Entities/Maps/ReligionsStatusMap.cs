using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class ReligionsStatusMap : EntityMap<ReligionsStatus>
    {
        public ReligionsStatusMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.CountryId).ToColumn("COUNTRY_ID");
            Map(p => p.ReligionId).ToColumn("RELIGION_ID");
            Map(p => p.Status).ToColumn("STATUS");
        }
    }
}