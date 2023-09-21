namespace HospitalManagementSystem.Interface
{
    public interface IGenericInterface<TEntity> where TEntity : class
    {
       IEnumerable<TEntity> GetList();

       TEntity GetOne(int? id);

        void Create(TEntity entity);

        void Update(int id,TEntity entity);


    }
}
