using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Kitap
{
    [Key]
    public int Id { get; set; }
    public string Baslik { get; set; }
    public string Yazar { get; set; }
    public string ISBN { get; set; }
    public decimal Fiyat { get; set; }
    public int StokMiktari { get; set; }
    public int KategoriId { get; set; }
    [ForeignKey("KategoriId")]
    public Kategori Kategori { get; set; }
}
