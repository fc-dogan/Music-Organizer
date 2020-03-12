
using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public string Name {get; set;}
    public int Id {get; }
    public static int CurrentId {get; set;} = 0;
    public static List<Artist> Instance {get; } = new List<Artist> {};

    public Artist(string name)
    {
      Name = name;
      Instance.Add(this);
      IncrementId();
      Id = CurrentId;
    }
    public static void IncrementId()
    {
      CurrentId ++;
    }

    public static Artist Find(int id)
    {
      for(int i = 0; i < Instance.Count; i++ )
      {
        if (Instance[i] is Artist)
        {
          if(Instance[i].Id == id)
          {
            return Instance[i];
          }
        }
      }
      return null;
    }

    public static void ClearAll()
    {
      Instance.Clear();
    }

    public static void Delete(int id)
    {
      for (int i = 0; i < Instance.Count; i++)
      {
        if (Instance[i] is Artist)
        {
          if(Instance[i].Id == id)
          {
            Instance.RemoveAt(i);
          }
        }        
      }
    }

  }
}  