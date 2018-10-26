using SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class SuperHeroesController : Controller
    {
        ApplicationDbContext db;

        public SuperHeroesController()
        {
            db = new ApplicationDbContext();
        }
        // GET: SuperHeroes
        public ActionResult Index()
        {
            return View();
        }
        //GET: SuperHeroes/Create
        public ActionResult Create()
        {
            return View(new SuperHeroes.Models.SuperHeroes());
        }

        //POST: SuperHeroes//Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Name,PrimaryAbility,SecondaryAbility,CAtchPhrase")] SuperHeroes.Models.SuperHeroes superHeroes)
        {
            try
            {
                //TODO: Add insert logic here
                db.SuperHeroes.Add(superHeroes);
                db.SaveChanges();

                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: SuperHeroes/Detail
        public ActionResult Detail()
        {
            return View();
        }

       

        public ActionResult Read(int id)
        {
            return View(db.SuperHeroes.Where(s => s.ID == id).Single());
        }

        public ActionResult List()
        {
            return View(db.SuperHeroes.ToList());
        }

        public ActionResult Delete(int id)
        {
            return View(db.SuperHeroes.Where(s => s.ID == id).Single());
        }

      
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)     
        {
            try
            {
                // TODO: Add update logic here

                db.SuperHeroes.Remove(db.SuperHeroes.Where(s => s.ID == id).Single());
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}