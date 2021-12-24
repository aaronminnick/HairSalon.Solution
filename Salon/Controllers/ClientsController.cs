using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Salon.Models;
using System.Collections.Generic;
using System.Linq;

namespace Salon.Controllers
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
      return RedirectToAction("Details", "Stylists");
    }

    public ActionResult Details(int id)
    {
      return View();
    }

    public ActionResult Edit(int id)
    {
      return View();
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      return RedirectToAction("Details", "Stylists");
    }

    public ActionResult Delete(int id)
    {
      return View();
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      return RedirectToAction("Details", "Stylists");
    }
  }
}