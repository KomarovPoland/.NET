using Application.IServices;
using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/arrivals")]
    public class ArrivalsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ArrivalsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var entities = await _serviceManager.ArrivalService.GetAllAsync(cancellationToken, x => !x.IsDeleted);

            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _serviceManager.ArrivalService.GetAsync(id, cancellationToken, x => !x.IsDeleted);

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArrivalDTO entity, CancellationToken cancellationToken)
        {
            var dbEntity = await _serviceManager.ArrivalService.CreateAsync(entity, cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = dbEntity.Id }, dbEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ArrivalDTO entity, CancellationToken cancellationToken)
        {
            await _serviceManager.ArrivalService.UpdateAsync(id, entity, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _serviceManager.ArrivalService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
