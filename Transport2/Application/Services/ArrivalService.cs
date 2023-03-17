using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Enums;
using Application.IServices;

namespace Application.Services
{
    public class ArrivalService : IArrivalService
    {
        private readonly IApplicationDbContext _db;

        public ArrivalService(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ArrivalDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Arrival, ArrivalDTO>()).CreateMapper();
            return mapper.Map<List<Arrival>, List<ArrivalDTO>>(await _db.Arrivals.ToListAsync(cancellationToken));
        }

        public async Task<IEnumerable<ArrivalDTO>> GetAllAsync(CancellationToken cancellationToken, 
            Expression<Func<Arrival, bool>> predicate, params Expression<Func<Arrival, object>>[] Includes)
        {
            var entities = _db.Arrivals.AsQueryable();
            if (Includes != null) 
            {
                foreach (var include in Includes)
                {
                    entities = entities.Include(include);
                }
            }
            entities =  entities.Where(predicate);


            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Arrival, ArrivalDTO>()).CreateMapper();

            return mapper.Map<List<Arrival>, List<ArrivalDTO>>(await entities.ToListAsync(cancellationToken));
        }

        public async Task<ArrivalDTO> GetAsync(int id, CancellationToken cancellationToken)
        {
            var entitiy = await _db.Arrivals.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (entitiy is null)
                throw new Exception($"Arrival with id {id} not found");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Arrival, ArrivalDTO>()).CreateMapper();

            return mapper.Map<Arrival, ArrivalDTO>(entitiy);
        }

        public async Task<ArrivalDTO> GetAsync(int id, CancellationToken cancellationToken,
            Expression<Func<Arrival, bool>> predicate, params Expression<Func<Arrival, object>>[] Includes)
        {
            var set = _db.Arrivals.Where(x => x.Id == id).AsQueryable();
            if (predicate != null)
                set = set.Where(predicate);

            if (Includes != null)
            {
                foreach (var include in Includes)
                    set = set.Include(include);
            }

            var entitiy = await set.FirstOrDefaultAsync(cancellationToken);

            if (entitiy is null)
                throw new Exception($"Arrival with id {id} not found");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Arrival, ArrivalDTO>()).CreateMapper();

            return mapper.Map<Arrival, ArrivalDTO>(entitiy);
        }

        public async Task<ArrivalDTO> CreateAsync(ArrivalDTO entity, CancellationToken cancellationToken)
        {
            var mapperFrom = new MapperConfiguration(cfg => cfg.CreateMap<ArrivalDTO, Arrival>()).CreateMapper();
            var mapperTo = new MapperConfiguration(cfg => cfg.CreateMap<Arrival, ArrivalDTO>()).CreateMapper();

            var newEntity = mapperFrom.Map<ArrivalDTO, Arrival>(entity);
            
            _db.Arrivals.Add(newEntity);
            await _db.SaveChangesAsync(cancellationToken);

            return mapperTo.Map<Arrival, ArrivalDTO>(newEntity);
        }

        public async Task UpdateAsync(int id, ArrivalDTO entity, CancellationToken cancellationToken)
        {
            var dbEntitiy = await _db.Arrivals.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (dbEntitiy is null)
                throw new Exception($"Arrival with id {id} not found");

            dbEntitiy.ArrivalTime = (ArrivalTime)entity.ArrivalTime;
            dbEntitiy.Campus = (Campus)entity.Campus;

            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var dbEntitiy = await _db.Arrivals.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (dbEntitiy is null)
                throw new Exception($"Arrival with id {id} not found");

            _db.Arrivals.Remove(dbEntitiy);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
