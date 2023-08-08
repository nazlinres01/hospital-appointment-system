using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
  public class Randevu
  {
        [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int HastaId { get; set; }
    public Hasta Hasta { get; set; }
    public int DoktorId { get; set; }
    public Doktor Doktor { get; set; }
    public ICollection<Doktor> Doktors { get; set; }

    }
}
