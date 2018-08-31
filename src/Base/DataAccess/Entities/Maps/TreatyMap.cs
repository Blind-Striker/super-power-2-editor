using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class TreatyMap : EntityMap<Treaty>
    {
        public TreatyMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.TreatyId).ToColumn("TREATY_ID");
            Map(p => p.Name).ToColumn("NAME");
            Map(p => p.TypeTreaty).ToColumn("TYPE_TREATY");
            Map(p => p.Private).ToColumn("PRIVATE");
            Map(p => p.Activated).ToColumn("ACTIVATED");
        }
    }
}