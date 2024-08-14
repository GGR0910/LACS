using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUnitOfWorkApplication : IDisposable
    {
        int SaveChanges();

        #region Interfaces

        IUserApplication User { get; }
        ISampleApplication Sample { get; }
        ISolicitationApplication Solicitation { get; }
        ILaboratoryApplication Laboratory { get; }

        #endregion
    }
}
