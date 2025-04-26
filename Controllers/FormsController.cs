//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using SocialWelfarre.Models;
//using System;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using SocialWelfarre.Data;

//namespace SocialWelfare.Controllers
//{
//    public class FormsController : Controller
//    {
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        private readonly ApplicationDbContext _context;

//        public FormsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
//        {
//            _context = context;
//            _webHostEnvironment = webHostEnvironment;
//        }

//        public IActionResult FoodPacksForms() => View();

//        public IActionResult ConsultationForms() => View();

//        public IActionResult CertificateOfIndigencyForm() => View();

//        [HttpPost]
//        public async Task<IActionResult> Submit(FoodPackForm model)
//        {
//            if (ModelState.IsValid)
//            {
//                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Files");
//                Directory.CreateDirectory(uploadsFolder); // Ensure folder exists

//                //// Upload Barangay Certificate
//                //if (model.BarangayCertificateFile != null && model.BarangayCertificateFile.Length > 0)
//                //{
//                //    string barangayFileName = Guid.NewGuid() + "_" + Path.GetFileName(model.BarangayCertificateFile.FileName);
//                //    string barangayFilePath = Path.Combine(uploadsFolder, barangayFileName);

//                //    using (var fileStream = new FileStream(barangayFilePath, FileMode.Create))
//                //    {
//                //        await model.BarangayCertificateFile.CopyToAsync(fileStream);
//                //    }

//                //    model.BarangayCertificatePath = "/Files/" + barangayFileName;
//                //}

//                //// Upload Valid ID
//                //if (model.ValidIdFile != null && model.ValidIdFile.Length > 0)
//                //{
//                //    string validIdFileName = Guid.NewGuid() + "_" + Path.GetFileName(model.ValidIdFile.FileName);
//                //    string validIdFilePath = Path.Combine(uploadsFolder, validIdFileName);

//                //    using (var fileStream = new FileStream(validIdFilePath, FileMode.Create))
//                //    {
//                //        await model.ValidIdFile.CopyToAsync(fileStream);
//                //    }

//                //    model.ValidIdPath = "/Files/" + validIdFileName;
//                //}

//                model.Status = "Pending";
//                _context.FoodPackForms.Add(model);
//                await _context.SaveChangesAsync();

//                return RedirectToAction("FoodPacksForms");
//            }

//            return View("FoodPacksForms", model);
//        }

//        public IActionResult AdminArea()
//        {
//            var forms = _context.FoodPackForms.ToList();
//            return View(forms);
//        }

//        public IActionResult ViewForm(int id)
//        {
//            var form = _context.FoodPackForms.FirstOrDefault(f => f.Id == id);
//            if (form == null)
//            {
//                return NotFound();
//            }

//            return View(form);
//        }

//        public IActionResult Accept(int id)
//        {
//            var form = _context.FoodPackForms.FirstOrDefault(f => f.Id == id);
//            if (form != null)
//            {
//                form.Status = "Accepted";
//                _context.SaveChanges();
//            }

//            return RedirectToAction("AdminArea");
//        }

//        public IActionResult Reject(int id)
//        {
//            var form = _context.FoodPackForms.FirstOrDefault(f => f.Id == id);
//            if (form != null)
//            {
//                form.Status = "Rejected";
//                _context.SaveChanges();
//            }

//            return RedirectToAction("AdminArea");
//        }
//    }
//}
