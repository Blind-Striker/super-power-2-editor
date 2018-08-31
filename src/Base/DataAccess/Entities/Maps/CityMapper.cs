using DapperExtensions.Mapper;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public sealed class CityMapper : ClassMapper<City>
    {
        public CityMapper()
        {
            Table("CITIES");

            Map(p => p.Id).Column("ID");
            Map(p => p.NameStid).Column("NAME_STID");
            Map(p => p.Pop).Column("POP");
            Map(p => p.Longitude).Column("LONGITUDE");
            Map(p => p.Latitude).Column("LATITUDE");
            Map(p => p.RegionId).Column("REGION_ID");
        }
    }
}