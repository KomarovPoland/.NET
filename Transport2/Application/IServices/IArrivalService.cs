using Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IArrivalService
    {
        Task<IEnumerable<ArrivalDTO>> GetAllAsync(CancellationToken cancellationToken);

        Task<IEnumerable<ArrivalDTO>> GetAllAsync(CancellationToken cancellationToken,
            Expression<Func<Arrival, bool>> predicate, params Expression<Func<Arrival, object>>[] Includes);

        Task<ArrivalDTO> GetAsync(int id, CancellationToken cancellationToken);

        Task<ArrivalDTO> GetAsync(int id, CancellationToken cancellationToken,
            Expression<Func<Arrival, bool>> predicate, params Expression<Func<Arrival, object>>[] Includes);

        Task<ArrivalDTO> CreateAsync(ArrivalDTO entity, CancellationToken cancellationToken);

        Task UpdateAsync(int id, ArrivalDTO entity, CancellationToken cancellationToken);

        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
