using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class TreatyConditionMap : EntityMap<TreatyCondition>
    {
        public TreatyConditionMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.TreatyId).ToColumn("TREATY_ID");
            Map(p => p.ConditionId).ToColumn("CONDITION_ID");
            Map(p => p.ConditionStatus).ToColumn("CONDITION_STATUS");
        }
    }
}