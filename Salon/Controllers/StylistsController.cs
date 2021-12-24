using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Salon.Models;
using System.Collections.Generic;
using System.Linq;

namespace Salon.Controllers
{
  
  public class StylistsController : Controller
  {
    private readonly SalonContext _db;

    public StylistsController(SalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylists.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      _db.Stylists.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = stylist.StylistId});
    }

    public ActionResult Details(int id)
    {
      Stylist model = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      return View(model);
    }

    public ActionResult Edit(int id)
    {
      Stylist model = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      return View(model);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
      _db.Entry(stylist).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details");
    }

    public ActionResult Delete(int id)
    {
      return View();
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id) //need to also receive reassigns for any clients
    {
      return RedirectToAction("Index");
    }
  }
}