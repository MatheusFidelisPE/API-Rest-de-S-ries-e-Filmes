using Microsoft.AspNetCore.Mvc;
using SeriesFilmes.Classes;
using SeriesFilmes.Enums;
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
            model.setId(repositorioSerie.ProximoId());
            Serie serie = model.ToSerie();
            
            repositorioSerie.Insere(serie);
            return Created("",serie);
        }
        [HttpGet("Serie/id/{id}")]
        public IActionResult Consulta(int id)
        {
            return Ok(new SerieModel(repositorioSerie.Lista().Find(x => x.Id == id)));
        }
        [HttpGet("Serie/titulo/{titulo}")]
        public IActionResult ConsultaTitulo(string titulo)
        {
            SerieModel serie = new SerieModel(repositorioSerie.Lista().Find(x => x.RetornaTitulo() == titulo));
            return Ok(serie);
        }
        // [HttpGet("Serie/{genero}")]
        // public IActionResult consultaGeneros(Genero genre)
        // {
        //     List<Serie> listagem = repositorioSerie.Lista();
        //     List<SerieModel> listagemGeneroDesejado = new List<SerieModel>();
        //     foreach (var serie in listagem)
        //     {
        //        foreach (var genero in serie.getGeneros())
        //        {
        //            if(genero == genre)
        //            {
        //                listagemGeneroDesejado.Add(new SerieModel(serie));
        //            }
        //        }
        //     }
            
        //     return Ok(listagemGeneroDesejado);
        // }
        [HttpPut("{id}")]
        public IActionResult Atualiza(int id, [FromBody] SerieModel model)
        {   
            model.setId(id);
            this.repositorioSerie.Atualiza(id, model.ToSerie());
            return Ok(model);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.repositorioSerie.Exclui(id);
            return NoContent();
        }
    
    }
}