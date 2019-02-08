using Arcus.DataAccess.UnitOfWork;
using Arcus.Domain.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcus.DataAccess.Repository
{
    public interface INavigationRepository : IRepository<Navigation>
    {
        List<Navigation> GetNavigation();
    }
}
