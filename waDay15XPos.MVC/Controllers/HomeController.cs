using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using waDay15XPos.MVC.Models;

namespace waDay15XPos.MVC.Controllers
{
    public class HomeController : Controller
    {
        public static List<Jurusan> listJurusan = new List<Jurusan>()
            {
                new Jurusan() {Id=1, Kode_jurusan="M123",Nama_jurusan="Matematika", Status_jurusan="Aktif" }
            };
        // GET: Home
        public ActionResult Index()
        {
            return View("TJurusan", listJurusan);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Jurusan model)
        {
            int idx = listJurusan.Max(e => e.Id) + 1;
            model.Id = idx;
            listJurusan.Add(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            Jurusan idx = listJurusan.Find(e => e.Id == Id);
            return View(idx);
        }

        [HttpPost]
        public ActionResult Edit(Jurusan model)
        {
            int idx = listJurusan.FindIndex(e => e.Id == model.Id);
            listJurusan[idx] = model;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            Jurusan idx = listJurusan.Find(e => e.Id == Id);
            return View(idx);
        }

        [HttpPost]
        public ActionResult Delete(Jurusan model)
        {
            int idx = listJurusan.FindIndex(e => e.Id == model.Id);
            listJurusan.Remove(listJurusan[idx]);
            return RedirectToAction("Index");
        }
    }
}