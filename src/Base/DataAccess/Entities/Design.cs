using SuperPowerEditor.Base.DataAccess.Enums;

namespace SuperPowerEditor.Base.DataAccess.Entities
{
    public class Design
    {
        private Design()
        {            
        }

        public Design(int id, int designId, Country countryDesigner, int typeId, int nameId, int speed, int sensors,
            int gunRange, int gunPrecision, int gunDamage, int missilePayload, int missileRange, int missilePrecision, 
            int missileDamage, int stealth, int countermeasures, int armor, short? piece1,short? piece2, short? piece3, short? texture)
        {
            CountryDesignerRef = countryDesigner;

            Id = id;
            DesignId = designId;
            CountryDesigner = CountryDesignerRef.Id;
            TypeId = typeId;
            Name = nameId;
            Speed = speed;
            Sensors = sensors;
            GunRange = gunRange;
            GunPrecision = gunPrecision;
            GunDamage = gunDamage;
            MissilePayload = missilePayload;
            MissileRange = missileRange;
            MissilePrecision = missilePrecision;
            MissileDamage = missileDamage;
            Stealth = stealth;
            Countermeasures = countermeasures;
            Armor = armor;
            Piece1 = piece1;
            Piece2 = piece2;
            Piece3 = piece3;
            Texture = texture;
        }

        public Country CountryDesignerRef { get; private set; }

        public DesignType TypeRef => !TypeId.HasValue ? null : DesignType.FromId(TypeId.Value);

        public int? Id { get; private set; }
        public int? DesignId { get; private set; }
        public int? CountryDesigner { get; private set; }
        public int? TypeId { get; private set; }
        public int? Name { get; private set; }
        public int? Speed { get; private set; }
        public int? Sensors { get; private set; }
        public int? GunRange { get; private set; }
        public int? GunPrecision { get; private set; }
        public int? GunDamage { get; private set; }
        public int? MissilePayload { get; private set; }
        public int? MissileRange { get; private set; }
        public int? MissilePrecision { get; private set; }
        public int? MissileDamage { get; private set; }
        public int? Stealth { get; private set; }
        public int? Countermeasures { get; private set; }
        public int? Armor { get; private set; }
        public short? Piece1 { get; private set; }
        public short? Piece2 { get; private set; }
        public short? Piece3 { get; private set; }
        public short? Texture { get; private set; }
    }
}