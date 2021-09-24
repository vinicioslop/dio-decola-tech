using System;

namespace desafio01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Leia dois valores inteiros identificados como variáveis A e B.
            // Calcule a soma entre elas e chame essa variável de SOMA.
            // A seguir escreva o valor desta variável.

            int valor01, valor02, soma;

            Console.WriteLine("Bem vindo ao desafio 01 dos desafios matemáticos em C#.");
            Console.WriteLine("SOMA de dois valores INTEIROS.");

            Console.Write("\n");
            
            Console.Write("Digite o primeiro valor inteiro: ");
            valor01 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o segundo valor inteiro.: ");
            valor02 = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n");

            soma = valor01 + valor02;

            Console.WriteLine($"A soma de {valor01} + {valor02} é igual a {soma}");
        }
    }
}
