using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class UnitsMap : EntityMap<Units>
    {
        public UnitsMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.UnitId).ToColumn("UNIT_ID");
            Map(p => p.CountryId).ToColumn("COUNTRY_ID");
            Map(p => p.DesignId).ToColumn("DESIGN_ID");
            Map(p => p.Amount).ToColumn("AMOUNT");
            Map(p => p.Training).ToColumn("TRAINING");
        }
    }
}