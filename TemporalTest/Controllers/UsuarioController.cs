using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemporalTest.Data;
using TemporalTest.DTO;
using TemporalTest.Entity;

namespace TemporalTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController(Context contexto) : Controller
    {
        private DbSet<Usuario> _dbSet = contexto.Set<Usuario>();

        [HttpPost]
        public async Task<IActionResult> Criar(CriarAtualizarUsuarioDTO model)
        {
            var usuario = new Usuario(model);

            await _dbSet.AddAsync(usuario);
            await contexto.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, CriarAtualizarUsuarioDTO model)
        {
            var usuario = await _dbSet.FindAsync(id);

            usuario!.Atualizar(model);

            _dbSet.Entry(usuario).State = EntityState.Modified;
            _dbSet.Update(usuario);
            await contexto.SaveChangesAsync();
                
            return Ok();
        }

        [HttpGet("Alteracoes/{id}")]
        public async Task<IActionResult> ObterAlteracoes(int id)
        {
            var usuarios = _dbSet.TemporalAll().Where(x => x.Id == id);

            return Ok(usuarios);
        }

        [HttpGet("CadeiaEstahValida")]
        public async Task<IActionResult> CadeiaEstahValida(int id)
        {
            var usuarios = _dbSet.TemporalAll()
                .Where(x => x.Id == id)
                .Select(x => new Block() { DataInsercao = x.DataInsercao, Dados = x.Dados, Hash = x.Hash, HashAnterior = x.HashAnterior })
                .OrderBy(x => x.DataInsercao)
                .ToList();

            return usuarios.EstahValido() ? Ok() : NoContent();
        }

    }
}
