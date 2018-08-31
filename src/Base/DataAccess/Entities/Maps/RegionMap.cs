using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class RegionMap : EntityMap<Region>
    {
        public RegionMap()
        {
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.RegionId).ToColumn("REGION_ID");
            Map(p => p.RegionName).ToColumn("REGION_NAME");
            Map(p => p.CountryId).ToColumn("COUNTRY_ID");
            Map(p => p.MilitaryOwnerId).ToColumn("MILITARY_OWNER_ID");
            Map(p => p.GeoGroup).ToColumn("GEO_GROUP");
            Map(p => p.Continent).ToColumn("CONTINENT");
            Map(p => p.History).ToColumn("HISTORY");
            Map(p => p.Population15).ToColumn("POPULATION_15");
            Map(p => p.Population1565).ToColumn("POPULATION_15_65");
            Map(p => p.Population65).ToColumn("POPULATION_65");
            Map(p => p.Infrastructure).ToColumn("INFRASTRUCTURE");
            Map(p => p.TelecomLevel).ToColumn("TELECOM_LEVEL");
            Map(p => p.TourismIncome).ToColumn("TOURISM_INCOME");
            Map(p => p.AreaWater).ToColumn("AREA_WATER");
            Map(p => p.ArableLand).ToColumn("ARABLE_LAND");
            Map(p => p.ForestLand).ToColumn("FOREST_LAND");
            Map(p => p.ParksLand).ToColumn("PARKS_LAND");
            Map(p => p.NotUsedLand).ToColumn("NOT_USED_LAND");
            Map(p => p.HighestPoint).ToColumn("HIGHEST_POINT");
            Map(p => p.LowestPoint).ToColumn("LOWEST_POINT");
            Map(p => p.StandardElevation).ToColumn("STANDARD_ELEVATION");
            Map(p => p.Coastlines).ToColumn("COASTLINES");
            Map(p => p.CerealsProduction).ToColumn("CEREALS_PRODUCTION");
            Map(p => p.VegFruitsProduction).ToColumn("VEG_FRUITS_PRODUCTION");
            Map(p => p.MeatProduction).ToColumn("MEAT_PRODUCTION");
            Map(p => p.DairyProduction).ToColumn("DAIRY_PRODUCTION");
            Map(p => p.TobaccoProduction).ToColumn("TOBACCO_PRODUCTION");
            Map(p => p.DrugsProduction).ToColumn("DRUGS_PRODUCTION");
            Map(p => p.ElectricityProduction).ToColumn("ELECTRICITY_PRODUCTION");
            Map(p => p.FossileFuelsProduction).ToColumn("FOSSILE_FUELS_PRODUCTION");
            Map(p => p.WoodProduction).ToColumn("WOOD_PRODUCTION");
            Map(p => p.MineralsProduction).ToColumn("MINERALS_PRODUCTION");
            Map(p => p.IronSteelProduction).ToColumn("IRON_STEEL_PRODUCTION");
            Map(p => p.PrecStonesProduction).ToColumn("PREC_STONES_PRODUCTION");
            Map(p => p.FabricsProduction).ToColumn("FABRICS_PRODUCTION");
            Map(p => p.PlasticsProduction).ToColumn("PLASTICS_PRODUCTION");
            Map(p => p.ChemicalsProduction).ToColumn("CHEMICALS_PRODUCTION");
            Map(p => p.PharmaProduction).ToColumn("PHARMA_PRODUCTION");
            Map(p => p.HhApplProduction).ToColumn("HH_APPL_PRODUCTION");
            Map(p => p.VehiculesProduction).ToColumn("VEHICULES_PRODUCTION");
            Map(p => p.MachineryProduction).ToColumn("MACHINERY_PRODUCTION");
            Map(p => p.HhCommProduction).ToColumn("HH_COMM_PRODUCTION");
            Map(p => p.LuxuryCommProduction).ToColumn("LUXURY_COMM_PRODUCTION");
            Map(p => p.ConstructionProduction).ToColumn("CONSTRUCTION_PRODUCTION");
            Map(p => p.EngineeringProduction).ToColumn("ENGINEERING_PRODUCTION");
            Map(p => p.HealthCareProduction).ToColumn("HEALTH_CARE_PRODUCTION");
            Map(p => p.RetailProduction).ToColumn("RETAIL_PRODUCTION");
            Map(p => p.LegalServProduction).ToColumn("LEGAL_SERV_PRODUCTION");
            Map(p => p.MarketAdProduction).ToColumn("MARKET_AD_PRODUCTION");
            Map(p => p.RandomAvalanche).ToColumn("RANDOM_AVALANCHE");
            Map(p => p.RandomBlizzard).ToColumn("RANDOM_BLIZZARD");
            Map(p => p.RandomColdwave).ToColumn("RANDOM_COLDWAVE");
            Map(p => p.RandomCyclone).ToColumn("RANDOM_CYCLONE");
            Map(p => p.RandomDrought).ToColumn("RANDOM_DROUGHT");
            Map(p => p.RandomEarthquake).ToColumn("RANDOM_EARTHQUAKE");
            Map(p => p.RandomFlood).ToColumn("RANDOM_FLOOD");
            Map(p => p.RandomHeatwave).ToColumn("RANDOM_HEATWAVE");
            Map(p => p.RandomHurricane).ToColumn("RANDOM_HURRICANE");
            Map(p => p.RandomInsects).ToColumn("RANDOM_INSECTS");
            Map(p => p.RandomLandslide).ToColumn("RANDOM_LANDSLIDE");
            Map(p => p.RandomStorm).ToColumn("RANDOM_STORM");
            Map(p => p.RandomTidalwave).ToColumn("RANDOM_TIDALWAVE");
            Map(p => p.RandomTornado).ToColumn("RANDOM_TORNADO");
            Map(p => p.RandomTsunami).ToColumn("RANDOM_TSUNAMI");
            Map(p => p.RandomTyphoon).ToColumn("RANDOM_TYPHOON");
            Map(p => p.RandomVolcanic).ToColumn("RANDOM_VOLCANIC");
            Map(p => p.RandomWildfire).ToColumn("RANDOM_WILDFIRE");
            Map(p => p.RandomStockcrash).ToColumn("RANDOM_STOCKCRASH");
            Map(p => p.RandomEcoDep).ToColumn("RANDOM_ECO_DEP");
            Map(p => p.RandomEcoBoom).ToColumn("RANDOM_ECO_BOOM");
            Map(p => p.RandomPoorHarv).ToColumn("RANDOM_POOR_HARV");
            Map(p => p.RandomBountHarv).ToColumn("RANDOM_BOUNT_HARV");
            Map(p => p.RandomLivestock).ToColumn("RANDOM_LIVESTOCK");
            Map(p => p.RandomResOre).ToColumn("RANDOM_RES_ORE");
            Map(p => p.RandomResEnergy).ToColumn("RANDOM_RES_ENERGY");
            Map(p => p.RandomWealth).ToColumn("RANDOM_WEALTH");
            Map(p => p.RandomEpidemic).ToColumn("RANDOM_EPIDEMIC");
            Map(p => p.RandomPopBoom).ToColumn("RANDOM_POP_BOOM");
            Map(p => p.RandomFamine).ToColumn("RANDOM_FAMINE");
            Map(p => p.RandomNuclear).ToColumn("RANDOM_NUCLEAR");
            Map(p => p.RandomChemical).ToColumn("RANDOM_CHEMICAL");
            Map(p => p.RandomIndustrial).ToColumn("RANDOM_INDUSTRIAL");
            Map(p => p.RandomAntiglobal).ToColumn("RANDOM_ANTIGLOBAL");
        }
    }
}