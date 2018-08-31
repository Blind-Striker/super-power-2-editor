namespace SuperPowerEditor.Base.DataAccess.Entities
{
    public class CovOpsCell
    {
        public int? Id { get; set; }
        public int? CellId { get; set; }
        public int? Name { get; set; }
        public int? OwnerId { get; set; }
        public int? SpecificTarget { get; set; }
        public int? TargetSector { get; set; }
        public double? Training { get; set; }
        public int? CountryFrame { get; set; }
        public int? AssignedCountry { get; set; }
        public int? MissionType { get; set; }
        public int? MissionComplexity { get; set; }
        public int? ActualStatus { get; set; }
    }
}