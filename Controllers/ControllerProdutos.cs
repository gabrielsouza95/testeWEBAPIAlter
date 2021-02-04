using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using testeAlter.Data;
using testeAlter.Models;

namespace testeAlter.Controllers
{
    [ApiController]
    [Route("v1/produtos")]
    public class ControllerProdutos : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            var produtos = await context.Produtos.Include(x => x.Categoria).ToListAsync();
            return produtos;
        }

        [HttpGet]
        [Route("{id:int}")] ///Recebe um int com restrição na rota, que caso seja colocado outro tipo, não é aceito.
        public async Task<ActionResult<Produto>> GetById([FromServices] DataContext context, int id) ///esse id precisa ser exatamente igual do que foi declarado na rota.
        {
            var produto = await context.Produtos.Include(x => x.Categoria)
                .AsNoTracking() ///não deixa criar um proxy dos objetos
                .FirstOrDefaultAsync(x => x.Id == id);
            return produto;
        }

        [HttpGet]
        [Route("categorias/{id:int}")] ///.
        public async Task<ActionResult<List<Produto>>> GetByCategory([FromServices] DataContext context, int id) ///esse id precisa ser exatamente igual do que foi declarado na rota.
        {
            var produtos = await context.Produtos
                .Include(x => x.Categoria)
                .AsNoTracking() ///não deixa criar um proxy dos objetos
                .Where(x => x.Categoria_id == id)
                .ToListAsync();
            return produtos;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post(
            [FromServices] DataContext context,
            [FromBody] Produto model)
        {
            if(ModelState.IsValid)
            {
                var categoria = await context.Categorias.FindAsync(model.Categoria_id);

                if (categoria == null)
                    return BadRequest("Categoria não cadastrada");

                context.Produtos.Add(model);
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
        public async Task<ActionResult<Produto>> Put(
            [FromServices] DataContext context,
            [FromBody] Produto model,
            int id
            )
        {
            if (id != model.Id)
                return BadRequest("ID de Produto não está correto.");

            if (ModelState.IsValid)
            {
                //var produto = await context.Produtos.FindAsync(id);

                //if (produto == null)
                //    return NotFound($"Produto com ID = {id} não foi encontrada.");

                context.Produtos.Update(model);
                await context.SaveChangesAsync();

                return model;
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> Delete(
            [FromServices] DataContext context,
            int id)
        {
            var produto = await context.Produtos.Include(x => x.Categoria)
                .AsNoTracking() ///não deixa criar um proxy dos objetos
                .FirstOrDefaultAsync(x => x.Categoria_id == id);

            context.Produtos.Remove(produto);
            await context.SaveChangesAsync();

            return produto;
        }

    }
}
