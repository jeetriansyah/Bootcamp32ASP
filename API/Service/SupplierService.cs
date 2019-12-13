using API.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using Data.Model.ViewModel;
using Data.Context;
using Data.Repository.Interfaces;
using Data.Repository;

namespace API.Service
{
    public class SupplierService : ISupplierService
    {
        ISupplierRepository supplierRepository = new SupplierRepository();

        public int Create(SupplierVM supplierVM)
        {
            if (string.IsNullOrWhiteSpace(supplierVM.Name) || string.IsNullOrWhiteSpace(supplierVM.Email))
            {
                return 0;
            }
            else
            {
                return supplierRepository.Create(supplierVM);
            }
        }

        public int Delete(int id)
        {
            return supplierRepository.Delete(id);
        }

        public IEnumerable<Supplier> Get()
        {
            return supplierRepository.Get();
        }

        public Supplier Get(int id)
        {
            return supplierRepository.Get(id);
        }

        public int Update(int id, SupplierVM supplierVM)
        {
            if (string.IsNullOrWhiteSpace(supplierVM.Name) || string.IsNullOrWhiteSpace(supplierVM.Email))
            {
                return 0;
            }
            else
            {
                return supplierRepository.Update(id, supplierVM);
            }
        }
    }
}