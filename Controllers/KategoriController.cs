using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/kategoriler")]
[ApiController]
public class KategoriController : ControllerBase
{
    private readonly KitapciContext _context;
    public KategoriController(KitapciContext context) { _context = context; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Kategori>>> TumKategorileriGetir()
        => await _context.Kategoriler.ToListAsync();

    [HttpPost]
    public async Task<IActionResult> KategoriEkle([FromBody] Kategori kategori)
    {
        if (kategori == null)
            return BadRequest("Geçersiz kategori verisi.");
        _context.Kategoriler.Add(kategori);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(TumKategorileriGetir), new { id = kategori.Id }, kategori);
    }
}
