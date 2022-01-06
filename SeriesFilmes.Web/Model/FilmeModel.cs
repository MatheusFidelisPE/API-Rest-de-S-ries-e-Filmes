using SeriesFilmes.Classes;
using SeriesFilmes.Enums;

namespace SeriesFilmes.Web.Model
{
    public class FilmeModel
    {
        private int Id { get; set; }
        public List<Genero> Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Bilheteria { get; set; }
        public decimal NotaOmelete { get; set; }
        public bool Excluido { get; set; }
        public FilmeModel()
        {

        }
        public FilmeModel(Filme filme)
        {
            Id =            filme.RetornaId();
            Genero =        filme.getGeneros();
            Titulo =        filme.RetornaTitulo();
            Descricao =     filme.getDescricao();
            Bilheteria =    filme.RetornarBilheteria();
            NotaOmelete =   filme.RetornaNotaOmelete();
            Excluido =      filme.RetornaExcluido();
        }     
        public Filme ToFilme()
        {
            return new Filme(
                Id: this.Id,
                genero:this.Genero,
                titulo:this.Titulo,
                descricao:this.Descricao,
                notaOmelete:this.NotaOmelete,
                bilheteria:this.Bilheteria
            );
        }
        public int getId()
        {
            return Id;
        }
        public void setId(int id)
        {
            this.Id = id;
        }

    }
}