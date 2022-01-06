using Microsoft.AspNetCore.Mvc;
using SeriesFilmes.Classes;
using SeriesFilmes.Interfaces;
using SeriesFilmes.Web.Model;
namespace SeriesFilmes.Web.Controllers
{
    [Route("[controller]")]
    public class SerieController : Controller 
    {
        IRepositorio<Serie> repositorioSerie;
        public SerieController(IRepositorio<Serie> repositorio)
        {
            this.repositorioSerie = repositorio;
        }     

       [HttpGet("")]
        public IActionResult Lista()
        {            
            return Ok(repositorioSerie.Lista().Select(x => new SerieModel(x)));
        }
        [HttpPost("")]
        public IActionResult Insere([FromBody] SerieModel model)
        {   
            model.Id = repositorioSerie.ProximoId();
            Serie serie = model.ToSerie();
            
            repositorioSerie.Insere(serie);
            return Created("",serie);
        }
        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            return Ok(new SerieModel(repositorioSerie.Lista().Find(x => x.Id == id)));
        }
        [HttpPut("{id}")]
        public IActionResult Atualiza(int id, [FromBody] SerieModel model)
        {   
            model.Id = id;
            Serie serie = this.repositorioSerie.Lista().Find(x => x.Id == id);
            this.repositorioSerie.Atualiza(id, model.ToSerie());

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.repositorioSerie.Exclui(id);
            return NoContent();
        }
    
    }
}