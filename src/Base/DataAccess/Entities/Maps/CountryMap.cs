using Dapper.FluentMap.Mapping;

namespace SuperPowerEditor.Base.DataAccess.Entities.Maps
{
    public class CountryMap : EntityMap<Country>
    {
        public CountryMap()
        {
            Map(p => p.MiliManpowerAvai).ToColumn("MILI_MANPOWER_AVAI");
            Map(p => p.InflationLevelExpected).ToColumn("INFLATION_LEVEL_EXPECTED");
            Map(p => p.InflationLevel).ToColumn("INFLATION_LEVEL");
            Map(p => p.InterestLevel).ToColumn("INTEREST_LEVEL");
            Map(p => p.MinimumWage).ToColumn("MINIMUM_WAGE");
            Map(p => p.GdpGrowth).ToColumn("GDP_GROWTH");
            Map(p => p.PoliticalParty).ToColumn("POLITICAL_PARTY");
            Map(p => p.NationalHoliday).ToColumn("NATIONAL_HOLIDAY");
            Map(p => p.GvtType).ToColumn("GVT_TYPE");
            Map(p => p.GvtStability).ToColumn("GVT_STABILITY");
            Map(p => p.GvtStabilityEx).ToColumn("GVT_STABILITY_EX");
            Map(p => p.GvtApproval).ToColumn("GVT_APPROVAL");
            Map(p => p.GvtApprovalEx).ToColumn("GVT_APPROVAL_EX");
            Map(p => p.EmigrationLevel).ToColumn("EMIGRATION_LEVEL");
            Map(p => p.EmigrationLevelEx).ToColumn("EMIGRATION_LEVEL_EX");
            Map(p => p.EmigrationClosed).ToColumn("EMIGRATION_CLOSED");
            Map(p => p.ImmigrationLevel).ToColumn("IMMIGRATION_LEVEL");
            Map(p => p.ImmigrationClosed).ToColumn("IMMIGRATION_CLOSED");
            Map(p => p.NextElection).ToColumn("NEXT_ELECTION");
            Map(p => p.CorruptionLevel).ToColumn("CORRUPTION_LEVEL");
            Map(p => p.CorruptionLevelEx).ToColumn("CORRUPTION_LEVEL_EX");
            Map(p => p.MartialLaw).ToColumn("MARTIAL_LAW");
            Map(p => p.TelecomLevelEx).ToColumn("TELECOM_LEVEL_EX");
            Map(p => p.InfrastructureLevelEx).ToColumn("INFRASTRUCTURE_LEVEL_EX");
            Map(p => p.LawFreedomSpeech).ToColumn("LAW_FREEDOM_SPEECH");
            Map(p => p.LawFreedomDemonstration).ToColumn("LAW_FREEDOM_DEMONSTRATION");
            Map(p => p.LawWomenSuffrage).ToColumn("LAW_WOMEN_SUFFRAGE");
            Map(p => p.LawNbChildren).ToColumn("LAW_NB_CHILDREN");
            Map(p => p.LawContraception).ToColumn("LAW_CONTRACEPTION");
            Map(p => p.LawAbortion).ToColumn("LAW_ABORTION");
            Map(p => p.LawChildLabor).ToColumn("LAW_CHILD_LABOR");
            Map(p => p.LawPolygamy).ToColumn("LAW_POLYGAMY");
            Map(p => p.LawSameSexMarriage).ToColumn("LAW_SAME_SEX_MARRIAGE");
            Map(p => p.NatSecurityLevel).ToColumn("NAT_SECURITY_LEVEL");
            Map(p => p.AmdsLevel).ToColumn("AMDS_LEVEL");
            Map(p => p.NuclearReady).ToColumn("NUCLEAR_READY");
            Map(p => p.LastIteration).ToColumn("LAST_ITERATION");
            Map(p => p.Id).ToColumn("ID");
            Map(p => p.NameStid).ToColumn("NAME_STID");
            Map(p => p.Code).ToColumn("CODE");
            Map(p => p.Flag).ToColumn("FLAG");
            Map(p => p.CapitalId).ToColumn("CAPITAL_ID");
            Map(p => p.Groups).ToColumn("GROUPS");
            Map(p => p.Activated).ToColumn("ACTIVATED");
            Map(p => p.AcceptForeignOrder).ToColumn("ACCEPT_FOREIGN_ORDER");
            Map(p => p.IndivCollec).ToColumn("INDIV_COLLEC");
            Map(p => p.HierDistance).ToColumn("HIER_DISTANCE");
            Map(p => p.MaleFemale).ToColumn("MALE_FEMALE");
            Map(p => p.Climate).ToColumn("CLIMATE");
            Map(p => p.NaturalHazards).ToColumn("NATURAL_HAZARDS");
            Map(p => p.Terrain).ToColumn("TERRAIN");
            Map(p => p.Pop1565Unemployed).ToColumn("POP_15_65_UNEMPLOYED");
            Map(p => p.PopInPoverty).ToColumn("POP_IN_POVERTY");
            Map(p => p.PopEconomicModel).ToColumn("POP_ECONOMIC_MODEL");
            Map(p => p.PopPoliticalIdeology).ToColumn("POP_POLITICAL_IDEOLOGY");
            Map(p => p.BirthRate).ToColumn("BIRTH_RATE");
            Map(p => p.DeathRate).ToColumn("DEATH_RATE");
            Map(p => p.BirthRateEx).ToColumn("BIRTH_RATE_EX");
            Map(p => p.DeathRateEx).ToColumn("DEATH_RATE_EX");
            Map(p => p.HumanDevelopment).ToColumn("HUMAN_DEVELOPMENT ");
            Map(p => p.Suffrage).ToColumn("SUFFRAGE");
            Map(p => p.GlobalTaxMod).ToColumn("GLOBAL_TAX_MOD");
            Map(p => p.PersonalIncomeTax).ToColumn("PERSONAL_INCOME_TAX");
            Map(p => p.AvailableMoney).ToColumn("AVAILABLE_MONEY");
            Map(p => p.EconomicActivity).ToColumn("ECONOMIC_ACTIVITY");
            Map(p => p.EconomicHealth).ToColumn("ECONOMIC_HEALTH");
            Map(p => p.BudgetExpenseUnitUpkeep).ToColumn("BUDGET_EXPENSE_UNIT_UPKEEP");
            Map(p => p.BudgetExpenseSecurity).ToColumn("BUDGET_EXPENSE_SECURITY");
            Map(p => p.BudgetExpenseDiplomacy).ToColumn("BUDGET_EXPENSE_DIPLOMACY");
            Map(p => p.BudgetExpenseImports).ToColumn("BUDGET_EXPENSE_IMPORTS");
            Map(p => p.BudgetExpenseRatioResearch).ToColumn("BUDGET_EXPENSE_RATIO_RESEARCH");
            Map(p => p.BudgetExpenseRatioInfra).ToColumn("BUDGET_EXPENSE_RATIO_INFRA");
            Map(p => p.BudgetExpenseRatioEnviron).ToColumn("BUDGET_EXPENSE_RATIO_ENVIRON");
            Map(p => p.BudgetExpenseRatioHealthcare).ToColumn("BUDGET_EXPENSE_RATIO_HEALTHCARE");
            Map(p => p.BudgetExpenseRatioEducation).ToColumn("BUDGET_EXPENSE_RATIO_EDUCATION");
            Map(p => p.BudgetExpenseRatioGovernment).ToColumn("BUDGET_EXPENSE_RATIO_GOVERNMENT");
            Map(p => p.BudgetExpenseRatioImf).ToColumn("BUDGET_EXPENSE_RATIO_IMF");
            Map(p => p.BudgetExpenseRatioTelecom).ToColumn("BUDGET_EXPENSE_RATIO_TELECOM");
            Map(p => p.BudgetExpenseRatioTourism).ToColumn("BUDGET_EXPENSE_RATIO_TOURISM");
            Map(p => p.BudgetExpenseRatioPropaganda).ToColumn("BUDGET_EXPENSE_RATIO_PROPAGANDA");
            Map(p => p.BudgetExpenseCorruption).ToColumn("BUDGET_EXPENSE_CORRUPTION");
            Map(p => p.BudgetRevenueTax).ToColumn("BUDGET_REVENUE_TAX");
            Map(p => p.BudgetRevenueExports).ToColumn("BUDGET_REVENUE_EXPORTS");
            Map(p => p.BudgetRevenueImf).ToColumn("BUDGET_REVENUE_IMF");
            Map(p => p.BudgetRevenueTourism).ToColumn("BUDGET_REVENUE_TOURISM");
            Map(p => p.PropagandaLevel).ToColumn("PROPAGANDA_LEVEL");
        }
    }
}