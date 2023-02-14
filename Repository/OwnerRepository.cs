using RB_PetHotel.Data;
using RB_PetHotel.Models.DBObjects;
using RB_PetHotel.Models;

namespace RB_PetHotel.Repository
{
    public class OwnerRepository
    {
        private ApplicationDbContext dbContext;

        public OwnerRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public OwnerRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<OwnerModel> GetAllOwners()
        {
            List<OwnerModel> ownerList = new List<OwnerModel>();

            foreach (Owner dbOwner in dbContext.Owners)
            {
                ownerList.Add(MapDbObjectToModel(dbOwner));

            }
            return ownerList;
        }

        public OwnerModel GetOwnerByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Owners.FirstOrDefault(x => x.OwnerId == ID));
        }

        public List<OwnerModel> GetOwnerByOwnerName(string? ownerName)
        {
            List<OwnerModel> ownerList = new List<OwnerModel>();

            foreach (Owner dbOwner in dbContext.Owners.Where(x => x.OwnerName == ownerName))
            {
                ownerList.Add(MapDbObjectToModel(dbOwner));

            }
            return ownerList;
        }

        public List<OwnerModel> GetOwnerByPhone(string? phone)
        {
            List<OwnerModel> ownerList = new List<OwnerModel>();

            foreach (Owner dbOwner in dbContext.Owners.Where(x => x.Phone == phone))
            {
                ownerList.Add(MapDbObjectToModel(dbOwner));

            }
            return ownerList;
        }

        public List<OwnerModel> GetOwnerByEmail(string? email)
        {
            List<OwnerModel> ownerList = new List<OwnerModel>();

            foreach (Owner dbOwner in dbContext.Owners.Where(x => x.Email == email))
            {
                ownerList.Add(MapDbObjectToModel(dbOwner));

            }
            return ownerList;
        }

        public void InsertOwner(OwnerModel ownerModel)
        {
            ownerModel.OwnerId = Guid.NewGuid();
            dbContext.Owners.Add(MapModelToDbObject(ownerModel));
            dbContext.SaveChanges();
        }

        public void UpdateOwner(OwnerModel ownerModel)
        {
            Owner existingOwner = dbContext.Owners.FirstOrDefault(x => x.OwnerId == ownerModel.OwnerId);
            
            if (existingOwner != null)
            {
                existingOwner.OwnerId = ownerModel.OwnerId;
                existingOwner.OwnerName = ownerModel.OwnerName;
                existingOwner.Phone = ownerModel.Phone;
                existingOwner.Email = ownerModel.Email;
                dbContext.SaveChanges();
            }
        }

        public void DeleteOwner(Guid ownerModel)
        {
            Owner existingOwner = dbContext.Owners.FirstOrDefault(x => x.OwnerId == ownerModel);
            if (existingOwner != null)
            {
                dbContext.Owners.Remove(existingOwner);
                dbContext.SaveChanges();
            }
        }

        private OwnerModel MapDbObjectToModel(Owner dbOwner)
        {
            OwnerModel ownerModel = new OwnerModel();

            if(dbOwner != null)
            {
                ownerModel.OwnerId = dbOwner.OwnerId;
                ownerModel.OwnerName = dbOwner.OwnerName;
                ownerModel.Phone = dbOwner.Phone;
                ownerModel.Email = dbOwner.Email;
            }
            return ownerModel;
        }

        private Owner MapModelToDbObject (OwnerModel ownerModel)
        {
            Owner owner = new Owner();

            if(ownerModel != null) 
            { 
                owner.OwnerId = ownerModel.OwnerId;
                owner.OwnerName = ownerModel.OwnerName; 
                owner.Phone = ownerModel.Phone; 
                owner.Email = ownerModel.Email;
            }
            return owner;
        }
    }

}