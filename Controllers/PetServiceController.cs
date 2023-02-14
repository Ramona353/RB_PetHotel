using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB_PetHotel.Data;
using RB_PetHotel.Models;
using System.Data;

namespace RB_PetHotel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PetServiceController : Controller
    {
        private Repository.PetServiceRepository _repository;
        public PetServiceController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.PetServiceRepository(dbContext);
        }

        // GET: PetServiceController
        public ActionResult Index()
        {
            var petservices = _repository.GetAllPetService();
            return View("Index", petservices);
        }

        // GET: PetServiceController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetpetServiceByID(id);
            return View("DetailsPetService", model);
        }

        // GET: PetServiceController/Create
        public ActionResult Create()
        {
            return View("CreatePetService");
        }

        // POST: PetServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.PetServiceModel petServiceModel = new Models.PetServiceModel();

                var task = TryUpdateModelAsync(petServiceModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertpetService(petServiceModel);
                }
                return View("CreatePetService");
            }
            catch
            {
                return View("CreatePetService");
            }
        }

        // GET: PetServiceController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetpetServiceByID(id);
            return View("EditPetService", model);
        }

        // POST: PetServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var petServiceModel = new PetServiceModel();

                var task = TryUpdateModelAsync(petServiceModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdatepetService(petServiceModel);
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

        // GET: PetServiceController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetpetServiceByID(id);
            return View("DeletePetService", model);
        }

        // POST: PetServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeletepetService(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeletePetService", id);
            }
        }
    }
}
