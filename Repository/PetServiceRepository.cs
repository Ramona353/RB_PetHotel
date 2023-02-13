using RB_PetHotel.Data;
using RB_PetHotel.Models.DBObjects;
using RB_PetHotel.Models;

namespace RB_PetHotel.Repository
{
    public class PetServiceRepository
    {
        private ApplicationDbContext dbContext;

        public PetServiceRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public PetServiceRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<PetServiceModel> GetAllPetService()
        {
            List<PetServiceModel> petServiceList = new List<PetServiceModel>();

            foreach (PetService dbpetService in dbContext.PetServices)
            {
                petServiceList.Add(MapDbObjectToModel(dbpetService));

            }
            return petServiceList;
        }

        public PetServiceModel GetpetServiceByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.PetServices.FirstOrDefault(x => x.PetId == ID));
        }


        public List<PetServiceModel> GetpetServiceByPetID(Guid petID)
        {
            List<PetServiceModel> petServiceList = new List<PetServiceModel>();

            foreach (PetService dbpetService in dbContext.PetServices.Where(x => x.PetId == petID))
            {
                petServiceList.Add(MapDbObjectToModel(dbpetService));

            }
            return petServiceList;
        }

        public List<PetServiceModel> GetpetServiceByServiceID(Guid serviceID)
        {
            List<PetServiceModel> petServiceList = new List<PetServiceModel>();

            foreach (PetService dbpetService in dbContext.PetServices.Where(x => x.ServiceId == serviceID))
            {
                petServiceList.Add(MapDbObjectToModel(dbpetService));

            }
            return petServiceList;
        }

        public List<PetServiceModel> GetpetServiceByDateAdded(DateTime? dateAdded)
        {
            List<PetServiceModel> petServiceList = new List<PetServiceModel>();

            foreach (PetService dbpetService in dbContext.PetServices.Where(x => x.DateAdded == dateAdded))
            {
                petServiceList.Add(MapDbObjectToModel(dbpetService));

            }
            return petServiceList;
        }

        public void InsertpetService(PetServiceModel petServiceModel)
        {

            petServiceModel.PetId = Guid.NewGuid();
            dbContext.PetServices.Add(MapModelToDbObject(petServiceModel));
            dbContext.SaveChanges();
        }

        public void UpdatepetService(PetServiceModel petServiceModel)
        {
            PetService existingpetService = dbContext.PetServices.FirstOrDefault(x => x.PetId == petServiceModel.PetId);

            if (existingpetService != null)
            {
                existingpetService.PetId = petServiceModel.PetId;
                existingpetService.ServiceId = petServiceModel.ServiceId;
                existingpetService.DateAdded = petServiceModel.DateAdded;
                dbContext.SaveChanges();
            }
        }

        public void DeletepetService(Guid PetServiceModel)
        {
            PetService existingpetService = dbContext.PetServices.FirstOrDefault(x => x.PetId == PetServiceModel);
            if (existingpetService != null)
            {
                dbContext.PetServices.Remove(existingpetService);
                dbContext.SaveChanges();
            }
        }

        private PetServiceModel MapDbObjectToModel(PetService dbpetService)
        {
            PetServiceModel petServiceModel = new PetServiceModel();

            if (dbpetService != null)
            {
                petServiceModel.PetId = dbpetService.PetId;
                petServiceModel.ServiceId = dbpetService.ServiceId;
                petServiceModel.DateAdded = dbpetService.DateAdded;
            }

            return petServiceModel;
        }

        private PetService MapModelToDbObject(PetServiceModel PetServiceModel)
        {
            PetService petService = new PetService();

            if (PetServiceModel != null)
            {
                petService.PetId = PetServiceModel.PetId;
                petService.ServiceId = PetServiceModel.ServiceId;
                petService.DateAdded = PetServiceModel.DateAdded;
            }
            return petService;
        }
    }
}
