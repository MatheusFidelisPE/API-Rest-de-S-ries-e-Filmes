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
    }
}