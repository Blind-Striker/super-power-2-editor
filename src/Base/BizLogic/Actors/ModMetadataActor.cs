﻿using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;
using SuperPowerEditor.Base.BizLogic.Actors.Events;
using SuperPowerEditor.Base.BizLogic.Models;

namespace SuperPowerEditor.Base.BizLogic.Actors
{
    public class ModMetadataActor : ReceiveActor
    {
        private const string DefaultDatabaseName = "DATABASE2.GDB";
        private const string DefaultStringTable = "StringTable.english.gst";
        private const string ModInfoXml = "modinfo.xml";

        public ModMetadataActor()
        {
            Receive<ReadModMetadataCommand>(command =>
            {
                bool exists = Directory.Exists(command.Path);

                if (!exists)
                {
                    // TODO : User friendly message
                }

                string modInfoXmlPath = Path.Combine(command.Path, ModInfoXml);

                var modInfoXml = XDocument.Load(modInfoXmlPath);

                var modInfo = (from name in modInfoXml.Descendants()
                    select new
                    {
                        Name = name.Element("Name")?.Value,
                        Id = name.Element("Id")?.Value,
                        Version = name.Element("Version")?.Value,
                        Signature = name.Element("Signature")?.Value
                    }).FirstOrDefault();

                var dataFolderPath = Path.Combine(command.Path, "data");
                var databasePath = Path.Combine(dataFolderPath, DefaultDatabaseName);

                if (!File.Exists(databasePath))
                {
                    // TODO : User friendly message
                }

                var stringTables = Directory.GetFiles(dataFolderPath, "*.gst");

                if (!stringTables.Any())
                {
                    // TODO : User friendly message
                }

                var builder = ImmutableDictionary.CreateBuilder<string, StringTableMetadata>();

                foreach (var stringTable in stringTables)
                {
                    string lang = stringTable.Split('.')[1];
                    var tableMetadata = new StringTableMetadata(lang, stringTable);

                    builder.Add(lang, tableMetadata);
                }

                var stringTableMetadata = builder.ToImmutable();

                var modMetadata = new ModMetadata(modInfo.Id, modInfo.Name, modInfo.Version, modInfo.Signature, databasePath, stringTableMetadata);

                var readedEvent = new ModMetadataReadedEvent("Success", null, modMetadata);

                command.Sender.Tell(readedEvent);
            });
        }
    }
}