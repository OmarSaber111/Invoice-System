using DataAccessLayer.Interfaces;
using DataLayer.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly InvoiceDbContext _context;
    private DbSet<T> entity;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Repository(InvoiceDbContext context)
    {
        _context = context;
        entity = context.Set<T>();
        _httpContextAccessor = new HttpContextAccessor();

    }



    public IQueryable<T> AsQueryable()
    {
        return entity.AsQueryable();
    }
    public IQueryable<T>? Where(Expression<Func<T, bool>> predicate)
    {
        return entity.Where(predicate);
    }

    public async Task<T>? FirstOrDefaultAsync(Expression<Func<T, bool>> predicates)
    {
        return await entity.FirstOrDefaultAsync(predicates);
    }

    public async Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await entity.SingleOrDefaultAsync(predicate);
    }

    public async Task InsertAsync(T entity)
    {
        await this.entity.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        this.entity.Remove(entity);
    }

    public T? Find(params object?[]? keyValues)
    {
        return entity.Find(keyValues);
    }

    public async Task<T>? FindAsync(params object?[]? keyValues)
    {
        return await entity.FindAsync(keyValues);
    }

    private void SetDefaultValues()
    {


    }

    private bool IsEntityDerivedFromBaseClass(object entity, Type baseDomain)
    {
        Type entityType = entity.GetType();
        bool isEntityDerived = baseDomain.IsAssignableFrom(entityType);
        return isEntityDerived;
    }

    private bool EntityHasProperty(object entity, string property)
    {
        Type entityType = entity.GetType();
        return entityType.GetProperty(property) != null;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await entity.ToListAsync();
    }

    public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate)
    {
        return await entity.Where(predicate).ToListAsync();
    }

    public async Task<dynamic> GetEntityMaxId(Expression<Func<T, dynamic>> predicate)
    {
        return await entity.MaxAsync(predicate);
    }

    public async Task Commit()
    {
        //SetDefaultValues();
        //if (getUserType() == "1")
        //{
        //    AUDITEDSYS aduit = new AUDITEDSYS(_context, _httpContextAccessor);
        //    aduit.WriteAuditing(_context);
        //}
        await _context.SaveChangesAsync();
    }
    public T Add(T entity)
    {
        return _context.Set<T>().Add(entity).Entity;
    }
    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).CountAsync();
    }

    public static string getUserType()
    {
        var httpContext = new HttpContextAccessor().HttpContext;
        var claimsPrincipal = httpContext?.User;
        if (claimsPrincipal != null)
        {
            var userTypeClaim = claimsPrincipal.FindFirst("UserType");
            if (userTypeClaim != null)
            {
                return userTypeClaim.Value;
            }
        }
        return "";
    }

}