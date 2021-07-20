using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreEmpLibrary;
using Microsoft.Extensions.Logging;
namespace CoreEmpMvcApp.Controllers {
    public class EmpController : Controller {
        private readonly ILogger<HomeController> _logger;
        IEmpRepository empRep;
        // automatic dependency injection
        public EmpController(IEmpRepository ier, ILogger<HomeController> logger) {
            //empRep = new EFEmpRepository();
            empRep = ier;
            _logger = logger;       // built-in service
        }
        public ActionResult Index() {
            _logger.LogInformation("Index method called in Emp controller");
            return View(empRep.GetAllEmployees());
        }
        public ActionResult Details(int id) {
            try {
                _logger.LogInformation("Details method called in Emp controller");
                return View(empRep.GetEmployeeById(id));
            }
            catch(EmpException ex) {
                _logger.LogError(ex.Message, null);
                return RedirectToAction("Index");
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
