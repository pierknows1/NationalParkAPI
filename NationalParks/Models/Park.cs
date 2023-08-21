using System.ComponentModel.DataAnnotations;

namespace NationalParks.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public string ParkName { get; set; }
    public string ParkState { get; set; }
    public string ParkCity { get; set; }
    public int Rating { get; set; }
  }
}