namespace SysSara.Services;

public interface IGenericRepository<T> where T : class
{
    //Task<T> GetById(int id);
    //Task<IEnumerable<T>> GetAll();
    //Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    //Task<bool> Add(T entity);
    //Task<bool> AddRange(IEnumerable<T> entities);
    //void Remove(T entity);
    //void RemoveRange(IEnumerable<T> entities);
}

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }
    //public async Task<bool> Add(T entity)
    //{
    //   await _context.Set<T>().AddAsync(entity);
    //   return true;
    //}

    //public async Task<bool> AddRange(IEnumerable<T> entities)
    //{
    //    await _context.Set<T>().AddRangeAsync(entities);
    //    return true;
    //}

    //public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
    //{
    //    return await _context.Set<T>().Where(expression).ToListAsync();
    //}

    //public async Task<IEnumerable<T>> GetAll()
    //{
    //    return await _context.Set<T>().ToListAsync();
    //}

    //public async Task<T> GetById(int id)
    //{
    //    return await _context.Set<T>().FindAsync(id);
    //}

    //public void Remove(T entity)
    //{
    //    _context.Set<T>().Remove(entity);
    //}

    //public void RemoveRange(IEnumerable<T> entities)
    //{
    //    _context.Set<T>().RemoveRange(entities);
    //}    
}