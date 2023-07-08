using IngresosWabA.Server.DAL;
using IngresosWabA.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IngresosWabA.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngresosController : ControllerBase
{
    private readonly Context _Context;

    public IngresosController(Context context)
    {
        _Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ingresos>>> GetIngresos()
    {
        if(_Context.Ingresos == null)
        {
            return NotFound();
        }
        return await _Context.Ingresos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Ingresos>> GetIngresos(int id)
    {
        if(_Context.Ingresos == null)
        {
            return NotFound();
        }

        var ingresos = await _Context.Ingresos.FindAsync(id);

        if(ingresos == null)
        {
            return NotFound();
        }
        return ingresos;
    }

    [HttpPost]
    public async Task<ActionResult<Ingresos>> PostIngresos(Ingresos ingresos)
    {
        if (!Existe(ingresos.IngresoId))
            _Context.Ingresos.Add(ingresos);
        else
            _Context.Ingresos.Update(ingresos);

        await _Context.SaveChangesAsync();
        return Ok(ingresos);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteIngresos(int id)
    {
        if(_Context.Ingresos == null)
        {
            return NotFound();
        }

        var ingreso = await _Context.Ingresos.FindAsync(id);

        if(ingreso == null)
        {
            return NotFound();
        }

        _Context.Ingresos.Remove(ingreso);
        await _Context.AddRangeAsync(ingreso);

        return NoContent();
    }

    private bool Existe(int id)
    {
        return (_Context.Ingresos?.Any(i => i.IngresoId == id)).GetValueOrDefault();
    }
}


