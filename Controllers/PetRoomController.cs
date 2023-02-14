using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB_PetHotel.Data;
using RB_PetHotel.Models;
using System.Data;

namespace RB_PetHotel.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PetRoomController : Controller
    {
        private Repository.PetRoomRepository _repository;
        public PetRoomController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.PetRoomRepository(dbContext);
        }

        // GET: PetRoomController
        public ActionResult Index()
        {
            var petrooms = _repository.GetAllPetRooms(); 
            return View("Index", petrooms);
        }

        // GET: PetRoomController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetPetRoomByID(id);
            return View("DetailsPetRoom", model);
        }

        // GET: PetRoomController/Create
        public ActionResult Create()
        {
            return View("CreatePetRoom");
        }

        // POST: PetRoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.PetRoomModel petRoomModel= new Models.PetRoomModel();

                var task = TryUpdateModelAsync(petRoomModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertPetRoom(petRoomModel);
                }
                return View("CreatePetRoom");
            }
            catch
            {
                return View("CreatePetRoom");
            }
        }

        // GET: PetRoomController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetPetRoomByID(id);
            return View("EditPetRoom", model);
        }

        // POST: PetRoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var petRoomModel = new PetRoomModel();
                var task = TryUpdateModelAsync(petRoomModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdatePetRoom(petRoomModel);
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

        // GET: PetRoomController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetPetRoomByID(id);
            return View("DeletePetRoom", model);
        }

        // POST: PetRoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeletePetRoom(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeletePetRoom", id);
            }
        }
    }
}
