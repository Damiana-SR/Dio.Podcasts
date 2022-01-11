using System;
using System.Collections.Generic;
using Dio.Podcasts.Interfaces;


namespace DIO.Podcasts
{
    public class PodcastRepositorio : IRepositorio<Podcast>
    {
    private List<Podcast> listaPodcast = new List<Podcast>();

        public void Exclui(int id)
		{
			listaPodcast[id].Excluir();
		}

        internal static void Exclui(object indicePodcast)
        {
            throw new NotImplementedException();
        }

        public void Insere(Podcast objeto)
		{
			listaPodcast.Add(objeto);
		}

		public List<Podcast> Lista()
		{
			return listaPodcast;
		}

		public int ProximoId()
		{
			return listaPodcast.Count;
		}

		public Podcast RetornaPorId(int id)
		{
			return listaPodcast[id];
		}

        List<Podcast> IRepositorio<Podcast>.Lista()
        {
            throw new NotImplementedException();
        }

        internal void Insere(Series.Podcast novoPodcast)
        {
            throw new NotImplementedException();
        }

        public void Atualiza(int id, Podcast entidade)
        {
            throw new NotImplementedException();
        }

        internal void Atualiza(object indicePodcast, object atualizaPodcast)
        {
            throw new NotImplementedException();
        }

        internal void Atualiza(int indicePodcast11, object atualizaPodcast)
        {
            throw new NotImplementedException();
        }
    }
}