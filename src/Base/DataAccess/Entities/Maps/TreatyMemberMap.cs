using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class TreatyMemberMap : EntityMap<TreatyMember>
    {
        public TreatyMemberMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.TreatyId).ToColumn("TREATY_ID");
            Map(p => p.CountryId).ToColumn("COUNTRY_ID");
            Map(p => p.Side).ToColumn("SIDE");
            Map(p => p.Activated).ToColumn("ACTIVATED");
            Map(p => p.Original).ToColumn("ORIGINAL");
            Map(p => p.Suspended).ToColumn("SUSPENDED");
        }
    }
}