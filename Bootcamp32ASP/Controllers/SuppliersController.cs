using Bootcamp32ASP.Models;
using Bootcamp32ASP.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bootcamp32ASP.Controllers
{
    public class SuppliersController : Controller
    {
        Bootcamp32Entities myContext = new Bootcamp32Entities();
        readonly HttpClient client = new HttpClient();

        public SuppliersController()
        {
            client.BaseAddress = new Uri("http://localhost:4393/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Suppliers
        public ActionResult Index()
        {
            //untuk membuat halaman atau page : klik kanan disini Add View

            //var supplier = myContext.tb_m_supplier.AsEnumerable();
            return View(List());
        }

        public async Task<JsonResult> List()
        {
            HttpResponseMessage response = await client.GetAsync("api/suppliers");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<tb_m_supplier[]>();
                var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

                return Json(json, JsonRequestBehavior.AllowGet);
            }
            return Json("Internal Server Error", JsonRequestBehavior.AllowGet);
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Suppliers/Create
        [HttpPost]
        public ActionResult Create(tb_m_supplier supplier)
        {
            try
            {
                // TODO: Add insert logic here
                tb_m_supplier createSupp = new tb_m_supplier();
                createSupp.Name = supplier.Name;
                createSupp.Email = supplier.Email;
                createSupp.CreateDate = DateTimeOffset.Now.LocalDateTime;
                myContext.tb_m_supplier.Add(createSupp);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int id)
        {
            var supp = myContext.tb_m_supplier.Where(i => i.Id == id).FirstOrDefault();
            // var supp = myContext.tb_m_supplier.Find(id) ==> Cara cepat
            return View(supp);
        }

        // POST: Suppliers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tb_m_supplier supplier)
        {
            try
            {
                // TODO: Add update logic here
                var supp = myContext.tb_m_supplier.Where(i => i.Id == id).FirstOrDefault();
                supp.Name = supplier.Name;
                supp.Email = supplier.Email;
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int id)
        {
            var delRow = myContext.tb_m_supplier.Where(s => s.Id == id).FirstOrDefault();
            return View(delRow);
        }

        // POST: Suppliers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var delRow = myContext.tb_m_supplier.Where(s => s.Id == id).FirstOrDefault();
                myContext.tb_m_supplier.Remove(delRow);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
