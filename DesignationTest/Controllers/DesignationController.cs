using DesignationTest.Models;
using DesignationTest.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignationTest.Controllers
{
    public class DesignationController : Controller
    {
        private readonly AppDbContext _db;

        public DesignationController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            
            VmDesignation Emp = new VmDesignation();

            var oEm = _db.Designations.Where(x => x.Id == id).FirstOrDefault();
            if (oEm != null)
            {
                Emp.Id = oEm.Id;
                Emp.DesignationId = oEm.DesignationId;
                Emp.DesignationName = oEm.DesignationName;
                Emp.CreateDate = oEm.CreateDate;
                Emp.ModifiedDate = oEm.ModifiedDate;

            }

            Emp = Emp == null ? new VmDesignation() : Emp;
           // Emp.DesignationId += _db.Designations.Max(x => x.DesignationId);
            //Emp.DesignationId = oEm.DesignationId;
            ViewData["EmployeeList"] = _db.Designations.ToList();
            return View(Emp);

        }

        [HttpPost]
        public async Task<IActionResult> Index(VmDesignation vmEmp)
        {

            var oEmployee = _db.Designations.FirstOrDefault(x => x.Id == vmEmp.Id);
            if (oEmployee == null)
            {
                oEmployee = new Designation();
                //oEmployee.ID = "GCTL-00" + vmEmp.ID;
                oEmployee.DesignationName = vmEmp.DesignationName;
                oEmployee.DesignationId = vmEmp.DesignationId;
                oEmployee.CreateDate = vmEmp.CreateDate;
                _db.Designations.Add(oEmployee);
            }
            else
            {
                oEmployee = new Designation();
                oEmployee.DesignationName = vmEmp.DesignationName;
                oEmployee.DesignationId = vmEmp.DesignationId;
                oEmployee.CreateDate = vmEmp.CreateDate;
                oEmployee.DesignationId = vmEmp.DesignationId;
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Index", new { resetId = true });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = _db.Designations.Find(id);
            _db.Designations.Remove(emp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

