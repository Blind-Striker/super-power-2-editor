using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class LanguageMap : EntityMap<Language>
    {
        public LanguageMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.LanguageName).ToColumn("LANGUAGE_NAME");
        }
    }
}