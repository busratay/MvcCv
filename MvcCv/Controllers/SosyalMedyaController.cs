using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SosyalMedyaEkle(TblSosyalMedya sm)
        {
            repo.TAdd(sm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SosyalMedyaDuzenle(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SosyalMedyaDuzenle(TblSosyalMedya sm)
        {
            var hesap = repo.Find(x => x.ID == sm.ID);
            hesap.Ad = sm.Ad;
            hesap.Durum = true;
            hesap.Link = sm.Link;
            hesap.Ikon = sm.Ikon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalMedyaSil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}