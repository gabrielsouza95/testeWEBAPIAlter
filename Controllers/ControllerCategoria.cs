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

            return categorias;
        }

        [HttpGet]
        [Route("{id:int}")] ///Recebe um int com restrição na rota, que caso seja colocado outro tipo, não é aceito.
        public async Task<ActionResult<Categoria>> GetById([FromServices] DataContext context, int id) ///esse id precisa ser exatamente igual do que foi declarado na rota.
        {
            var categoria = await context.Categorias.FindAsync(id);
                //.FirstOrDefaultAsync(x => x.Id == id);
            return categoria;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Categoria>> Post (
            [FromServices] DataContext context,
            [FromBody] Categoria model )
        {
            if(ModelState.IsValid) // Adiciona as validações do modelo.
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

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Categoria>> Put (
            [FromServices] DataContext context,
            [FromBody] Categoria model,
            int id
            )
        {
            if (id != model.Id)
                return BadRequest("ID de Categoria não está correto.");

            if (ModelState.IsValid)
            {
                //var categoria = await context.Categorias.FindAsync(id);

                //if (categoria == null)
                //    return NotFound($"Categoria com ID = {id} não foi encontrada.");

                context.Categorias.Update(model);
                await context.SaveChangesAsync();

                return model;
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Categoria>> Delete (
            [FromServices] DataContext context,
            int id)
        {
            var produto = await context.Produtos.Include(x => x.Categoria)
                .AsNoTracking() ///não deixa criar um proxy dos objetos
                .FirstOrDefaultAsync(x => x.Categoria_id == id);

            if (produto != null)
                return BadRequest("Categoria está associada a um produto");

            var categoria = await context.Categorias.FindAsync(id);

            context.Categorias.Remove(categoria);
            await context.SaveChangesAsync();

            return categoria;
        }
    }
}