using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroManager.Data;

namespace SuperheroManager.Models
{
    public class SuperherosController : Controller
    {
        private ApplicationDbContext _context { get; }
        public SuperherosController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Superheros
        public ActionResult Index()
        {
            var superheros = _context.Superheros;
            return View(superheros);
        }

        // GET: Superheros/Details/5
        public ActionResult Details(int id)
        {
            Superhero superhero = _context.Superheros.FirstOrDefault(s => s.Id == id);
            return View(superhero);
        }

        // GET: Superheros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Superheros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Superheros.Add(superhero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheros/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superhero = _context.Superheros.FirstOrDefault(s => s.Id == id);
            return View(superhero);
        }

        // POST: Superheros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Superhero superheroToUpdate = _context.Superheros.First(s => s.Id == id);
                superheroToUpdate.Name = collection["Name"];
                superheroToUpdate.AlterEgo = collection["AlterEgo"];
                superheroToUpdate.PrimarySuperheroAbility = collection["PrimarySuperheroAbility"];
                superheroToUpdate.SecondarySuperheroAbility = collection["SecondarySuperheroAbility"];
                superheroToUpdate.Catchphrase = collection["Catchphrase"];
                _context.SaveChanges();
                //_context.Superheros.First(s => s.Id == id).
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheros/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superhero = _context.Superheros.First(s => s.Id == id);
            return View(superhero);
        }

        // POST: Superheros/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Superhero superhero = _context.Superheros.First(s => s.Id == id);
                _context.Superheros.Remove(superhero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}