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
    public class ContatoesController : Controller
    {
        private readonly BancoDados _context;

        public ContatoesController(BancoDados context)
        {
            _context = context;
        }

        // GET: Contatoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contatos.ToListAsync());
        }


        // GET: Contatoes/Create
        public IActionResult AddEdit(int id=0)
        {
            if (id == 0)
                return View(new Contato());
            else
                return View(_context.Contatos.Find(id));
        }

        // POST: Contatoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit([Bind("Id,Nome,Email")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                if(contato.Id == 0)
                _context.Add(contato);
                else
                    _context.Update(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }


        // GET: Contatoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}