using System;

namespace ConsoleApp1.functions
{
    public static class Utils
    {
        // Lê entrada do usuário
        public static string Ler()
        {
            return Console.ReadLine() ?? string.Empty;
        }
        
        // Escreve texto no console
        public static void Escrever(string valor, bool novaLinha = true)
        {
            if (novaLinha)
            {
                Console.WriteLine(valor);
            }
            else
            {
                Console.Write(valor);
            }
        }
        
        // Limpa a tela do console
        public static void Limpar()
        {
            Console.Clear();
        }
    }
}