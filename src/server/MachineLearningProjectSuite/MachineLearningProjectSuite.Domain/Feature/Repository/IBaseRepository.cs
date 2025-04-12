using System.Linq.Expressions;
using MachineLearningProjectSuite.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Query;

namespace MachineLearningProjectSuite.Domain.Feature.Repository
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>
        where TKey : IComparable

    {
        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);
        /// <summary>
        /// Add entity async
        ///  and return entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> AddAndReturnAsync(TEntity entity);
        /// <summary>
        /// Add entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);
        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entityToUpdate"></param>
        void Edit(TEntity entityToUpdate);
        /// <summary>
        /// Update Async
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <returns></returns>
        Task EditAsync(TEntity entityToUpdate);
        Task EditAsync(TEntity entityToUpdate, CancellationToken cancellationToken);
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>List of entity</returns>
        IList<TEntity> GetAll();
        /// <summary>
        /// Get all entities async
        /// </summary>
        /// <returns>List of entity</returns>
        Task<IList<TEntity>> GetAllAsync();
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single entity</returns>
        TEntity GetById(TKey id);
        /// <summary>
        /// Get entity by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single entity</returns>
        Task<TEntity> GetByIdAsync(TKey id);
        /// <summary>
        /// Get count of entities
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>int</returns>
        int GetCount(Expression<Func<TEntity, bool>>? filter = null);
        /// <summary>
        /// Get count of entities async
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>>? filter = null);
        /// <summary>
        /// Remove entity range by filter
        /// </summary>
        /// <param name="filter"></param>
        void Remove(Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// Remove entity single
        /// </summary>
        /// <param name="entityToDelete"></param>
        void Remove(TEntity entityToDelete);
        /// <summary>
        /// Remove entity by id
        /// </summary>
        /// <param name="id"></param>
        void Remove(TKey id);
        /// <summary>
        /// Remove entity range by filter async
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task RemoveAsync(Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// Remove entity single async
        /// </summary>
        /// <param name="entityToDelete"></param>
        /// <returns></returns>
        Task RemoveAsync(TEntity entityToDelete);
        /// <summary>
        /// Remove entity by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoveAsync(TKey id);
        Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByIncludingAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> navigationPropertyPath);
        Task<TEntity> FindAsync(TKey id);
        Task<TEntity?> FindAsync(TKey id, CancellationToken cancellationToken);
        IList<TEntity> Get(
           Expression<Func<TEntity, bool>>? filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
           bool isTrackingOff = false
       );
        (IList<TEntity> data, int total, int totalDisplay) Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int pageIndex = 1,
            int pageSize = 10,
            bool isTrackingOff = false
        );

        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

        Task<IList<TEntity>> GetAsync(object selector, Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool isTrackingOff = false);

        Task<(IList<TEntity> data, int total, int totalDisplay)> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int pageIndex = 1,
            int pageSize = 10,
            bool isTrackingOff = false
        );

        Task<IList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
        );

        Task<IEnumerable<TResult>> GetAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true,
            CancellationToken cancellationToken = default
        )
            where TResult : class;
        IList<TEntity> GetDynamic(
            Expression<Func<TEntity, bool>>? filter = null,
            string? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool isTrackingOff = false
        );

        (IList<TEntity> data, int total, int totalDisplay) GetDynamic(
            Expression<Func<TEntity, bool>>? filter = null,
            string? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int pageIndex = 1,
            int pageSize = 10,
            bool isTrackingOff = false
        );

        Task<IList<TEntity>> GetDynamicAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            string? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool isTrackingOff = false
        );

        Task<(IList<TEntity> data, int total, int totalDisplay)> GetDynamicAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            string? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int pageIndex = 1,
            int pageSize = 10,
            bool isTrackingOff = false
        );

        Task<TResult> SingleOrDefaultAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true
        );

        Task<TEntity?> SingleAsync(Expression<Func<TEntity, bool>> filter, bool isTrack = true);

        Task<TEntity?> SingleAsync(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, bool isTrack = true);
        Task EditRangeAsync(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
