using Data.Model;
using Data.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> Get();
        Supplier Get(int id);

        int Create(SupplierVM supplierVM);
        int Update(int id, SupplierVM supplierVM);
        int Delete(int id);
    }
}
