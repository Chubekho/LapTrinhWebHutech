using Buoi5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Buoi5.Controllers
{
    public class StudentController : Controller
    {
        private readonly Buoi5DbContext _context;

        public StudentController(Buoi5DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listStudent = _context.Student.Include(s => s.Grade).ToList();
            return View(listStudent);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            // Load danh sách Grade để hiển thị trong dropdown
            ViewData["GradeId"] = new SelectList(_context.Grade, "GradeId", "GradeName");
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,GradeId")] Student student)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
                ViewData["GradeId"] = new SelectList(_context.Grade, "GradeId", "GradeName", student.GradeId);
                return View(student);
            }

            _context.Add(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Student/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = _context.Student.Find(id);
            if (student == null) return NotFound();

            // Load danh sách Grade để hiển thị trong dropdown
            ViewData["GradeId"] = new SelectList(_context.Grade, "GradeId", "GradeName", student.GradeId);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("StudentId,FirstName,LastName,GradeId")] Student student)
        {
            if (id != student.StudentId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["GradeId"] = new SelectList(_context.Grade, "GradeId", "GradeName", student.GradeId);
            return View(student);
        }

        // GET: Student/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = _context.Student
                .Include(s => s.Grade)
                .FirstOrDefault(m => m.StudentId == id);
            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Student.Find(id);
            if (student != null)
            {
                _context.Student.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}