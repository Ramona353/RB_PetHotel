using RB_PetHotel.Data;
using RB_PetHotel.Models.DBObjects;
using RB_PetHotel.Models;

namespace RB_PetHotel.Repository
{
    public class PetRoomRepository
    {
        private ApplicationDbContext dbContext;

        public PetRoomRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public PetRoomRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<PetRoomModel> GetAllPetRooms()
        {
            List<PetRoomModel> PetRoomList = new List<PetRoomModel>();

            foreach (PetRoom dbPetRoom in this.dbContext.PetRooms)
            {
                PetRoomList.Add(MapDbObjectToModel(dbPetRoom));

            }
            return PetRoomList;
        }

        public PetRoomModel GetPetRoomByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.PetRooms.FirstOrDefault(x => x.PetId == ID));
        }


        public List<PetRoomModel> GetPetRoomByPetID(Guid petID)
        {
            List<PetRoomModel> PetRoomList = new List<PetRoomModel>();

            foreach (PetRoom dbPetRoom in dbContext.PetRooms.Where(x => x.PetId == petID))
            {
                PetRoomList.Add(MapDbObjectToModel(dbPetRoom));

            }
            return PetRoomList;
        }

        public List<PetRoomModel> GetPetRoomByRoomID(Guid roomID)
        {
            List<PetRoomModel> PetRoomList = new List<PetRoomModel>();

            foreach (PetRoom dbPetRoom in dbContext.PetRooms.Where(x => x.RoomId == roomID))
            {
                PetRoomList.Add(MapDbObjectToModel(dbPetRoom));

            }
            return PetRoomList;
        }

        public List<PetRoomModel> GetPetRoomByCheckInDate(DateTime? checkInDate)
        {
            List<PetRoomModel> PetRoomList = new List<PetRoomModel>();

            foreach (PetRoom dbPetRoom in dbContext.PetRooms.Where(x => x.CheckInDate == checkInDate))
            {
                PetRoomList.Add(MapDbObjectToModel(dbPetRoom));

            }
            return PetRoomList;
        }

        public List<PetRoomModel> GetPetRoomByCheckOutDate(DateTime? checkOutDate)
        {
            List<PetRoomModel> PetRoomList = new List<PetRoomModel>();

            foreach (PetRoom dbPetRoom in dbContext.PetRooms.Where(x => x.CheckOutDate == checkOutDate))
            {
                PetRoomList.Add(MapDbObjectToModel(dbPetRoom));

            }
            return PetRoomList;
        }

        public void InsertPetRoom(PetRoomModel petRoomModel)
        {

            petRoomModel.PetId = Guid.NewGuid();
            dbContext.PetRooms.Add(MapModelToDbObject(petRoomModel));
            dbContext.SaveChanges();
        }

        public void UpdatePetRoom(PetRoomModel petRoomModel)
        {
            PetRoom existingPetRoom = dbContext.PetRooms.FirstOrDefault(x => x.PetId == petRoomModel.PetId);

            if (existingPetRoom != null)
            {
                existingPetRoom.PetId = petRoomModel.PetId;
                existingPetRoom.RoomId = petRoomModel.RoomId;
                existingPetRoom.CheckOutDate = petRoomModel.CheckOutDate;
                existingPetRoom.CheckInDate = petRoomModel.CheckInDate;
                dbContext.SaveChanges();
            }
        }

        public void DeletePetRoom(Guid petRoomModel)
        {
            PetRoom existingPetRoom = dbContext.PetRooms.FirstOrDefault(x => x.PetId == petRoomModel);
            if (existingPetRoom != null)
            {
                dbContext.PetRooms.Remove(existingPetRoom);
                dbContext.SaveChanges();
            }
        }

        private PetRoomModel MapDbObjectToModel(PetRoom dbPetRoom)
        {
            PetRoomModel petRoomModel = new PetRoomModel();

            if (dbPetRoom != null)
            {
                petRoomModel.PetId = dbPetRoom.PetId;
                petRoomModel.RoomId = dbPetRoom.RoomId;
                petRoomModel.CheckInDate = dbPetRoom.CheckInDate;
                petRoomModel.CheckOutDate= dbPetRoom.CheckOutDate;
            }
            return petRoomModel;
        }

        private PetRoom MapModelToDbObject(PetRoomModel PetRoomModel)
        {
            PetRoom petRoom = new PetRoom();

            if (PetRoomModel != null)
            {
                petRoom.PetId = PetRoomModel.PetId;
                petRoom.RoomId = PetRoomModel.RoomId;
                petRoom.CheckInDate= PetRoomModel.CheckInDate;
                petRoom.CheckOutDate = PetRoomModel.CheckOutDate;
            }
            return petRoom;
        }
    }
}
