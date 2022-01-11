using DIO.Podcasts;

namespace DIO.Series
{
    internal class Podcast
    {
        private object id;
        private Genero genero;
        private string titulo;
        private int ano;
        private string descricao;

        public Podcast(object id, Genero genero, string titulo, int ano, string descricao)
        {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.ano = ano;
            this.descricao = descricao;
        }
    }
}