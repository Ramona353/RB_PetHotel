using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB_PetHotel.Data;
using RB_PetHotel.Models;
using System.Data;

namespace RB_PetHotel.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class PetController : Controller
    {
        private Repository.PetRepository _repository;
        public PetController(ApplicationDbContext dbContext)
        {
            _repository= new Repository.PetRepository(dbContext);
        }

        // GET: PetController
        public ActionResult Index()
        {
            var pets = _repository.GetAllPets();
            return View("Index", pets);
        }

        // GET: PetController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetPetByID(id);
            return View("DetailsPet", model);
        }

        // GET: PetController/Create
        public ActionResult Create()
        {
            return View("CreatePet");
        }

        // POST: PetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.PetModel petModel = new Models.PetModel();
                var task = TryUpdateModelAsync(petModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertPet(petModel);
                }
                return View("CreatePet");
            }
            catch
            {
                return View("CreatePet");
            }
        }

        // GET: PetController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetPetByID(id);
            return View("EditPet", model);
        }

        // POST: PetController/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var petModel = new PetModel();
                var task = TryUpdateModelAsync(petModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdatePet(petModel);
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

        // GET: PetController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetPetByID(id);
            return View("DeletePet", model);
        }

        // POST: PetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                
                _repository.DeletePet(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeletePet", id);
            }
        }
    }
}
