using Microsoft.AspNetCore.Mvc;
using SeriesFilmes.Classes;
using SeriesFilmes.Interfaces;
using SeriesFilmes.Web.Model;

namespace SeriesFilmes.Web.Controllers
{

    [Route("[controller]")]
    public class FilmeController : Controller
    {
        public IRepositorio<Filme> repositorioFilmes;
        
        public FilmeController(IRepositorio<Filme> repositorio)
        {
            this.repositorioFilmes = repositorio;
        }
        [HttpGet("")]
        public IActionResult Lista()
        {
            return Ok(repositorioFilmes.Lista().Select(x => new FilmeModel(x)));
        }
        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
           return  Ok(new FilmeModel(repositorioFilmes.RetornaPorId(id)));
        }
        [HttpPost("")]
        public IActionResult Insere([FromBody]FilmeModel model)
        {   
            model.setId(repositorioFilmes.ProximoId());
            repositorioFilmes.Insere(model.ToFilme());
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Atualiza(int id,[FromBody]FilmeModel model)
        {   
            model.setId(id);
            repositorioFilmes.Atualiza(id,model.ToFilme());
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Exclui(int id)
        {
            repositorioFilmes.Exclui(id);
            return NoContent();
        }

    }
}