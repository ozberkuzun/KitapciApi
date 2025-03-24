
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/kitaplar")]
[ApiController]
public class KitapController : ControllerBase
{
    private readonly KitapciContext _context;
    public KitapController(KitapciContext context) { _context = context; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Kitap>>> TumKitaplariGetir()
        => await _context.Kitaplar.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Kitap>> KitapGetir(int id)
    {
        var kitap = await _context.Kitaplar.FindAsync(id);
        if (kitap == null)
            return NotFound();
        return kitap;
    }

    [HttpPost]
    public async Task<IActionResult> KitapEkle([FromBody] Kitap kitap)
    {
        if (kitap == null)
            return BadRequest("Geçersiz kitap");
        _context.Kitaplar.Add(kitap);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(KitapGetir), new { id = kitap.Id }, kitap);
    }
}
