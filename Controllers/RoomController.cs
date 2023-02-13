using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Controllers
{
    public class RoomController : Controller
    {

        private Repository.RoomRepository _repository;
        public RoomController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.RoomRepository(dbContext);
        }
        // GET: RoomController
        public ActionResult Index()
        {
            var rooms = _repository.GetAllRooms();
            return View("Index", rooms);
        }

        // GET: RoomController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetRoomByID(id);
            return View("DetailsRoom", model);
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            return View("CreateRoom");
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.RoomModel roomModel = new Models.RoomModel();
                
                var task = TryUpdateModelAsync(roomModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertRoom(roomModel);
                }
                return View("CreateRoom");
            }
            catch
            {
                return View("CreateRoom");
            }
        }

        // GET: RoomController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetRoomByID(id);
            return View("EditRoom", model);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var roomModel = new RoomModel();

                var task = TryUpdateModelAsync(roomModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateRoom(roomModel);
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

        // GET: RoomController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetRoomByID(id);
            return View("DeleteRoom", model);
        }

        // POST: RoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteRoom(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteRoom", id);
            }
        }
    }
}
