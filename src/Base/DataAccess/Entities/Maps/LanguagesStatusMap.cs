using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class LanguagesStatusMap : EntityMap<LanguagesStatus>
    {
        public LanguagesStatusMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.CountryId).ToColumn("COUNTRY_ID");
            Map(p => p.LanguageId).ToColumn("LANGUAGE_ID");
            Map(p => p.Status).ToColumn("STATUS");
        }
    }
}