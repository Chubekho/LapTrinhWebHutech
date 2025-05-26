using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buoi5.Models;

namespace Buoi5.Controllers
{
    public class GradeController : Controller
    {
        private readonly Buoi5DbContext _context;

        public GradeController(Buoi5DbContext context)
        {
            _context = context;
        }

        // GET: Grade
        public IActionResult Index()
        {
            List<Grade> listGrade = _context.Grade.ToList();
            return View(listGrade);
        }

        // GET: Grade/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var grade = _context.Grade
                .Include(g => g.Students)
                .FirstOrDefault(m => m.GradeId == id);
            if (grade == null) return NotFound();

            return View(grade);
        }

        // GET: Grade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Grade grade)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
                return View(grade);
            }
            _context.Add(grade);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Grade/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var grade = _context.Grade.Find(id);
            if (grade == null) return NotFound();

            return View(grade);
        }

        // POST: Grade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("GradeId,GradeName")] Grade grade)
        {
            if (id != grade.GradeId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(grade);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(grade);
        }

        // GET: Grade/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var grade = _context.Grade.FirstOrDefault(m => m.GradeId == id);
            if (grade == null) return NotFound();

            return View(grade);
        }

        // POST: Grade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var grade = _context.Grade.Find(id);
            if (grade != null)
            {
                _context.Grade.Remove(grade);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
