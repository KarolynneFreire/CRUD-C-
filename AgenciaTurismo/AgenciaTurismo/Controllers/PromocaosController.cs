using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Controllers
{
    public class PromocaosController : Controller
    {
        private readonly BancoDados _context;

        public PromocaosController(BancoDados context)
        {
            _context = context;
        }

        // GET: Promocaos
        public async Task<IActionResult> Index()
        {
            var bancoDados = _context.Promocaos.Include(p => p.Destino);
            return View(await bancoDados.ToListAsync());
        }

        // GET: Promocaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = await _context.Promocaos
                .Include(p => p.Destino)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promocao == null)
            {
                return NotFound();
            }

            return View(promocao);
        }

        // GET: Promocaos/Create
        public IActionResult AddEdit()
        {
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Nome");
            return View();
        }

        // POST: Promocaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit([Bind("Id,Desconto,DestinoId")] Promocao promocao)
        {
            if (ModelState.IsValid)
            {
                if (promocao.Id == 0)
                    _context.Add(promocao);
                else
                    _context.Update(promocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Nome", promocao.DestinoId);
            return View(promocao);
        }


        // GET: Promocaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var promocao = await _context.Promocaos.FindAsync(id);
            _context.Promocaos.Remove(promocao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
