using Application.Interfaces;
using Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly IApplicationDbContext _db;
        private readonly Lazy<IArrivalService> _lazyArrivalService;

        public ServiceManager(IApplicationDbContext _db)
        {
            _lazyArrivalService = new Lazy<IArrivalService>(() => new ArrivalService(_db));
        }

        public IArrivalService ArrivalService => _lazyArrivalService.Value;
    }
}
