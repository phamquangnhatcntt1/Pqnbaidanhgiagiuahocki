using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PqnBaiDanhGiaGiuaKy.Models;

namespace PqnBaiDanhGiaGiuaKy.Controllers
{
    public class PqnStudentsController : Controller
    {
        private static List<PqnStudent> pqnStudents = new List<PqnStudent>
        {
            new PqnStudent { Id = 0, Name = "Nhất", Image = "imageA.jpg", Quantity = 10, Price = 100, IsActive = true },
            new PqnStudent { Id = 1, Name = "Nhật", Image = "imageB.jpg", Quantity = 20, Price = 200, IsActive = true }
        };


        public ActionResult Index()
        {
            return View(pqnStudents);
        }


        public ActionResult Create()
        {
            return View(new PqnStudent());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PqnStudent pqnProduct)
        {
            if (ModelState.IsValid)
            {
                pqnProduct.Id = pqnStudents.Any() ? pqnStudents.Max(p => p.Id) + 1 : 0;
                pqnStudents.Add(pqnProduct);
                return RedirectToAction("Index");
            }

            return View(pqnProduct);
        }


        public ActionResult Edit(int id)
        {
            var pqnProduct = pqnStudents.FirstOrDefault(p => p.Id == id);
            if (pqnProduct == null)
            {
                return HttpNotFound();
            }
            return View(pqnProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PqnStudent pqnProduct)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = pqnStudents.FirstOrDefault(p => p.Id == ntqProduct.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = pqnProduct.Name;
                    existingProduct.Image = pqnProduct.Image;
                    existingProduct.Quantity = pqnProduct.Quantity;
                    existingProduct.Price = pqnProduct.Price;
                    existingProduct.IsActive = pqnProduct.IsActive;
                }
                return RedirectToAction("Index");
            }

            return View(pqnProduct);
        }


        public ActionResult Delete(int id)
        {
            var pqnProduct = pqnStudents.FirstOrDefault(p => p.Id == id);
            if (pqnProduct == null)
            {
                return HttpNotFound();
            }
            return View(pqnProduct);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pqnProduct = pqnStudents.FirstOrDefault(p => p.Id == id);
            if (pqnProduct != null)
            {
                pqnStudents.Remove(pqnProduct);
            }
            return RedirectToAction("Index");
        }


    }
}