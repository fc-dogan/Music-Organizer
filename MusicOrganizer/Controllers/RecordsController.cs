  
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class RecordsController : Controller
  {
    [HttpGet("/records")]
    public ActionResult Index()
    {
      List<Record> allRecords = Record.Records;
      return View(allRecords);
    }

    [HttpGet("/records/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/records")]
    public ActionResult Create(string title)
    {
      Record newRecord = new Record(title);
      return RedirectToAction("Index");
    }

    [HttpGet("/records/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> music = new Dictionary<string, object>();
      Record selectedRecord = Record.Find(id);
      List<Artist> artistInRecord = selectedRecord.Artists;
      music.Add("record", selectedRecord);
      music.Add("artists", artistInRecord);
      return View("Show", music);
    }

    [HttpPost("/records/{recordId}/artists")]
    public ActionResult Create(int recordsId, string artistName)
    {
      Dictionary<string, object> music = new Dictionary<string, object>();
      Record foundRecord = Record.Find(recordsId);
      Artist newArtist = new Artist(artistName);
      foundRecord.AddArtist(newArtist);
      List<Artist> artistInRecord = foundRecord.Artists;
      music.Add("artists", artistInRecord);
      music.Add("record", foundRecord);
      return View("Show", music);
    }
  }
} 