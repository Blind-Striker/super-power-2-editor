using SuperPowerEditor.Base.DataAccess.Contracts;
using SuperPowerEditor.Base.DataAccess.Entities;
using SuperPowerEditor.Base.DataAccess.Repositories.Base;

namespace SuperPowerEditor.Base.DataAccess.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(IConnectionFactory connectionFactory) 
            : base(connectionFactory)
        {
        }
    }
}
