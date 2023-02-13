using RB_PetHotel.Data;
using RB_PetHotel.Models.DBObjects;
using RB_PetHotel.Models;

namespace RB_PetHotel.Repository
{
    public class PetRepository
    {
        private ApplicationDbContext dbContext;

        public PetRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public PetRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<PetModel> GetAllPets()
        {
            List<PetModel> PetList = new List<PetModel>();

            foreach (Pet dbPet in this.dbContext.Pets)
            {
                PetList.Add(MapDbObjectToModel(dbPet));

            }
            return PetList;
        }

        public PetModel GetPetByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Pets.FirstOrDefault(x => x.PetId == ID));
        }

        public List<PetModel> GetPetByPetName(string? petName)
        {
            List<PetModel> PetList = new List<PetModel>();

            foreach (Pet dbPet in dbContext.Pets.Where(x => x.PetName == petName))
            {
                PetList.Add(MapDbObjectToModel(dbPet));

            }
            return PetList;
        }

        public List<PetModel> GetPetByBreed(string? breed)
        {
            List<PetModel> PetList = new List<PetModel>();

            foreach (Pet dbPet in dbContext.Pets.Where(x => x.Breed == breed))
            {
                PetList.Add(MapDbObjectToModel(dbPet));

            }
            return PetList;
        }

        public List<PetModel> GetPetByAge(int age)
        {
            List<PetModel> PetList = new List<PetModel>();

            foreach (Pet dbPet in dbContext.Pets.Where(x => x.Age == age))
            {
                PetList.Add(MapDbObjectToModel(dbPet));

            }
            return PetList;
        }

        public List<PetModel> GetPetByWeight(decimal weight)
        {
            List<PetModel> PetList = new List<PetModel>();

            foreach (Pet dbPet in dbContext.Pets.Where(x => x.Weight == weight))
            {
                PetList.Add(MapDbObjectToModel(dbPet));

            }
            return PetList;
        }

        public List<PetModel> GetPetBySpecialNeeds(string specialNeeds)
        {
            List<PetModel> PetList = new List<PetModel>();

            foreach (Pet dbPet in dbContext.Pets.Where(x => x.SpecialNeeds == specialNeeds))
            {
                PetList.Add(MapDbObjectToModel(dbPet));

            }
            return PetList;
        }

        public void InsertPet(PetModel PetModel)
        {
            PetModel.PetId = Guid.NewGuid();
            dbContext.Pets.Add(MapModelToDbObject(PetModel));
            dbContext.SaveChanges();
        }

        public void UpdatePet(PetModel PetModel)
        {
            Pet existingPet = dbContext.Pets.FirstOrDefault(x => x.PetId == PetModel.PetId);

            if (existingPet != null)
            {
                existingPet.PetId = PetModel.PetId;
                existingPet.PetName = PetModel.PetName;
                existingPet.Breed = PetModel.Breed;
                existingPet.Age= PetModel.Age;
                existingPet.Weight= PetModel.Weight;
                existingPet.SpecialNeeds= PetModel.SpecialNeeds;
                
                dbContext.SaveChanges();
            }
        }

        public void DeletePet(Guid PetModel)
        {
            Pet existingPet = dbContext.Pets.FirstOrDefault(x => x.PetId == PetModel);
            if (existingPet != null)
            {
                dbContext.Pets.Remove(existingPet);
                dbContext.SaveChanges();
            }
        }

        private PetModel MapDbObjectToModel(Pet dbPet)
        {
            PetModel PetModel = new PetModel();

            if (dbPet != null)
            {
                PetModel.PetId = dbPet.PetId;
                PetModel.PetName = dbPet.PetName;
                PetModel.Breed = dbPet.Breed;
                PetModel.Age = dbPet.Age;
                PetModel.Weight = dbPet.Weight;
                PetModel.SpecialNeeds = dbPet.SpecialNeeds;
            }
            return PetModel;
        }

        private Pet MapModelToDbObject(PetModel PetModel)
        {
            Pet Pet = new Pet();

            if (PetModel != null)
            {
                Pet.PetId = PetModel.PetId;
                Pet.PetName = PetModel.PetName;
                Pet.Breed= PetModel.Breed;
                Pet.Age = PetModel.Age;
                Pet.Weight = PetModel.Weight;
                Pet.SpecialNeeds= PetModel.SpecialNeeds;
            }
            return Pet;
        }
    }
}
