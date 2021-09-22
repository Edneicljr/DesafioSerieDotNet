using System;
using DesafioAppCadastroDotNet;

namespace DesafioAppCadastroDotNet
{

    class Program
    {
        static CursoRepositorio repositorio = new CursoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarCursos();
						break;
					case "2":
						InserirCurso();
						break;
					case "3":
						AtualizarCurso();
						break;
					case "4":
						ExcluirCurso();
						break;
					case "5":
						VisualizarCurso();
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

        private static void ExcluirCurso()
		{
			Console.Write("Digite o id da Curso: ");
			int indiceCurso = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceCurso);
		}

        private static void VisualizarCurso()
		{
			Console.Write("Digite o id da Curso: ");
			int indiceCurso = int.Parse(Console.ReadLine());

			var Curso = repositorio.RetornaPorId(indiceCurso);

			Console.WriteLine(Curso);
		}

        private static void AtualizarCurso()
		{
			Console.Write("Digite o id da Curso: ");
			int indiceCurso = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Tema)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tema), i));
			}
			Console.Write("Digite o tema entre as opções acima: ");
			int entradaTema = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Curso: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite a Duracao de Início da Curso: ");
			int entradaDuracao = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Curso: ");
			string entradaDescricao = Console.ReadLine();

			Curso atualizaCurso = new Curso(id: indiceCurso,
										tema: (Tema)entradaTema,
										titulo: entradaTitulo,
										duracao: entradaDuracao,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceCurso, atualizaCurso);
		}
        private static void ListarCursos()
		{
			Console.WriteLine("Listar Cursos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma Curso cadastrada.");
				return;
			}

			foreach (var Curso in lista)
			{
                var excluido = Curso.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Curso.retornaId(), Curso.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirCurso()
		{
			Console.WriteLine("Inserir novo Curso");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Tema)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tema), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaTema = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Curso: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Duracao de Início da Curso: ");
			int entradaDuracao = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Curso: ");
			string entradaDescricao = Console.ReadLine();

			Curso novaCurso = new Curso(id: repositorio.ProximoId(),
										tema: (Tema)entradaTema,
										titulo: entradaTitulo,
										duracao: entradaDuracao,
										descricao: entradaDescricao);

			repositorio.Insere(novaCurso);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Cursos a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Cursos");
			Console.WriteLine("2- Inserir novo Curso");
			Console.WriteLine("3- Atualizar Curso");
			Console.WriteLine("4- Excluir Curso");
			Console.WriteLine("5- Visualizar Curso");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
