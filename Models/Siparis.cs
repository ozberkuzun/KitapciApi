using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Siparis
{
    [Key]
    public int Id { get; set; }
    public int KitapId { get; set; }
    [ForeignKey("KitapId")]
    public Kitap Kitap { get; set; }
    public int Miktar { get; set; }
    public decimal ToplamFiyat { get; set; }
    public DateTime SiparisTarihi { get; set; }
    public string Durum { get; set; }
}
