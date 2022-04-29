namespace SysSara.Services;

public class DomiciliosRepository : GenericRepository<Domicilio>, IDomiciliosRepository
{
    public DomiciliosRepository(AppDbContext context) : base(context)
    {
        
    }

    
}