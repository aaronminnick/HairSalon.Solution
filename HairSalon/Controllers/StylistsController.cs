using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HairSalon.Controllers
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
      return RedirectToAction("Details", new {id = stylist.StylistId});
    }

    public ActionResult Delete(int id)
    {
      Stylist model = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      List<Stylist> stylists = _db.Stylists.ToList();
      stylists.Remove(model);
      ViewBag.Stylists = stylists;
      return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(IFormCollection reassigns) 
    {
      foreach (string key in reassigns.Keys)
      {
        if (key != "id" && key != "__RequestVerificationToken")
        {
          Client client = _db.Clients.FirstOrDefault(client => client.ClientId == int.Parse(key));
          if (reassigns[key] == "0")
          {
            _db.Clients.Remove(client);
          }
          else
          {
          client.StylistId = int.Parse(reassigns[key]);
          _db.Entry(client).State = EntityState.Modified;
          }
        }
      }
      Stylist stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == int.Parse(reassigns["id"]));
      _db.Stylists.Remove(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}