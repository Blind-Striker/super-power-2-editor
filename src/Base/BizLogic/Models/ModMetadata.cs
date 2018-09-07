using System.Collections.Immutable;

namespace SuperPowerEditor.Base.BizLogic.Models
{
    public class ModMetadata
    {
        public ModMetadata(string id, string name, string version, string signature, string dataPath, string modDatabasePath, IImmutableDictionary<string, StringTableMetadata> stringTableMetadata)
        {
            Id = id;
            Name = name;
            Version = version;
            Signature = signature;
            DataPath = dataPath;
            ModDatabasePath = modDatabasePath;
            StringTableMetadata = stringTableMetadata;
        }

        public string Id { get; }

        public string Name { get; }

        public string Version { get; }

        public string Signature { get; }

        public string DataPath { get; }

        public string ModDatabasePath { get;  }

        public IImmutableDictionary<string, StringTableMetadata> StringTableMetadata { get; }
    }

    public class StringTableMetadata
    {
        public StringTableMetadata(string lang, string tablePath)
        {
            Lang = lang;
            TablePath = tablePath;
        }

        public string Lang { get; }

        public string TablePath { get; }
    }
}
