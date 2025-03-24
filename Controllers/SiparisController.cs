
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

[Route("api/siparisler")]
[ApiController]
public class SiparisController : ControllerBase
{
    private readonly KitapciContext _context;
    public SiparisController(KitapciContext context) { _context = context; }

    [HttpPost]
    public async Task<IActionResult> SiparisOlustur([FromBody] Siparis siparis)
    {
        if (siparis == null)
            return BadRequest("Geçersiz sipariş");
        var kitap = await _context.Kitaplar.FindAsync(siparis.KitapId);
        if (kitap == null || kitap.StokMiktari < siparis.Miktar)
            return BadRequest("Yetersiz stok veya geçersiz kitap.");

        siparis.ToplamFiyat = kitap.Fiyat * siparis.Miktar;
        siparis.SiparisTarihi = DateTime.Now;
        siparis.Durum = "BEKLEMEDE";

        _context.Siparisler.Add(siparis);
        kitap.StokMiktari -= siparis.Miktar;
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(SiparisGetir), new { id = siparis.Id }, siparis);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Siparis>> SiparisGetir(int id)
    {
        var siparis = await _context.Siparisler.FindAsync(id);
        if (siparis == null)
            return NotFound();
        return siparis;
    }
}
