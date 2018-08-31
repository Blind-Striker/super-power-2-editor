using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class ResourceNameMap : EntityMap<ResourceName>
    {
        public ResourceNameMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.NameStid).ToColumn("NAME_STID");
        }
    }
}