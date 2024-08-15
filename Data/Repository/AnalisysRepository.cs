
using Data.Context;
using Data.Interface;
using Domain.Entities;

namespace Data.Repository
{
    public class AnalisysRepository : BaseRepository<Analisys>, IAnalisysRepository
    {
        public AnalisysRepository(DataContext baseContext) : base(baseContext)
        {
        }
    }
}
