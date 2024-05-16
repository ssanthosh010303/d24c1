using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

using DoctorAppointmentApi.Models;
using DoctorAppointmentApi.Services;

namespace DoctorAppointmentApi.Controllers;

public class ApplicationControllerBase<TEntity, TService> : ControllerBase
    where TEntity : ModelBase
    where TService : IServiceBase<TEntity>
{
    private readonly TService _service;

    public ApplicationControllerBase(TService service)
    {
        _service = service;
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            return Ok(await _service.GetById(id));
        }
        catch (ServiceException ex)
        {
            return BadRequest(new ErrorResponse
            {
                Message = ex.Message,
                ErrorCode = "EntityNotFound"
            });
        }
    }

    [HttpPost]
    public virtual async Task<IActionResult> Create([FromBody] TEntity entity)
    {
        try
        {
            var createdEntity = await _service.Add(entity);

            return CreatedAtAction(
                nameof(GetById), new { id = createdEntity.Id }, createdEntity);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new ErrorResponse
            {
                Message = ex.Message,
                ErrorCode = "ValidationFailed"
            });
        }
    }

    [HttpPut("{id}")]
    public virtual async Task<IActionResult> Update(
        [FromRoute] int id, [FromBody] TEntity entity)
    {
        try
        {
            await _service.Update(id, entity);
            return Ok();
        }
        catch (ServiceException ex)
        {
            return BadRequest(new ErrorResponse
            {
                Message = ex.Message,
                ErrorCode = "EntityNotFound"
            });
        }
        catch (ValidationException ex)
        {
            return BadRequest(new ErrorResponse
            {
                Message = ex.Message,
                ErrorCode = "ValidationFailed"
            });
        }
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            await _service.Delete(id);
            return Ok();
        }
        catch (ServiceException ex)
        {
            return BadRequest(new ErrorResponse
            {
                Message = ex.Message,
                ErrorCode = "EntityNotFound"
            });
        }
    }

}
