using RB_PetHotel.Data;
using RB_PetHotel.Models.DBObjects;
using RB_PetHotel.Models;

namespace RB_PetHotel.Repository
{
    public class ServiceRepository
    {
        private ApplicationDbContext dbContext;

        public ServiceRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public ServiceRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ServiceModel> GetAllServices()
        {
            List<ServiceModel> ServiceList = new List<ServiceModel>();

            foreach (Service dbService in this.dbContext.Services)
            {
                ServiceList.Add(MapDbObjectToModel(dbService));

            }
            return ServiceList;
        }

        public ServiceModel GetServiceByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Services.FirstOrDefault(x => x.ServiceId == ID));
        }

        public List<ServiceModel> GetServiceByServiceName(string? serviceName)
        {
            List<ServiceModel> ServiceList = new List<ServiceModel>();

            foreach (Service dbService in dbContext.Services.Where(x => x.ServiceName == serviceName))
            {
                ServiceList.Add(MapDbObjectToModel(dbService));

            }
            return ServiceList;
        }

        public List<ServiceModel> GetServiceByDescription(string? decription)
        {
            List<ServiceModel> ServiceList = new List<ServiceModel>();

            foreach (Service dbService in dbContext.Services.Where(x => x.Description == decription))
            {
                ServiceList.Add(MapDbObjectToModel(dbService));

            }
            return ServiceList;
        }
        public List<ServiceModel> GetServiceByPrice(decimal price)
        {
            List<ServiceModel> ServiceList = new List<ServiceModel>();

            foreach (Service dbService in dbContext.Services.Where(x => x.Price == price))
            {
                ServiceList.Add(MapDbObjectToModel(dbService));

            }
            return ServiceList;
        }

        public void InsertService(ServiceModel serviceModel)
        {
            serviceModel.ServiceId = Guid.NewGuid();
            dbContext.Services.Add(MapModelToDbObject(serviceModel));
            dbContext.SaveChanges();
        }

        public void UpdateService(ServiceModel serviceModel)
        {
            Service existingService = dbContext.Services.FirstOrDefault(x => x.ServiceId == serviceModel.ServiceId);

            if (existingService != null)
            {
                existingService.ServiceId = serviceModel.ServiceId;
                existingService.ServiceName= serviceModel.ServiceName;
                existingService.Description= serviceModel.Description;
                existingService.Price = serviceModel.Price;
                dbContext.SaveChanges();
            }
        }

        public void DeleteService(Guid serviceModel)
        {
            Service existingService = dbContext.Services.FirstOrDefault(x => x.ServiceId == serviceModel);
            if (existingService != null)
            {
                dbContext.Services.Remove(existingService);
                dbContext.SaveChanges();
            }
        }

        private ServiceModel MapDbObjectToModel(Service dbService)
        {
            ServiceModel serviceModel = new ServiceModel();

            if (dbService != null)
            {
                serviceModel.ServiceId = dbService.ServiceId;
                serviceModel.ServiceName = dbService.ServiceName;
                serviceModel.Description = dbService.Description;
                serviceModel.Price = dbService.Price;
            }
            return serviceModel;
        }

        private Service MapModelToDbObject(ServiceModel serviceModel)
        {
            Service Service = new Service();

            if (serviceModel != null)
            {
                Service.ServiceId = serviceModel.ServiceId;
                Service.ServiceName = serviceModel.ServiceName;
                Service.Description = serviceModel.Description;
                Service.Price = serviceModel.Price;
            }
            return Service;
        }
    }
}
