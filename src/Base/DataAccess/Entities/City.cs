namespace SuperPowerEditor.Base.DataAccess.Entities
{
    public class City
    {
        private City()
        {         
        }

        public City(int? id, int? nameStId, int? pop, double? longitude, double? latitude, int? regionId)
        {
            Id = id;
            NameStid = nameStId;
            Pop = pop;
            Longitude = longitude;
            Latitude = latitude;
            RegionId = regionId;
        }

        public int? Id { get; private set; }
        public int? NameStid { get; private set; }
        public int? Pop { get; private set; }
        public double? Longitude { get; private set; }
        public double? Latitude { get; private set; }
        public int? RegionId { get; private set; }
    }
}
