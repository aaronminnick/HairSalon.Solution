using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    public int StylistId {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}

    public string FullName {
      get
        {
          return FirstName + " " + LastName;
        }
    }
    public virtual ICollection<Client> Clients {get; set;}

    public Stylist()
    {
      Clients = new HashSet<Client>() {};
    }
  }
}