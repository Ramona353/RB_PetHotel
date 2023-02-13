using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Controllers
{
    public class ServiceController : Controller
    {
        private Repository.ServiceRepository _repository;
        public ServiceController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.ServiceRepository(dbContext);
        }
        // GET: ServiceController
        public ActionResult Index()
        {
            var services = _repository.GetAllServices();
            return View("Index", services);
        }

        // GET: ServiceController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetServiceByID(id);
            return View("DetailsService", model);
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View("CreateService");
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.ServiceModel serviceModel = new Models.ServiceModel();

                var task = TryUpdateModelAsync(serviceModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertService(serviceModel);
                }
                return View("CreateService");
            }
            catch
            {
                return View("CreateService");
            }
        }

        // GET: ServiceController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetServiceByID(id);
            return View("EditService", model);
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var serviceModel = new ServiceModel();
                
                var task = TryUpdateModelAsync(serviceModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateService(serviceModel);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: ServiceController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetServiceByID(id);
            return View("DeleteService", model);
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteService(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteService", id);
            }
        }
    }
}
