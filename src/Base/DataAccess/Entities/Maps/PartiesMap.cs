using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class PartiesMap : EntityMap<Parties>
    {
        public PartiesMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.CountryId).ToColumn("COUNTRY_ID");
            Map(p => p.NameStid).ToColumn("NAME_STID");
            Map(p => p.Status).ToColumn("STATUS");
            Map(p => p.Perc).ToColumn("PERC");
            Map(p => p.Ideology).ToColumn("IDEOLOGY");
            Map(p => p.GvtType).ToColumn("GVT_TYPE");
            Map(p => p.InPower).ToColumn("IN_POWER");
        }
    }
}