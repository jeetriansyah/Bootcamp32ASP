using API.Service;
using API.Service.Interfaces;
using Data.Model;
using Data.Model.ViewModel;
using Data.Repository;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class SuppliersController : ApiController
    {
        //ISupplierRepository supplier = new SupplierRepository();
        ISupplierService supplierService = new SupplierService();
        // GET: api/Suppliers

        public SuppliersController() { }

        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public IEnumerable<Supplier> Get()
        {
            var data = supplierService.Get();
            return data;
        }

        // GET: api/Suppliers/5
        public Supplier Get(int id)
        {
            return supplierService.Get(id);
        }

        // POST: api/Suppliers
        public int Post(SupplierVM supplierVM)
        {
            return supplierService.Create(supplierVM);
        }

        // PUT: api/Suppliers/5
        public int Put(int id, SupplierVM supplierVM)
        {
            return supplierService.Update(id, supplierVM);
        }

        // DELETE: api/Suppliers/5
        public int Delete(int id)
        {
            return supplierService.Delete(id);
        }
    }
}
