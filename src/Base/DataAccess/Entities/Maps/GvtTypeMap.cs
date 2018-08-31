using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class GvtTypeMap : EntityMap<GvtType>
    {
        public GvtTypeMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.NameStid).ToColumn("NAME_STID");
        }
    }
}