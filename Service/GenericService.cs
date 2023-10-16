using HospitalManagementSystem.AppDbContext;
using HospitalManagementSystem.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Service
{
    public class GenericService<TEntity> : IGenericInterface<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        
        private readonly DbSet<TEntity> _database;
        public GenericService(ApplicationDbContext context)
        {
            _context = context;
            _database = _context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _database.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetList()
        {
            return _database.ToList();
        }

        public TEntity GetOne(int? id)
        {
            var entity = _database.Find(id);
            if(entity == null)
            {
                return null;
            }
            return entity;
        }

        public void Update(TEntity entity)
        {
            _database.Update(entity);
            _context.SaveChanges();    
            

        }

        
    }
}
