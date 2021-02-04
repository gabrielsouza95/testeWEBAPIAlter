using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using testeAlter.Data;
using testeAlter.Models;

namespace testeAlter.Controllers
{
    [ApiController]
    [Route("v1/categorias")]
    public class ControllerCategoria : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Categoria>>> Get([FromServices] DataContext context)
        {
            var categorias = await context.Categorias.ToListAsync();
            //categorias = new List<Categoria>()
            //{
            //    new Categoria()
            //    {
            //        Id = 1,
            //        Name = "Categoria 1"
            //    },
            //    new Categoria()
            //    {
            //        Id = 2,
            //        Name = "Categoria 2"
            //    }
            //};

            return categorias;
        }
        
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Categoria>> Post (
            [FromServices] DataContext context,
            [FromBody] Categoria model )
        {
            if(ModelState.IsValid)
            {
                context.Categorias.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}