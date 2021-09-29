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

            // GRAVA UMA LISTA DE OBJETOS DO REPOSITÓRIO DE SÉRIES PARA EXIBIÇÃO
            var lista = repositorio.Lista();

            // PARA CADA VALOR EXISTENTE DENTRO DA LISTA DE SERIES EXECUTASSE O COMANDO ABAIXO
            // EXIBINDO O ID E TÍTULO DE CADA SÉRIE. CASO UMA DESTAS SÉRIES ESTIVER MARCADA COMO
            // DESATIVADA, NÃO SERÁ EXIBIDA
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

            Serie novaSerie = CriaSerie();

            // CHAMA A FUNÇÃO Insere() DO REPOSITÓRIO DE SÉRIES PARA
            // INSERIR UMA NOVA SÉRIE, LEVANDO COMO ARGUMENTO A INSTÂNCIA
            // DE SÉRIE.
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            exibeGeneros();

            // PEDE PARA O USUÁRIO DIGITAR UMA DAS OPÇÕES DE GÊNERO DA SÉRIE
            // EXIBIDAS, CONVERTE EM INTEIRO E ARMAZENA NA VARIÁVEL ABAIXO
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Serie atualizaSerie = CriaSerie(indiceSerie);

            // CHAMA A FUNÇÃO Atualiza() DO REPOSITÓRIO DE SÉRIES PARA
            // ATUALIZAR SÉRIE, LEVANDO COMO ARGUMENTO A INSTÂNCIA
            // DE SÉRIE E O ID DA SÉRIE EXISTENTE.
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void DesativarSerie()
        {
            // COLETA O ID DIGITADO PELO USUÁRIO E, APÓS CONVERTÊ-LO PRA INTEIRO
            // ARMAZENA EM UMA VARIÁVEL COM O NOME indiceSerie
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            // COM O INDICE DIGITADO ARMAZENADO CHAMA A FUNÇÃO DESATIVA,
            // ESSA FUNÇÃO A PARTIR DO INDICE DO USUARIO DESATIVARA A
            // SERIE EM QUE O INDICE FOR IGUAL AO DIGITADO
            repositorio.Desativa(indiceSerie);

            Console.WriteLine("Série excluida com sucesso!");
        }

        private static void VisualizarSerie()
        {
            // COLETA O ID DIGITADO PELO USUÁRIO E, APÓS CONVERTÊ-LO PRA INTEIRO
            // ARMAZENA EM UMA VARIÁVEL COM O NOME indiceSerie
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            // COM O INDICE DIGITADO ARMAZENADO CHAMA A FUNÇÃO RetornaPorId()
            // ESTA FUNCAO RETORNARA O OBJETO ONDE O ID DIGITADO SEJA IGUAL
            // AO DE UMA DAS SERIES ARMAZENADAS
            var serie = repositorio.RetornaPorId(indiceSerie);

            // LAÇO RESPONSAVEL POR EXIBIR A SERIE COLETADA
            // CASO A SERIE DIGITADA ESTEJA MARCADA COMO
            // DESATIVADA NÃO EXIBIRA O OBJETO DA SERIE
            // E EXIBIRA A MENSAGEM "Série informada não está mais disponível."
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
            // EXIBE UM MENU FEITO NO CONSOLE PARA EXIBIÇÃO DAS
            // OPÇÕES DE FUNCIONALIDADE QUE O PROGRAMA POSSUI
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

            // COLETA A OPÇÃO DIGITADA PELO USUÁRIO E ARMAZENA EM
            // UMA VARIAVEL, DEIXANDO TODAS AS LETRAS DIGITADAS
            // POR ELE EM CAIXA ALTA
            Console.Write("Opção: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.Write("\n");

            // RETORNA O VALOR DIGITADO PELO USUARIO PARA O
            // TRECHO EM QUE ESTE MÉTODO FOI CHAMADO
            return opcaoUsuario;
        }

        private static void Inserir(string categoria)
        {
            Serie novaSerie = CriaSerie();

            repositorio.Insere(novaSerie);
        }

        private static void exibeGeneros()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("\n");
        }

        private static Serie CriaSerie()
        {
            // CHAMA A FUNÇÃO RESPONSÁVEL POR COLETAR E EXIBIR TODOS OS
            // GENEROS DE SÉRIES DISPONÍVEIS NO PROGRAMA PARA O USUÁRIO
            exibeGeneros();

            // PEDE PARA O USUÁRIO DIGITAR O GÊNERO DA SÉRIE
            // E ARMAZENA NA VARIÁVEL ABAIXO
            Console.Write($"Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            // PEDE PARA O USUÁRIO DIGITAR O TÍTULO DA SÉRIE
            // E ARMAZENA NA VARIÁVEL ABAIXO
            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            // PEDE PARA O USUÁRIO DIGITAR O ANO DE INÍCIO DA SÉRIE,
            // CONVERTE EM INTEIRO E ARMAZENA NA VARIÁVEL ABAIXO
            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            // PEDE PARA O USUÁRIO DIGITAR A DESCRIÇÃO DA SÉRIE
            // E ARMAZENA NA VARIÁVEL ABAIXO
            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            // PEGA OS DADOS DIGITADOS PELO USUÁRIO E ATRIBUI A UMA NOVA
            // INSTANCIA DE SÉRIE, USANDO DO ID JÁ EXISTENTE.

            return new Serie(id: repositorio.ProximoId(),
                                genero: (Genero)entradaGenero,
                                titulo: entradaTitulo,
                                ano: entradaAno,
                                descricao: entradaDescricao);
        }

        private static Serie CriaSerie(int entradaId)
        {
            // CHAMA A FUNÇÃO RESPONSÁVEL POR COLETAR E EXIBIR TODOS OS
            // GENEROS DE SÉRIES DISPONÍVEIS NO PROGRAMA PARA O USUÁRIO
            exibeGeneros();

            // PEDE PARA O USUÁRIO DIGITAR O GÊNERO DA SÉRIE
            // E ARMAZENA NA VARIÁVEL ABAIXO
            Console.Write($"Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            // PEDE PARA O USUÁRIO DIGITAR O TÍTULO DA SÉRIE
            // E ARMAZENA NA VARIÁVEL ABAIXO
            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            // PEDE PARA O USUÁRIO DIGITAR O ANO DE INÍCIO DA SÉRIE,
            // CONVERTE EM INTEIRO E ARMAZENA NA VARIÁVEL ABAIXO
            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            // PEDE PARA O USUÁRIO DIGITAR A DESCRIÇÃO DA SÉRIE
            // E ARMAZENA NA VARIÁVEL ABAIXO
            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            // PEGA OS DADOS DIGITADOS PELO USUÁRIO E ATRIBUI A UMA NOVA
            // INSTANCIA DE SÉRIE, USANDO DO ID JÁ EXISTENTE.
            return new Serie(id: entradaId,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
        }
    }
}
