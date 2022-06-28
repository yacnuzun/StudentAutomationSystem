using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OgrenciOto.Models.DataAccess;
using OgrenciOto.Models.Entity;

namespace OgrenciOto.Controllers
{
    
    public class StudentController :Controller
    {
        StudentDbContext db=new StudentDbContext();
        public IActionResult Index()
        {
            ViewBag.Id = db.Students.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            db.Add(student);
            db.SaveChanges();
            var jsonStudent=JsonConvert.SerializeObject(student);
            
            return Json(jsonStudent);
        }
        public IActionResult DeleteStudent(int id)
        {
            var result=db.Students.Where(s=>s.StudentId==id).Single();
            db.Students.Remove(result);
            db.SaveChanges();
            var jsonStudent=JsonConvert.SerializeObject((Student)result);
            return Json(jsonStudent);
        }
        public JsonResult GetAllStudentList()
        {
            var result=db.Students.ToList();
            var jsonStudents = JsonConvert.SerializeObject(result);
            return Json(jsonStudents);
        }
        public static List<int> ids;
        public JsonResult StudentUpd(int id)
        {
            var result = db.Students.Where(s => s.StudentId == id).First();
            var jsonStudent=JsonConvert.SerializeObject(result);
            return Json(jsonStudent);
        }
        //[System.Web.Mvc.HttpGet]
        //public JsonResult Gonder()
        //{

        //    var result=db.Set<Student>().First();
        //    return Json(result,System.Web.Mvc.JsonRequestBehavior.AllowGet);
        //}
    }
}
