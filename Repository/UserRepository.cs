using RB_PetHotel.Data;
using RB_PetHotel.Models.DBObjects;
using RB_PetHotel.Models;

namespace RB_PetHotel.Repository
{
    public class UserRepository
    {
        private ApplicationDbContext dbContext;

        public UserRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<UserModel> GetAllUsers()
        {
            List<UserModel> UserList = new List<UserModel>();

            foreach (User dbUser in this.dbContext.Users)
            {
                UserList.Add(MapDbObjectToModel(dbUser));

            }
            return UserList;
        }

        public UserModel GetUserByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Users.FirstOrDefault(x => x.UserId == ID));
        }

        public List<UserModel> GetUserByUserName(string? userName)
        {
            List<UserModel> UserList = new List<UserModel>();

            foreach (User dbUser in dbContext.Users.Where(x => x.Username == userName))
            {
                UserList.Add(MapDbObjectToModel(dbUser));

            }
            return UserList;
        }

        public List<UserModel> GetUserByEmail(string? email)
        {
            List<UserModel> UserList = new List<UserModel>();

            foreach (User dbUser in dbContext.Users.Where(x => x.Email == email))
            {
                UserList.Add(MapDbObjectToModel(dbUser));

            }
            return UserList;
        }
        public List<UserModel> GetUserByPassword(string password)
        {
            List<UserModel> UserList = new List<UserModel>();

            foreach (User dbUser in dbContext.Users.Where(x => x.Password == password))
            {
                UserList.Add(MapDbObjectToModel(dbUser));

            }
            return UserList;
        }

        public List<UserModel> GetUserByCreatedAt(DateTime? createdAt)
        {
            List<UserModel> UserList = new List<UserModel>();

            foreach (User dbUser in dbContext.Users.Where(x => x.CreatedAt == createdAt))
            {
                UserList.Add(MapDbObjectToModel(dbUser));

            }
            return UserList;
        }

        public void InsertUser(UserModel userModel)
        {
            userModel.UserId = Guid.NewGuid();
            dbContext.Users.Add(MapModelToDbObject(userModel));
            dbContext.SaveChanges();
        }

        public void UpdateUser(UserModel userModel)
        {
            User existingUser = dbContext.Users.FirstOrDefault(x => x.UserId == userModel.UserId);

            if (existingUser != null)
            {
                existingUser.UserId = userModel.UserId;
                existingUser.Username = userModel.Username;
                existingUser.Email = userModel.Email;
                existingUser.Password = userModel.Password;
                existingUser.CreatedAt = userModel.CreatedAt;
                dbContext.SaveChanges();
            }
        }

        public void DeleteUser(Guid userModel)
        {
            User existingUser = dbContext.Users.FirstOrDefault(x => x.UserId == userModel);
            if (existingUser != null)
            {
                dbContext.Users.Remove(existingUser);
                dbContext.SaveChanges();
            }
        }

        private UserModel MapDbObjectToModel(User dbUser)
        {
            UserModel userModel = new UserModel();

            if (dbUser != null)
            {
                userModel.UserId = dbUser.UserId;
                userModel.Username = dbUser.Username;
                userModel.Email = dbUser.Email;
                userModel.Password = dbUser.Password;
                userModel.CreatedAt = dbUser.CreatedAt;
            }
            return userModel;
        }

        private User MapModelToDbObject(UserModel userModel)
        {
            User User = new User();

            if (userModel != null)
            {
                User.UserId = userModel.UserId;
                User.Username = userModel.Username;
                User.Email = userModel.Email;
                User.Password = userModel.Password;
                User.CreatedAt = userModel.CreatedAt;
            }
            return User;
        }
    }
}
