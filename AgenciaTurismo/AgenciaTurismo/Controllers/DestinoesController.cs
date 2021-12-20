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
    public class DestinoesController : Controller
    {
        private readonly BancoDados _context;

        public DestinoesController(BancoDados context)
        {
            _context = context;
        }

        // GET: Destinoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Destinos.ToListAsync());
        }

        // GET: Destinoes/Create
        public IActionResult AddEdit(int id= 0)
        {
            if (id == 0)
                return View(new Destino());
            else
                return View(_context.Destinos.Find(id));

        }

        // POST: Destinoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit([Bind("Id,Nome,Valor,DataInicio,DataFinal,Descricao")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                if (destino.Id == 0)
                    _context.Add(destino);
                else
                    _context.Update(destino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destino);
        }

        // GET: Destinoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var destino = await _context.Destinos.FindAsync(id);
            _context.Destinos.Remove(destino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
