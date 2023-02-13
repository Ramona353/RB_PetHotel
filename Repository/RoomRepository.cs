using RB_PetHotel.Data;
using RB_PetHotel.Models.DBObjects;
using RB_PetHotel.Models;

namespace RB_PetHotel.Repository
{
    public class RoomRepository
    {
        private ApplicationDbContext dbContext;

        public RoomRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public RoomRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<RoomModel> GetAllRooms()
        {
            List<RoomModel> RoomList = new List<RoomModel>();

            foreach (Room dbRoom in this.dbContext.Rooms)
            {
                RoomList.Add(MapDbObjectToModel(dbRoom));

            }
            return RoomList;
        }

        public RoomModel GetRoomByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Rooms.FirstOrDefault(x => x.RoomId == ID));
        }

        public List<RoomModel> GetRoomByRoomNumber(string? roomNumber)
        {
            List<RoomModel> RoomList = new List<RoomModel>();

            foreach (Room dbRoom in dbContext.Rooms.Where(x => x.RoomNumber == roomNumber))
            {
                RoomList.Add(MapDbObjectToModel(dbRoom));

            }
            return RoomList;
        }

        public List<RoomModel> GetRoomByRoomType(string? roomType)
        {
            List<RoomModel> RoomList = new List<RoomModel>();

            foreach (Room dbRoom in dbContext.Rooms.Where(x => x.RoomType == roomType))
            {
                RoomList.Add(MapDbObjectToModel(dbRoom));

            }
            return RoomList;
        }

        public List<RoomModel> GetRoomByOccupancy(int occupancy)
        {
            List<RoomModel> RoomList = new List<RoomModel>();

            foreach (Room dbRoom in dbContext.Rooms.Where(x => x.Occupancy == occupancy))
            {
                RoomList.Add(MapDbObjectToModel(dbRoom));

            }
            return RoomList;
        }
        public List<RoomModel> GetRoomByPrice(decimal price)
        {
            List<RoomModel> RoomList = new List<RoomModel>();

            foreach (Room dbRoom in dbContext.Rooms.Where(x => x.Price == price))
            {
                RoomList.Add(MapDbObjectToModel(dbRoom));

            }
            return RoomList;
        }

        public void InsertRoom(RoomModel RoomModel)
        {
            RoomModel.RoomId = Guid.NewGuid();
            dbContext.Rooms.Add(MapModelToDbObject(RoomModel));
            dbContext.SaveChanges();
        }

        public void UpdateRoom(RoomModel roomModel)
        {
            Room existingRoom = dbContext.Rooms.FirstOrDefault(x => x.RoomId == roomModel.RoomId);

            if (existingRoom != null)
            {
                existingRoom.RoomId = roomModel.RoomId;
                existingRoom.Price = roomModel.Price;
                existingRoom.RoomNumber= roomModel.RoomNumber;
                existingRoom.RoomType= roomModel.RoomType;
                existingRoom.Occupancy=roomModel.Occupancy;
                dbContext.SaveChanges();
            }
        }

        public void DeleteRoom(Guid roomModel)
        {
            Room existingRoom = dbContext.Rooms.FirstOrDefault(x => x.RoomId == roomModel);
            if (existingRoom != null)
            {
                dbContext.Rooms.Remove(existingRoom);
                dbContext.SaveChanges();
            }
        }

        private RoomModel MapDbObjectToModel(Room dbRoom)
        {
            RoomModel roomModel = new RoomModel();

            if (dbRoom != null)
            {
                roomModel.RoomId = dbRoom.RoomId;
                roomModel.RoomNumber = dbRoom.RoomNumber;
                roomModel.RoomType= dbRoom.RoomType;
                roomModel.Occupancy=dbRoom.Occupancy;
                roomModel.Price=dbRoom.Price;
            }
            return roomModel;
        }

        private Room MapModelToDbObject(RoomModel roomModel)
        {
            Room room = new Room();

            if (roomModel != null)
            {
                room.RoomId = roomModel.RoomId;
                room.RoomNumber= roomModel.RoomNumber;
                room.RoomType= roomModel.RoomType;
                room.Occupancy= roomModel.Occupancy;
                room.Price= roomModel.Price;
            }
            return room;
        }
    }
}
