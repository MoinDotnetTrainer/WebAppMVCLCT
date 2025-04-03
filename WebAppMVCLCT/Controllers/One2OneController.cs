using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMVCLCT.Models;

namespace WebAppMVCLCT.Controllers
{
    public class One2OneController : Controller
    {
        public readonly Databasecontext _context;

        public One2OneController(Databasecontext context)
        {
            _context = context;
        }
        public IActionResult ExonOne2One()
        {

            var data = _context.patient.Include("PatientAddress").ToList();
            // var data = _context.PatientAddress.Include(p=>p.patient).ToList(); // this will not work ,bcoz no multiple navigation prop
            return View(data);

        }

        public async Task<IActionResult> AnotherExonOne2One()
        {
            var persons = await _context.Persons.Include(p => p.PersonDetail).ToListAsync();
            return View(persons);
        }

        public async Task<IActionResult> AnotherExonOne2One_()
        {
            var persons = await _context.PersonDetails.Include(p => p.Person).ToListAsync();
            return View(persons);
        }

        public IActionResult LazyLoad()
        {

            List<Villa> villa = _context.Villa.ToList();
            
            var totalvilla = villa.Count;

            for (int i = 0; i < totalvilla; i++)
            {
                villa[i].villaAmentities = _context.VillaAmentity.Where(x => x.VillaId == villa[i].Id).ToList();
            }  
            return View();
        }
    }
}
