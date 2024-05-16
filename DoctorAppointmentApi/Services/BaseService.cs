using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Repositories;

namespace DoctorAppointmentApi.Services;

public interface IServiceBase<TEntity> where TEntity : ModelBase
{
    public Task<IList<TEntity>> GetAll();
    public Task<TEntity> GetById(int id);
    public Task<TEntity> Add(TEntity entity);
    public Task Update(int id, TEntity entity);
    public Task Delete(int id);
}

public abstract class ServiceBase<TEntity> : IServiceBase<TEntity>
    where TEntity : ModelBase
{
    protected readonly IRepositoryBase<TEntity> _repository;

    public ServiceBase(IRepositoryBase<TEntity> repository)
    {
        _repository = repository
            ?? throw new ArgumentNullException(nameof(repository));
    }

    public virtual async Task<IList<TEntity>> GetAll()
    {
        try
        {
            return await _repository.GetAll();
        }
        catch (RepositoryException ex)
        {
            throw new ServiceException(
                "An error occurred in the service while fetching entities.",
                ex);
        }
    }

    public virtual async Task<TEntity> GetById(int id)
    {
        try
        {
            return await _repository.GetById(id);
        }
        catch (RepositoryException ex)
        {
            throw new ServiceException(
                $"An error occurred in the service while fetching the entity " +
                "with ID: {id}.", ex);
        }
    }

    public virtual async Task<TEntity> Add(TEntity entity)
    {
        try
        {
            return await _repository.Add(entity);
        }
        catch (RepositoryException ex)
        {
            throw new ServiceException(
                "An error occurred in the service while adding the entity.",
                ex);
        }
    }

    public virtual async Task Update(int id, TEntity entity)
    {
        try
        {
            await _repository.Update(id, entity);
        }
        catch (RepositoryException ex)
        {
            throw new ServiceException(
                "An error occurred in the service while updating the entity.",
                ex);
        }
    }

    public virtual async Task Delete(int id)
    {
        try
        {
            await _repository.Delete(id);
        }
        catch (RepositoryException ex)
        {
            throw new ServiceException(
                "An error occurred in the service while deleting the entity.",
                ex);
        }
    }
}
