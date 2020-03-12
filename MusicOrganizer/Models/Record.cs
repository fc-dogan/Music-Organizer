
using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string Title {get; set;}
    public int Id {get; set;}
    public static int CurrentId {get; set;} = 0;
    public List<Artist> Artists {get; set;}

    public static List<Record> Records {get; set;} = new List<Record> {};

    public Record(string title)
    {
      Title = title;
      Records.Add(this);
      IncrementId();
      Id = CurrentId;
      Artists = new List<Artist> {};
    }

    public static void IncrementId()
    {
      CurrentId ++;
    }

    public void AddArtist(Artist artist)
    {
      Artists.Add(artist);
    }

    public static Record Find(int id)
    {
      for(int i = 0; i < Records.Count; i++ )
      {
        if (Records[i] is Record)
        {
          if(Records[i].Id == id)
          {
            return Records[i];
          }
        }
      }
      return null;
    }

    public static void ClearAll()
    {
      Records.Clear();
    }

    public static void Delete(int id)
    {
      for (int i = 0; i < Records.Count; i++)
      {
        if (Records[i] is Record)
        {
          if(Records[i].Id == id)
          {
            Records.RemoveAt(i);
          }
        }        
      }
    }
    

  }
}  