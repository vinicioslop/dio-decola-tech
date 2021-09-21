using System;

namespace DIO.Series
{
    class Program
    {
        // DECLARA UM REPOSITÓRIO DE SERIES, USANDO A ESTRUTURA DEFINIDA DA CLASSE SerieRepositorio
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            // CHAMA O MÉTODO PARA OBTER A OPÇÃO DIGITADA PELO USUÁRIO
            string opcaoUsuario = ObterOpcaoUsuario();

            // INSTANCIA UM UM LAÇO DE REPETIÇÃO WHILE QUE SERÁ EXECUTADO ENQUANTO O USUÁRIO NÃO DIGITAR A
            // OPÇÃO PARA SAIR DO MESMO. ENQUANTO ISSO, ATRAVÉS DA OPÇÃO DIGITADA PELO USUÁRIO EXECUTARÁ UMA
            // DAS OPÇÕES DO PROGRAMA
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
                        DesativarSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!! Digite novamente.");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine("Pressione qualquer tecla...");
            Console.ReadKey();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            Console.Write("\n");

            int desativados = 0;

            // GRAVA UMA LISTA DE OBJETOS DO REPOSITÓRIO DE SÉRIES PARA EXIBIÇÃO
            var lista = repositorio.Lista();

            foreach (var serie in lista)
            {
                if(!serie.retornaDesativado())
                {
                    desativados++;
                }
            }

            // UM VALOR NUNCA É EXCLUIDO, MAS MARCADO, ASSIM É POSSÍVEL TER UM CONTROLE DE
            // IDS. USA DESTA PARTICULARIDADE PARA ENCONTRAR SE EXISTEM OU NÃO SERIES ARMAZENADAS
            if (desativados == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            // PARA CADA VALOR EXISTENTE DENTRO DA LISTA DE SERIES EXECUTASSE O COMANDO ABAIXO
            // EXIBINDO O ID E TÍTULO DE CADA SÉRIE. CASO UMA DESTAS SÉRIES ESTIVER MARCADA COMO
            // DESATIVADA, EXIBIRÁ A MENSAGEM DESATIVADO
            foreach (var serie in lista)
            {
                if (!serie.retornaDesativado())
                {
                    Console.WriteLine("#ID {0} - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            exibeGeneros();

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            exibeGeneros();
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void DesativarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Desativa(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            if (!serie.retornaDesativado())
            {
                Console.WriteLine(serie);
            }
            else
            {
                Console.WriteLine("Série informada não está mais disponível.");
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.Write("\n");
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.Write("\n");
            Console.WriteLine("Informe a opção desejada:");
            Console.Write("\n");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Vizualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.Write("\n");

            Console.Write("Opção: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.Write("\n");
            return opcaoUsuario;
        }

        private static void Inserir(string categoria)
        {
            exibeGeneros();

            Console.Write($"Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static void exibeGeneros()
        {
            //link get value de enum
            //link get name de enum
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("\n");
        }
    }
}
