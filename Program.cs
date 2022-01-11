using System;

namespace DIO.Podcasts
{
    internal class NewBaseType
    {
         private static int indicePodcast ;

         private static void ExcluirPodcast()
         {
             Console.Write("Digite o id do Podcast: ");
             int indiceSerie = int.Parse(Console.ReadLine());

         PodcastRepositorio.Exclui(indicePodcast);
         }
    }

    class Program : NewBaseType
    {
        static PodcastRepositorio repositorio = new PodcastRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarPodcasts();
						break;
					case "2":
						InserirPodcast();
						break;
					case "3":
						AtualizarPodcast();
						break;
					case "4":
						ExcluirPodcast();
						break;
					case "5":
						VisualizarPodcast();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        // private static void ListarPodcasts()
        // {
        //     throw new NotImplementedException();
        // }

        private static void VisualizarPodcast()
        {
            throw new NotImplementedException();
        }

        private static void ExcluirPodcast()
        {
            throw new NotImplementedException();
        }

        private static void VisualizarPodcasts()
		{
			Console.Write("Digite o id do Podcast: ");
			int indicePodcast = int.Parse(Console.ReadLine());

			var podcast = repositorio.RetornaPorId(indicePodcast);

			Console.WriteLine(podcast);
		}

        private static void AtualizarPodcast()
		{
			Console.Write("Digite o id do podcast: ");
			int indicePodcast = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Podcast: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Podcast: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Podcast: ");
			string entradaDescricao = Console.ReadLine();

			Podcast atualizaPodcast = new Podcast(id: indicePodcast,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indicePodcast, atualizaPodcast);
		}
        private static void ListarPodcasts()
		{
			Console.WriteLine("Listar podcasts");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum podcast cadastrado.");
				return;
			}

			foreach (var podcast in lista)
			{
                var excluido = podcast.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", podcast.retornaId(), podcast.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirPodcast()
		{
			Console.WriteLine("Inserir novo Podcast");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Podcast: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Podcast: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Podcast: ");
			string entradaDescricao = Console.ReadLine();

			Podcast novoPodcast = new Podcast(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoPodcast);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Podcasts a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Podcasts");
			Console.WriteLine("2- Inserir novo Podcast");
			Console.WriteLine("3- Atualizar Podcast");
			Console.WriteLine("4- Excluir Podcast");
			Console.WriteLine("5- Visualizar Podcast");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}