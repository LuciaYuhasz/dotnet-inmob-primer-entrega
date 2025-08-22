using Microsoft.AspNetCore.Mvc;
using dotnet_inmob_primer_entrega.Models;

namespace dotnet_inmob_primer_entrega.Controllers
{
    public class PropietarioController : Controller
    {
        private readonly DataContext _context;

        public PropietarioController(DataContext context)
        {
            _context = context;
        }

        // GET: /Propietario
        public IActionResult Index()
        {
            var propietarios = _context.Propietarios.ToList();
            return View(propietarios);
        }

        // GET: /Propietario/Details/5
        public IActionResult Details(int id)
        {
            var propietario = _context.Propietarios.FirstOrDefault(p => p.Id == id);
            if (propietario == null) return NotFound();
            return View(propietario);
        }

        // GET: /Propietario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Propietario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                _context.Propietarios.Add(propietario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(propietario);
        }

        // GET: /Propietario/Edit/5
        public IActionResult Edit(int id)
        {
            var propietario = _context.Propietarios.Find(id);
            if (propietario == null) return NotFound();
            return View(propietario);
        }

        // POST: /Propietario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Propietario propietario)
        {
            if (id != propietario.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(propietario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(propietario);
        }

        // GET: /Propietario/Delete/5
        public IActionResult Delete(int id)
        {
            var propietario = _context.Propietarios.FirstOrDefault(p => p.Id == id);
            if (propietario == null) return NotFound();
            return View(propietario);
        }

        // POST: /Propietario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var propietario = _context.Propietarios.Find(id);
            if (propietario != null)
            {
                _context.Propietarios.Remove(propietario);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
