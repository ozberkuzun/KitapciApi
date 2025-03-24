using System.ComponentModel.DataAnnotations;

public class Kategori
{
    [Key]
    public int Id { get; set; }
    public string Ad { get; set; }
    public List<Kitap> Kitaplar { get; set; }
}
