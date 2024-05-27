using SoftwareVillage.Data;
using SoftwareVillage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

namespace SoftwareVillage.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class StudentFeedbacksController : Controller
    {
        public readonly SoftwareVillageDbContext _context;
        private readonly IWebHostEnvironment _env;

        public StudentFeedbacksController(SoftwareVillageDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public async Task<IActionResult> Index()
        {
            List<StudentFeedbacks> person = await _context.studentsFeedbacks
                .Include(p => p.Bootcamp)
                .ToListAsync();

            return View(person);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Bootcamps = await _context.bootcamps.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentFeedbacks studentFeedbacks)
        {
            bool result = await _context.studentsFeedbacks.AnyAsync(p => p.Id == studentFeedbacks.BootcampId);

            if (!result)
            {
                ModelState.AddModelError("ProfessionId", "Bele vezife yoxdur");
                ViewBag.StudentsFeedbacks = await _context.studentsFeedbacks.ToListAsync();
                return View();
            }

            if (studentFeedbacks == null)

            {
                ModelState.AddModelError("Photo", "Sekil Secilmeyib");
                return View();

            }

            if (!studentFeedbacks.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Tipi sehvdir");
                return View();

            }


            if (studentFeedbacks.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Olcu Odemir");
                return View();
            }

            var filename = Guid.NewGuid().ToString() + "_" + studentFeedbacks.Photo.FileName;
            studentFeedbacks.Image = filename;
            string path = Path.Combine(_env.WebRootPath, "assets/img", filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await studentFeedbacks.Photo.CopyToAsync(stream);
            }
            

            await _context.studentsFeedbacks.AddAsync(studentFeedbacks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int Id)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            StudentFeedbacks exit = await _context.studentsFeedbacks.FirstOrDefaultAsync(p => p.Id == Id);
            if (exit == null)
            {
                return NotFound();
            }
            ViewBag.Bootcamps = await _context.bootcamps.ToListAsync();


            return View(exit);

        }

        [HttpPost]
        public async Task<IActionResult> Update(int Id, StudentFeedbacks studentFeedbacks)
        {
            if (Id == null || Id < 1)
            {
                return BadRequest();
            }

            StudentFeedbacks exit = await _context.studentsFeedbacks.FirstOrDefaultAsync(p => p.Id == Id);
            if (exit == null)
            {
                return NotFound();
            }

            bool result = await _context.studentsFeedbacks.AnyAsync(p => p.Id == studentFeedbacks.BootcampId);
            if (!result)
            {
                ModelState.AddModelError("ProfessionId", "Bele vezife yoxdur");
                ViewBag.StudentsFeedbacks = await _context.studentsFeedbacks.ToListAsync();
                return View();
            }
            if (studentFeedbacks.Photo != null)
            {
                if (!studentFeedbacks.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi duzgun deyil");
                    return View();
                }
                if (studentFeedbacks.Photo.Length / 1024 > 200)
                {
                    ModelState.AddModelError("Photo", "Olcu duzgun deyil");
                    return View();
                }
            }


            string path = Path.Combine(_env.WebRootPath + "img" + exit.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            var fileName = Guid.NewGuid().ToString() + "" + studentFeedbacks.Photo.FileName;
            exit.Image = fileName;

            string newpath = Path.Combine(_env.WebRootPath, "assets/img", fileName);
            using (FileStream stream = new FileStream(newpath, FileMode.Create))
            {
                await studentFeedbacks.Photo.CopyToAsync(stream);
            }

            exit.FullName = studentFeedbacks.FullName;
            exit.BootcampId = studentFeedbacks.BootcampId;
            exit.Feedbacks = studentFeedbacks.Feedbacks;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!ModelState.IsValid) return View();

            StudentFeedbacks person = await _context.studentsFeedbacks.FirstOrDefaultAsync(p => p.Id == Id);

            if (person == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath + "img" + person.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
           
            _context.studentsFeedbacks.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
