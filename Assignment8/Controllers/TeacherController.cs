using Microsoft.AspNetCore.Mvc;
using Assignment8.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment8.Controllers {

    public class TeacherController : Controller {

        private readonly ApplicationDbContext db;

        public TeacherController(ApplicationDbContext db) {

            this.db = db;
        }

        public async Task<IActionResult> Index(string SearchString) {

            var teachers = from t in db.Teacher select t;
            if(!string.IsNullOrEmpty(SearchString)) {

                teachers = teachers.Where(s=> s.Teacher_Name!.Contains(SearchString));
            }

            return View(await teachers.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Teacher_Name, Subject")] Teacher teacherobj) {

            db.Teacher!.Add(teacherobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int teacherid) {
            
            var teacherobj = db.Teacher!.Find(teacherid);
            return View(teacherobj);
        }

        [HttpPost]
        public IActionResult Edit(Teacher teacherobj) {

            db.Teacher!.Update(teacherobj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int teacherid) {
            
            var teacherobj = db.Teacher!.Find(teacherid);
            db.Teacher.Remove(teacherobj!);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}