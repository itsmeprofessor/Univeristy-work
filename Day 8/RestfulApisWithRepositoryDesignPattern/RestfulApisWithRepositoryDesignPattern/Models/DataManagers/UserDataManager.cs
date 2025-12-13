using RestfulApisWithRepositoryDesignPattern.Models.Entities;
using RestfulApisWithRepositoryDesignPattern.Repository;

namespace RestfulApisWithRepositoryDesignPattern.Models.DataManagers
{
    public class UserDataManager : IDataRepository<User>
    {
        private readonly AppDbContext appDbContext;

        public UserDataManager(AppDbContext dbContext)
        {
            this.appDbContext = dbContext;
        }
        public void Add(User entity)
        {
            appDbContext.Users.Add(entity);
            appDbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            appDbContext.Users.Remove(entity);
            appDbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return appDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return appDbContext.Users.SingleOrDefault(x => x.Id == id);
        }

        public void Update(User dbEntity, User entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Email = entity.Email;
            appDbContext.SaveChanges();
        }
    }
}
