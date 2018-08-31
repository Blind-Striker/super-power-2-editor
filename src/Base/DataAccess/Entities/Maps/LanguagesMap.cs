using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class LanguagesMap : EntityMap<Languages>
    {
        public LanguagesMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.RegionId).ToColumn("REGION_ID");
            Map(p => p.LanguageId).ToColumn("LANGUAGE_ID");
            Map(p => p.Population).ToColumn("POPULATION");
        }
    }
}