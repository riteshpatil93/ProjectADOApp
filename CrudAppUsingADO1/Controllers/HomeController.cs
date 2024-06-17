using CrudAppUsingADO1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudAppUsingADO1.Controllers
{
    public class HomeController : Controller
    {

        private readonly PatientDataAccessLayer pal;

        public HomeController()
        {
            pal = new PatientDataAccessLayer();
        }

        public IActionResult Index()
        {
            List<Patient> pt = pal.getAllPatient();
            return View(pt);
        }

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient pt)
        {
            try
            {
                pal.AddPatient(pt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(); 

            }
           
        }

        public IActionResult Details(int id)
        {
            Patient pt = pal.getPatientById(id);
            return View(pt);
        }

        public IActionResult delete(int id)
        {
            Patient pt = pal.getPatientById(id);
            return View(pt);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult delete(Patient pt)
        {
            try
            {
                pal.deleteById(pt.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();

            }

        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
