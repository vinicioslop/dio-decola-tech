using System;

namespace Cadastro_de_Alunos
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indice = 0;
            string opcao = ObterOpcaoUsuario();

            while(opcao.ToUpper() != "X")
            {
                switch(opcao)
                {
                    case "1":
                        var aluno = new Aluno();
                        Console.Write("\nInforma o nome do Aluno: ");
                        aluno.Nome = Console.ReadLine();

                        Console.Write("Informa a nota do Aluno: ");
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indice] = aluno;
                        indice++;

                        break;
                    
                    case "2":
                        foreach(var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Nome: {a.Nome} - Nota: {a.Nota}");
                            }
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        { 
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcao = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\nOpções");
            Console.WriteLine("1 - Cadastrar um novo aluno");
            Console.WriteLine("2 - Listar alunos cadastrados");
            Console.WriteLine("3 - Media geral da turma");
            Console.WriteLine("X - Sair\n");

            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
