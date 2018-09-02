using System.Collections.Immutable;
using System.Linq;

namespace SuperPowerEditor.Base.DataAccess.Enums
{
    public class DesignType
    {
        private DesignType()
        {            
        }

        private DesignType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }

        public static readonly DesignType Infantry = new DesignType(1, "Infantry");
        public static readonly DesignType InfantryVehicle = new DesignType(2, "Infantry Vehicle");
        public static readonly DesignType AirDefense = new DesignType(3, "Air Defense");
        public static readonly DesignType MobileLauncher = new DesignType(4, "Mobile Launcher");
        public static readonly DesignType Tank = new DesignType(5, "Tank");
        public static readonly DesignType ArtilleryGun = new DesignType(6, "Artillery Gun");
        public static readonly DesignType AttackHelicopter = new DesignType(7, "Attack Helicopter");
        public static readonly DesignType TransportHelicopter = new DesignType(8, "Transport Helicopter");
        public static readonly DesignType AswHelicopter = new DesignType(9, "ASW Helicopter");
        public static readonly DesignType FighterAircraft = new DesignType(10, "Fighter Aircraft");
        public static readonly DesignType AttackAircraft = new DesignType(11, "Attack Aircraft");
        public static readonly DesignType Bomber = new DesignType(12, "Bomber");
        public static readonly DesignType PatrolCraft = new DesignType(13, "Patrol Craft");
        public static readonly DesignType Corvette = new DesignType(14, "Corvette");
        public static readonly DesignType Frigate = new DesignType(15, "Frigate");
        public static readonly DesignType Destroyer = new DesignType(16, "Destroyer");
        public static readonly DesignType AttackSubmarine = new DesignType(17, "Attack Submarine");
        public static readonly DesignType BallisticMissileSubmarine = new DesignType(18, "Ballistic Missile Submarine");
        public static readonly DesignType AircraftCarrier = new DesignType(19, "Aircraft Carrier");
        public static readonly DesignType BallisticMissile = new DesignType(20, "Ballistic Missile");

        public static readonly IImmutableList<DesignType> DesignTypes = ImmutableList.Create<DesignType>(Infantry,
            InfantryVehicle, AirDefense, MobileLauncher, Tank, ArtilleryGun, AttackHelicopter, TransportHelicopter,
            AswHelicopter, FighterAircraft, AttackAircraft, Bomber, PatrolCraft, Corvette, Frigate, Destroyer,
            AttackSubmarine, BallisticMissileSubmarine, AircraftCarrier, BallisticMissile);

        public static DesignType FromId(int id)
        {
            return DesignTypes.SingleOrDefault(type => type.Id == id);
        }
    }
}
