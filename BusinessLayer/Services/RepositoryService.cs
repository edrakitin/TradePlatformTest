using BusinessLayer.Repositories.Interfaces;
using BusinessLayer.Repositories.Realizations;
using DataAccessLayer.DbModels;

namespace BusinessLayer.Services
{
    public class RepositoryService
    {
        public RepositoryService(IUnitOfWork unitOfWork)
        {
            IRepository<Product> productRepository = new Repository<Product>(unitOfWork);
            ProductService = new DbService<Product>(productRepository);

            IRepository<ProductCategory> productCategoryRepository = new Repository<ProductCategory>(unitOfWork);
            ProductCategoryService = new DbService<ProductCategory>(productCategoryRepository);

            IRepository<ProductFile> productFileRepository = new Repository<ProductFile>(unitOfWork);
            ProductFileService = new DbService<ProductFile>(productFileRepository);
            
            IRepository<ProductStatus> productStatusRepository = new Repository<ProductStatus>(unitOfWork);
            ProductStatusService = new DbService<ProductStatus>(productStatusRepository);            
        }

        public DbService<Product> ProductService { get; }
        public DbService<ProductCategory> ProductCategoryService { get; }
        public DbService<ProductFile> ProductFileService { get; }
        public DbService<ProductStatus> ProductStatusService { get; }
    }
}
