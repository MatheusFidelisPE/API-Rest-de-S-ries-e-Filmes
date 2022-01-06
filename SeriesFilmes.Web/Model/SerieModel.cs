using SeriesFilmes.Classes;
using SeriesFilmes.Enums;

namespace SeriesFilmes.Web.Model
{
    public class SerieModel
    {
        private int Id { get; set; }
        public List<Genero> Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; } 
        public int Ano { get; set; }
        public bool Excluido { get; set; }
        
        public SerieModel()
        {

        }
        public SerieModel(Serie serie)
        {   
            this.Id = serie.RetornaId();
            this.Genero = serie.getGeneros();
            this.Titulo = serie.RetornaTitulo();
            this.Descricao = serie.getDescricao();
            this.Ano = serie.getAno();
            this.Excluido = serie.RetornaExcluido();
        }
        public Serie ToSerie()
        {
            return new Serie(
                Id: this.Id,
                titulo: this.Titulo,
                genero: this.Genero,
                descricao: this.Descricao,
                ano: this.Ano
            );
        }
        public int getId()
        {
            return this.Id;
        }
        public void setId(int id)
        {
            this.Id = id;
        }
    }
}