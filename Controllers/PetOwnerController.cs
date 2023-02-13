using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Controllers
{
    public class PetOwnerController : Controller
    {
        private Repository.PetOwnerRepository _repository;
        public PetOwnerController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.PetOwnerRepository(dbContext);
        }

        // GET: PetOwnerController
        public ActionResult Index()
        {
            var petowners = _repository.GetAllPetOwners();
            return View("Index", petowners);
        }

        // GET: PetOwnerController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetPetOwnerByID(id);
            return View("DetailsPetOwner", model);
        }

        // GET: PetOwnerController/Create
        public ActionResult Create()
        {
            return View("CreatePetOwner");
        }

        // POST: PetOwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.PetOwnerModel petOwnerModel = new Models.PetOwnerModel();

                var task = TryUpdateModelAsync(petOwnerModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertPetOwner(petOwnerModel);
                }
                return View("CreatePetOwner");
            }
            catch
            {
                return View("CreatePetOwner");
            }
        }

        // GET: PetOwnerController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetPetOwnerByID(id);
            return View("EditPetOwner", model);
        }

        // POST: PetOwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var petOwnerModel = new PetOwnerModel();
                var task = TryUpdateModelAsync(petOwnerModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdatePetOwner(petOwnerModel);
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

        // GET: PetOwnerController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetPetOwnerByID(id);
            return View("DeletePetOwner", id);
        }

        // POST: PetOwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeletePetOwner(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeletePetOwner", id);
            }
        }
    }
}
