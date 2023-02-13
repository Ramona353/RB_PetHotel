using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB_PetHotel.Data;
using RB_PetHotel.Models;

namespace RB_PetHotel.Controllers
{
    public class UserController : Controller
    {
        private Repository.UserRepository _repository;
        public UserController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.UserRepository(dbContext);
        }

        // GET: UserController
        public ActionResult Index()
        {
            var users = _repository.GetAllUsers();
            return View("Index", users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetUserByID(id);
            return View("DetailsUser", model);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View("CreateUser");
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.UserModel userModel = new Models.UserModel();

                var task = TryUpdateModelAsync(userModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertUser(userModel);
                }
                return View("CreateUser");
            }
            catch
            {
                return View("CreateUser");
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetUserByID(id);
            return View("EditUser", model);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var userModel = new UserModel();
             
                var task = TryUpdateModelAsync(userModel);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateUser(userModel);
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

        // GET: UserController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetUserByID(id);
            return View("DeleteUser", model);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteUser, id");
            }
        }
    }
}
