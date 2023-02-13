using RB_PetHotel.Data;
using RB_PetHotel.Models.DBObjects;
using RB_PetHotel.Models;

namespace RB_PetHotel.Repository
{
    public class PetOwnerRepository
    {
        private ApplicationDbContext dbContext;

        public PetOwnerRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public PetOwnerRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<PetOwnerModel> GetAllPetOwners()
        {
            List<PetOwnerModel> PetOwnerList = new List<PetOwnerModel>();

            foreach (PetOwner dbPetOwner in this.dbContext.PetOwners)
            {
                PetOwnerList.Add(MapDbObjectToModel(dbPetOwner));

            }
            return PetOwnerList;
        }

        public PetOwnerModel GetPetOwnerByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.PetOwners.FirstOrDefault(x => x.PetId == ID));
        }


        public List<PetOwnerModel> GetPetOwnerByOwnerID(Guid ownerID)
        {
            List<PetOwnerModel> PetOwnerList = new List<PetOwnerModel>();

            foreach (PetOwner dbPetOwner in dbContext.PetOwners.Where(x => x.OwnerId == ownerID))
            {
                PetOwnerList.Add(MapDbObjectToModel(dbPetOwner));

            }
            return PetOwnerList;
        }

        public List<PetOwnerModel> GetPetOwnerByPetID(Guid petID)
        {
            List<PetOwnerModel> PetOwnerList = new List<PetOwnerModel>();

            foreach (PetOwner dbPetOwner in dbContext.PetOwners.Where(x => x.PetId == petID))
            {
                PetOwnerList.Add(MapDbObjectToModel(dbPetOwner));

            }
            return PetOwnerList;
        }

        public void InsertPetOwner(PetOwnerModel petOwnerModel)
        {

            petOwnerModel.PetId = Guid.NewGuid();
            dbContext.PetOwners.Add(MapModelToDbObject(petOwnerModel));
            dbContext.SaveChanges();
        }

        public void UpdatePetOwner(PetOwnerModel petOwnerModel)
        {
            PetOwner existingPetOwner = dbContext.PetOwners.FirstOrDefault(x => x.PetId == petOwnerModel.PetId);

            if (existingPetOwner != null)
            {
                existingPetOwner.PetId = petOwnerModel.PetId;
                existingPetOwner.OwnerId = petOwnerModel.OwnerId;
                dbContext.SaveChanges();
            }
        }

        public void DeletePetOwner(Guid PetOwnerModel)
        {
            PetOwner existingPetOwner = dbContext.PetOwners.FirstOrDefault(x => x.PetId == PetOwnerModel);
            if (existingPetOwner != null)
            {
                dbContext.PetOwners.Remove(existingPetOwner);
                dbContext.SaveChanges();
            }
        }

        private PetOwnerModel MapDbObjectToModel(PetOwner dbPetOwner)
        {
            PetOwnerModel PetOwnerModel = new PetOwnerModel();

            if (dbPetOwner != null)
            {
                PetOwnerModel.PetId = dbPetOwner.PetId;
                PetOwnerModel.OwnerId = dbPetOwner.OwnerId;
            }
            return PetOwnerModel;
        }

        private PetOwner MapModelToDbObject(PetOwnerModel PetOwnerModel)
        {
            PetOwner PetOwner = new PetOwner();

            if (PetOwnerModel != null)
            {
                PetOwner.PetId = PetOwnerModel.PetId;
                PetOwner.OwnerId = PetOwnerModel.OwnerId;
            }
            return PetOwner;
        }
    }
}
