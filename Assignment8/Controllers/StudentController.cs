
using Microsoft.AspNetCore.Mvc;
using Assignment8.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment8.Controllers {

    public class StudentController : Controller {

        private readonly ApplicationDbContext db;

        public StudentController(ApplicationDbContext db) {

            this.db = db;
        }

        public async Task<IActionResult> Index(string SearchString) {

            var students = from t in db.Student select t;

            if(!string.IsNullOrEmpty(SearchString)) {

                students = students.Where(s => s.Student_Name!.Contains(SearchString));

            }

            return View(await students.ToListAsync());
        }

        [HttpGet]
        public IActionResult Edit(int studentid) {

            var student = db.Student!.Find(studentid);
            return View(student);
        }

        [HttpPost] 
        public IActionResult Edit(Student updatedstudent) {

            db.Student!.Update(updatedstudent);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Student_Name, Class, percentage")] Student studobj) {

            db.Student!.Add(studobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int studentid) {

            Student? studobj = db.Student!.Find(studentid);
            db.Student.Remove(studobj!);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}