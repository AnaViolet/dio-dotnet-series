using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por escolher a DIO Séries!");

        }

        private static void VisualizarSerie()
        {
            ListarSeries();
            Console.WriteLine("* Digite o ID da série *");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void VisualizarSerie(int indiceSerie)
        {
            var serie = repositorio.RetornarPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            ListarSeries();
            Console.WriteLine("* Digite o ID da série *");
            int indiceSerie = int.Parse(Console.ReadLine());

            //Visualizar a serie e confirmar exclusão
            VisualizarSerie(indiceSerie);

            Serie serie = repositorio.RetornarPorId(indiceSerie);

            if (!serie.retornarExcluido())
            {
                Console.WriteLine("Confirmar a exclusão? S/N");

                string opcConfirmacao = Console.ReadLine().ToUpper();

                if (Equals(opcConfirmacao, "S"))
                    repositorio.Excluir(indiceSerie);
                else if (Equals(opcConfirmacao, "N"))
                {
                    Console.WriteLine("\nVoltando ao menu principal...");
                    return;
                }
                else
                    throw new ArgumentOutOfRangeException("Opção inválida!");
            } else
            {
                Console.WriteLine("\nSérie já excluída!");
                return;
            }
        }

        private static void AtualizarSerie()
        {
            ListarSeries();
            Console.WriteLine("* Digite o ID da série *");
            int indiceSerie = int.Parse(Console.ReadLine());

            int entradaGenero, entradaAno;
            string entradaTitulo, entradaDescricao;
            entradaSerie(out entradaGenero, out entradaTitulo, out entradaAno, out entradaDescricao);

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualizar(indiceSerie, atualizaSerie);
        }

        private static void entradaSerie(out int entradaGenero, out string entradaTitulo, out int entradaAno, out string entradaDescricao)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            do
            {
                Console.WriteLine("\nDigite o gênero entre as opções acima: ");
                entradaGenero = int.Parse(Console.ReadLine());
            } while (entradaGenero > Enum.GetValues(typeof(Genero)).Length);

            Console.WriteLine("Digite o Título da Série: ");
            entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            entradaDescricao = Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("** Séries cadastradas **");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornarExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornarId(), serie.retornarTitulo(), (excluido ? "[EXCLUIDO]" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("*** Inserir série ***");
            Console.WriteLine("****** Gêneros ******");

            int entradaGenero, entradaAno;
            string entradaTitulo, entradaDescricao;
            entradaSerie(out entradaGenero, out entradaTitulo, out entradaAno, out entradaDescricao);

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Inserir(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("********** DIO Séries **********");
            Console.WriteLine("*** Informe a opção desejada ***");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcUsuario;
        }
    }
}