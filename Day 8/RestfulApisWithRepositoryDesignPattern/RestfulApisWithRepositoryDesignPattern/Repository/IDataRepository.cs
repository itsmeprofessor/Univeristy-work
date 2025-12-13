namespace RestfulApisWithRepositoryDesignPattern.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity,TEntity entity);
        void Delete(TEntity entity);
    }
}
