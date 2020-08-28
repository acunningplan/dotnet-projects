using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TravelBug.Entities;
using TravelBug.CrudServices;

namespace TravelBug.Web.Controllers
{
    [ApiController]
    public abstract class CrudController<TEntity, TEntityDto> : ControllerBase
       where TEntity : class, IBase
    {
        protected readonly IBaseService<TEntity, TEntityDto> _service;

        protected CrudController([NotNull] IBaseService<TEntity, TEntityDto> service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync(TEntity entity)
        {
            var entityDto = await _service.CreateAsync(entity);

            return Ok(entityDto);
        }

        [HttpGet("{id:Guid}")]
        public virtual async Task<IActionResult> ReadAsync(Guid id)
        {
            var entityDto = await _service.ReadAsync(id);

            if (entityDto == null) return NotFound();

            return Ok(entityDto);
        }

        [HttpPatch("{id:Guid}")]
        public virtual async Task<IActionResult> UpdatePartialAsync(Guid id, [FromBody] JsonPatchDocument<TEntity> patchEntity)
        {
            var entity = await _service.GetEntity(id);

            // Add logic here to check whether user from token = user of entity

            if (entity == null) return NotFound();

            patchEntity.ApplyTo(entity, ModelState);
            var entityDto = await _service.UpdateAsync(id, entity);

            return Ok(entityDto);
        }

        [HttpDelete("{id:Guid}")]
        public virtual async Task<IActionResult> DeleteAsync(Guid id)
        {
            var entityDto = await _service.ReadAsync(id);

            if (entityDto == null) return NotFound();

            await _service.DeleteAsync(id);

            return Ok(entityDto);
        }
    }
}
