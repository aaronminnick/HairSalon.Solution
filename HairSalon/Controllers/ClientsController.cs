using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  
  public class ClientsController : Controller
  {
    private readonly SalonContext _db;

    public ClientsController(SalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Client> model = _db.Clients.ToList();
      return View(model);
    }

    public ActionResult Create(int stylistId, string stylistName)
    {
      ViewBag.StylistId = stylistId;
      ViewBag.StylistName = stylistName;
      return View();
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
      _db.Clients.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Details", "Stylists", new {id = client.StylistId});
    }

    public ActionResult Details(int id)
    {
      Client model = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      ViewBag.Stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == model.StylistId);
      return View(model);
    }

    public ActionResult Edit(int id)
    {
      Client model = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      Stylist current = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == model.StylistId);
      List<Stylist> stylists = _db.Stylists.ToList();
      stylists.Remove(current);
      stylists.Insert(0, current);
      ViewBag.StylistId = new SelectList(stylists, "StylistId", "FullName");
      return View(model);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      _db.Entry(client).State = EntityState.Modified;
      _db.SaveChanges();
      ViewBag.Stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == client.StylistId);
      return RedirectToAction("Details", new {id = client.ClientId});
    }

    public ActionResult Delete(int id)
    {
      Client model = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client client = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      _db.Clients.Remove(client);
      _db.SaveChanges();
      return RedirectToAction("Details", "Stylists", new {id = client.StylistId});;
    }
  }
}