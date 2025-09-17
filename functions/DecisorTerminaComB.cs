using System;

namespace ConsoleApp1.functions
{
    public static class DecisorTerminaComB
    {
        private static readonly string alfabeto = "ab";
        
        // Decide se uma cadeia sobre Σ termina com 'b'
        public static void TerminaComB()
        {
            Utils.Escrever("Digite uma cadeia: ", false);
            string cadeia = Utils.Ler();

            if (string.IsNullOrEmpty(cadeia))
            {
                Utils.Escrever("NAO");
            }
            else if (!ValidarAlfabeto(cadeia))
            {
                Utils.Escrever("Cadeia inválida para o alfabeto {a,b}");
            }
            else
            {
                string resultado = cadeia.EndsWith("b") ? "SIM" : "NAO";
                Utils.Escrever(resultado);
            }

            Utils.Escrever("Pressione qualquer tecla para continuar...");
            Utils.Ler();
            Utils.Limpar();
        }
        
        // Valida se todos os símbolos da cadeia pertencem ao alfabeto
        private static bool ValidarAlfabeto(string cadeia)
        {
            foreach (char simbolo in cadeia)
            {
                if (!alfabeto.Contains(simbolo))
                {
                    return false;
                }
            }
            return true;
        }
    }
}