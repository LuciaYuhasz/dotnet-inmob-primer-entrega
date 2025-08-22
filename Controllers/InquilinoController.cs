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
        return View();
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

        return View(inquilino);
    }
}
