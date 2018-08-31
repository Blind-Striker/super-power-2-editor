using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class StatusMap : EntityMap<Status>
    {
        public StatusMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.NameStid).ToColumn("NAME_STID");
        }
    }
}