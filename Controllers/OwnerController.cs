using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Controllers
{
    public class OwnerController : Controller
    {
        private Repository.OwnerRepository _repository;
        public OwnerController (ApplicationDbContext dbContext)
        {
            _repository = new Repository.OwnerRepository (dbContext);
        }
        // GET: OwnerController
        public ActionResult Index()
        {
            var owners = _repository.GetAllOwners();
            return View("Index", owners);
        }

        // GET: OwnerController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetOwnerByID(id);
            return View("DetailsOwner", model);
        }

        // GET: OwnerController/Create
        public ActionResult Create()
        {
            return View("CreateOwner");
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.OwnerModel ownerModel = new Models.OwnerModel ();
                var task = TryUpdateModelAsync(ownerModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertOwner(ownerModel);
                }
                return View("CreateOwner");
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateOwner");
                //return View();
            }

        }

        // GET: OwnerController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetOwnerByID(id);
            return View("EditOwner", model);
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var ownerModel = new OwnerModel();
                var task = TryUpdateModelAsync(ownerModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateOwner(ownerModel);
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

        // GET: OwnerController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetOwnerByID(id);
            return View("DeleteOwner", model);
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteOwner(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteOwner", id);
            }
        }
    }
}
