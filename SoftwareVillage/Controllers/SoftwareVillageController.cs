using Microsoft.AspNetCore.Mvc;
using SoftwareVillage.Data;
using SoftwareVillage.Models;
using SoftwareVillage.ViewModels;
using System;
using System.Linq;

namespace SoftwareVillage.Controllers
{
    public class SoftwareVillageController : Controller
    {
        private readonly SoftwareVillageDbContext _context;

        public SoftwareVillageController(SoftwareVillageDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teacherCount=GetTeacherCountFromDatabase();
            var studentCount = GetStudentCountFromDatabase();
            var partnyorCount = GetPartnyorCountFromDatabase();
            //ViewBag.teacherCount=teacherCount;

            //int maxTeachersId = _context.akademiyaTeachers.Max(t => t.Id);
            //int maxStudentsId = _context.students.Max(s => s.Id);
            //int maxPartnyorsId = _context.Partnyors.Max(p => p.Id);


            var down_software_villages = _context.Down_SoftwareVillages.FirstOrDefault();
            var it_SoftwareVillages = _context.it_SoftwareVillages.ToList();
            var missiyamiz = _context.Missiyamız.ToList();

            
             var downAndIt_SoftwareVillage = new Down_ItAndMissiyamiz_SoftwareVillage_VM
            {
                Down_SoftwareVillages = down_software_villages,
                It_SoftwareVillages = it_SoftwareVillages,
                missiyamız = missiyamiz
            };


            downAndIt_SoftwareVillage.Down_SoftwareVillages.MaxCountOfTeachers = teacherCount;
            downAndIt_SoftwareVillage.Down_SoftwareVillages.MaxCountOfStudents = studentCount;
            downAndIt_SoftwareVillage.Down_SoftwareVillages.MaxCountOfPartnyors = partnyorCount;

            return View(downAndIt_SoftwareVillage);
        }

        private int GetTeacherCountFromDatabase()
        {
            var teacherCount=_context.akademiyaTeachers.Count();
            return teacherCount;    
        }

        private int GetStudentCountFromDatabase()
        {
            var studentCount = _context.students.Count();
            return studentCount;
        }

        private int GetPartnyorCountFromDatabase()
        {
            var partnyorCount = _context.Partnyors.Count();
            return partnyorCount;
        }

    }
}
