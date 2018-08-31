using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class GroupUnitMap : EntityMap<GroupUnit>
    {
        public GroupUnitMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.GroupId).ToColumn("GROUP_ID");
            Map(p => p.UnitId).ToColumn("UNIT_ID");
        }
    }
}