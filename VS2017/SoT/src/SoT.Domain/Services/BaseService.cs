using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace SoT.Domain.Services
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> repository;
        private readonly IBaseReadOnlyRepository<TEntity> readOnlyRepository;

        public BaseService(IBaseRepository<TEntity> repository, IBaseReadOnlyRepository<TEntity> readOnlyRepository)
        {
            this.repository = repository;
            this.readOnlyRepository = readOnlyRepository;
        }

        public void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return readOnlyRepository.GetAll();
        }

        public TEntity GetById(Guid id)
        {
            return readOnlyRepository.GetById(id);
        }

        public void Remove(Guid id)
        {
            repository.Delete(id);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }

        public void Dispose()
        {
            repository.Dispose();
            readOnlyRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
