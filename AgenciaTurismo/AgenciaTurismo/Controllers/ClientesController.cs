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
    public class ClientesController : Controller
    {
        private readonly BancoDados _context;

        public ClientesController(BancoDados context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }


        // GET: Clientes/Create
        public IActionResult AddEdit(int id = 0)
        {
            if (id == 0)
                return View(new Cliente());
            else
                return View(_context.Clientes.Find(id));
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit([Bind("Id,Nome,Cpf")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Id == 0)
                    _context.Add(cliente);
                else
                    _context.Update(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

  
        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
