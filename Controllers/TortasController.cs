using Doceria.Models;
using Doceria.Persistencia;
using Doceria.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doceria.Controllers
{
    public class TortasController : Controller
    {
        private readonly DoceriaDbContext _context;

        public TortasController(DoceriaDbContext context)
        {
            _context = context;
        }

        // GET: Tortas
        public async Task<IActionResult> Index()
        {
            TortaListaViewModel viewLista = new TortaListaViewModel();
            viewLista.Lista = _context.Tortas.ToList();
            return View(viewLista);
        }

        // GET: Tortas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torta = await _context.Tortas
                .FirstOrDefaultAsync(m => m.TordaId == id);
            if (torta == null)
            {
                return NotFound();
            }

            return View(torta);
        }

        // GET: Tortas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tortas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TordaId,Nome,Descricao,Preco,Data,Tipo,IsVegana")] Torta torta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(torta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(torta);
        }

        // GET: Tortas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torta = await _context.Tortas.FindAsync(id);
            if (torta == null)
            {
                return NotFound();
            }
            return View(torta);
        }

        // POST: Tortas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TordaId,Nome,Descricao,Preco,Data,Tipo,IsVegana")] Torta torta)
        {
            if (id != torta.TordaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TortaExists(torta.TordaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = torta.TordaId });
            }
            return View(torta);
        }

        // GET: Tortas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torta = await _context.Tortas
                .FirstOrDefaultAsync(m => m.TordaId == id);
            if (torta == null)
            {
                return NotFound();
            }

            return View(torta);
        }

        // POST: Tortas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var torta = await _context.Tortas.FindAsync(id);
            if (torta != null)
            {
                _context.Tortas.Remove(torta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult VisualizarEmLista()
        {
            TortaListaViewModel viewLista = new TortaListaViewModel();
            viewLista.Lista = _context.Tortas.ToList();
            return View(viewLista);
        }
        private bool TortaExists(int id)
        {
            return _context.Tortas.Any(e => e.TordaId == id);
        }
    }
}