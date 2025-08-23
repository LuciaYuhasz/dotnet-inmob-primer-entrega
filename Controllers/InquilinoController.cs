using Microsoft.AspNetCore.Mvc;
using dotnet_inmob_primer_entrega.Models;

public class InquilinoController : Controller
{
    private readonly DataContext _context;

    public InquilinoController(DataContext context)
    {
        _context = context;
    }

    // GET: /Inquilino
    public IActionResult Index()
    {
        var lista = _context.Inquilinos.ToList();
        return View(lista);
    }

    // GET: /Inquilino/Create
    public IActionResult Create()
    {
        return View("Form", new Inquilino()); // Vista compartida
    }

    // POST: /Inquilino/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Inquilino inquilino)
    {
        if (ModelState.IsValid)
        {
            _context.Inquilinos.Add(inquilino);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View("Form", inquilino);
    }

    // GET: /Inquilino/Edit/5
    public IActionResult Edit(int id)
    {
        var inquilino = _context.Inquilinos.FirstOrDefault(i => i.Id == id);
        if (inquilino == null)
        {
            return NotFound();
        }
        return View("Form", inquilino);
    }

    // POST: /Inquilino/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Inquilino inquilino)
    {
        if (ModelState.IsValid)
        {
            _context.Inquilinos.Update(inquilino);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View("Form", inquilino);
    }

    // GET: /Inquilino/Delete/5
    public IActionResult Delete(int id)
    {
        var inquilino = _context.Inquilinos.FirstOrDefault(i => i.Id == id);
        if (inquilino == null)
        {
            return NotFound();
        }
        return View(inquilino); // Podés crear una vista Delete.cshtml para confirmar
    }

    // POST: /Inquilino/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var inquilino = _context.Inquilinos.FirstOrDefault(i => i.Id == id);
        if (inquilino != null)
        {
            _context.Inquilinos.Remove(inquilino);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}
