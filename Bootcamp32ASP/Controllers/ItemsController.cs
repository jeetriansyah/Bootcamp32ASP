using Bootcamp32ASP.Models;
using Bootcamp32ASP.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootcamp32ASP.Controllers
{
    public class ItemsController : Controller
    {
        Bootcamp32Entities myContext = new Bootcamp32Entities();

        // GET: Items
        public ActionResult Index()
        {
            //var items = myContext.tb_m_items.ToList();
            return View(List());
        }

        public JsonResult List()
        {
            var data = myContext.tb_m_items.ToList();
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            var db = new Bootcamp32Entities();
            IEnumerable<SelectListItem> listSupp = db.tb_m_supplier.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToArray();
            ViewBag.Supplier_Id = listSupp;
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(ItemVM itemVm)
        {
            try
            {
                // TODO: Add insert logic here

                tb_m_items createItem = new tb_m_items();
                createItem.NameItem = itemVm.NameItem;
                createItem.Price = itemVm.Price;
                createItem.Stock = itemVm.Stock;
                createItem.Supplier_Id = itemVm.Supplier_Id;
                myContext.tb_m_items.Add(createItem);
                myContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET
        public ActionResult Edit(int id)
        {
            var item = myContext.tb_m_items.Find(id);
            ItemVM itemVM = new ItemVM();
            var db = new Bootcamp32Entities();

            IEnumerable<SelectListItem> listSupp = db.tb_m_supplier.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
                //Selected = s.Id == item.tb_m_supplier.Id
            }).ToArray();
            foreach (var selItem in listSupp)
            {
                if (item.tb_m_supplier.Name == selItem.Text)
                {
                    selItem.Selected = true;
                }
                else
                {
                    selItem.Selected = false;
                }
            }
            ViewBag.Supplier_Id = listSupp;
            itemVM.ID = item.ID;
            itemVM.NameItem = item.NameItem;
            itemVM.Price = item.Price;
            itemVM.Stock = item.Stock;
            itemVM.Supplier_Id = item.tb_m_supplier.Id;
            return View(itemVM);
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ItemVM itemVm)
        {
            try
            {
                // TODO: Add update logic here
                var editItem = myContext.tb_m_items.Where(i => i.ID == id).FirstOrDefault();
                tb_m_items itm = new tb_m_items();
                editItem.NameItem = itemVm.NameItem;
                editItem.Price = itemVm.Price;
                editItem.Stock = itemVm.Stock;
                editItem.Supplier_Id = itemVm.Supplier_Id;
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int id)
        {
            var delRow = myContext.tb_m_items.Where(i => i.ID == id).FirstOrDefault();
            return View(delRow);
        }

        // POST: Items/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var delRow = myContext.tb_m_items.Where(i => i.ID == id).FirstOrDefault();
                myContext.tb_m_items.Remove(delRow);
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