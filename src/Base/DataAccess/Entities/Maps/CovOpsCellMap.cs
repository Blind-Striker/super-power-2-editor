using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class CovOpsCellMap : EntityMap<CovOpsCell>
    {
        public CovOpsCellMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.CellId).ToColumn("CELL_ID");
            Map(p => p.Name).ToColumn("NAME");
            Map(p => p.OwnerId).ToColumn("OWNER_ID");
            Map(p => p.SpecificTarget).ToColumn("SPECIFIC_TARGET");
            Map(p => p.TargetSector).ToColumn("TARGET_SECTOR");
            Map(p => p.Training).ToColumn("TRAINING");
            Map(p => p.CountryFrame).ToColumn("COUNTRY_FRAME");
            Map(p => p.AssignedCountry).ToColumn("ASSIGNED_COUNTRY");
            Map(p => p.MissionType).ToColumn("MISSION_TYPE");
            Map(p => p.MissionComplexity).ToColumn("MISSION_COMPLEXITY");
            Map(p => p.ActualStatus).ToColumn("ACTUAL_STATUS");
        }
    }
}