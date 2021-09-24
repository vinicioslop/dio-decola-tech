using AgenciaBancaria.Dominio;
using System;

namespace AgenciaBancaria.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Endereco endereco = new Endereco("Rua teste", "12345678", "City", "SP");
                Cliente cliente = new Cliente("Nome", "12345", "6789", endereco);

                ContaCorrente conta = new ContaCorrente(cliente, 100);

                Console.WriteLine("Conta " + conta.Situacao + ": " + conta.NumeroConta + "-" + conta.DigitoVerificador);

                string senha = "Abd@1234";

                conta.Abrir(senha);

                Console.WriteLine("Conta " + conta.Situacao + ": " + conta.NumeroConta + "-" + conta.DigitoVerificador);

                conta.Sacar(10, senha);

                Console.WriteLine("Saldo: " + conta.Saldo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
