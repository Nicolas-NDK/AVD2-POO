using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabalho.Models;

namespace Trabalho.Controllers
{
    public class CursoDisciplinasController : Controller
    {
        private readonly DataContext _context;

        public CursoDisciplinasController(DataContext context)
        {
            _context = context;
        }

        // GET: CursoDisciplinas
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.CursoDisciplina.Include(c => c.Curso).Include(c => c.Disciplina).Include(x => x.Curso.Departamento).Include(x => x.Curso.Departamento.Instituicao);
            return View(await dataContext.ToListAsync());
        }

        // GET: CursoDisciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CursoDisciplina == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursoDisciplina
                .Include(c => c.Curso)
                .Include(c => c.Disciplina)
                .FirstOrDefaultAsync(m => m.DisciplinaId == id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return View(cursoDisciplina);
        }

        // GET: CursoDisciplinas/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Curso, "CursoId", "CursoId");
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "DisciplinaId", "DisciplinaId");
            return View();
        }

        // POST: CursoDisciplinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CursoId,DisciplinaId")] CursoDisciplina cursoDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "CursoId", "CursoId", cursoDisciplina.CursoId);
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "DisciplinaId", "DisciplinaId", cursoDisciplina.DisciplinaId);
            return View(cursoDisciplina);
        }

        // GET: CursoDisciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CursoDisciplina == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursoDisciplina.FindAsync(id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "CursoId", "CursoId", cursoDisciplina.CursoId);
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "DisciplinaId", "DisciplinaId", cursoDisciplina.DisciplinaId);
            return View(cursoDisciplina);
        }

        // POST: CursoDisciplinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CursoId,DisciplinaId")] CursoDisciplina cursoDisciplina)
        {
            if (id != cursoDisciplina.DisciplinaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoDisciplinaExists(cursoDisciplina.DisciplinaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "CursoId", "CursoId", cursoDisciplina.CursoId);
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "DisciplinaId", "DisciplinaId", cursoDisciplina.DisciplinaId);
            return View(cursoDisciplina);
        }

        // GET: CursoDisciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CursoDisciplina == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursoDisciplina
                .Include(c => c.Curso)
                .Include(c => c.Disciplina)
                .FirstOrDefaultAsync(m => m.DisciplinaId == id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return View(cursoDisciplina);
        }

        // POST: CursoDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CursoDisciplina == null)
            {
                return Problem("Entity set 'DataContext.CursoDisciplina'  is null.");
            }
            var cursoDisciplina = await _context.CursoDisciplina.FindAsync(id);
            if (cursoDisciplina != null)
            {
                _context.CursoDisciplina.Remove(cursoDisciplina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoDisciplinaExists(int id)
        {
          return (_context.CursoDisciplina?.Any(e => e.DisciplinaId == id)).GetValueOrDefault();
        }
    }
}
