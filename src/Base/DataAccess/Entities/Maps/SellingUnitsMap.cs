using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class SellingUnitsMap : EntityMap<SellingUnits>
    {
        public SellingUnitsMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.UnitId).ToColumn("UNIT_ID");
        }
    }
}