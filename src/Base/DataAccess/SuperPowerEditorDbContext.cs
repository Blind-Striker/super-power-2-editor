using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SuperPowerEditor.Base.DataAccess.Entities;

namespace SuperPowerEditor.Base.DataAccess
{
    public class SuperPowerEditorDbContext : DbContext
    {
        public SuperPowerEditorDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CovOpsCell> CovOpsCells { get; set; }
        public DbSet<Design> Designs { get; set; }
        public DbSet<DesignFormat> DesignFormats { get; set; }
        public DbSet<GroupUnit> GroupUnits { get; set; }
        public DbSet<GvtType> GvtTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageMapping> LanguageMappings { get; set; }
        public DbSet<LanguagesStatus> LanguagesStatuses { get; set; }
        public DbSet<Missile> Missiles { get; set; }
        public DbSet<PoliticalParty> PoliticalParties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<ReligionMapping> ReligionMappings { get; set; }
        public DbSet<ReligionsStatus> ReligionsStatuses { get; set; }
        public DbSet<Research> Researches { get; set; }
        public DbSet<ResourceName> ResourceNames { get; set; }
        public DbSet<Resources> Resourceses { get; set; }
        public DbSet<SellingUnit> SellingUnits { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Treaty> Treaties { get; set; }
        public DbSet<TreatyCondition> TreatyConditions { get; set; }
        public DbSet<TreatyMember> TreatyMembers { get; set; }
        public DbSet<UnitGroup> UnitGroups { get; set; }
        public DbSet<UnitMapping> UnitMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().ToTable("CITIES");
            modelBuilder.Entity<Country>().ToTable("COUNTRY");
            modelBuilder.Entity<CovOpsCell>().ToTable("COV_OPS_CELL");
            modelBuilder.Entity<Design>().ToTable("DESIGN");
            modelBuilder.Entity<DesignFormat>().ToTable("DESIGN_FORMAT");
            modelBuilder.Entity<GroupUnit>().ToTable("GROUP_UNIT");
            modelBuilder.Entity<GvtType>().ToTable("GVT_TYPE");
            modelBuilder.Entity<Language>().ToTable("LANGUAGE");
            modelBuilder.Entity<LanguageMapping>().ToTable("LANGUAGES");
            modelBuilder.Entity<LanguagesStatus>().ToTable("LANGUAGES_STATUS");
            modelBuilder.Entity<Missile>().ToTable("MISSILE");
            modelBuilder.Entity<PoliticalParty>().ToTable("PARTIES");
            modelBuilder.Entity<Region>().ToTable("REGION");
            modelBuilder.Entity<Relation>().ToTable("RELATIONS");
            modelBuilder.Entity<Religion>().ToTable("RELIGION");
            modelBuilder.Entity<ReligionMapping>().ToTable("RELIGIONS");
            modelBuilder.Entity<ReligionsStatus>().ToTable("RELIGIONS_STATUS");
            modelBuilder.Entity<Research>().ToTable("RESEARCH");
            modelBuilder.Entity<ResourceName>().ToTable("RESOURCE_NAME");
            modelBuilder.Entity<Resources>().ToTable("RESOURCES");
            modelBuilder.Entity<SellingUnit>().ToTable("SELLING_UNITS");
            modelBuilder.Entity<Status>().ToTable("STATUS");
            modelBuilder.Entity<Treaty>().ToTable("TREATY");
            modelBuilder.Entity<TreatyCondition>().ToTable("TREATY_CONDITION");
            modelBuilder.Entity<TreatyMember>().ToTable("TREATY_MEMBER");
            modelBuilder.Entity<UnitGroup>().ToTable("UNIT_GROUPS");
            modelBuilder.Entity<UnitMapping>().ToTable("UNITS");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    property.Relational().ColumnName = ToColumnName(property.Name);
                }
            }

            modelBuilder.Entity<Country>()
                .Property(country => country.Pop1565Unemployed)
                .HasColumnName("POP_15_65_UNEMPLOYED");

            modelBuilder.Entity<Design>()
                .HasOne(d => d.CountryDesignerRef)
                .WithMany()
                .HasForeignKey(design => design.CountryDesigner);

            modelBuilder.Entity<Design>()
                .Ignore(b => b.TypeRef);
        }

        private string ToColumnName(string propertyName)
        {
            return string.Concat(propertyName.Select((c, i) =>
                i > 0 && char.IsUpper(c)
                    ? "_" + c.ToString()
                    : c.ToString().ToUpper(CultureInfo.GetCultureInfo("en-US"))));
        }
    }
}
