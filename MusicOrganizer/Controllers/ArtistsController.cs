using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    [HttpGet("/records/{recordId}/artists/new")]
    public ActionResult New(int recordId)
    {
      Record record = Record.Find(recordId);
      return View(record);
    }

    [HttpGet("/records/{recordId}/artists/{artistId}")]
    public ActionResult Show(int recordId, int artistId)
    {
      Artist artist = Artist.Find(artistId);
      Record record = Record.Find(recordId);
      Dictionary<string, object> music = new Dictionary<string, object>();
      music.Add("artist", artist);
      music.Add("record", record);
      return View(music);
    }
  }
} 